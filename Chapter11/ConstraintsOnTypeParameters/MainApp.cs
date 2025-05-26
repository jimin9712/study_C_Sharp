using System;

namespace ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }

    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyyArray<T>(T[] Target) where T : U
        {
            Target.CopyTo(Array, 0);
        }
    }

    class MainApp
    {
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);

            BaseArray<Base> c = new BaseArray<Base>(3);
            // Base 형식의 객체 3개를 저장할 수 있는 배열을 만든다.
            // 이 배열에는 Base 또는 Base를 상속한 모든 객체를 저장할 수 있음.

            c.Array[0] = new Base();
            // Base 객체 저장

            c.Array[1] = new Derived();
            // Derived는 Base를 상속했으므로, Base 형식 배열에 저장 가능

            c.Array[2] = CreateInstance<Base>();
            // Base 객체를 생성하는 제네릭 메서드로 객체를 만들어 저장

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            // Derived 형식의 객체 3개를 저장할 수 있는 배열을 만든다.
            // 이 배열에는 반드시 Derived 객체만 저장 가능 (Base 객체는 안 됨)

            d.Array[0] = new Derived();
            // Derived 객체 저장 (정상)

            d.Array[1] = CreateInstance<Derived>();
            // Derived 객체를 생성하는 제네릭 메서드로 객체를 만들어 저장

            d.Array[2] = CreateInstance<Derived>();
            // Derived 객체를 생성하는 제네릭 메서드로 객체를 만들어 저장

            // d.Array[0] = new Base(); // 오류! Base 형식은 Derived에 대입 불가


            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyyArray<Derived>(d.Array);
        }
    }
}