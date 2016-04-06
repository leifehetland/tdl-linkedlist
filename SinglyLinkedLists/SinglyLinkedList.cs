using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode firstLocation { get; set; }
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                this.AddLast(values[i] as String);
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set {
                SinglyLinkedListNode myRef = this.firstLocation;
                SinglyLinkedListNode lastRef = null;
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                int length = this.Count();

                if (myRef != null && i <= length)
                {
                    for (int j = 0; j < i; j++)
                    {
                        lastRef = myRef;
                        myRef = myRef.Next;
                    }
                    myRef = newNode;
                    lastRef.Next = newNode;
                }
                else
                {
                    throw new ArgumentException("Error");
                }
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            SinglyLinkedListNode myRef = firstLocation;

            if (myRef == null)
            {
                throw new ArgumentException();
            }
            else
            {
                while (myRef.Value != existingValue)
                {
                    if (myRef.Next == null)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        myRef = myRef.Next;
                    }
                }
                newNode.Next = myRef.Next;
                myRef.Next = newNode;
            }
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode firstNode = new SinglyLinkedListNode(value);
            firstNode.Next = firstLocation;
            firstLocation = firstNode;
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode lastNode = new SinglyLinkedListNode(value);
            if (this.First() == null)
            {
                firstLocation = lastNode;
            }
            else
            {
                SinglyLinkedListNode latestNode = firstLocation;
                while (!(latestNode.IsLast()))
                {
                    latestNode = latestNode.Next;
                }
                latestNode.Next = lastNode;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            int count = 0;

            if (firstLocation != null)
            {
                SinglyLinkedListNode increment = firstLocation;
                while (increment != null)
                {
                    increment = increment.Next;
                    count++;
                }
                return count;
            }
            else
            {
                return 0;
            }
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode elementAtNode = firstLocation;
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    elementAtNode = elementAtNode.Next;
                }
                return elementAtNode.Value.ToString();
            }     
        }

        public string First()
        {
            return firstLocation?.ToString();
        }

        public int IndexOf(string value)
        {
            string [] myArray = this.ToArray();
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i].ToString() == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsSorted()
        {
            if (this.First() != null)
            {
                for (int i = 0; i < this.Count()-1; i++)
                {
                    if (String.Compare(this.ElementAt(i), this.ElementAt(i+1), StringComparison.CurrentCulture) == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            SinglyLinkedListNode latestNode = null;
            if (this.firstLocation != null)
            {
                latestNode = this.firstLocation;

                while (!latestNode.IsLast())
                {
                    latestNode = latestNode.Next;
                }

                return latestNode.Value.ToString();

            }
            else
            {
                return null;
            }
        }

        public void Remove(string value)
        {
            int nodeSpot = this.IndexOf(value);
            var myList = new SinglyLinkedList();
            for (int i = 0; i < this.Count(); i++)
            {
                if (i != nodeSpot)
                {
                    myList.AddLast(ElementAt(i));
                }
            }
            this.firstLocation = new SinglyLinkedListNode(myList.First());
   
            for (int j = 1; j < myList.Count(); j++)
            {
                this.AddLast(myList.ElementAt(j));
            }
        }

        public void Sort()
        {
            if (this.Count() < 2)
            {
                return;
            }
            else
            {
                while (!this.IsSorted())
                {
                    var myRef = this.firstLocation;
                    var nextNode = myRef.Next;
                    for (int i = 1; i < this.Count(); i++)
                    {
                        if (myRef.Value.CompareTo(nextNode.Value) > 0)
                        {
                            var shortLived = myRef.Next.Value;
                            nextNode.Value = myRef.Value;
                            myRef.Value = shortLived;
                        }
                        myRef = myRef.Next;
                        nextNode = nextNode.Next;
                    }
                }
            }
        }

        public string[] ToArray()
        {
            int count = this.Count();
            SinglyLinkedListNode newNode = firstLocation;
            string[] toArray = new string[count];


            int i = 0;
            while (newNode != null)
            {
                toArray[i] = newNode.Value;
                i++;
                newNode = newNode.Next;
            }
            return toArray;
        }

        public override string ToString()
        {
            string toString = "{ ";
            SinglyLinkedListNode newNode = firstLocation;

            if (newNode == null)
            {
                return "{ }";
            }

            while (newNode != null)
            {
                toString += "\"" + newNode.Value + "\"";
                newNode = newNode.Next;
                if (newNode != null)
                {
                    toString += ", ";
                }
            }
            toString += " }";
            return toString;
        }
    }
}
