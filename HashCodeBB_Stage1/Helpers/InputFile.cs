using HashCodeBB_Stage1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeBB_Stage1.Helpers
{
    class InputFile
    {
        public int DaysForScanning { get; set; }
        public List<Library> Libraries { get; set; }
        public List<Book> Books { get; set; }
        public int LibrariesCount { get; set; }
        public int BooksCount { get; set; }
        public InputFile(string[] input)
        {
            var firstLine = input[0].Split(new string[] { " " }, StringSplitOptions.None);
            DaysForScanning = int.Parse(firstLine[2]);
            LibrariesCount = int.Parse(firstLine[1]);
            BooksCount = int.Parse(firstLine[0]);



        }
    }
}
