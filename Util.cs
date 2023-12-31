using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SkiaSharp;

namespace CatWorx.BadgeMaker
{
  class Util
  {
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
      //Layout variables
      int BADGE_WIDTH = 669;
      int BADGE_HEIGHT = 1044;

      int PHOTO_LEFT_X = 184;
      int PHOTO_TOP_Y = 215;
      int PHOTO_RIGHT_X = 486;
      int PHOTO_BOTTOM_Y = 517;

      int COMPANY_NAME_Y = 150;

      int EMPLOYEE_NAME_Y = 600;

      int EMPLOYEE_ID_Y = 730;

      // instance of HttpClient is disposed after code in the block has run
      using (HttpClient client = new HttpClient())
      {
        for (int i = 0; i < employees.Count; i++)
        {
          SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
          SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

          SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
          SKCanvas canvas = new SKCanvas(badge);

          canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
          canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));


          SKPaint paint = new SKPaint();
          paint.TextSize = 42.0f;
          paint.IsAntialias = true;
          paint.Color = SKColors.White;
          paint.IsStroke = false;
          paint.TextAlign = SKTextAlign.Center;
          paint.Typeface = SKTypeface.FromFamilyName("Arial");

          // Company name
          canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH / 2f, COMPANY_NAME_Y, paint);

          paint.Color = SKColors.Black;

          // Employee name
          canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);

          paint.Typeface = SKTypeface.FromFamilyName("Courier New");

          // Employee ID
          canvas.DrawText(employees[i].GetID().ToString(), BADGE_WIDTH / 2f, EMPLOYEE_ID_Y, paint);

          SKImage finalImage = SKImage.FromBitmap(badge);
          SKData data = finalImage.Encode();
          string template = "data/{0}_badge.png";
          data.SaveTo(File.OpenWrite(string.Format(template, employees[i].GetID())));
        }
      }
    }
  }
}