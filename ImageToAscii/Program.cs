using System;

namespace ImageToAscii
{
	class Program
    {
        static void Main(string[] args)
        {
            ReadBitmapImage readBitmapImage = new ReadBitmapImage();

            CamReader camReader = new CamReader();
            camReader.onBitmapChanged += readBitmapImage.ReadBitmap;

            Console.ReadKey();
        }

    }
}
