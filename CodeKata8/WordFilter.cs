using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeKata8
{
    public class WordFilter
    {
        private const int MaxWordLength = 6;

        /// <summary>
        /// Function to filter 6 letter words that are composed by concatenating two smaller string. 
        /// The function takes in a ReadonlyCollection of words on which filtering happens. 
        /// </summary>
        /// <remarks>
        /// Have used IReadOnlyCollection because there is no need to modify the input collection 
        /// and the user can take the advantage of the Count method. 
        /// </remarks>
        /// <param name="wordList">Readonly collection of all the words including the 6 letter words and other small words</param>
        /// <returns>new list of 6 letter words formed by concatenating 2 smaller words</returns>
        public IList<string> FilterWords(IReadOnlyCollection<string> wordList)
        {
            if (wordList == null)
            {
                throw new ArgumentNullException("wordList");
            }

            // collection might be initialised with no data
            if (wordList.Count == 0)
            {
                // can be handled better with custom exceptions
                throw new ArgumentException("Word list is empty.");
            }

            // sort the wordlist by ascending order of word length such that the "MaxWordLength" words go down in the list
            var sortedWordList = from w in wordList orderby w.Length select w;

            // group by length. ToLookup is quite apt here as the object is local and we do not need deferred execution in this case. 
            var lookUpWords = sortedWordList.ToLookup(w => w.Length);

            // get all the "MaxWordLength" letter words from the collection (6 being the max word length in the program)
            var maxLengthWords = lookUpWords.Where(k => k.Key == MaxWordLength);

            // if there are no words of length equal to 6, then throw exception
            var lengthWords = maxLengthWords as IGrouping<int, string>[] ?? maxLengthWords.ToArray();
            if (!lengthWords.Any())
            {
                // can be handled better with custom exceptions
                throw new Exception(string.Format("Word list does not contain any {0} letter words. Cannot create a dictionary.", MaxWordLength));
            }

            // get all the words of length less than MaxWordLength (6 being the max word length in the program)
            var lessThanMaxLengthWords = lookUpWords.Where(k => k.Key < MaxWordLength);

            // if there are no words less than length 6, then throw exception 
            if (!lessThanMaxLengthWords.Any())
            {
                // can be handled better with custom exceptions
                throw new Exception(string.Format("Word list does not contain any words less than {0}.", MaxWordLength));
            }
            
            // make a dictionary out of all the MaxWordLength-letter words. Using HashSet for faster lookup performance - O(1)
            // For this problem, the dictionary is self-contained within the list.
            // using the .First() extension method as it is not legal for the sequence (maxLengthWords) to be empty here
            var dictionary = new HashSet<string>(lengthWords.First());

            // instantiate a new list for storing the filtered word(s) output
            var output = new List<string>();
            
            // The nesting of foreach can be flattened by using LINQ extension method (SelectMany). 
            // Left it like that for readability purpose.
            foreach (var word1 in sortedWordList.TakeWhile(word1 => word1.Length < MaxWordLength))
            {
                // iterate through all words whose length is less than MaxWordLength (6 being the max word length in the program)
                output.AddRange(lookUpWords[MaxWordLength - word1.Length].Select(word2 => (word1 + word2)).Where(concatenatedWord => dictionary.Contains(concatenatedWord)));
            }

            // get the list of concatenated words of length 6
            return output;
        }
    }
}