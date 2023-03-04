namespace SecondLab
{
    public class Node<T>
    {
        public Node<T>? NextNode { get; set; }
        public T Data { get; set; }

        public Node(T data) 
        {
            Data = data;
            NextNode = null; 
        }

    }
}