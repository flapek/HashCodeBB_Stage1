using HashCodeBB_Stage1.Helpers;
using System;
using System.Collections.Generic;

namespace HashCodeBB_Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathsIn = new List<string>();
            pathsIn.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\ExampleData\a_example.txt");
            pathsIn.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\ExampleData\b_read_on.txt");
            pathsIn.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\ExampleData\c_incunabula.txt");
            pathsIn.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\ExampleData\d_tough_choices.txt");
            pathsIn.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\ExampleData\e_so_many_books.txt");
            pathsIn.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\ExampleData\f_libraries_of_the_world.txt");

            var pathsOut = new List<string>();
            pathsOut.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\OutputData\a_example.txt");
            pathsOut.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\OutputData\b_read_on.txt");
            pathsOut.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\OutputData\c_incunabula.txt");
            pathsOut.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\OutputData\d_quite_big.out");
            pathsOut.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\OutputData\e_so_many_books.txt");
            pathsOut.Add(@"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\OutputData\f_libraries_of_the_world.txt");

            File file = new File();
            
            InputFile inputFile = new InputFile(file.ReadFile(pathsIn[1]));
            Console.WriteLine(inputFile.DaysForScanning);

            foreach (var library in inputFile.Libraries)
            {
                Console.WriteLine(library.ID);
                foreach (var book in library.Books)
                {
                    Console.WriteLine(book.ID + "  " + book.Score);
                }
                Console.WriteLine();
            }
        }
    }
}
