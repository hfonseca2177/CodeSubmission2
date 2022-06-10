using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    internal class UserInputHandler
    {   
        public static Action KeyEnterPressed;

        public static void HandleInput()
        {   
            ConsoleKeyInfo key = Console.ReadKey();
            if(ConsoleKey.Enter.Equals(key.Key))
            {
                KeyEnterPressed.Invoke();
            }

        }

    }
}
