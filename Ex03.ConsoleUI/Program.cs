using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    // $G$ DSN-999 (-5) why not use base class member instead of override them?
    // $G$ SFN-999 (-5) bad feedback messages to user.
    public class Program
    {
        public static void Main()
        {
            UserInterface userInterface = new UserInterface();
            userInterface.RunApp();
        }
    }
}
