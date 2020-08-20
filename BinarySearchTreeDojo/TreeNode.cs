using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeDojo
{
    public class TreeNode
    {
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        public int Value { get; set; }

        public TreeNode(int value/* TreeNode parent, TreeNode leftChild, TreeNode rightChild*/)
        {
            Value = value;
            //Parent = parent;
            //LeftChild = leftChild;
            //RightChild = rightChild;
        }
    }
}
