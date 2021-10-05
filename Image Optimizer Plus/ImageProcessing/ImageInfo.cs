using System;
using System.IO;

namespace Image_Optimizer_Plus
{
    public class ImageInfo
    {

        public enum ProcessStatus
        {
            NotProcessed = 0,
            Processing = 1,
            Processed = 2,
            Discarded = 3,
            Error = 4
        }

        public String InputPath { get; set; }

        public String Name { get; set; }

        public String TempPath { get; set; }

        public String OutputPath { get; set; }

        public String ErrorMessage { get; set; }

        public ProcessStatus Status { get; set; }

        public int Steps { get; set; }

        private long uncompressedSize;

        public long UncompressedSize
        {
            get { return uncompressedSize; }
            set { uncompressedSize = value; }
        }

        private long compressedSize;

        public long CompressedSize
        {
            get { return compressedSize; }
            set { compressedSize = value; }
        }

        public String CompressedSizeToString
        {
            get { return Util.ConvertLongToByte(CompressedSize); }
        }

        public String UncompressedSizeToString
        {
            get { return Util.ConvertLongToByte(UncompressedSize); }
        }

        public Double CompressionRate()
        {
            return CompressedSize * 100 / UncompressedSize;
        }

        public ImageInfo(String inputPath)
        {
            InputPath = inputPath;
            Name = Path.GetFileName(inputPath);

            Status = ProcessStatus.NotProcessed;
            Steps = 0;

            uncompressedSize = new System.IO.FileInfo(inputPath).Length;
            compressedSize = 0;
        }
    }
}
