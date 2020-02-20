﻿using HashCodeBB_Stage1.Helpers;
using System;
using System.Collections.Generic;

namespace HashCodeBB_Stage1
{
    class Program
    {
        static void Main(string[] args)
        {

            var beginPathExampleData = @"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\ExampleData\";
            var beginPathEOutputData = @"C:\Users\filap\source\repos\HashCode\HashCodeBB_Stage1\HashCodeBB_Stage1\OutputData\";

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
