using System;
using System.Collections.Generic;

namespace CodeKata8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var wordList = new List<string>
                               {
                                   "al",
                                   "albums",
                                   "aver",
                                   "bar",
                                   "barely",
                                   "be",
                                   "befoul",
                                   "bums",
                                   "by",
                                   "cat",
                                   "con",
                                   "see",
                                   "convex",
                                   "ely",
                                   "foul",
                                   "here",
                                   "hereby",
                                   "jig",
                                   "jigsaw",
                                   "or",
                                   "saw",
                                   "tail",
                                   "tailor",
                                   "vex",
                                   "we",
                                   "weaver",
                                   "seesaw"
                               };

            var wordFilter = new WordFilter();
            var filteredWords = wordFilter.FilterWords(wordList);

            foreach (var word in filteredWords)
            {
                Console.WriteLine("{0} :: Length {1}", word, word.Length);
            }

            Console.ReadLine();
        }
    }
}
