using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Image_Optimizer_Plus
{
    class AdvPng : ImageProcessor
    {

        public override String Name => "AdvPng";

        public enum CompressionLevels
        {
            Store = 0,

            Fast = 1,
            Normal = 2,
            Extra = 3,
            Insane = 4,

            Zlib = 1,
            LibDeflate = 2,
            SevenZ = 3,
            Zopfli = 4
        }

        public Boolean SilentMode { get; set; }

        public Boolean CompressFile { get; set; }

        public CompressionLevels? CompressionLevel { get; set; }

        public AdvPng(String executablePath)
        {
            ExecutablePath = executablePath;

            SilentMode = true;
            CompressFile = true;
            CompressionLevel = CompressionLevels.Zopfli;
        }

        public override string GetArguments()
        {
            //  -q      =   Silent mode
            //  -z      =   Recompress files
            //  -[0-4]  =   Compression level
            //              0 = Store
            //              1 = Zlib
            //              2 = LibDeflate
            //              3 = 7z
            //              4 = Zopfli

            String arguments = String.Empty;

            if (SilentMode)
            {
                arguments += " -q";
            }

            if (CompressFile)
            {
                arguments += " -z";
            }

            if (CompressionLevel.HasValue)
            {
                arguments += $" -{(int)CompressionLevel}";
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
            else if (ExitCode == 1)
            {
                return "Generic error";
            }
            else if (ExitCode == -1)
            {
                return "Unexpected error";
            }

            return String.Empty;
        }
    }
}
