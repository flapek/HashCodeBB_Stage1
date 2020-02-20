using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeBB_Stage1.Model
{
    class CurrentDay
    {
        public int Day { get; set; }
        public HashSet<Book> Books { get; set; }
        public HashSet<int> LibrariesID { get; set; }
    }

    
}
