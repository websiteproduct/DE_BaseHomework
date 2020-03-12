using System;
using System.Collections.Generic;
using System.Text;

namespace BaseHomework
{
    public class DLinkedList
    {
        DNode head;
        DNode tail;
        int size;

        class DNode
        {
            public int Value { get; set; }
            public DNode Next { get; set; }
            public DNode Previous { get; set; }
        }

        public DLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public DLinkedList(int[] array)
        {
            DNode prev = null;

            for (int i = 0; i < array.Length; i++)
            {
                DNode node = new DNode();
                node.Value = array[i];

                if (i == 0)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    prev.Next = node;
                    tail = node;
                    tail.Previous = prev;
                }
                prev = node;
            }
            size = array.Length;
        }

        public int[] ToArray()
        {
            DNode current = head;
            int[] arr = new int[size];
            int count = 0;

            while (current != null)
            {
                arr[count] = current.Value;
                current = current.Next;
                count++;
            }
            return arr;
        }

        public void AddFirst(int val)
        {
            DNode node = new DNode
            {
                Value = val,
                Next = head
            };
            head = node;

            if (size == 0)
                tail = head;
            else
                head.Previous = node;

            size++;
        }

        public void AddFirstArr(int[] vals)
        {
            for (int i = vals.Length - 1; i >= 0; i--)
            {
                AddFirst(vals[i]);
            }
        }

        public void AddLast(int val)
        {
            DNode node = new DNode
            {
                Value = val
            };

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            size++;
        }

        public void AddLastArr(int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                AddLast(vals[i]);
            }
        }

        public void AddAt(int idx, int val)
        {
            DNode node = new DNode
            {
                Value = val
            };

            DNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.Next;
                count++;
            }

            if (size == idx)
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }

            node.Next = prev.Next;
            prev.Next = node;
            node.Previous = prev;
            prev.Next.Previous = node;
            size++;
        }

        public void AddAtArr(int idx, int[] vals)
        {
            if (idx > size)
            {
                return;
            }

            for (int i = 0; i < vals.Length; i++)
            {
                AddAt(idx, vals[i]);
                idx++;
            }

        }

        public int GetSize()
        {
            return size;
        }

        public int GetFirst()
        {
            if (head == null)
            {
                return -1;
            }

            return head.Value;
        }

        public int GetLast()
        {
            if (head == null)
            {
                return -1;
            }

            return tail.Value;
        }

        public int Get(int idx)
        {
            if (idx < 0 || idx > size)
            {
                return -1;
            }

            DNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.Next;
                count++;
            }

            return prev.Value;
        }

        public bool Contains(int val)
        {
            DNode node = head;

            if (GetSize() == 0) return false;

            while (node.Next != null)
            {
                if (node.Value == val)
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public void Set(int idx, int val)
        {
            if (idx > size) return;

            DNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.Next;
                count++;
            }
            prev.Value = val;
        }

        public void RemoveFirst()
        {
            head = head.Next;
            head.Previous = null;

            if (head == null) { tail = null; }
            size--;
        }

        public void RemoveLast()
        {
            if (head == null) return;

            tail.Previous.Next = null;
            tail = tail.Previous;

            size--;
        }

        public void RemoveAt(int idx)
        {
            if (head == null) return;

            DNode current = head, prev = null;
            int count = 0;

            while (count < idx)
            {
                prev = current;
                current = current.Next;
                count++;
            }

            if (prev == null)
            {
                head = head.Next;
                head.Previous = null;
            }
            else
            {
                if (current.Next == null)
                {
                    tail = prev.Previous;
                    prev.Next = null;
                }
                else
                {
                    prev.Next = current.Next;
                    current.Next.Previous = prev;
                }
            }
            size--;
        }

        public int IndexOf(int val)
        {
            DNode node = head;
            int idx = 0;

            while (node != null)
            {
                if (node.Value == val)
                {
                    return idx;
                }
                node = node.Next;
                idx++;
            }

            return -1;
        }


        public void Reverse()
        {
            if (head == null) return;

            DNode current = head;

            while (current.Next != null)
            {
                DNode tmp = current.Next;
                current.Next = current.Previous;
                current.Previous = tmp;
                current = current.Previous;
            }

            DNode tmp1 = current.Next;
            current.Next = current.Previous;
            current.Previous = tmp1;
            head = current;
        }

        public void RemoveAll(int val)
        {
            if (head == null) return;

            DNode current = head, prev = null;

            while (current != null)
            {
                if (current.Value.Equals(val))
                {
                    if (prev == null)
                    {
                        head = head.Next;
                        head.Previous = null;
                    }
                    else
                    {
                        if (current.Next == null)
                        {
                            tail = prev.Previous;
                            prev.Next = null;
                        }
                        else
                        {
                            prev.Next = current.Next;
                            current.Next.Previous = prev;
                        }
                    }

                    size--;
                }
                prev = current;
                current = current.Next;
            }
        }

        public void PrintList()
        {
            DNode tmp = head;
            while (tmp != null)
            {
                Console.Write(tmp.Value + " ");
                tmp = tmp.Next;
            }
            Console.WriteLine();
        }
    }
}