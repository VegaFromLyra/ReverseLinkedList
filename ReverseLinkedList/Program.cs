using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            Console.WriteLine("Result of iterative reverse ");
            Node result1 = ReverseIterative(node1);
            Node temp = result1;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }

            Console.WriteLine();

            Console.WriteLine("Result of recursive reverse ");
            Node result2 = ReverseRecursive(result1);

            temp = result2;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }

            Console.WriteLine();

        }

        // Example for reverse
        //prev  cu   next
        //a -   b -   c -  null

        //prev  cu    next
        //null - a    b -   c  - null

        //      prev   curr  next
        //null - a  -   b     c  - null

        //             prev  curr  next
        //null - a  -   b     c  - null

        //                    prev curr
        //null - a  -   b   -  c   null
        static Node ReverseIterative(Node head)
        {
            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        // 1 - 2 - 3 - 4 - null
        // 1 - null
        //     2 - 3 - 4 - null
        //     2 - null
        //         3 - 4 - null
        //         3 - null
        //             4 - null
        //         4 - 3 - null
        //      4 - 3 - 2 - null
        //  4 - 3 - 2 - 1 - null
        static Node ReverseRecursive(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node first = head;
            Node rest = null;
            Node result = null;

            if (first.Next != null)
            {
               rest = first.Next;
               first.Next = null;

               result = ReverseRecursive(rest);
               
               // Add curr to the end of result   
               Node temp = result;
               while (temp.Next != null)
               {
                   temp = temp.Next;
               }
   
               temp.Next = first;
            }
            else 
            {
               result = first;
            }

            return result;
        }
    }

    class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; private set; }

        public Node Next { get; set; }
    }
}
