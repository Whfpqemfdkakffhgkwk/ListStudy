using HS_LinkedList;

namespace Program
{
    //사용 예제
    class Program
    {
        static void Main()
        {
            HS_List.List<int> list = new HS_List.List<int>();

            //Remove와 RemoveAt의 차이점은 값을 찾아서 지우냐와 index로 지우냐로 차이가 난다.


            list.Add(3);
            list.Add(1);
            list.Add(2);
            list.Remove(4);

            for (int i = 0; i < list.Count; i++)
            {
                //Console.WriteLine(list.items[i]);
            }

            HS_LinkedList.LinkedList<int> linkedList = new HS_LinkedList.LinkedList<int>();

            //머리(앞)부분에 추가
            linkedList.AddHead(1);
            linkedList.AddHead(2);
            Node<int> node = linkedList.AddHead(3);
            linkedList.AddHead(4);

            //꼬리(뒷)부분에 추가
            linkedList.AddTail(5);

            //원하는 Node 지우기 (3)
            linkedList.ReMove(node);
            //머리 부분 지우기(1)
            linkedList.ReMoveHead();
            //꼬리 부분 지우기(4)
            linkedList.ReMoveTail();
            Console.WriteLine(linkedList.First()); //2
            Console.WriteLine(linkedList.Last()); //4
            Console.WriteLine(linkedList.Count); //2개
        }

    }
}



namespace HS_LinkedList
{
    class Node<T>
    {
        public T Data;
        //노드의 앞부분
        public Node<T> Next;
        //노드의 뒷부분
        public Node<T> Prev;
    }

    class LinkedList<T>
    {
        public Node<T> Head = null; //첫번째 머리 배열
        public Node<T> Tail = null; //마지막 꼬리 배열
        public int Count = 0; //얼만큼 들어있는지 크기

        /// <summary>
        /// 머리 부분에 추가하는 기능
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> AddHead(T data)
        {
            //추가하고 싶은 값을 넣은 newRoom이라는 새로운 Node 생성
            Node<T> newRoom = new Node<T>();
            newRoom.Data = data;

            //머리 부분이 없다면
            if (Head == null)
            {
                //머리 부분과 꼬리 부분에 추가하고 싶은 값을 넣는다
                Head = newRoom;
                Tail = newRoom;
            }
            //머리 부분이 있다면
            else
            {
                var cur = Head;
                //머리부분부터 계속 다음껄로 넘어가며 탐색을 돈다
                while (cur != null && cur.Next != null)
                    cur = cur.Next;

                //마지막 부분을 찾았다면 마지막 부분의 다음 Node를 넣고싶은 Node로 설정하고
                cur.Next = newRoom;
                //넣고싶은 Node의 전 Node를 마지막 부분에 연결 시켜준다
                newRoom.Prev = cur;
                //새로 들어온 Node는 꼬리이기 때문에 Next는 ㅜull로 만들어준다
                newRoom.Next = null;
                //새로 들어온 방을 마지막 방으로 지정한다
                Tail = newRoom;
            }
            Count++;
            return newRoom;
        }

        /// <summary>
        /// 꼬리 부분에 추가하는 기능
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> AddTail(T data)
        {
            //위와 동일.
            Node<T> newRoom = new Node<T>();
            newRoom.Data = data;

            //꼬리 부분이 없다면
            if (Tail == null)
            {
                //머리 부분과 꼬리 부분에 추가하고 싶은 값을 넣는다
                Head = newRoom;
                Tail = newRoom;
            }
            //꼬리 부분이 있다면
            else
            {
                //꼬리 부분의 다음 Node를 넣고싶은 값의 Node랑 연결 시켜주고
                Tail.Next = newRoom;
                //그 새로운 Node의 전 Node는 꼬리랑 연결 시켜준다
                newRoom.Prev = Tail;
                //꼬리에는 넣고 싶은 값의 Node를 넣어준다
                Tail = newRoom;
                //넣고 싶은 값의 Node는 꼬리이기 때문에 Next는 비워준다
                newRoom.Next = null;
            }
            Count++;
            return newRoom;
        }

