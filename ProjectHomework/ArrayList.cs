using System;

namespace BaseHomework
{
    public class ArrayList
    {
        private int[] array;
        private int realLength;

        public ArrayList()
        {
            array = new int[10];
            realLength = 0;
        }

        public ArrayList(int[] array)
        {
            this.array = array;
            realLength = array.Length;
        }

        // Add element
        public void Add(int val)
        {
            if (array.Length == realLength)
            {
                array = ArrayOneElementIncrease(array);
            }
            array[realLength] = val;
            realLength++;
        }

        // Add element at index
        public void Add(int idx, int val)
        {
            if (array.Length == realLength)
            {
                array = ArrayOneElementIncrease(array);
            }

            for (int i = realLength; i >= idx; i--)
            {
                array[i + 1] = array[i];
            }
            array[idx] = val;
            realLength++;
        }

        // Set element at index
        public void Set(int idx, int val)
        {
            if (idx < realLength - 1)
            {
                array[idx] = val;
            }
            else
            {
                throw new InvalidCastException("Array index out of bounds exception");
            }
        }

        // Get element at index
        public int Get(int idx)
        {
            if (idx < realLength - 1)
            {
                return array[idx];
            }
            else
            {
                throw new InvalidCastException("Array index out of bounds exception");
            }
        }

        // Increase array length by 1
        private int[] ArrayOneElementIncrease(int[] array)
        {
            int[] newArray = new int[array.Length * 3 / 2 + 1];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        // Reduce array length by 1
        private int[] ArrayOneElementReduce(int[] array)
        {
            int[] newArray = new int[2 * (array.Length - 1) / 3];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        // Increase array length by certain value
        private int[] ArrayIncrease(int[] array, int valsLength)
        {
            int[] newArray = new int[array.Length + valsLength * 3 / 2 + 1];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        // Get array length
        public int Size(int[] array)
        {
            return array.Length;
        }

        // Array element contains
        public bool Contains(int val)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (val == array[i])
                {
                    return true;
                }
            }
            return false;
        }

        // Add array of elements
        public void AddAll(int[] vals)
        {
            int[] newArray = ArrayIncrease(array, vals.Length);
            int numberOfElement = 0;
            for (int i = realLength; i < realLength + vals.Length; i++)
            {
                newArray[i] = vals[numberOfElement];
                numberOfElement++;
            }
            array = newArray;
            realLength += vals.Length;
        }


        // Add array of elements at index
        public int[] AddAll(int idx, int[] vals)
        {
            int[] newArray = ArrayIncrease(array, vals.Length);
            int numberOfElement = 0;

            for (int i = idx; i < vals.Length + idx; i++)
            {
                newArray[i + idx + 1] = newArray[i];
            }

            for (int i = idx; i < vals.Length + idx; i++)
            {
                newArray[i] = vals[numberOfElement];
                numberOfElement++;
            }
            array = newArray;
            realLength += vals.Length;
            return array;
        }

        // Get first index of element value
        public int IndexOf(int val)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (val == array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        // Get indexes of element
        public int[] Search(int val)
        {
            int indexCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (val == array[i])
                {
                    indexCount++;
                }
            }

            int[] indexArray = new int[indexCount];
            int indexOfSearch = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (val == array[i])
                {
                    indexArray[indexOfSearch] = i;
                    indexOfSearch++;
                }
            }

            return indexArray;
        }

        // Remove element by value
        public int[] RemoveVal(int val)
        {
            if (array.Length - realLength == Math.Round(0.5 * array.Length) - 1)
            {
                array = ArrayOneElementReduce(array);
            }

            int indexOfElement = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == val)
                {
                    indexOfElement = i;
                    break;
                }
            }

            if (indexOfElement == -1)
            {
                throw new ArgumentException("Val not found");
            }
            else
            {
                array[indexOfElement] = 0;
                for (int i = indexOfElement; i < realLength - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[realLength - 1] = 0;
                realLength--;
                return array;
            }
        }

        // Remove element at index
        public void RemoveAtIndex(int idx)
        {
            if (idx > array.Length)
            {
                throw new ArgumentException("Value not found");
            }
            else
            {
                array[idx] = 0;
                for (int i = idx + 1; i < realLength; i++)
                {
                    array[i - 1] = array[i];
                }
                array[realLength - 1] = 0;
                realLength--;
            }
        }

        // Remove all elements of value
        public void RemoveAll(int val)
        {
            int counter = 0;
            int[] temp = new int[array.Length];
            for (int i = 0; i < realLength; i++)
            {
                if (array[i - counter] != val)
                {
                    temp[i - counter] = array[i];
                }
                else
                {
                    counter++;
                }

                array = temp;
                realLength -= counter;
            }

            int indexOfElement = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == val)
                {
                    array[i] = 0;
                    indexOfElement = i;
                }
            }

            if (indexOfElement == -1)
            {
                throw new ArgumentException("Value not found");
            }
            else
            {
                int countOfElements = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] == 0)
                    {
                        int tempSwap = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tempSwap;
                        countOfElements++;
                    }
                }
                realLength -= countOfElements;
            }
        }

        // Print Array
        public void PrintArr(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        // Get Real Array
        public int[] ToArray()
        {
            int[] newArray = new int[realLength];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
    }
}