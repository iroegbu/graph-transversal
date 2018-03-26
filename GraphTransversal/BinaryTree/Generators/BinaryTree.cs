using GraphTransversal.GenericGraph.BinaryNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.BinaryTree.Generators
{
    class BinaryTreeGenerator
    {
        BinaryTree<int> binaryTree;

        public BinaryTree<int> Generate(Stack<int> Values)
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

        private BinaryTree<int> CreateBinaryTree(int RootValue)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root.Value = RootValue;

            return binaryTree;
        }

        private BinaryNode<int> PopulateBinaryTree(BinaryNode<int> binaryNode, int Value)
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
