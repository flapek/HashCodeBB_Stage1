using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeBB_Stage1.Model
{
    class Library
    {
        public int ID { get; set; }
        public int SignupProcessTime { get; set; }
        public int BooksPerDay { get; set; }

        public List<Book> BooksToScan { get; set; }
        public List<Book> BooksScanned { get; set; }

        public int StepID { get; set; }
        public RegistrationTimeRange SignupProcessDate { get; set; }

        public Library()
        {
            BooksToScan = new List<Book>();
            BooksScanned = new List<Book>();
            SignupProcessDate = new RegistrationTimeRange();
        }

        public void UpdateStepId(int days)
        {
            StepID = (days - SignupProcessTime) * BooksPerDay;
        }
    }
}
