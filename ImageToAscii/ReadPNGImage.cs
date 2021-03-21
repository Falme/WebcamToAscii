using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageToAscii
{
    class ReadPNGImage : IImageReader
    {
        readonly string path = "../../../C2.png";
        const int headerDispose = (8+4+8+4+1+1+1+1+1);

        public ReadPNGImage()
        {
            ReadFile();
        }

        public void ReadFile()
        {
            byte[] imgBytes = File.ReadAllBytes(path);

            for (int a = 0; a < imgBytes.Length; a++)
            {
                if (a < imgBytes.Length - 4)
                    CheckHeaders(imgBytes, a);
                
                Console.Write(imgBytes[a]);
                Console.Write(" ");

            }
        }

        private void CheckHeaders(byte[] imgBytes, int a)
        {

            if (GetValidHeaderBytes(imgBytes, a, 137, 80, 78, 71)) Console.WriteLine("  \n\n== Header PNG == ");
            if (GetValidHeaderBytes(imgBytes, a, 73, 72, 68, 82)) Console.WriteLine("  \n\n== IHDR PNG == ");
            if (GetValidHeaderBytes(imgBytes, a, 80, 76, 84, 69)) Console.WriteLine("  \n\n== PLTE Palette == ");
            if (GetValidHeaderBytes(imgBytes, a, 73, 68, 65, 84)) Console.WriteLine("  \n\n== IDAT Image Data == ");
            if (GetValidHeaderBytes(imgBytes, a, 73, 69, 78, 68)) Console.WriteLine("  \n\n== IEND PNG == ");
            if (GetValidHeaderBytes(imgBytes, a, 116, 82, 78, 83)) Console.WriteLine("  \n\n== tRNS Transparency == ");
            if (GetValidHeaderBytes(imgBytes, a, 99, 72, 82, 77)) Console.WriteLine("  \n\n== cHRM Primary chromaticities and white point == ");
            if (GetValidHeaderBytes(imgBytes, a, 103, 65, 77, 65)) Console.WriteLine("  \n\n== gAMA Image gamma == ");
            if (GetValidHeaderBytes(imgBytes, a, 105, 67, 67, 80)) Console.WriteLine("  \n\n== iCCP Embedded ICC profile == ");
            if (GetValidHeaderBytes(imgBytes, a, 115, 66, 73, 84)) Console.WriteLine("  \n\n== sBIT Significant bits == ");
            if (GetValidHeaderBytes(imgBytes, a, 115, 82, 71, 66)) Console.WriteLine("  \n\n== sRGB Standard RGB colour space == ");
            if (GetValidHeaderBytes(imgBytes, a, 116, 69, 88, 116)) Console.WriteLine("  \n\n== tEXt Textual data == ");
            if (GetValidHeaderBytes(imgBytes, a, 122, 84, 88, 116)) Console.WriteLine("  \n\n== zTXt Compressed textual data == ");
            if (GetValidHeaderBytes(imgBytes, a, 105, 84, 88, 116)) Console.WriteLine("  \n\n== iTXt International textual data == ");
            if (GetValidHeaderBytes(imgBytes, a, 98, 75, 71, 68)) Console.WriteLine("  \n\n== bKGD Background colour == ");
            if (GetValidHeaderBytes(imgBytes, a, 104, 73, 83, 84)) Console.WriteLine("  \n\n== hIST Image histogram == ");
            if (GetValidHeaderBytes(imgBytes, a, 112, 72, 89, 115)) Console.WriteLine("  \n\n== pHYs Physical pixel dimensions == ");
            if (GetValidHeaderBytes(imgBytes, a, 115, 80, 76, 84)) Console.WriteLine("  \n\n== sPLT Suggested palette == ");
            if (GetValidHeaderBytes(imgBytes, a, 116, 73, 77, 69)) Console.WriteLine("  \n\n== tIME Image last-modification time == ");
        }

        private bool GetValidHeaderBytes(byte[] imgBytes, int index, byte a, byte b, byte c, byte d)
        {
            return (
                imgBytes[index] == a &&
                imgBytes[index + 1] == b &&
                imgBytes[index + 2] == c &&
                imgBytes[index + 3] == d
                );
        }
    }
}

/*

[137 80 78 71 13 10 26 10] -- Header PNG /8
[0 0 0 13] -- ? /4
[73 72 68 82] [0 0 0 32]  -- [IDHR Header] [Width] /8
[0 0 0 32]  --  [Height] /4
[1] -- Bit Depth /1
[3] -- color Type /1
[0] -- Compression method /1
[0] -- Filter method /1
[0] -- Interlace method /1

.
.
.

[103 65 77 65] -- gAMA Image gamma
[0 0 177 143] -- gAMA Values

.
.
.

[80 76 84 69] -- PLTE color Palette
[0 0 0] -- Color Black
[255 255 255] -- Color White

.
.
.

[73 68 65 84] -- IDAT Image Data

.
.
.
[73 69 78 68] -- IEND image trailer /4
[174 66 96 130] -- ? /4

 
 */

