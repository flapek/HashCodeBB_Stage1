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
        public List<Library> LibrariesReady { get; set; }
        public Library LibrarySignUp { get; set; }

        public Scanner()
        {
            LibrariesReady = new List<Library>();
            LibrarySignUp = null;
        }

        public void Simulate(InputFile input)
        {
            sortBooks(input);

            for (int currentDay = 0; currentDay < input.DaysForScanning; currentDay++)
            {
                // jeżeli są biblioteki, które są aktualnie gotowe do skanowanie, to dodajemy do nich książki do skanowania
                foreach (var library in LibrariesReady)
                {
                    selectBooksToScan(library);
                }

                if (LibrarySignUp == null)
                {
                    // jeżeli można zarejestrować jakąś bibliotekę, to ją rejestrujemy
                    if (input.Libraries.Count != 0)
                    {
                        System.Console.WriteLine(input.Libraries.Count);
                        generateNextLibrary(input, currentDay);
                    } // wybór nowej biblioteki do zarejestrowania
                }
                else
                {
                    // aktualnie jedna biblioteka się rejestruje, więc sprawdzamy czy już kończy
                    if (LibrarySignUp.SignupProcessDate.EndDate <= currentDay)
                    {
                        // jeżeli biblioteka kończy rejestracje, to należy dodać ją do kolejki LibrariesReady i ustawić rejestrację na null
                        LibrariesReady.Add(LibrarySignUp);
                        LibrarySignUp = null;
                    }
                }
            }
        }

        private void sortBooks(InputFile input)
        {
            foreach (var library in input.Libraries)
            {
                library.BooksToScan = library.BooksToScan.OrderByDescending(x => x.Score).ToList();
            }
        }

        private void selectBooksToScan(Library library)
        {
            var booksToScan = library.BooksToScan
                .Take(library.BooksPerDay)
                .ToList();

            foreach (var book in booksToScan)
            {
                library.BooksScanned.Add(book);
                library.BooksToScan.Remove(book);
            }
        }

        private void generateNextLibrary(InputFile input, int currentDay)
        {
            var daysSpent = currentDay;
            var daysLast = input.DaysForScanning - daysSpent;

            foreach (var library in input.Libraries)
            {
                library.UpdateStepId(daysLast);
            }

            if (input.Libraries.Count == 0) return;

            LibrarySignUp = input.Libraries.FirstOrDefault(x => input.Libraries.Max(z => z.StepID) == x.StepID);

            if (LibrarySignUp == null) return;

            LibrarySignUp.SignupProcessDate.StartDate = currentDay;
            LibrarySignUp.SignupProcessDate.EndDate = currentDay + LibrarySignUp.SignupProcessTime - 1;
            input.Libraries.Remove(LibrarySignUp);
        }
    }
}
