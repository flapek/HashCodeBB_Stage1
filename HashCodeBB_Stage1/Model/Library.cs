using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeBB_Stage1.Model
{
    enum ProcessType
    {
        Signup,
        Scannded
    }

    class Library
    {
        public int ID { get; set; }
        public HashSet<Book> Books { get; set; }
        public int SignupProcess { get; set; }
        public int BooksPerDay { get; set; }

        public Library()
        {
            Books = new HashSet<Book>();
        }
    }
}
