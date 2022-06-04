using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageToAscii
{
	class ReadBitmapImage : IImageReader
    {
        readonly string path = "";
        const int headerDispose = 62;
        const int byteInterval = 4;
        const int byteIntervalOffset = -1;

        public ReadBitmapImage()
        {
            //ReadFile();
        }

        public void ReadFile()
        {
            byte[] imgBytes = File.ReadAllBytes(path);

            for(int a= headerDispose; a < imgBytes.Length;a++)
            {
                Console.Write(ReadBinary(imgBytes[a]));

                if ((a+ byteIntervalOffset) % byteInterval == 0) 
                    Console.WriteLine("");
            }
        }

        

        private string ReadBinary(byte number)
        {
            StringBuilder stringBuilder = new StringBuilder();

            byte comparer = 0b_1000_0000;

            stringBuilder.Append( (comparer & number) == comparer ? GradientAscii.GetGradientByByte(11): GradientAscii.GetGradientByByte(0));

            while(comparer > 1)
            {
                comparer = (byte)(comparer >> 1);
                stringBuilder.Append((comparer & number) == comparer ? GradientAscii.GetGradientByByte(11) : GradientAscii.GetGradientByByte(0));
            }


            return stringBuilder.ToString();
        }


        /// <summary>
        /// This Function is Called to read From Camera
        /// </summary>
        /// <param name="bitmap"></param>
        public void ReadBitmap(Bitmap bitmap)
        {

            StringBuilder stringBuilder = new StringBuilder();

            for (int b = 0, t = 0; b < bitmap.Height; b += 10, t++)
            {
                for (int a = bitmap.Width-1; a > 0; a -= 10)
                {

                    Color c = bitmap.GetPixel(a, b);
                    byte _min = Math.Min(c.R, c.G);
                    _min = Math.Min(_min, c.B);

                    stringBuilder.Append(GradientAscii.GetGradientByByte((byte)(_min / 24))); //24
                }
                stringBuilder.Append('\n');
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(stringBuilder.ToString());

            bitmap.Dispose();
        }
    }
}
