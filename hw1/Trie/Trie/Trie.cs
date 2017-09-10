namespace Trie
{
    /// <summary>
    /// Self-written Trie class.
    /// </summary>
    public class Trie
    {

        public Trie()
        {
            _rootNode = new TrieNode();
            _size = 0;
        }
        
        /// <summary>
        /// Check if Trie contains an element.
        /// </summary>
        /// <param name="element"> Testing element.</param>
        /// <returns> True if trie contains requesting element, false otherwise.</returns>
        public bool Contains(string element)
        {
            var currentNode = _rootNode;
            foreach (var ch in element)
            {
                if (!currentNode.IsContainLinkWithValue(ch))
                {
                    return false;
                }
                currentNode = currentNode.GetLink(ch);
            }
            return currentNode.IsTerminateNode();
        }
        
        /// <summary>
        /// Add new element to the Trie.
        /// </summary>
        /// <param name="element"> New element.</param>
        /// <returns> Returns true if this Trie did not already contain the specified element.</returns>
        public bool Add(string element)
        {
            if (Contains(element))
            {
                return false;
            }
            _size++;
            var curNode = _rootNode;
            foreach (var ch in element)
            {
                if (curNode.IsContainLinkWithValue(ch))
                {
                    curNode.IncreaseStringCounter();
                    curNode = curNode.GetLink(ch);
                }
                else
                {
                    TrieNode newNode = new TrieNode();
                    curNode.AddLink(ch, newNode);
                    curNode = newNode;
                }
            }
            curNode.MarkNodeAsTerminated();
            curNode.IncreaseStringCounter();
            return true;
        }
        
        /// <summary>
        /// Remove element from the Trie.
        /// </summary>
        /// <param name="element"> Removing element.</param>
        /// <returns> Returns true if this Trie contained the specified element.</returns> 
        public bool Remove(string element)
        {
            if (!Contains(element))
            {
                return false;
            }
            _size--;
            var curNode = _rootNode;
            foreach (var ch in element)
            {
                var nextNode = curNode.GetLink(ch);
                if (nextNode.GetPrefixCount() == 1)
                {
                    curNode.RemoveLink(ch);
                }
                else
                {
                    curNode.DecreaseStringCounter();
                }
                curNode = nextNode;
            }
            curNode.UnmarkNodeAsTerminated();
            curNode.DecreaseStringCounter();
            return true;
        }

        /// <summary>
        /// Returns number of elements in the trie.
        /// </summary>
        /// <returns> The size of the Trie.</returns>
        public int Size()
        {
            return _size;
        }
        
        /// <summary>
        /// Returns the number of strings starting from this prefix. 
        /// </summary>
        /// <param name="prefix"> Lookuping prefix.</param>
        /// <returns> Number of strings starting from 'prefix'.</returns>
        public int HowManyStartsWithPrefix(string prefix)
        {
            var curNode = _rootNode;
            foreach (var ch in prefix)
            {
                if (!curNode.IsContainLinkWithValue(ch))
                {
                    return 0;
                }
                curNode = curNode.GetLink(ch);
            }
            return curNode.GetPrefixCount();
        }
        
        private readonly TrieNode _rootNode;
        private int _size;
    }
}