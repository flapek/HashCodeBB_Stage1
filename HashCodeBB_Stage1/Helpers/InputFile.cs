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
            Libraries = new List<Library>();
            Books = new List<Book>();

            var firstLine = input[0].Split(new string[] { " " }, StringSplitOptions.None);
            DaysForScanning = int.Parse(firstLine[2]);
            LibrariesCount = int.Parse(firstLine[1]);
            BooksCount = int.Parse(firstLine[0]);

            var secondLine = input[1].Split(new string[] { " " }, StringSplitOptions.None);
            for (int i = 0; i < BooksCount; i++)
            {
                Books.Add(new Book { ID = i, Score = int.Parse(secondLine[i]) });
            }

            var id = 0;
            for (int i = 2; i < 2 + LibrariesCount * 2; i += 2)
            {
                firstLine = input[i].Split(new string[] { " " }, StringSplitOptions.None);
                secondLine = input[i + 1].Split(new string[] { " " }, StringSplitOptions.None);

                Libraries.Add(new Library
                {
                    ID = id,
                    SignupProcess = int.Parse(firstLine[1]),
                    BooksPerDay = int.Parse(firstLine[2]),
                });

                for (int j = 0; j < secondLine.Length; j++)
                {
                    Libraries[id].Books.Add(new Book
                    {
                        ID = int.Parse(secondLine[j]),
                        Score = Books[int.Parse(secondLine[j])].Score
                    });
                }

                ++id;
            }


        }
    }
}
