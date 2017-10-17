using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void Init()
        {
            _trie = new Trie.Trie();
        }
        
        [Test]
        public void TestInit()
        {
        }

        [Test]
        public void TestEmptyString()
        {
            Assert.True(_trie.Add(""));
        }

        [Test]
        public void TestEmptyStringContaining()
        {
            Assert.True(_trie.Add(""));
            Assert.AreEqual(1, _trie.Size());
        }

        [Test]
        public void TestRemoveNonExistingEmptyString()
        {
            Assert.False(_trie.Remove(""));
        }

        [Test]
        public void TestAddAndRemoveEmptyString()
        {
            Assert.True(_trie.Add(""));
            Assert.AreEqual(1, _trie.Size());
            Assert.True(_trie.Remove(""));
        }

        [Test]
        public void TestPrefixCountEmptyString()
        {
            Assert.True(_trie.Add(""));
            Assert.AreEqual(1, _trie.HowManyStartsWithPrefix(""));
            Assert.True(_trie.Remove(""));
        }

        [Test]
        public void TestAddSameStringTwice()
        {
            Assert.True(_trie.Add("test"));
            Assert.False(_trie.Add("test"));
        }
        
        [Test]
        public void TestAddNonEmptyStrings()
        {
            Assert.True(_trie.Add("test1"));
            Assert.True(_trie.Add("test2"));
            Assert.True(_trie.Add("1test"));
            Assert.True(_trie.Add("2test"));
        }

        [Test]
        public void TestNonEmptyStringsContaining()
        {
            Assert.True(_trie.Add("test1"));
            Assert.True(_trie.Add("test3"));
            Assert.True(_trie.Add("2test"));
            Assert.AreEqual(3, _trie.Size());
        }

        [Test]
        public void TestContains()
        {
            Assert.True(_trie.Add("aba"));
            Assert.True(_trie.Add("baba"));
            Assert.False(_trie.Contains(""));
            Assert.False(_trie.Contains("a"));
            Assert.False(_trie.Contains("ab"));
            Assert.True(_trie.Contains("aba"));
            Assert.False(_trie.Contains("bab"));
            Assert.True(_trie.Contains("baba"));
            Assert.AreEqual(2, _trie.Size());
        }

        [Test]
        public void TestAddStringsWithEqualPrefix()
        {
            Assert.True(_trie.Add("ab"));
            Assert.True(_trie.Add("abab"));
            Assert.True(_trie.Contains("ab"));
            Assert.False(_trie.Contains("aba"));
            Assert.True(_trie.Contains("abab"));
        }

        [Test]
        public void TestCountPrefix()
        {
            Assert.True(_trie.Add(""));
            Assert.True(_trie.Add("aba"));
            Assert.True(_trie.Add("aca"));
            Assert.True(_trie.Add("ada"));
            Assert.True(_trie.Add("bab"));
            Assert.True(_trie.Add("bac"));
            Assert.True(_trie.Add("cad"));
            var prefixAndOccurrences = new List<Tuple<string, int>>
            {
                Tuple.Create("", 7),
                Tuple.Create("a", 3),
                Tuple.Create("ab", 1),
                Tuple.Create("aba", 1),
                Tuple.Create("ac", 1),
                Tuple.Create("aca", 1),
                Tuple.Create("ad", 1),
                Tuple.Create("ada", 1),
                Tuple.Create("b", 2),
                Tuple.Create("ba", 2),
                Tuple.Create("bab", 1),
                Tuple.Create("bac", 1),
                Tuple.Create("c", 1),
                Tuple.Create("ca", 1),
                Tuple.Create("cad", 1)
            };
            foreach (var testData in prefixAndOccurrences)
            {
                Assert.AreEqual(testData.Item2, _trie.HowManyStartsWithPrefix(testData.Item1));
            }
        }

        [Test]
        public void TestContainsOnEmptyTrie()
        {
            Assert.False(_trie.Contains("aba"));
        }
        
        private Trie.Trie _trie;
    }
}