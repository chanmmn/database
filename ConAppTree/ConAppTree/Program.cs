using ConAppTree.Models;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Course Data { get; set; }
    }

    class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(Course value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value.CourseId < after.Data.CourseId) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value.CourseId > after.Data.CourseId) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value.CourseId < before.Data.CourseId)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data.CourseId + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data.CourseId + " ");
                TraverseInOrder(parent.RightNode);
            }
        }
        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data.CourseId + " ");
            }
        }

        private Node Find(Course value, Node parent)
        {
            if (parent != null)
            {
                if (value.CourseId == parent.Data.CourseId) return parent;
                if (value.CourseId < parent.Data.CourseId)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        public Node Find(Course value)
        {
            return this.Find(value, this.Root);
        }

        private Course MinValue(Node node)
        {
            Course minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node Remove(Node parent, Course key)
        {
            if (parent == null) return parent;

            if (key.CourseId < parent.Data.CourseId) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key.CourseId > parent.Data.CourseId)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        public void Remove(Course value)
        {
            this.Root = Remove(this.Root, value);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolDBContext schoolDBContext = new SchoolDBContext();
            BinaryTree binaryTree = new BinaryTree();
            var result = schoolDBContext.Courses;

            foreach(var course in result)
            {
                binaryTree.Add(course);
            }

            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();
            binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine();
            binaryTree.TraversePostOrder(binaryTree.Root);
        }
    }
}