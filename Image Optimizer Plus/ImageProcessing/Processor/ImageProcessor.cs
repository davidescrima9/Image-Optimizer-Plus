using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Image_Optimizer_Plus
{
    public abstract class ImageProcessor
    {
        public abstract String Name { get; }

		public List<Int32> ValidCodes { get; set; }

		public String ExecutablePath { get; set; }

		public abstract String GetArguments();

        public Int32 ExitCode { get; set; }

        public String ErrorMessage { get; set; }

        public abstract String GetExitCodeMessage();

		public ImageProcessor()
        {
			ValidCodes = new List<int>();
			ValidCodes.Add(0);

            ErrorMessage = String.Empty;
        }

        public Boolean Run(String imagePath)
        {
			Process process = new Process();

			if (!File.Exists(ExecutablePath))
			{
                ErrorMessage = $"{Name} failed, unable to find the file";

                return false;
            }

			process.StartInfo.FileName = ExecutablePath;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;

			process.StartInfo.Arguments = $"{GetArguments()} \"{imagePath}\"";
			process.Start();
			process.WaitForExit();

            //if (Settings.Default.LowPriority)
            //{
            //	process.PriorityClass = ProcessPriorityClass.BelowNormal;
            //}
            //while (!process.HasExited)
            //{
            //    if (cancelToken.IsCancellationRequested)
            //    {
            //        process.Kill();
            //        cancelToken.ThrowIfCancellationRequested();
            //    }
            //    Thread.Sleep(500);
            //}

            ExitCode = process.ExitCode;

            Boolean isProcessed = ValidCodes.Contains(ExitCode);

            if (!isProcessed)
            {
                ErrorMessage = $"{Name} failed, Code {ExitCode}";

                String exitCodeMessage = GetExitCodeMessage();

                if (exitCodeMessage.Length > 0)
                {
                    ErrorMessage += $", {exitCodeMessage}";
                }
            }

            return isProcessed;
		}
    }
}
