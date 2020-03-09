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

        //Добавляет элемент
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

        //Реверс листа
        public void Reverse()
        {

            Node tmp = head, lostLink = null;
            while (tmp.next != null)
            {
                lostLink = tmp.next; 
                tmp.next = tmp.next.next; 
                lostLink.next = head; 
                head = lostLink; 
                
            }
        }
        
        // Размер листа
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

        // Добавляет элемент на определенную позицию
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

        // Меняет значение ноды на определенной позиции
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

        // Получить значение по индексу
        public int Get(int indx)
        {
            Node temp = head;
            int count = 0;
            while (count < indx)
            {
                temp = temp.next;
                count++;
            }
            return temp.value;
        }

        // Содержит ли лист значение
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

        // Добавить массив в лист в конец
        public void AddAll(int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                Add(new LinkedList.Node(vals[i]));
            }
        }

        // Добавить массив в лист по индексу
        public void AddAllAtIndex(int indx, int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                AddAtIndex(new LinkedList.Node(vals[i]),indx);
                indx++;
            }
        }

        //Возвращает индекс первого совпадения
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

        //Возвращает индексы совпадающих элементов
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

        //Удаляет элемент со значением val
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

        //Удаляет элемент по индексу
        public void RemoveIndx(int indx)
        {
            Node temp = head;
            int count = 0;
            while (count < indx)
            {
                if (count == indx -1)
                {
                    temp.next = temp.next.next;
                }
                temp = temp.next;
                count++;
            }
        }

        // Удаляет все элементы с начением val
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


        // Вывести лист
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
