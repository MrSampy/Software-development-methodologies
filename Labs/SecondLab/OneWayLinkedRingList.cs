using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecondLab
{
    public class OneWayLinkedRingList<T> : IEquatable<OneWayLinkedRingList<T>>
    {
        public int Length { get; private set; }

        public OneWayLinkedRingList() 
        {

        }

        public void Append(T data) 
        {

        }


        public void Insert(T data, int index) 
        {
            
        }

        public void Delete(int index) 
        {
        }


        public void DeleteAll(T element) 
        {
           
        }

        public T Get(int index) 
        {
            return default(T);
        }

        public OneWayLinkedRingList<T> Clone() 
        {
            return new OneWayLinkedRingList<T>();
        }

        public void Reverse() 
        {
           
        }

        public int FindFirst(T element) 
        {
            return -1;

        }
        public int FindLast(T element)
        {
            return -1;

        }

        public void Clear() 
        {
           
        }

        public void Extend(OneWayLinkedRingList<T> list) 
        {
            

        }

        public override string ToString()
        {
            return string.Empty;
        }

        public bool Equals(OneWayLinkedRingList<T>? other)
        {
            return true;
        }


    }
}
