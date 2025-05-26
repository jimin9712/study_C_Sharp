using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    // 제네릭 대리자 정의: 두 개의 T 형식을 받아 int형(비교 결과)를 반환
    delegate int Compare<T>(T a, T b);

    class MainApp
    {
        // 오름차순 비교 메서드 (T는 IComparable<T>을 구현해야 함)
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);  // 작으면 -1, 같으면 0, 크면 1 반환
        }

        // 내림차순 비교 메서드
        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1;  // 부호를 반대로 해서 내림차순 비교
        }

        // 제네릭 버블 정렬 메서드
        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            int i = 0;
            int j = 0;
            T temp;

            // 버블 정렬 알고리즘
            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    // 대리자를 이용해 비교하고 자리 바뀨기
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // 정수 배열 정렬 (오름차순)
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting ascending...");
            BubbleSort<int>(array, new Compare<int>(AscendCompare));

            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");

            // 문자열 배열 정렬 (내림차순)
            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };

            Console.WriteLine("\nSorting descending...");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
                Console.Write($"{array2[i]} ");

            Console.WriteLine(); 
        }
    }
}
