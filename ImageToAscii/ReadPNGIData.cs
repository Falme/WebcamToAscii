using System;
using System.Collections.Generic;
using System.Text;

namespace ImageToAscii
{
    public class ReadPNGIData
    {
        public ReadPNGIData()
        {

        }

        public string ConvertDataToAscii(byte[] bytesIData)
        {
            if(bytesIData[7] == 80) return ".";
            else if(bytesIData[7] == 152) return "@";
            else return ".";
        }


    }
}

//[   HEADER    ][                          CONTENT                          ][  Ending ]
//73, 68, 65, 84, 120, 156, 99, 152, 0, 0, 0, 146, 0, 145,  18,  34, 251, 123, 0, 0, 0, 0 [ White Black ]
//73, 68, 65, 84, 120, 156, 99, 136, 0, 0, 0, 90,  0,  89, 127, 255, 234, 207, 0, 0, 0, 0 [ Black White ]
//73, 68, 65, 84, 120, 156, 99, 208, 0, 0, 0, 42,  0,  41, 107,  49,  84, 115, 0, 0, 0, 0 [ Black Black ]
//                                                                            [   CRC   ]

//

//120, 156, 99, 152, 0, 0, 0, 146, 0, 145, 18,  34,  251, 123 [ White Black ]
//120, 156, 99, 136, 0, 0, 0, 90,  0, 89,  127, 255, 234, 207 [ Black White ]
//120, 156, 99, 208, 0, 0, 0, 42,  0, 41,  107,  49,  84, 115 [ Black Black ]

//[     3      ][1][     3  ][ 1 ][1][          5           ]
//                           [A    0 A-1 ]
// [ Repeated ]
//[ 4 byte Length ][ 4 byte data ][                         ]