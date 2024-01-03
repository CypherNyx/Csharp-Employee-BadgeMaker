using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      Dictionary<string, int> kpopGroups = new Dictionary<string, int>(){
        {"BTS", 7}, // members
        {"BlackPink", 4},
        {"Twice", 9},
        {"Red Velvet", 5},
        {"EXO", 9},
        {"Girls Generation", 8}
      };

      Console.WriteLine("----------------");
      Console.WriteLine("Kpop Groups");
      Console.WriteLine("----------------");
      Console.WriteLine("           Group | Members");
      Console.WriteLine("             BTS | {0}", kpopGroups["BTS"] );
      Console.WriteLine("       BlackPink | {0}", kpopGroups["BlackPink"]);
      Console.WriteLine("           Twice | {0}", kpopGroups["Twice"]);
      Console.WriteLine("      Red Velvet | {0}", kpopGroups["Red Velvet"]);
      Console.WriteLine("             EXO | {0}", kpopGroups["EXO"]);
      Console.WriteLine("Girls Generation | {0}", kpopGroups["Girls Generation"]);

    }
  }
}