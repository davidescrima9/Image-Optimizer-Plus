using System;
using System.Collections.Generic;

namespace Image_Optimizer_Plus
{
    public class Util
    {

        public static String ConvertLongToByte(long l)
        {
            double currentValue = l;
            List<String> magnitude = new List<string>() { "B", "KB", "MB", "GB", "TB" };

            int i = 0;
            while (i < magnitude.Count && Math.Abs(currentValue) >= 1024)
            {
                currentValue /= 1024;
                i++;
            }

            return String.Format("{0:0.##} {1}", currentValue, magnitude[i]);

        }
    }
}
