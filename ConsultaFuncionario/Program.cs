using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using ConsultaFuncionario.Entities;

namespace ConsultaFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;

            List<Employee> list = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine(), CI);

            Console.WriteLine($"Email of people whose salary is more than {salary.ToString("F2", CI)}:");

            using StreamReader sr = File.OpenText(path);

            while (!sr.EndOfStream)
            {
                string[] lines = sr.ReadLine().Split(",");
                string name = lines[0];
                string email = lines[1];
                salary = double.Parse(lines[2], CI);
                list.Add(new Employee(name, email, salary));
            }

            var queryResult = list.Where(e => e.Salary > 2000.00).Select(e => e.Email);
            foreach (var item in queryResult)
            {
                Console.WriteLine(item);
            }

            var sum = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sum.ToString("F2", CI)}");
        }
    }
}
