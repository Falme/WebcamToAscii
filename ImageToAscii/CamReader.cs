using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using WebEye.Controls.Wpf;

namespace ImageToAscii
{
    class CamReader
    {
        public delegate void OnBitmapChanged(Bitmap bitmap);
        public event OnBitmapChanged onBitmapChanged;

        Bitmap image = null;
        WebCameraControl webCameraControl;
        WebCameraId camera = null;

        public CamReader()
        {
            Thread t = new Thread(ThreadProc);
            t.SetApartmentState(ApartmentState.STA);

            t.Start();
        }

        private void ThreadProc()
        {
            webCameraControl = new WebCameraControl();

            foreach (var c in webCameraControl.GetVideoCaptureDevices())
            {
                if (c != null)
                {
                    Console.WriteLine("found camera");
                    camera = c;
                    break;
                }
            }
            if (camera != null)
            {
                webCameraControl.StartCapture(camera);
                webCameraControl.RenderSize = new System.Windows.Size(100, 100);
                System.Threading.Thread.Sleep(2000);
                while(true)
                {
                    System.Threading.Thread.Sleep(50);
                    CaptureAndSend();
                }
                System.Threading.Thread.Sleep(250);
                webCameraControl.StopCapture();
            }

            Console.WriteLine("end");
        }

        private void CaptureAndSend()
        {
            image = webCameraControl.GetCurrentImage();
            onBitmapChanged?.Invoke(image);

        }
    }
}