        /// <summary>
        /// 원하는 Node를 지우는 기능
        /// </summary>
        /// <param name="room"></param>
        public void ReMove(Node<T> room)
        {
            //지울려는 방이 머리라면
            if (Head == room)
            {
                //머리는 머리의 다음 Node로 설정한다
                Head = Head.Next;
            }
            //만약 지울려는 방이 꼬리라면
            else if (room == Tail)
            {
                //지울려는 방의 전 Node를 꼬리로 설정한다
                room.Prev = Tail;
            }
            else
            {
                //지울려는 방의 전의 다음은 지울려는 방의 다음이다
                //지울려는 방 뒤에 있는 방. 그 방의 앞부분을 지울려는 방의 앞부분 방과 연결 시켜줌으로써
                //지울려는 방과 분리 시켜주는 것이다
                room.Prev.Next = room.Next;

                //위의 반대
                room.Next.Prev = room.Prev;
                
            }

            Count--;
        }

        /// <summary>
        /// 머리 부분을 지우는 기능
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
        public void ReMoveHead()
        {
            if (Head == null)
                throw new ApplicationException("Null");

            //요소가 하나만 있을 시
            else if(Head == Tail)
            {
                //머리와 꼬리 부분을 비워준다
                Head = null;
                Tail = null;
            }
            //요소가 여러개 있을 시
            else
            {
                //머리 부분은 머리 부분의 다음 Node로 설정한다
                Head = Head.Next;
            }

            Count--;
        }

        /// <summary>
        /// 꼬리 부분을 지우는 기능
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
        public void ReMoveTail()
        {
            if (Tail == null)
                throw new ApplicationException("Null");

            //요소가 하나만 있을 시
            else if (Tail == Head)
            {
                //꼬리와 머리 부분을 비워준다
                Tail = null;
                Head = null;
            }
            //요소가 여러개 있을 시
            else
            {
                //꼬리 부분은 꼬리 부분 전 Node로 설정한다
                Tail = Tail.Prev;
            }

            Count--;
        }

        /// <summary>
        /// 머리 부분의 Data를 반환해주는 기능
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T First()
        {
            if (Head == null)
                throw new ApplicationException("Null");

            return Head.Data;
        }

        /// <summary>
        /// 꼬리 부분의 Data를 반환해주는 기능
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T Last()
        {
            if (Tail == null)
                throw new ApplicationException("Null");

            return Tail.Data;
        }
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
                if (value != items.Length)
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
        /// 인덱스를 찾아서 지워주는 함수
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index > size - 1)
            {
                string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                //유니티 전용 에러 문구
                //Debug.LogError($"배열의 크기를 초과한 값으로 정상적으로 {MethodName} 함수를 실행할 수 없습니다");

                Console.WriteLine($"배열의 크기를 초과한 값으로 정상적으로 {MethodName} 함수를 실행할 수 없습니다");
                return;
            }

            size--;

            if (index < size)
            {
                Array.Copy(items, index + 1, items, index, size - index);
            }

            //default(T) = 리스트 자료형의 기본값
            items[size] = default(T);
        }

        /// <summary>
        /// 값을 찾아서 지워주는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            //들어온 값 item의 인덱스를 찾는다
            int index = IndexOf(item);

            //인덱스가 0보다 크다면 (배열이 0부터 시작하니까)
            if (index >= 0)
            {
                //그 인덱스의 값을 지운다 
                RemoveAt(index);

                return true;
            }

            return false;
        }

        /// <summary>
        /// 인덱스 찾아주는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            //찾는 값의 인덱스 반환
            //!주의! 찾는 값이 없다면 -1을 반환한다
            return Array.IndexOf(items, item, 0, size);
        }

        /// <summary>
        /// 리스트 안에 모든 값 삭제
        /// </summary>
        public void Clear()
        {
            //비어있지 않다면
            if (size > 0)
            {
                //비워주기 (items를 0번째부터 size 만큼)
                Array.Clear(items, 0, size);
                //size 크기 0으로 초기화
                size = 0;
            }
        }

        /// <summary>
        /// 용량이 꽉차면 2배로 늘려주는 함수
        /// </summary>
        private void EnsureCapacity()
        {
            //items의 크기가 0이면 4로 만들어주고 아니면 4의 N제곱씩 크기를 키워준다
            int newCapacity = items.Length == 0 ? 4 : items.Length * 2;

            Capcity = newCapacity;
        }
    }
}