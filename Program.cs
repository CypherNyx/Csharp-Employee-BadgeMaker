using System;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(2 * 3);         // Basic Arithmetic: +, -, /, * {6}
Console.WriteLine(10 % 3);        // Modulus Op => remainder of 10/3 {1}
Console.WriteLine(1 + 2 * 3);     // order of operations  {7}
Console.WriteLine(10 / 3.0);      // int's and doubles 
Console.WriteLine(10 / 3);        // int's 
Console.WriteLine("12" + "3");    // What happens here? {123}

int num = 10;
num += 100;
Console.WriteLine(num); //110
num ++;
Console.WriteLine(num); //111
    }
  }
}