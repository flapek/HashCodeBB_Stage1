using HashCodeBB_Stage1.Helpers;
using HashCodeBB_Stage1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCodeBB_Stage1
{
    class Scanner
    {
        public List<Library> Libraries { get; set; }
        private List<Library> LibrariesStep { get; set; }

        public Scanner()
        {
            Libraries = new List<Library>();
            LibrariesStep = new List<Library>();
        }

        public void Scanning(InputFile input)
        {
            var currentLibrary = input.Libraries.FirstOrDefault(x => input.Libraries.Max(x => x.StepID) == x.StepID);
            currentLibrary.ProcessType = ProcessType.SCANNED;
            LibrariesStep.Add(currentLibrary);
            input.Libraries.Remove(currentLibrary);
            Libraries.Add(new Library() { ID = 0 });

            for (int i = currentLibrary.SignupProcess; i < input.DaysForScanning; i++)
            {
                generateNextLibrary(input);
                foreach (var item in LibrariesStep)
                {
                    if (item.ProcessType == ProcessType.SCANNED)
                    {
                        scannBooks(item);
                    }
                }

                UpdateLibrary(i);
            }
        }

        private void UpdateLibrary(int day)
        {
            var libCount = LibrariesStep.Where(x => x.ProcessType == ProcessType.SCANNED).Count();
            var s = libCount + 1;
            if (s > LibrariesStep.Count())
                return;

            var sumDay = LibrariesStep.Take(s).Sum(x => x.SignupProcess);
            foreach (var item in LibrariesStep)
            {
                if (day == sumDay)
                {
                    LibrariesStep[s - 1].ProcessType = ProcessType.SCANNED;
                }
            }
        }

        private void scannBooks(Library library)
        {
            var sortedList = LibrariesStep.FirstOrDefault(x => x.ID == library.ID);
            sortedList.Books.OrderByDescending(x => x.Score);

            for (int i = 0; i < library.BooksPerDay; i++)
            {
                var currentBook = sortedList.Books.FirstOrDefault();
                Libraries.FirstOrDefault(x => x.ID == library.ID).Books.Add(currentBook);
                sortedList.Books.Remove(currentBook);

            }

        }

        private void generateNextLibrary(InputFile input)
        {
            var daysSpent = LibrariesStep.Sum(x => x.SignupProcess);
            var daysLast = input.DaysForScanning - daysSpent;

            foreach (var library in input.Libraries)
            {
                library.UpdateStepId(daysLast);
            }
            if (input.Libraries.Count == 0)
                return;

            var currentLibrary = input.Libraries.FirstOrDefault(x => input.Libraries.Max(z => z.StepID) == x.StepID);
            currentLibrary.ProcessType = ProcessType.SIGNUP;

            LibrariesStep.Add(currentLibrary);
            Libraries.Add(new Library() { ID = Libraries.Max(x => x.ID) + 1 });
            input.Libraries.Remove(currentLibrary);
        }



    }
}
