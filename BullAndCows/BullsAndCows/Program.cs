using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
