using GraphTransversal.Graph.BinaryNode;

namespace GraphTransversal.BinaryTree
{
    class BinaryTree<T>
    {
        public BinaryNode<T> Root
        {
            get; set;
        }

        public BinaryTree()
        {
            Root = null;
        }

        public virtual void Clear()
        {
            Root = null;
        }
    }
}
