using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecondLab
{
    public class OneWayLinkedRingList<T> : IEquatable<OneWayLinkedRingList<T>>
    {
        public List<T> elements;
        public int Length { get=>elements.Count; }

        public OneWayLinkedRingList() 
        {
            elements = new List<T>();
        }

        public void Append(T data) 
        {
            elements.Add(data);
        }


        public void Insert(T data, int index) 
        {
            elements.Insert(index,data);
        }

        public void Delete(int index) 
        {
            elements.RemoveAt(index);
        }


        public void DeleteAll(T element) 
        {
            elements.RemoveAll(x=>Comparer<T>.Default.Compare(x, element) == 0);
        }

        public T Get(int index) 
        {
            return elements[index];
        }

        public OneWayLinkedRingList<T> Clone() 
        {
            var result = new OneWayLinkedRingList<T>();
            result.elements.AddRange(this.elements);
            return result;
        }

        public void Reverse() 
        {
            elements.Reverse();
        }

        public int FindFirst(T element) 
        {
            return elements.IndexOf(element);

        }
        public int FindLast(T element)
        {
            return elements.LastIndexOf(element);
        }

        public void Clear() 
        {
            elements.Clear();
        }

        public void Extend(OneWayLinkedRingList<T> list) 
        {
            elements.AddRange(list.elements);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var element in elements) 
            {
                result.Append($"{element} ");            
            }
            return result.ToString();
        }

        public bool Equals(OneWayLinkedRingList<T>? other)
        {
            return elements.SequenceEqual(other.elements);
        }


    }
}
