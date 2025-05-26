using System;

namespace ConstraintsOnTypeParameters
{
    // 인터페이스 선언
    interface IPrintable
    {
        void Print();
    }

    // Base 클래스가 인터페이스 구현
    class Base : IPrintable
    {
        public Base() { Console.WriteLine("Base 객체 생성"); }
        public virtual void Print() { Console.WriteLine("나는 Base입니다."); }
    }

    // Derived 클래스가 Base를 상속 (자동으로 IPrintable 구현)
    class Derived : Base
    {
        public Derived() { Console.WriteLine("Derived 객체 생성"); }
        public override void Print() { Console.WriteLine("나는 Derived입니다."); }
    }

    // StructArray: 값 형식만 허용
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
            Console.WriteLine($"StructArray<{typeof(T).Name}> 생성, 크기: {size}");
        }
    }

    // RefArray: 참조 형식만 허용
    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
            Console.WriteLine($"RefArray<{typeof(T).Name}> 생성, 크기: {size}");
        }
    }

    // IPrintable을 구현하는 클래스만 타입으로 허용하는 제네릭 클래스
    class PrintableArray<T> where T : IPrintable
    {
        public T[] Array { get; set; }
        public PrintableArray(int size)
        {
            Array = new T[size];
            Console.WriteLine($"PrintableArray<{typeof(T).Name}> 생성, 크기: {size}");
        }

        // 전체 출력
        public void PrintAll()
        {
            Console.WriteLine($"--- PrintableArray<{typeof(T).Name}> 전체 출력 ---");
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] != null)
                {
                    Console.Write($"{i}: ");
                    Array[i].Print();
                }
                else
                {
                    Console.WriteLine($"{i}: null");
                }
            }
        }
    }

    // Base만 상속하는 클래스로 제한하는 배열 클래스
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
            Console.WriteLine($"BaseArray<{typeof(U).Name}> 생성, 크기: {size}");
        }

        public void CopyyArray<T>(T[] Target) where T : U
        {
            Console.WriteLine($"CopyyArray<{typeof(T).Name}> 호출 -> {typeof(T).Name}[] -> {typeof(U).Name}[]");
            Target.CopyTo(Array, 0);
        }
    }

    class MainApp
    {
        public static T CreateInstance<T>() where T : new()
        {
            Console.WriteLine($"CreateInstance<{typeof(T).Name}> 호출");
            return new T();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==== StructArray<int> ====");
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;
            Console.WriteLine("a.Array: " + string.Join(", ", a.Array));

            Console.WriteLine("\n==== RefArray<StructArray<double>> ====");
            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);

            Console.WriteLine("\n==== PrintableArray<Base> ====");
            PrintableArray<Base> pa = new PrintableArray<Base>(3);
            pa.Array[0] = new Base();
            pa.Array[1] = new Derived();
            pa.Array[2] = CreateInstance<Base>();
            pa.PrintAll();

            Console.WriteLine("\n==== PrintableArray<Derived> ====");
            PrintableArray<Derived> pd = new PrintableArray<Derived>(3);
            pd.Array[0] = new Derived();
            pd.Array[1] = CreateInstance<Derived>();
            pd.Array[2] = CreateInstance<Derived>();
            pd.PrintAll();

            Console.WriteLine("\n==== BaseArray<Base> ====");
            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();

            Console.WriteLine("\n==== BaseArray<Derived> ====");
            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived();
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            Console.WriteLine("\n==== CopyyArray Test ====");
            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyyArray<Derived>(d.Array);
        }
    }
}
