using System;
using System.Collections.Generic;
using System.IO;

namespace Q1
{
    public class Program
    {
        //read in all the lines from the document
        public static string[] lines = File.ReadAllLines(@"data.edi");
        public static List<string> locLines = new List<string>();
        public static List<string> finalResults = new List<string>();

        public static void Main()
        {

            ExtractText(lines, locLines, "LOC");
            FilterAndSeparateText(locLines, finalResults, '+', "LOC");
            Print(finalResults);

            Console.ReadLine();
        }

        public static void ExtractText(string[] fileAsString, List<string> emptyList, string text)
        {
            //extract all lines that have the text desired text in it, in this case "LOC"
            foreach (string line in fileAsString)
            {
                if (line.Contains(text))
                    emptyList.Add(line);
            }
        }

        public static void FilterAndSeparateText(List<string> inputList, List<string> resultsList, char separator, string filterWord)
        {
            //separate each segment of the line containing value, in this case "LOC"
            foreach (string line in inputList)
            {
                string[] segments = line.Split(separator);
                for (int i = 0; i < segments.Length; i++)
                {
                    //filter out all of the unwanted segments, leaving only the remaining 2 segments
                    if (segments[i] != filterWord)
                        resultsList.Add(segments[i]);
                }
            }
        }

        public static void Print(List<string> list)
        {
            //print out the results
            foreach (string element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}