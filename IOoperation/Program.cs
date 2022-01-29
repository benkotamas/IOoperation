using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOoperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @".\";
            string fileName = "person.txt";


            string filePath = Path.Combine(path, fileName);


            List<Person> data;
            if (File.Exists(filePath))
            {
                data = new List<Person>();

                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] lineData = line.Split(';');
                        data.Add(new Person(lineData[0], int.Parse(lineData[1])));
                    }
                }

                foreach (Person person in data)
                {
                    Console.WriteLine(person.ToString());
                }
            }

            else
            {
                data = CreateData();

                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (Person person in data)
                    {
                        streamWriter.WriteLine(String.Format("{0};{1}", person.Name, person.Age));
                    }
                }
                Console.WriteLine("Test data created!");
            }
            Console.Read();

        }

        static List<Person> CreateData()
        {
            List<Person> result = new List<Person>();

            result.Add(new Person("James", 17));
            result.Add(new Person("Rober", 42));
            result.Add(new Person("Scarlet", 31));
            result.Add(new Person("Kathy", 8));

            return result;
        }
    }
}
