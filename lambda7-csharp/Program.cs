using lambda7_csharp.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda7_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\in.txt";
            List<Employee> employees = new List<Employee>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] content = sr.ReadLine().Split(',');
                        string pname = content[0];
                        string pemail = content[1];
                        double psalary = double.Parse(content[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(pname, pemail, psalary));
                    }
                    Console.Write("Enter Salary : ");
                    double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.WriteLine("Email of people whose salary is more than " + salary.ToString("F2", CultureInfo.InvariantCulture));
                    var emails = employees.Where(e => e.Salary > salary).Select(e => e.Email).OrderBy(e => e);
                    foreach (var item in emails)
                    {
                        Console.WriteLine(item);
                    }
                    var employeesSum = employees.Where(e => e.Name.StartsWith("M")).Select(e => e.Salary).Sum();
                    Console.WriteLine("Sum of salary of people whose name starts with 'M':" + employeesSum.ToString("F2", CultureInfo.InvariantCulture));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
