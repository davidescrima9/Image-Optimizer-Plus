using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Image_Optimizer_Plus
{
    class DeflOpt : ImageProcessor
    {

        public override String Name => "DeflOpt";

        public Boolean SilentMode { get; set; }

        public Boolean PreserveTimeStamp { get; set; }

        public Boolean KeepAllChunks { get; set; }

        public DeflOpt(String executablePath)
        {
            ExecutablePath = executablePath;

            SilentMode = true;
            PreserveTimeStamp = false;
            KeepAllChunks = false;
        }

        public override string GetArguments()
        { 
            //  -s  =   Silent mode
            //  -d  =   Preserve timestamp
            //  -k  =   Keep all chunks

            String arguments = String.Empty;

            if (SilentMode)
            {
                arguments += " -s";
            }

            if (PreserveTimeStamp)
            {
                arguments += " -d";
            }

            if (KeepAllChunks)
            {
                arguments += " -k";
            }

            arguments = arguments.TrimStart(' ');

            return arguments;
        }

        public override String GetExitCodeMessage()
        {
            if (ExitCode == 0)
            {
                return "No error";
            }

            return String.Empty;
        }
    }
}
