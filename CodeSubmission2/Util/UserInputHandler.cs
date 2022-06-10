using System;


namespace Util
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
