namespace HS_LinkedList
{
    //사용 예제
    class Class
    {
        static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(1);
            linkedList.Add(2);
            Node<int> node = linkedList.Add(3);
            linkedList.ReMove(node);
        }
    }
}

class Node<T>
{
    public T Data;
    public Node<T> Next;
    public Node<T> Prev;
}

class LinkedList<T>
{
    public Node<T> Head = null; //첫번째 머리 배열
    public Node<T> Tail = null; //마지막 꼬리 배열
    public int Count = 0;
    public Node<T> Add(T data)
    {
        Node<T> newRoom = new Node<T>();
        newRoom.Data = data;

        //아직 첫 방이 없었다면 방금 추가한 방이 첫 방으로 지정해준다.
        if (Head == null)
        {
            Head = newRoom;
        }

        //마지막 방이 비어있지 않는다면
        //마지막 방과 새로 들어온 방을 서로 연결시켜준다
        if (Tail != null)
        {
            Tail.Next = newRoom;
            newRoom.Prev = Tail;
        }

        //새로 들어온 방을 마지막 방으로 지정한다
        Tail = newRoom;
        Count++;
        return newRoom;
    }

    public void ReMove(Node<T> room)
    {
        //지울려는 방이 첫번째 방이라면 
        //2번째 방을 1번째 방으로 변경한다
        if (Head == room)
        {
            Head = Head.Next;
        }

        //지울려는 방이 마지막 방이라면
        //마지막 전 방을 마지막 방으로 변경한다 
        if (Tail == room)
        {
            Tail = Tail.Prev;
        }

        //지울려는 방의 앞 방과 뒷 방을 연결시켜준다
        if (room.Prev != null)
            room.Prev.Next = room.Next;

        //지울려는 방의 뒷 방과 앞 방을 연결시켜준다
        if (room.Next != null)
            room.Next.Prev = room.Prev;

        Count--;
    }
}

namespace HS_List
{
    class List<T>
    {
        private T[] items;
        private int size;

        public int Count
        {
            get => size;
        }

        //용량
        public int Capcity
    }
}