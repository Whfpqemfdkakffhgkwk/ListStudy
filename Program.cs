namespace HS_LinkedList
{
    //사용 예제
    class Class
    {
        static void Main()
        {
            HS_List.List<int> list = new HS_List.List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveAt(2);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.items[i]);
            }



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
        public T[] items;
        private int size;

        public int Count
        {
            get => size;
        }

        //용량
        public int Capcity
        {
            get => items.Length;
            set
            {
                if(value != items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        
                        //items = 복사할 대상
                        //Index (0) = 복사할 배열의 시작 인덱스
                        //newItems = 복사될 대상
                        //Index (0) = 복사될 배열의 시작 인덱스
                        //size = 복사할 길이
                        Array.Copy(items, 0, newItems, 0, size);

                        items = newItems;
                    }
                    else
                    {
                        items = new T[0];
                    }
                }
            }
        }

        //null 값이 할당되지 않도록 초기화
        public List()
        {
            items = new T[0];
            size = 0;
        }

        /// <summary>
        /// 값 추가
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            //사이즈가 배열의 크기랑 같다면
            if (size == items.Length)
                EnsureCapacity();

            items[size++] = item;
        }

        /// <summary>
        /// 원하는 요소의 값을 삭제
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if(index > size - 1)
            {
                string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                
                //유니티 전용 에러 문구
                //Debug.LogError($"배열의 크기를 초과한 값으로 정상적으로 {MethodName} 함수를 실행할 수 없습니다");
                
                Console.WriteLine($"배열의 크기를 초과한 값으로 정상적으로 {MethodName} 함수를 실행할 수 없습니다");
                return;
            }

            size--;
            
            if(index < size)
            {
                Array.Copy(items, index + 1, items, index, size - index);
            }

            //default(T) = 리스트 자료형의 기본값
            items[size] = default(T);
        }

        /// <summary>
        /// 용량이 꽉차면 2배로 늘려주는 함수
        /// </summary>
        private void EnsureCapacity()
        {
            int newCapacity = items.Length == 0 ? 4 : items.Length * 2;
            Capcity = newCapacity;
        }
    }
}