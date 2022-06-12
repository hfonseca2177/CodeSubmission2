using System;


namespace Util
{
    //User input handler basad on Action event implementation
    internal class UserInputHandler
    {
        public static Action KeyOnePressed;
        public static Action KeyTwoPressed;
        public static Action KeyThreePressed;
        public static Action KeyFourPressed;
        public static Action KeyQPressed;

        public static void HandleInput()
        {   
            ConsoleKeyInfo key = Console.ReadKey();
            if(ConsoleKey.D1.Equals(key.Key))
            {
                KeyOnePressed.Invoke();
            }else if (ConsoleKey.D2.Equals(key.Key))
            {
                KeyTwoPressed.Invoke();
            }
            else if (ConsoleKey.D3.Equals(key.Key))
            {
                KeyThreePressed.Invoke();
            }
            else if (ConsoleKey.D4.Equals(key.Key))
            {
                KeyFourPressed.Invoke();
            }else if(ConsoleKey.Q.Equals(key.Key))
            {
                KeyQPressed.Invoke();
            }

        }

    }
}
