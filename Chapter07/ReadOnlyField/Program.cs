using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadonlyField
{
    class Configuration
    {
        readonly int min;
        readonly int max;

        public Configuration(int v1, int v2)
        {
            min = v1;
            min = v2; // 읽기 전용 필드는 생성자 안에서만 초기화 할 수 있음
        }

        public void ChangeMax(int newMax)
        {
            max = newMax;
            // 생성자가 아닌 다른 곳에서 값을 수정하여 하면 컴파일 에러가 발생
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Configuration c = new Configuration(100, 10);
        }
    }
}