using System;
using System.Collections.Generic;
using System.Text;

namespace BaseHomework
{
    public class LinkedList
    {
        Node head;
        public class Node
        {
            public int value;
            public Node next;

            public Node(int d)
            {
                value = d;
                next = null;
            }
        }

        // Add element
        public void Add(Node node)
        {
            if (head == null)
                head = node;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        // List Reverse
        public void Reverse()
        {
            Node tmp = head, lostLink = null;
            while (tmp.next != null)
            {
                lostLink = tmp.next; 
                tmp.next = tmp.next.next; 
                lostLink.next = head; 
                head = lostLink;
                PrintList();
            }
        }
        
        // Get List size
        public int ListSize()
        {
            int count = 0;
            Node tmp = head;
            while (tmp != null)
            {
                tmp = tmp.next;
                count++;
            }
            return count;
        }

        // Add element at index
        public void AddAtIndex(Node node, int index)
        {
            {
                if (index > ListSize()-1)
                {
                    Add(node);
                }
                else
                {
                    if (head == null)
                        head = node;

                    else
                    {
                        Node temp = head;
                        int count = 0;
                        while (count < index - 1)
                        {
                            temp = temp.next;
                            count++;
                        }
                        Node lostLink = temp.next;
                        temp.next = node;
                        node.next = lostLink;
                    }
                }
            }
        }

        // Set element value at index
        public void ChangeElementAtIndex(Node node, int index)
        {
            {
                if (index > ListSize() - 1)
                {
                    ChangeElementAtIndex(node, ListSize() - 1);
                }
                else
                {
                    if (head == null)
                        head = node;

                    else
                    {
                        Node temp = head;
                        int count = 0;
                        while (count < index)
                        {
                            temp = temp.next;
                            count++;
                        }
                        temp.value = node.value;
                    }
                }
            }
        }

        // Get value of element at index
        public int Get(int idx)
        {
            Node temp = head;
            int count = 0;
            while (count < idx)
            {
                temp = temp.next;
                count++;
            }
            return temp.value;
        }

        // List value contains
        public bool Contains(int val)
        {
            Node temp = head;
            while (temp.next != null)
            {
                if (temp.value == val)
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }

        // Add array of nodes at the end of the list
        public void AddAll(int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                Add(new LinkedList.Node(vals[i]));
            }
        }

        // Add array of nodes to List at index
        public void AddAllAtIndex(int idx, int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                AddAtIndex(new LinkedList.Node(vals[i]),idx);
                idx++;
            }
        }

        // Get first index of value
        public int IndexOf(int val)
        {
            Node temp = head;
            int count = 0;
            while (temp.value != val)
            {
                temp = temp.next;
                count++;
            }
            return count;
        }

        // Get indexes of value
        public int[] Search(int val)
        {
            Node temp = head;
            int count = 0;
            while (temp.next != null)
            {
                if (temp.value == val)
                {
                    count++;
                }
                temp = temp.next;
            }
            int[] result = new int[count];
            count = 0;
            while (temp.next != null)
            {
                if (temp.value == val)
                {
                    result[count] = temp.value;
                    count++;
                }
                temp = temp.next;
            }
            return result;
        }

        // Remove node of value
        public void RemoveVal(int val)
        {
            Node temp = head;
            while (temp.next.next != null)
            {
                if (temp.next.value == val)
                {
                    temp.next = temp.next.next;
                    break;
                }
                temp=temp.next;
            }

        }

        // Remove node at index
        public void RemoveIndx(int idx)
        {
            Node temp = head;
            int count = 0;
            while (count < idx)
            {
                if (count == idx -1)
                {
                    temp.next = temp.next.next;
                }
                temp = temp.next;
                count++;
            }
        }

        // Remove all nodes of value
        public void RemoveAll(int val)
        {
            Node temp = head;
            while (temp.next.next != null)
            {
                if (temp.next.value == val)
                {
                    temp.next = temp.next.next;
                    continue;
                }
                temp = temp.next;
            }
            temp.next = null;
        }


        // Print Lists
        public void PrintList()
        {
            Node tmp = head;
            while (tmp != null)
            {
                Console.Write(tmp.value + " ");
                tmp = tmp.next;
            }
            Console.WriteLine();
        }

    }
}
