using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    class MyEumerator
    {
        int[] numbers = { 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break; // yield break는 GetEnumerator() 메소드를 종료시킴
           yield return numbers[3]; // 따라서 이 코드는 실행되지 않음
        }
    }
    internal class MainApp
    {
        static void Main(string[] args)
        {
            var obj = new MyEumerator();
            foreach(int i in obj)
                Console.WriteLine(i);
        }
    }
}
