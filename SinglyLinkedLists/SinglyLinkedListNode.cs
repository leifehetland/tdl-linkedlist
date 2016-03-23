using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return this.next; }
            set {
                /*'value' keyword is anything to the right side of the assign operator, '='*/
                if (value == this)
                {
                    throw new ArgumentException();
                }
                this.next = value;

            }
        }

        private string value; /*Access using "this.value"*/
        public string Value 
        {
            get { return value; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value)
        {
            this.value = value;


            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;

            SinglyLinkedListNode difNode = obj as SinglyLinkedListNode;
            if (difNode != null)
                return this.value.CompareTo(difNode.value);
            else
                throw new ArgumentException("Object is not a difNode");
        }

        public bool IsLast()
        {
            return this.next == null;
        }

        public override string ToString()
        {
            return value;
        }

        public override bool Equals(object obj)
        {
            if (obj is SinglyLinkedListNode)
            {
                var cast = (SinglyLinkedListNode)obj;   // throws an exception
                return this.value == cast.value;
            }
            else {
                return false;
            }
        }
    }
}
