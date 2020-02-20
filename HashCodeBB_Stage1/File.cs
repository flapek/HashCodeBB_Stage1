using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HashCodeBB_Stage1
{
    class File
    {
        public File() { }

        public string[] ReadFile(string path)
        {
            if (!System.IO.File.Exists(path))
                return null;

            using (StreamReader stream = new StreamReader(path))
            {
                string all = stream.ReadToEnd();
                string[] result = all.Split(new string[] { " ", "\n" }, StringSplitOptions.None);
                return result;
            }
        }

        public void CreateFile(string path, string data)
        {
            using (FileStream fs = System.IO.File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(data);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
