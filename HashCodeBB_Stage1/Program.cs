using System.Text;
using System.Linq;
using HashCodeBB_Stage1.Helpers;
using System;
using System.Collections.Generic;

namespace HashCodeBB_Stage1
{
    class Program
    {
        static void Main(string[] args)
        {

            var beginPathExampleData = @"/home/tomasz/Programowanie/BBcoders/HashCodeBB_Stage1/HashCodeBB_Stage1/ExampleData/";
            var beginPathEOutputData = @"/home/tomasz/Programowanie/BBcoders/HashCodeBB_Stage1/HashCodeBB_Stage1/OutputData/";

            var pathsIn = new List<string>
            {
                beginPathExampleData + "a_example.txt",
                beginPathExampleData + "b_read_on.txt",
                beginPathExampleData + "c_incunabula.txt",
                beginPathExampleData + "d_tough_choices.txt",
                beginPathExampleData + "e_so_many_books.txt",
                beginPathExampleData + "f_libraries_of_the_world.txt"
            };

            var pathsOut = new List<string>
            {
                beginPathEOutputData + "a_example.txt",
                beginPathEOutputData + "b_read_on.txt",
                beginPathEOutputData + "c_incunabula.txt",
                beginPathEOutputData + "d_quite_big.out",
                beginPathEOutputData + "e_so_many_books.txt",
                beginPathEOutputData + "f_libraries_of_the_world.txt"
            };


            for (int i = 0; i < pathsIn.Count; i++)
            {
                var points = 0;
                File file = new File();
                Scanner scanner = new Scanner();
                InputFile inputFile = new InputFile(file.ReadFile(pathsIn[i]));

                scanner.Simulate(inputFile);

                StringBuilder results = new StringBuilder();

                results.Append(scanner.LibrariesReady.Count + $"\n");

                foreach (var library in scanner.LibrariesReady)
                {
                    results.Append(library.ID + " " + library.BooksScanned.Count + $"\n");

                    foreach (var book in library.BooksScanned)
                    {
                        points += book.Score;
                        results.Append(book.ID + " ");
                    }
                    results.Append($"\n");
                }

                file.CreateFile(pathsOut[i], results.ToString());
                System.Console.WriteLine("Ścieżka: " + pathsIn[i] + " " + points);
            }
        }
    }
}
