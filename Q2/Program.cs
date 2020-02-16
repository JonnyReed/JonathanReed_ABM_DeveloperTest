using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Q2
{
    public class Program
    {
        public static void Main()
        {
            //array of 3 search strings
            string[] RefText = new string[3];
            RefTextArray(RefText, "MWB", "TRV", "CAR");

            //read in the document, and query it using Linq
            IEnumerable<string> results = from data in XDocument.Load(@"data.xml")
                                        .Descendants("DeclarationHeader")
                                        .Descendants("Reference")//scope in on the desired element
                                          where (string)data.Attribute("RefCode") == RefText[0] ||
                                           (string)data.Attribute("RefCode") == RefText[1] ||
                                           (string)data.Attribute("RefCode") == RefText[2] //filter the results to match the requirements
                                          select data.Element("RefText").Value; //extract the desired values


            Print(results.ToList());

            Console.ReadLine();
        }

        public static void RefTextArray(string[] array, string word1, string word2, string word3)
        {
            array[0] = word1;
            array[1] = word2;
            array[2] = word3;
        }


        public static void Print(List<string> list)
        {
            //print the results
            foreach (string element in list)
                Console.WriteLine(element);
        }
    }
}