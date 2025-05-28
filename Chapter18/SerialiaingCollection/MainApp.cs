using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Serialization
{
    class NameCard
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            var fileName = "a.json";

            using (Stream ws = new FileStream(fileName, FileMode.Create))
            {
                var list = new List<NameCard>();
                list.Add(new NameCard() { Name = "이지훈", Phone = "010-7777-0406", Age = 26 });
                list.Add(new NameCard() { Name = "이지민", Phone = "010-7777-0602", Age = 26 });
                list.Add(new NameCard() { Name = "이지우", Phone = "010-7777-0407", Age = 22 });
                list.Add(new NameCard() { Name = "이지안", Phone = "010-7777-1218", Age = 8 });

                string jsonString = JsonSerializer.Serialize<List<NameCard>>(list);
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
                ws.Write(jsonBytes, 0, jsonBytes.Length);
            }

            using (Stream rs = new FileStream(fileName, FileMode.Open))
            {
                byte[] jsonBytes = new byte[rs.Length];
                rs.Read(jsonBytes, 0, jsonBytes.Length);
                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);

                var list2 = JsonSerializer.Deserialize<List<NameCard>>(jsonString);

                foreach (NameCard nc in list2)
                {
                    Console.WriteLine(
                        $"Name: {nc.Name}, Phone: {nc.Phone}, Age: {nc.Age}");
                }
            }
        }
    }
}