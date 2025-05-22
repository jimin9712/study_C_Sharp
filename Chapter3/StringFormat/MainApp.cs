using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace StringFormat
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 생산성
            {
                string format = "이름 : {0}, 이메일주소 : {1}";
                string[] arr = new string[3];

                arr[0] = string.Format(format, "박상현", "seanlab@gmail.com");
                arr[1] = string.Format(format, "박상준", "junpark@jmail.com");
                arr[2] = string.Format(format, "박상범", "beompark@bmail.com");

                foreach (string s in arr)
                    WriteLine(s);
            }

            // 숫자에 콤마 표시하기
            {
                string s = string.Format("{0:N0}", 12345); // 알파벳 N과 숫자 0
                WriteLine(s); // 12,345
            }

            // 날짜와 시간 표시하기
            {
                string s = string.Format("{0:yyyy-MM-dd hh:mm:ss}", System.DateTime.Now);
                WriteLine(s);

                string[] cultureNames = new string[] { "en-US", "ko-KR", "zh-CN", "ja-JP" };
                foreach (string cultureName in cultureNames)
                {
                    var ci = new System.Globalization.CultureInfo(cultureName);
                    s = string.Format(ci, "{0:D} {0:T}", System.DateTime.Now);
                    WriteLine(s);
                }
            }

            // 정해진 자리수로 숫자 표시하기
            {
                int number = 123;
                string s1 = string.Format("{0:D5}", number);   // 5자리, 빈자리는 0으로
                string s2 = string.Format("{0,7}", number);    // 7칸 오른쪽 정렬
                string s3 = string.Format("{0,-7}", number);   // 7칸 왼쪽 정렬
                WriteLine(s1); // 00123
                WriteLine(s2); // '    123'
                WriteLine(s3); // '123    '
            }

            // 정해진 간격으로 복수 데이터 표시하기
            {
                WriteLine("{0,-10} | {1,5}", "이름", "나이");
                WriteLine("{0,-10} | {1,5}", "박상현", 38);
                WriteLine("{0,-10} | {1,5}", "박상준", 33);
                WriteLine("{0,-10} | {1,5}", "박상범", 20);
            }

            // 전화번호 표시하기
            {
                int num1 = 010;
                int num2 = 1234;
                int num3 = 5678;
                string s = string.Format("{0:D3}-{1:D4}-{2:D4}", num1, num2, num3);
                WriteLine(s); // 010-1234-5678
            }

            // 진수를 변환해서 표시하기
            {
                int value = 255;
                string bin = string.Format("{0:b}", Convert.ToString(value, 2)); // 2진수
                string oct = string.Format("{0:o}", Convert.ToString(value, 8)); // 8진수
                string hex = string.Format("{0:X}", value); // 16진수
                WriteLine("10진수: {0}, 2진수: {1}, 8진수: {2}, 16진수: {3}", value, bin, oct, hex);
            }
        }
    }
}
