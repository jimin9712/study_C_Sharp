using System;
using System.IO;
using System.Text.Json;


namespace Serialiazation
{
    class NameCard
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age {  get; set; }
    }
    internal class MainApp
    {
        static void Main(string[] args)
        {
            var fileName = "a.json";
            using (Stream ws = new FileStream(fileName, FileMode.Create))
            {
                NameCard nc = new NameCard()
                {
                    Name = "이지민",
                    Phone = "010-5392-9712",
                    Age = 26
                };

                string jsonString = JsonSerializer.Serialize<NameCard>(nc);
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
                ws.Write(jsonBytes, 0, jsonBytes.Length);
            }

            using (Stream rs = new FileStream(fileName, FileMode.Open))
            {
                byte[] jsonBytes = new byte[rs.Length];
                rs.Read(jsonBytes, 0, jsonBytes.Length);
                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);

                NameCard nc2 = JsonSerializer.Deserialize<NameCard>(jsonString);

                Console.WriteLine($"Name : {nc2.Name}");
                Console.WriteLine($"Phone : {nc2.Phone}");
                Console.WriteLine($"만 나이 : {nc2.Age - 2} 세");
            }
        }
    }
}
