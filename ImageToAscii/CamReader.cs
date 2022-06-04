using System;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageToAscii
{
	class CamReader
    {
        public delegate void OnBitmapChanged(Bitmap bitmap);
        public event OnBitmapChanged onBitmapChanged;

		private FilterInfoCollection filterInfoCollection;
		private VideoCaptureDevice captureDevice;

        public CamReader()
        {
			filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

			Console.WriteLine("== Select the camera to be converted ==");

			for(int a=0; a< filterInfoCollection.Count; a++)
			{
				Console.WriteLine(a + " - " + filterInfoCollection[a].Name);
			}

			//int input;
			try
			{
				int input = Int32.Parse(Console.ReadLine());
				captureDevice = new VideoCaptureDevice(filterInfoCollection[input].MonikerString);

				captureDevice.NewFrame += new NewFrameEventHandler(video_NewFrame);
				captureDevice.Start();
			} catch
			{
				Console.WriteLine("Not Valid Input");
				return;
			}

		}

		private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			onBitmapChanged?.Invoke(eventArgs.Frame);
		}
    }
}
