using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace DigiPower.Onlinecol.Standard.Web
{
    public class UpZipFile
    {
        string file;
        string TempPath;
        public UpZipFile(string _file, string _TempPath)
        {
            file = _file;
            TempPath = _TempPath;

            if (!Directory.Exists(TempPath))
                Directory.CreateDirectory(TempPath);
        }

        public void StartUnZip()
        {
            ZipInputStream zis = new ZipInputStream(System.IO.File.OpenRead(file));
            ZipEntry theEntry = null;


            while ((theEntry = zis.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(theEntry.Name);
                string fileName = Path.GetFileName(theEntry.Name);
                if (directoryName != string.Empty)
                    Directory.CreateDirectory(TempPath + "\\" + directoryName);

                if (fileName != string.Empty)
                {
                    FileStream streamWriter = System.IO.File.Create(TempPath + "\\" + theEntry.Name);
                    int size = 2048;
                    byte[] data = new byte[size];
                    while (true)
                    {
                        size = zis.Read(data, 0, data.Length);
                        if (size > 0)
                            streamWriter.Write(data, 0, size);
                        else
                            break;
                    }

                    streamWriter.Close();
                }
            }

            zis.Close();
        }
    }
}
