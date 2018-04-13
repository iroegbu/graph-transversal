using GraphTransversal.BinaryTree;
using GraphTransversal.Graph.BinaryNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.GraphGenerators.Generators
{
    class BinaryTreeFromStack
    {
        BinaryTree<char> binaryTree;

        public BinaryTree<char> Generate(Stack<char> Values)
        {
            if (Values.Count == 0)
            {
                throw new ArgumentException("Empty stack supplied.");
            }
            binaryTree = CreateBinaryTree(Values.Pop());

            foreach (var node in Values)
            {
                binaryTree.Root = PopulateBinaryTree(binaryTree.Root, node);
            }

            return binaryTree;
        }

        private BinaryTree<char> CreateBinaryTree(char RootValue)
        {
            BinaryTree<char> binaryTree = new BinaryTree<char>();
            binaryTree.Root.Value = RootValue;

            return binaryTree;
        }

        private BinaryNode<char> PopulateBinaryTree(BinaryNode<char> binaryNode, char Value)
        {
            if (binaryNode.Value < Value)
            {
                binaryNode.Left = PopulateBinaryTree(binaryNode.Left, Value);
            }
            else
            {
                binaryNode.Right = PopulateBinaryTree(binaryNode.Right, Value);
            }

            return binaryNode;
        }
    }
}
