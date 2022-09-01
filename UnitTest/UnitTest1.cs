using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeAssesmentLokih;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<String> listString = new List<string>();
            List<String> listStringSorted = new List<string>();
            listString.Add("Orson Milka Iddins");
            listString.Add("Erna Dorey Battelle");
            listString.Add("Flori Chaunce Franzel");
            listString.Add("Odetta Sue Kaspar");
            listString.Add("Roy Ketti Kopfen");
            listString.Add("Madel Bordie Mapplebeck");
            listString.Add("Selle Bellison");
            listString.Add("Leonerd Adda Mitchell Monaghan");
            listString.Add("Debra Micheli");
            listString.Add("Hailey Avie Annakin");

            listStringSorted = Sorter.SortName(listString);

            foreach (String theString in listStringSorted)
            {
                Console.WriteLine(theString);
            }
        }
    }
}
