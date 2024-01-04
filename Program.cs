using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static List<string> GetEmployees()
    {
      List<string> employees = new List<string>();
      // Collect user values until the value is an empty string
      while (true)
      {
        Console.WriteLine("Please enter a name: (leave empty to exit): ");
        // Get a name from the console and assign it to a variable
        string input = Console.ReadLine() ?? "";
        // Break if the user hits ENTER without typing a name
        if (input == "")
        {
          break;
        }
        // Create a new Employee instance
        Employee currentEmployee = new Employee(input, "guido");
        employees.Add(currentEmployee.GetFullName());
      }
      return employees;
    }

    static void PrintEmployees(List<string> employees)
    {
      for (int i = 0; i < employees.Count; i++)
      {
        Console.WriteLine(employees[i]);
      }
    }

    static void Main(string[] args)
    {
      List<string> employees = GetEmployees();
      PrintEmployees(employees);
    }
  }
}