using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SkiaSharp;

namespace CatWorx.BadgeMaker
{
  class Util{
    // Print employees data
    public static void PrintEmployees(List<Employee> employees)
    {
      for (int i = 0; i < employees.Count; i++)
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetID(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
      }

    }

// make the CSV file
    public static void MakeCSV(List<Employee> employees)
    {
      // Check to see if folder exists
      if (!Directory.Exists("data"))
      {
        // If not, create it
        Directory.CreateDirectory("data");
      }

      using (StreamWriter file = new StreamWriter("data/employees.csv"))
      {
        file.WriteLine("ID,Name,PhotoUrl"); // CSV File headings
        // Loop over employees
        for (int i = 0; i < employees.Count; i++)
      {
        // Write each employee to the file
        string template = "{0},{1},{2}";
        file.WriteLine(String.Format(template, employees[i].GetID(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
      }
      }
    }

    // make the badges
     async public static Task MakeBadges(List<Employee> employees)
    {
      // instance of HttpClient is disposed after code in the block has run
      using(HttpClient client = new HttpClient())
      {
        for (int i = 0; i < employees.Count; i++ )
        {
          SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
          SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

          SKData data = background.Encode();
          data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
        }
      }
    }
  }
}