using System;
using System.Linq;

namespace BullsAndCows
{
    class Program
    {      
         static void Main(string[] args)
         {
             Play.StartNewGame();
             while (Play.ReadAction())
             {
             }
         }
    }
    
}
