using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMember
{
    class FriendList
    {
        private List<string> list = new List<string>(); // 내부적으로 string 리스트 사용

        public void Add(string name) => list.Add(name);

        public void Remove(string name) => list.Remove(name);

        // 리스트의 모든 이름을 출력하는 메서드
        public void PrintAll()
        {
            foreach (var s in list)
                Console.WriteLine(s); 
        }

        // 생성자: FriendList 객체가 생성될 때 호출됨
        public FriendList() => Console.WriteLine("FriendList()");

        // 소멸자: FriendList 객체가 소멸될 때 호출됨
        ~FriendList() => Console.WriteLine("~FriendList()");

        // 리스트의 Capacity(내부 버퍼 크기) 속성 (읽기/쓰기)
        public int Capacity
        {
            get => list.Capacity;          
            set => list.Capacity = value;  
        }

        // 인덱서를 이용해 리스트의 요소를 읽거나 쓸 수 있게 함
        public string this[int index]
        {
            get => list[index];           
            set => list[index] = value;   
        }
    }

    internal class MainApp
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList(); // FriendList 객체 생성 (생성자 호출됨)
            obj.Add("Eeny");    
            obj.Add("Meeny");
            obj.Add("Miny");
            obj.Remove("Eeny"); 
            obj.PrintAll();

            Console.WriteLine($"{obj.Capacity}"); // 현재 리스트의 Capacity 출력
            obj.Capacity = 10;                   // Capacity 값을 10으로 변경
            Console.WriteLine($"{obj.Capacity}"); // 변경된 Capacity 출력

            Console.WriteLine($"{obj[0]}"); // 인덱서 사용: 0번 인덱스의 값 출력
            obj[0] = "Moe";                 // 0번 인덱스의 값을 "Moe"로 변경
            obj.PrintAll();                 // 변경된 이름들 출력
        }
    }
}
