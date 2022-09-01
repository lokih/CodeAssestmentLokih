using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CodeAssesmentLokih
{
    public class Sorter
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String currentAddress = Directory.GetCurrentDirectory();
            String textInput;
            String commandName;
            String fileName;
            List<String> listStringInFile = new List<string>();
            List<String> listStringSorted = new List<string>();

            textInput = Console.ReadLine();
            commandName = textInput.Split(null)[0];
            
            //check command valid or invalid
            if (commandName.Equals("name-sorter"))
            {
                fileName = textInput.Split(null)[1];
                //read file and get all line of string in file
                var files = from file in Directory.EnumerateFiles(currentAddress, fileName, SearchOption.AllDirectories)
                            from line in File.ReadLines(file)
                            select new
                            {
                                File = file,
                                Line = line
                            };

                Console.WriteLine("\n============CONTENT OF THE FILES============\n");
                //display content of file to the screen and put inside a list
                foreach (var file in files)
                {
                    Console.WriteLine(file.Line);
                    listStringInFile.Add(file.Line);
                }
                Console.WriteLine("\n============BELOW IS THE SORTED RESULT============\n");

                //call function to sort the list string of names
                listStringSorted = SortName(listStringInFile);

                //display content of file to the screen 
                foreach (String theString in listStringSorted)
                {
                    Console.WriteLine(theString);
                }

                //prepare a file to be write
                using StreamWriter sortedText = new StreamWriter("sorted-names-list.txt");

                //write the sorted names into the file
                foreach (String theString in listStringSorted)
                {
                    sortedText.WriteLineAsync(theString);
                }
            }
            else
            {
                Console.WriteLine("\n============UNKNOWN COMMAND============\n");
            }
            Console.Read();
        }

        public static List<String> SortName(List<String> listNames)
        {
            List<String> listResult = new List<string>();
            String[] arrayString = new String[4];

            //ordering the last name by getting the last index of the array of string when string got splited
            var res = from name in listNames
                      orderby name.Split(null)[name.Split(null).Length - 1]
                      ascending
                      select name;

            //add string one by one to a listResult
            foreach (var name in res)
            {
                listResult.Add(name);
            }
            return listResult;
        }
    }
}
