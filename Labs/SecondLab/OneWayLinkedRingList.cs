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

        public void PrintList() 
        {
            var index = 0;
            Node<T> tempNode = Head;

            while (index != Length) 
            {
                Console.WriteLine(tempNode.Data);
                tempNode = tempNode.NextNode;
            }
        
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



        public void Insert(T? data, int index) 
        {
            if (index >= Length || index < 0) 
            {
                throw new ArgumentOutOfRangeException();
            }
            

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
