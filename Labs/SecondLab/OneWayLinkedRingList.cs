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
        public Node<T>? Head { get; private set; }
        public int Length { get; private set; }

        public OneWayLinkedRingList() 
        {
            Length = 0;
            Head = null;  
        }

        public void Append(T data) 
        {

            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
                newNode.NextNode = Head;
            }
            else
            {
                Node<T> temp = new Node<T>(Head.Data);
                temp = Head;
                while (temp!.NextNode != Head) 
                {
                    temp = temp.NextNode!;
                }
                temp.NextNode = newNode;
                newNode.NextNode = Head;
            }

            ++Length;
        }

        private void CheckIndex(int index) 
        {
            if (index >= Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        } 

        public void Insert(T data, int index) 
        {
            CheckIndex(index);

            Node<T> newNode = new Node<T>(data);
            Node<T> temp = Head!;

            if (index == 0)
            {

                while (temp.NextNode != Head)
                {
                    temp = temp.NextNode!;
                }
                newNode.NextNode = Head;
                Head = newNode;
                temp.NextNode = Head;
                
            }
            else
            {
                temp = Head;
                for (int i = 1; i < index; i++) 
                {
                    temp = temp.NextNode;
                }
                newNode.NextNode = temp.NextNode;
                temp.NextNode = newNode;
            }

            ++Length;

        }

        public void Delete(int index) 
        {
            CheckIndex(index);

            Node<T> nodeToDelete = Head!;
            Node<T> temp = Head!;

            if (index == 0)
            {
                if (Head!.NextNode == Head)
                {
                    Head = null;
                }
                else
                {
                    while (temp.NextNode != Head) 
                    {
                        temp = temp.NextNode!;
                    }
                    Head = Head.NextNode;
                    temp.NextNode = Head;
                    nodeToDelete = null;
                }
            }
            else
            {
                temp = Head!;
                for (int i = 1; i < index; i++) 
                {               
                    temp = temp!.NextNode!;
                }
                nodeToDelete = temp.NextNode!;
                temp.NextNode = temp.NextNode!.NextNode;
                nodeToDelete = null;
            }
            --Length;
        }


        public void DeleteAll(T element) 
        {
            var numberOfSameElements = 0;
            var startLength = Length;
            var index = 0;
            Node<T> tempNode = Head!;
            while (index != startLength)
            {
                if (Comparer<T>.Default.Compare(tempNode!.Data, element) == 0) 
                {
                    Delete(index-numberOfSameElements);
                    numberOfSameElements++;
                    
                }
                tempNode = tempNode.NextNode!;
                ++index;
            }
        }

        public T Get(int index) 
        {
            CheckIndex(index);

            var tempIndex = 0;
            Node<T> tempNode = Head!;
            T result = Head!.Data;
            while (tempIndex != Length)
            {
                if (tempIndex == index) 
                {
                    result = tempNode!.Data;
                    break;
                }
                tempNode = tempNode!.NextNode!;
                ++tempIndex;
            }
            return result;
        }

        public OneWayLinkedRingList<T> Clone() 
        {
            OneWayLinkedRingList<T> result = new OneWayLinkedRingList<T>();

            var index = 0;
            Node<T> tempNode = Head!;
            while (index != Length)
            {
                result.Append(tempNode.Data);
                tempNode = tempNode.NextNode!;
                ++index;
            }

            return result;
        }

        public void Reverse() 
        {
            if (Head != null) 
            {
                Node<T> prevNode = Head;
                Node<T> tempNode = Head;
                Node<T> curNode = Head!.NextNode!;

                prevNode.NextNode = prevNode;

                while (curNode != Head)
                {
                    tempNode = curNode!.NextNode!;
                    curNode.NextNode = prevNode;
                    Head.NextNode = curNode;
                    prevNode = curNode;
                    curNode = tempNode;
                }
                Head = prevNode;
                
            }
        }

        public override string ToString()
        {
            var index = 0;
            Node<T> tempNode = Head!;
            var stringBuilder = new StringBuilder();
            while (index != Length)
            {
                stringBuilder.Append($"{tempNode.Data} ");
                tempNode = tempNode.NextNode!;
                ++index;
            }
            return stringBuilder.ToString();
        }

        public bool Equals(OneWayLinkedRingList<T>? other)
        {
            if (other == null || other.Length!=this.Length) 
            {
                return false;
            }
            var index = 0;
            Node<T> thisNode = Head!;
            Node<T> otherNode = other.Head!;
            while (index != Length)
            {
                if (Comparer<T>.Default.Compare(otherNode.Data, thisNode.Data) != 0)
                {
                    return false;
                }
                thisNode = thisNode.NextNode!;
                otherNode = otherNode.NextNode!;
                ++index;
            }
            return true;
        }
    }
}
