using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Image_Optimizer_Plus
{
    class OptiPng : ImageProcessor
    {
        public override String Name => "OptiPNG";

        public enum OptimizeLevels
        {
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Least = 0,
            Most = 7
        }

        public OptimizeLevels? OptimizeLevel { get; set; }

        public Boolean SilentMode { get; set; }

        public Boolean PreserveTimeStamp { get; set; }

        public OptiPng(String executablePath)
        {
            ExecutablePath = executablePath;

            SilentMode = true;
            PreserveTimeStamp = false;
            OptimizeLevel = OptimizeLevels.Most;
        }

        public override string GetArguments()
        {
            //  -quiet      =   Quiet mode
            //  -preserve   =   Preserve timestamp
            //  -o[0-7]     =   Optimize level
            //                  0 = None
            //                  1
            //                  2
            //                  3
            //                  4
            //                  5
            //                  6
            //                  7 = Most

            String arguments = String.Empty;

            if (SilentMode)
            {
                arguments += " -quiet";
            }

            if (PreserveTimeStamp)
            {
                arguments += " -preserve";
            }

            if (OptimizeLevel.HasValue)
            {
                arguments += $" -o{(int)OptimizeLevel}";
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
