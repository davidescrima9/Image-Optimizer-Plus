using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Image_Optimizer_Plus
{
    class PngOut : ImageProcessor
    {
        public override String Name => "PngOut";

		public enum ColorTypes
		{
			Gray = 0,
			RGB = 2,
			Paletted = 3,
			GrayAlpha = 4,
			RGBAlpha = 6
		}

		public enum FilterTypes
		{
			None = 0,
			DeltaX = 1,
			DeltaY = 2,
			DeltaXAndY = 3,
			Paeth = 4,
			Mixed = 5,
			Reuse = 6
		}

		public enum StrategyTypes
		{
			Xtreme = 0,
			Intense = 1,
			LongestMatch = 2,
			HuffmanOnly = 3,
			Uncompressed = 4
		}

		public enum BuggyDecoderModes
		{
			Default = 0,
			Zlib121 = 1,
			BuggyMobiles =2
		}

		public enum BitDepths
        {
			Zero = 0,
			One = 1,
			Two = 2,
			Four = 4,
			Eight = 8
        }

		public Boolean SilentMode { get; set; }

		public Boolean PreserveTimeStamp { get; set; }

		public Boolean AutoOverwrite { get; set; }

		public ColorTypes? ColorType { get; set; }

        public FilterTypes? FilterType { get; set; }

        public StrategyTypes? StrategyType { get; set; }

        public BuggyDecoderModes? BuggyDecoderMode { get; set; }

        public BitDepths? BitDepth { get; set; }

		public Int32? BlockSplitThreshold { get; set; }

		public Int32? HuffmanBlocksNum { get; set; }

		public Boolean RandomizeInitialTables { get; set; }

		public Boolean KeepGAMA { get; set; }

		public Boolean KeepPaletteOrder { get; set; }

		public Boolean KeepAllChunks { get; set; }

		public Boolean KeepParams { get; set; }

		public PngOut(String executablePath)
        {
            ExecutablePath = executablePath;

            SilentMode = true;
			PreserveTimeStamp = false;
			AutoOverwrite = true;
			ColorType = null;
			FilterType = null;
			StrategyType = StrategyTypes.Xtreme;
			BuggyDecoderMode = BuggyDecoderModes.Default;
			BitDepth = BitDepths.Zero;
			BlockSplitThreshold = null;
			HuffmanBlocksNum = null;
			RandomizeInitialTables = false;
			KeepGAMA = false;
			KeepPaletteOrder = false;
			KeepAllChunks = false;
			KeepParams = false;

            ValidCodes.Add(2);
        }

        public override string GetArguments()
        {
			//  /q				=	Quiet mode
			//	/kt				=	Keep time
			//	/y				=	Automatic yes to overwrite prompts
			//	/c[0-6]			=	Output color
			//						0 = Gray
			//						2 = RGB
			//						3 = Pal
			//						4 = Gray+Alpha
			//						6 = RGB+Alpha
			//	/f[0-6]			=	Output filter
			//						0 = None
			//						1 = Delta x
			//						2 = Delta y
			//						3 = Delta x and y
			//						4 = Paeth
			//						5 = Mixed
			//						6 = Reuse
			//	/s[0-4]			=	Strategy mode
			//						0 = Xtreme
			//						1 = Intense
			//						2 = Longest Math
			//						3 = Huffman Only
			//						4 = Uncompressed
			//	/mincodes[0-2]	=	Workaround for buggy decoder
			//						0 = Default
			//						1 = Zlib 1.2.1 bug
			//						2 = Buggy mobiles
			//	/d[0-8]			=	Bit depth
			//						0 = Min
			//						1
			//						2
			//						4
			//						8 = Max
			//	/b[0-+inf]			=	Block split threshold (lower = more blocks)
			//						0		=	1 block per file
			//						128
			//						196
			//						256		=	Default
			//						512
			//						1024
			//	/n[0-+inf]			=	Number of Huffman blocks (overrides /b[0-+inf])
			//	/r					=	Randomized initial tables
			//	/k1					=	Keep all chunks
			//	/ks					=	Keep settings for /c, f, d, b
			//	/kp					=	Keep palette indices
			//	/kgAMA				=	Preserve named chunk gAMA

			String arguments = String.Empty;

			if (SilentMode)
			{
				arguments += " /q";
			}

			if (PreserveTimeStamp)
			{
				arguments += " /kt";
			}

			if (AutoOverwrite)
			{
				arguments += " /y";
			}

			if (ColorType.HasValue)
			{
				arguments += $" /c{(int)ColorType}";
			}

			if (FilterType.HasValue)
			{
				arguments += $" /f{(int)FilterType}";
			}

			if (StrategyType.HasValue)
			{
				arguments += $" /s{(int)StrategyType}";
			}

			if (BuggyDecoderMode.HasValue)
			{
				arguments += $" /mincodes{(int)BuggyDecoderMode}";
			}

			if (BitDepth.HasValue)
			{
				arguments += $" /d{(int)BitDepth}";
			}

			if (BlockSplitThreshold.HasValue)
			{
				arguments += $" /b{(int)BlockSplitThreshold}";
			}

			if (HuffmanBlocksNum.HasValue)
			{
				arguments += $" /n{(int)HuffmanBlocksNum}";
			}

			if (RandomizeInitialTables)
			{
				arguments += " /r";
			}

			if (KeepAllChunks)
			{
				arguments += " /k1";
			}

			if (KeepParams)
			{
				arguments += " /ks";
			}

			if (KeepPaletteOrder)
			{
				arguments += " /kp";
			}

			if (KeepGAMA)
			{
				arguments += " /kgAMA";
			}

			arguments = arguments.TrimStart(' ');

			return arguments;
        }

		public override String GetExitCodeMessage()
		{
			if (ExitCode == 0)
            {
				return "Wrote file";
            }
			else if (ExitCode == 1)
            {
				return "File error";
            }
			else if (ExitCode == 2)
            {
				return "Unable to compress further";
            }
			else if (ExitCode == 3)
            {
				return "Bad options";
            }

			return String.Empty;
		}
	}
}
