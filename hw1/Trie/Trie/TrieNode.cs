using System.Collections.Generic;

namespace Trie
{
    /// <summary>
    /// Class for Trie element.
    /// </summary>
    public class TrieNode
    {
        public TrieNode()
        {
            _nextNode = new Dictionary<char, TrieNode>();
            _startPrefixCount = 0;
            _isTerminateNode = false;
        }
        
        /// <summary>
        /// Increase the number achieved strings from the current node. 
        /// </summary>
        public void IncreaseStringCounter()
        {
            _startPrefixCount++;
        }
        
        /// <summary>
        /// Decrease the number achieved strings from the current node.
        /// </summary>
        public void DecreaseStringCounter()
        {
            _startPrefixCount--;
        }
        
        /// <summary>
        /// Returns the number achieved strings from the current node.
        /// </summary>
        /// <returns> Number of achieved strings from the current node.</returns>
        public int GetPrefixCount()
        {
            return _startPrefixCount;
        }

        /// <summary>
        /// Add next TrieNode which accessible be edge with value 'edgeValue'.
        /// </summary>
        /// <param name="edgeValue"> Value on the edge.</param>
        /// <param name="linkingNode"> Next TrieNode.</param>
        public void AddLink(char edgeValue, TrieNode linkingNode)
        {
            _nextNode.Add(edgeValue, linkingNode);
            IncreaseStringCounter();
        }

        /// <summary>
        /// Remove linked TrieNode from current Node.
        /// </summary>
        /// <param name="edgeValue"> Value on the removing edge.</param>
        public void RemoveLink(char edgeValue)
        {
            _nextNode.Remove(edgeValue);
            DecreaseStringCounter();
        }
        
        /// <summary>
        /// Check if the node contains an edge with value 'edgeValue'.
        /// </summary>
        /// <param name="edgeValue"> Value on the edge.</param>
        /// <returns> True if node contains edge with value 'edgeValue', false otherwise.</returns>
        public bool IsContainLinkWithValue(char edgeValue)
        {
            return _nextNode.ContainsKey(edgeValue);
        }
        
        /// <summary>
        /// Returns TrieNode which accessible be value 'edgeValue';
        /// </summary>
        /// <param name="edgeValue"> Value on the edge.</param>
        /// <returns> TrieNode connected with current Node by edge with value 'edgeValue'.</returns>
        public TrieNode GetLink(char edgeValue)
        {
            return _nextNode[edgeValue];  
        }
        
        /// <summary>
        /// Checks if any string ending in this node. 
        /// </summary>
        /// <returns> Return true if there is string which ends in this node.</returns>
        public bool IsTerminateNode()
        {
            return _isTerminateNode;
        }
        
        /// <summary>
        /// Mark that some string ends in this node.
        /// </summary>
        public void MarkNodeAsTerminated()
        {
            _isTerminateNode = true;
        }
        
        /// <summary>
        /// Mark that noone string ends in this node.
        /// </summary>
        public void UnmarkNodeAsTerminated()
        {
            _isTerminateNode = false;
        }

        private readonly Dictionary<char, TrieNode> _nextNode;
        private int _startPrefixCount;
        private bool _isTerminateNode;

    }
}