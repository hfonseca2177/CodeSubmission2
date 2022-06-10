using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    internal class Manager
    {

        private bool missionDone;

        public void Run()
        {
            missionDone = false;
            UserInputHandler.KeyEnterPressed += HandleEnter;
            while (true)
            {
                UserInputHandler.HandleInput();
                if (missionDone)
                {
                    break;
                } 
            }

            Console.WriteLine("Goodbye!!!");
        }

        public void HandleEnter()
        {
            Console.WriteLine("Enter was pressed");
            missionDone = true;
        }
    }
}
