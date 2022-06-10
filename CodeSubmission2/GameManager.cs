using System;
using Util;

namespace CodeSubmission2
{
    internal class GameManager
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
