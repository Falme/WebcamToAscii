using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows;
using WebEye.Controls.Wpf;

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
