using System;
using System.Collections.Generic;
using System.IO;

namespace Q1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //read in all the lines from the document
            string[] lines = File.ReadAllLines(@"data.edi");
            List<string> locLines = new List<string>();
            List<string> finalResults = new List<string>();

            //extract all lines that have the text "LOC" in it
            foreach (string line in lines)
            {
                if (line.Contains("LOC"))
                    locLines.Add(line);
            }

            //separate each segment of the line containing "LOC"
            foreach (string line in locLines)
            {
                string[] segments = line.Split('+');
                for (int i = 0; i < segments.Length; i++)
                {
                    //filter out all of the 1st segments, leaving only the remaining 2 segments
                    if (segments[i] != "LOC")
                        finalResults.Add(segments[i]);
                }
            }

            //print out the results
            foreach (string result in finalResults)
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
}