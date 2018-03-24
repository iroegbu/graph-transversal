using GraphTransversal.GenericGraph.BinaryNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.BinaryTree.Generators
{
    class BinaryTreeGenerator<T>
    {
        public BinaryTreeGenerator<T> Generate(Stack<BinaryNode<T>> Nodes)
        {
            if (Nodes.Count == 0)
            {
                throw new ArgumentException("Root node was not supplied.");
            }
            

            bool branch = true; //true for left, false for right

            foreach (var item in Nodes)
            {
                if (branch)
                {

                }
            }
            return new BinaryTreeGenerator<T>();
        }

        private BinaryTree<T> CreateBinaryTree(BinaryNode<T> Node)
        {
            BinaryTree<T> binaryTree = new BinaryTree<T>();
            binaryTree.Root = Node;

            return binaryTree;
        }
    }
}
