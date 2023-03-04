using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab
{
    public class OneWayLinkedRingList<T>
    {
        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }

        public int Length { get; private set; }

        public OneWayLinkedRingList() 
        {
            Length = 0;
            Head = Tail = null;  
        }

        public void Append(T? data) 
        {
            var tempNode = new Node<T>(data);

            if (Head == null)
            {
                Head = Tail = tempNode;
            }

            tempNode.NextNode = Head;
            Tail!.NextNode = tempNode;
            Tail = tempNode;
            ++Length;
        }

        private void CheckIndex(int index) 
        {
            if (index >= Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

        } 

        public void Insert(T? data, int index) 
        {
            CheckIndex(index);

            if (index == Length - 1)
            {
                Append(data);
            }
            else if (index == 0) 
            {

                var newNode = new Node<T>(data);
                Tail.NextNode = newNode;
                newNode.NextNode = Head;
                Head = Tail.NextNode;
                ++Length;
            }
            else
            {
                var tempIndex = 0;
                var tempNode = Tail;
                var newNode = new Node<T>(data);
                while (tempIndex != Length)
                {
                    if (tempIndex == index)
                    {
                        newNode.NextNode = tempNode.NextNode;
                        tempNode.NextNode = newNode;
                        Tail!.NextNode = Head;
                        break;
                    }
                    tempNode = tempNode.NextNode;
                    ++tempIndex;
                }
                ++Length;

            }
        }

        public void Delete(int index) 
        {
            CheckIndex(index);

            if (index == 0)
            {
                Head = Head!.NextNode;
                Tail!.NextNode = Head;
            }
            else
            {
                var tempIndex = 0;
                Node<T> firstNode = Tail;
                Node<T> secondNode = Head;

                while (tempIndex != Length)
                {
                    if (tempIndex == index)
                    {
                        firstNode.NextNode = secondNode.NextNode;
                        break;
                    }

                    firstNode = firstNode.NextNode;
                    secondNode = secondNode.NextNode;
                    ++tempIndex;
                }
            }
            --Length;
        }

        public override string ToString()
        {
            var index = 0;
            Node<T> tempNode = Head;
            var stringBuilder = new StringBuilder();
            while (index != Length)
            {
                stringBuilder.Append($"{tempNode.Data} ");
                tempNode = tempNode.NextNode;
                ++index;
            }
            return stringBuilder.ToString();
        }

    }
}
