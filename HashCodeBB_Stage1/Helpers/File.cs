using HashCodeBB_Stage1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeBB_Stage1.Helpers
{
    class File
    {
        public int DaysForScanning { get; set; }
        public List<Library> Libraries { get; set; }
        public List<Book> Books { get; set; }
    }
}
