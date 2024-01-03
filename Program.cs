﻿using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      // Dictionaries
      Dictionary<string, int> kpopGroups = new Dictionary<string, int>(){
        {"BTS", 7}, //Key: Group Name | Value: Number of members
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

      // Arrays
      string [] bangtanSongs = new string[4]{ "Spring Day", "Save Me", "Silver Spoon", "DNA"};
      string firstSong = bangtanSongs[0];
      string secondSong = bangtanSongs[1];
      string thirdSong = bangtanSongs[2];
      string lastSong = bangtanSongs[3];
      Console.WriteLine("----------------");
      Console.WriteLine("My Top 3 BTS Songs are {0}, {1}, {2} and my favorite song of all time is {3}.", secondSong, thirdSong, lastSong, firstSong);

      // Lists
      List<string> bangtanies = new List<string>() { "Namjoon", "Seokjin", "Yoongi", "Hoseok", "Jimin", "Taehyung", "Jungkook"};
      Console.WriteLine("----------------");
      Console.WriteLine("The hyung line includes {0}, {1}, {2} and {3} who is also the group's leader.", bangtanies[1], bangtanies[2], bangtanies[3], bangtanies[0]);
      Console.WriteLine("The maknae line includes {0}, {1}, and {2}.", bangtanies[4], bangtanies[5], bangtanies[6] );
      Console.WriteLine("----------------");

      // Loops
      for (int i = 0; i < bangtanies.Count; i++)
      {
        Console.WriteLine(bangtanies[i]);
      }

    }
  }
}