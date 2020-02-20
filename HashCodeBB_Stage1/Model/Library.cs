using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeBB_Stage1.Model
{
    public enum ProcessType
    {
        SIGNUP,
        SCANNED
    }

    class Library
    {
        public int ID { get; set; }
        public HashSet<Book> Books { get; set; }
        public int SignupProcess { get; set; }
        public int BooksPerDay { get; set; }
        public int StepID { get; set; }
        public ProcessType ProcessType { get; set; }
        public Library()
        {
            Books = new HashSet<Book>();
        }

        public void UpdateStepId(int days)
        {
            if (BooksPerDay == null || SignupProcess == null)
                return;

            StepID = (days - SignupProcess) * BooksPerDay;
        }
    }
}
