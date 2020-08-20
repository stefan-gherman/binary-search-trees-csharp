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
            if(toFind == node.Value)
            {
                return true;
            } 
            else
            {
                if(toFind > node.Value && node.RightChild != null)
                {
                    return SearchRecursive(toFind, node.RightChild);
                } 
                else if(toFind < node.Value && node.LeftChild != null)
                {
                    return SearchRecursive(toFind, node.LeftChild );
                }
               
                return false;
            }
        }

        public TreeNode Find(int valueToFind)
        {
            if(Root == null)
            {
                return null;
            } 
            else
            {
                return FindRecursive(valueToFind, Root);
            }
        }

        private TreeNode FindRecursive(int valueToFind, TreeNode currentNode)
        {
            if(valueToFind == currentNode.Value)
            {
                return currentNode;
            } 
            else
            {
                if(valueToFind > currentNode.Value && currentNode.RightChild != null)
                {
                    return FindRecursive(valueToFind, currentNode.RightChild);
                } 
                else if(valueToFind < currentNode.Value && currentNode.LeftChild != null)
                {
                    return FindRecursive(valueToFind, currentNode.LeftChild);
                }
                return null;
            }
        }


        public void Add(int toAdd) {
            // TODO adds an element. Throws an error if it exist.
            if(Search(toAdd))
            {
                throw new Exception("Value already exists, no duplicates allowed");
            }
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
                    currentNode.LeftChild.Parent = currentNode;
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
                    currentNode.RightChild.Parent = currentNode;
                }
                else
                {
                    AddRecursive(value, currentNode.RightChild);
                }
            }
        }

        public void Remove(int toRemove) {
            if(!Search(toRemove))
            {
                throw new Exception("Value does not exist!");
            }
            // TODO removes an element. Throws an error if its not on the tree.
            Remove(Find(toRemove));
        }

        private void Remove(TreeNode currentNode)
        {
            var nodeParent = currentNode.Parent;
            int numberChildren = NumberOfChildren(currentNode);

            if(numberChildren == 0) 
            {
                if (nodeParent.LeftChild == currentNode)
                {
                    nodeParent.LeftChild = null;
                }
                else if(nodeParent.RightChild == currentNode)
                {
                    nodeParent.RightChild = null;
                }
            }
            else if(numberChildren == 1)
            {
                TreeNode childNode;
                if(currentNode.LeftChild != null)
                {
                    childNode = currentNode.LeftChild;
                } 
                else
                {
                    childNode = currentNode.RightChild;
                }
                if(nodeParent.LeftChild == currentNode)
                {
                    nodeParent.LeftChild = childNode;
                } 
                else
                {
                    nodeParent.RightChild = childNode;
                }
                childNode.Parent = nodeParent;
            }
            else if(numberChildren == 2)
            {
                var successor = MinSuccessor(currentNode.RightChild);
                currentNode.Value = successor.Value;
                Remove(successor);
            }
            
        }

        private int NumberOfChildren(TreeNode node)
        {
            int numChildren = 0;
            if(node.RightChild != null)
            {
                numChildren += 1;
            }

            if(node.LeftChild != null)
            {
                numChildren += 1;
            }
            return numChildren;
        }

        private TreeNode MinSuccessor(TreeNode node)
        {
            TreeNode currentNode = node;
            while(currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }
            return currentNode;
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
