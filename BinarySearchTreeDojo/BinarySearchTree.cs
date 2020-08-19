using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace BinarySearchTreeDojo
{
    public class BinarySearchTree

    {
        public TreeNode Root { get;  private set; }
        private BinarySearchTree()
        {
            // private constructor so it can't be instantiated like this
        }

        
        public static BinarySearchTree Build(List<int> elements)
        {
            BinarySearchTree tree = new BinarySearchTree();
            // TODO construct a binary search tree here
            if (elements.Count == 0)
            {
                throw new Exception("Array is of lenght 0");
            }
            int left = 0;
            int right = elements.Count - 1;
            if(left > right)
            {
                return null;
            }
            int midpoint = left + (right - left) / 2;
            TreeNode nodeToAdd = new TreeNode(elements[midpoint]);
            tree.Root = nodeToAdd;

            for (int i = left; i <=midpoint-1; i++)
            {
                tree.Add(elements[i]);
            }
            for (int i = midpoint + 1; i<=right; i++)
            {
                tree.Add(elements[i]);
            }
            return tree;
            
        }

        //private static BinarySearchTree CreateFromSortedList(List<int> elems, int left, int right)
        //{
        //    if (left > right) return null;
        //    int midpoint = left + (right - left) / 2;
        //}
    
        public Boolean Search(int toFind) {
            // TODO return true if the element has been found, false if its not in the tree.
            if(Root == null)
            {
                return false;
            }
            else
            {
                return SearchRecursive(toFind,Root);
            }
            
        }

        private Boolean SearchRecursive(int toFind, TreeNode node)
        {
            return false;
        }

        public void Add(int toAdd) {
            // TODO adds an element. Throws an error if it exist.
            TreeNode nodeToAdd = new TreeNode(toAdd);
            if (Root == null)
            {
                Root = nodeToAdd;
            } 
            else
            {
                AddRecursive(toAdd, Root);
            }
        }

        public void AddRecursive(int value, TreeNode currentNode)
        {
            TreeNode nodeToAdd = new TreeNode(value);
            if(value < currentNode.Value)
            {
                if(currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = nodeToAdd;
                } 
                else
                {
                    AddRecursive(value, currentNode.LeftChild);
                }
            } 
            else
            if (value > currentNode.Value)
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = nodeToAdd;
                }
                else
                {
                    AddRecursive(value, currentNode.RightChild);
                }
            }
        }

        public void Remove(int toRemove) {
            // TODO removes an element. Throws an error if its not on the tree.
        }
        
        public void PreOrderTraversal()
        {
            if(Root == null)
            {
                return;
            }
            else 
                PreorderTraversalRecursive(Root);
        }

        private void PreorderTraversalRecursive(TreeNode node)
        {
            if(node != null)
            {
                Console.WriteLine(node.Value);
                //if(node.LeftChild != null)
                //{
                //    Console.Write($"Left child: {node.LeftChild.Value} ");
                //}
                //if (node.RightChild != null)
                //{
                //    Console.Write($"Right child: {node.RightChild.Value} ");
                //}
                PreorderTraversalRecursive(node.LeftChild);
                PreorderTraversalRecursive(node.RightChild);
            }
                
        }
    }
}
