using System;
using System.Collections.Generic;
using CodeKata8;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentUnitTest
{
    [TestClass]
    public class WordFilterTest
    {
        [TestMethod]
        public void FilterWords_WhenInputWordIsNull_ThrowsException()
        {
            var wordFilter = new WordFilter();
            ExceptionAssert.Throws<ArgumentNullException>(() => wordFilter.FilterWords(null));
        }

        [TestMethod]
        public void FilterWords_WhenInputListIsEmpty_ThrowsException()
        {
            var wordFilter = new WordFilter();
            var inputWordList = new List<string>();
            ExceptionAssert.Throws<ArgumentException>(() => wordFilter.FilterWords(inputWordList));
        }

        [TestMethod]
        public void FilterWords_WhenInputListDoesNotContainAny6LetterWords_ThrowsException()
        {
            var wordFilter = new WordFilter();
            var inputWordList = new List<string> {"al", "bums"};
            ExceptionAssert.Throws<Exception>(() => wordFilter.FilterWords(inputWordList));
        }

        [TestMethod]
        public void FilterWords_WhenInputListDoesNotContainAnyWordLessThan6InLength_ThrowsException()
        {
            // Arrange
            var wordFilter = new WordFilter();
            var inputWordList = new List<string> { "albums", "beaver" };

            // Assert                              *Act*
            ExceptionAssert.Throws<Exception>(() => wordFilter.FilterWords(inputWordList));
        }

        [TestMethod]
        public void FilterWords_WhenInputListContainsWordsButCannotComposeValid6LetterWords_ReturnsEmptyList()
        {
            // Arrange
            var wordFilter = new WordFilter();
            var inputWordList = new List<string> { "albums", "beaver", "al", "jig", "weaver" };

            // Act
            var output = wordFilter.FilterWords(inputWordList);

            // Assert
            Assert.AreEqual(0, output.Count);            
        }

        [TestMethod]
        public void FilterWords_WhenInputListContains6LetterWordWith2ValidSmallWordsForConcatenation_ReturnsListWithAValid6LetterWord()
        {
            // Arrange
            var wordFilter = new WordFilter();
            var inputWordList = new List<string> { "albums", "al", "bums" };

            // Act
            var output = wordFilter.FilterWords(inputWordList);

            // Assert
            Assert.AreEqual("albums", output[0]);
        }

        [TestMethod]
        public void FilterWords_WhenInputListContainsTwo6LetterWordWith4ValidSmallWordsForConcatenation_ReturnsListWithTwo6LetterWords()
        {
            // Arrange
            var wordFilter = new WordFilter();
            var inputWordList = new List<string> { "albums", "al", "jigsaw", "bums", "jig", "saw" };

            // Act
            var output = wordFilter.FilterWords(inputWordList);

            // Assert
            Assert.AreEqual(2, output.Count);
        }

        [TestMethod]
        public void FilterWords_WhenInputListContainsOne7LetterWordOne6LetterWordWith2ValidSmallWordsForConcatenation_ReturnsListWithAWordOfLength6()
        {
            // Arrange
            var wordFilter = new WordFilter();
            var inputWordList = new List<string> { "albums", "al", "bums", "rhythms" };

            // Act
            var output = wordFilter.FilterWords(inputWordList);

            // Assert
            Assert.AreEqual(6, output[0].Length);
        }

        [TestMethod]
        public void FilterWords_WhenInputListContains6LetterWordsWithManyOtherWords_ReturnsListContainingOnlyValidConcatenated6LetterWords()
        {
            // Arrange
            var wordFilter = new WordFilter();
            var inputWordList = new List<string> { "albums", "al", "jigsaw", "bums", "jig", "saw", "beaver", "be", "aver", "four", "two", "masters", "mas", "ters" };

            // Act
            var output = wordFilter.FilterWords(inputWordList);

            // Assert (album, beaver, jigsaw)
            Assert.AreEqual(3, output.Count);
        }
       
    }
}
