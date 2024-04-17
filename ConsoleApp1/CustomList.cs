using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CustomList<T>
    {
        private T[] items;
        private int capacity;
        private int count;

        public CustomList()
        {
            capacity = 4;
            items = new T[capacity];
            count = 0;
        }

        public void Add(T item)
        {
            EnsureCapacity();
            items[count++] = item;
        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                {
                    return items[i];
                }
            }
            return default(T);
        }

        public CustomList<T> FindAll(Predicate<T> match)
        {
            CustomList<T> resultList = new CustomList<T>();
            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                {
                    resultList.Add(items[i]);
                }
            }
            return resultList;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    items[count - 1] = default(T);
                    count--;
                    return true;
                }
            }
            return false;
        }

        public int RemoveAll(Predicate<T> match)
        {
            int removedCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    items[count - 1] = default(T);
                    count--;
                    removedCount++;
                    i--;
                }
            }
            return removedCount;
        }

        private void EnsureCapacity()
        {
            if (count == capacity)
            {
                capacity *= 2;
                ResizeArray(capacity);
            }
        }

        private void ResizeArray(int newSize)
        {
            capacity = newSize;
            T[] newArray = new T[newSize];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;
        }

        public int Count
        {
            get { return count; }
        }
    }

}
