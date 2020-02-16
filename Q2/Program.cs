using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Q2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //read in the document, and query it using Linq
            IEnumerable<string> results = from data in XDocument.Load(@"data.xml")
                                        .Descendants("DeclarationHeader")
                                        .Descendants("Reference")//scope in on the desired element
                                          where (string)data.Attribute("RefCode") == "MWB" ||
                                           (string)data.Attribute("RefCode") == "TRV" ||
                                           (string)data.Attribute("RefCode") == "CAR" //filter the results to match the requirements
                                          select data.Element("RefText").Value; //extract the desired values

            //print the results
            foreach (string result in results)
                Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}