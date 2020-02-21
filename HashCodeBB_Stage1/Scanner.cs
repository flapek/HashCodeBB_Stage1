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
        public List<Library> LibrariesReady { get; set; } // lista bibliotek które są już zarejestrowane
        public Library LibrarySignUp { get; set; } // biblioteka która aktualnie jest rejestrowana

        public Scanner()
        {
            LibrariesReady = new List<Library>();
            LibrarySignUp = null;
        }

        public void Simulate(InputFile input)
        {
            for (int currentDay = 0; currentDay < input.DaysForScanning; currentDay++)
            {
                // jeżeli są biblioteki, które są aktualnie gotowe do skanowanie, to dodajemy do nich książki do skanowania
                foreach (var library in LibrariesReady)
                {
                    selectBooksToScan(library);
                }

                // jeżeli aktualnie nie jest rejestrowana żadna biblioteka ...
                if (LibrarySignUp == null)
                {
                    // oraz istnieją biblioteki do rejestracji
                    if (input.Libraries.Count != 0)
                    {
                        // to wyberamy nową bibliotę do zarejestrowania
                        selectLibraryToSignUp(input, currentDay);
                    } 
                }
                else
                {
                    // aktualnie jedna biblioteka się rejestruje, więc sprawdzamy czy już skończyła
                    if (LibrarySignUp.SignupProcessDate.EndDate <= currentDay)
                    {
                        // jeżeli biblioteka kończy rejestracje, to należy dodać ją do kolejki LibrariesReady i ustawić rejestrację na null
                        LibrariesReady.Add(LibrarySignUp);
                        LibrarySignUp = null;
                    }
                }
            }
        }

        private void selectBooksToScan(Library library)
        {
            // wybieramy książki o najlepszym wyniku punktowym
            var booksToScan = library.BooksToScan
                .OrderByDescending(x => x.Score)
                .Take(library.BooksPerDay)
                .ToList();

            // dodajemy książki do listy do skanowania dla danej biblioteki
            foreach (var book in booksToScan)
            {
                library.BooksScanned.Add(book);
                library.BooksToScan.Remove(book);
            }
        }

        private void selectLibraryToSignUp(InputFile input, int currentDay)
        {
            var daysSpent = currentDay;
            var daysLast = input.DaysForScanning - daysSpent; // obliczamy ile dni pozostało

            foreach (var library in input.Libraries)
            {
                // aktualizujemy wskaźnik według tego ile dni pozostało
                library.UpdateStepId(daysLast);
            }

            // wybieramy bibliotekę do rejestracji z największą wartością wskaźnika
            LibrarySignUp = input.Libraries.FirstOrDefault(x => input.Libraries.Max(z => z.StepID) == x.StepID);

            if (LibrarySignUp == null) return;

            // zapisujemy datę zakończenia rejestracji i usuwamy bibliotekę z danych wejściowych
            LibrarySignUp.SignupProcessDate.StartDate = currentDay;
            LibrarySignUp.SignupProcessDate.EndDate = currentDay + LibrarySignUp.SignupProcessTime - 1;
            input.Libraries.Remove(LibrarySignUp);
        }
    }
}
