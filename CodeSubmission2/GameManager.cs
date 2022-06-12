using CodeSubmission2.Characters;
using System;
using Util;

namespace CodeSubmission2
{
    //Class Duel Game manager implementation
    internal class GameManager
    {

        private bool gameOver = false;
        private bool combatOn = false;
        private CharacterClassManager characterClassManager;
        private CharacterClass player;
        private CharacterClass enemy;

        //Execute the game
        public void Run()
        {
            //Init the character classes manager
            characterClassManager = new CharacterClassManager();
            characterClassManager.InitCharacterClasses();
            //Subscribe listeners to user inputs
            SubscribeUserChoices();
            
            while (true)
            {   
                
                if (gameOver)
                {
                    break;
                }
                if(combatOn)
                {
                    GenerateEnemy();
                    Combat();
                }else
                {
                    StartNewMatch();
                    UserInputHandler.HandleInput();
                }
            }
            Destroy();
        }

        //Starts a new combat
        public void StartNewMatch()
        {   
            PrintHeader();
            Print("Pick up a class: ");
            for (int i = 0; i < characterClassManager.GetCharacterClasses().Length; i++)
            {
                Print("[" + (i + 1) + "]" + characterClassManager.GetCharacterClasses()[i].GetName());
            }
            Print("[Q] Exit");
        }

        //Generate a random Enemy
        private void GenerateEnemy()
        {
            enemy = characterClassManager.GetCharacterClasses()[RandomUtils.GenRandom(0, characterClassManager.GetCharacterClasses().Length-1)];
        }

        //Perform a combat
        private void Combat()
        {
            bool nobodyDied = true;
            while(nobodyDied)
            {
                //Get a random ability from both, player and enemy
                Ability playerAbility = player.GetRandomAbility();
                Ability enemyAbility = enemy.GetRandomAbility();
                //Process the ability damage rolls
                int playerDamageDealt = playerAbility.GetDamage().Roll();
                int enemyDamageDealt = enemyAbility.GetDamage().Roll();
                //Assign the damage generated
                player.TakeDamage(enemyDamageDealt);
                enemy.TakeDamage(playerDamageDealt);
                //Print out result 
                PrintCombatSummary("Player", ref player, ref playerAbility, playerDamageDealt, ConsoleColor.Blue);
                PrintCombatSummary("Enemy", ref enemy, ref enemyAbility, enemyDamageDealt, ConsoleColor.Red);
                //check if anyone died
                nobodyDied = player.IsAlive() && enemy.IsAlive();
                Print("...");
                Console.ReadKey();
            }
            Print("==================================================");
            Print(player.IsAlive() ? "YOU WON! ;)" : "You Lose :(", ConsoleColor.Yellow);
            Print("==================================================");
            //reset hit points
            player.ResetHitPoints();
            enemy.ResetHitPoints();
            //end combat flag
            combatOn = false;
        }

        //Assign a callback function for each Key [1-4] and X to exit
        private void SubscribeUserChoices()
        {
            UserInputHandler.KeyOnePressed += PlayAsWarrior;
            UserInputHandler.KeyTwoPressed += PlayAsRogue;
            UserInputHandler.KeyThreePressed += PlayAsMage;
            UserInputHandler.KeyFourPressed += PlayAsWarlock;
            UserInputHandler.KeyQPressed += ExitGame;
        }

        //Remove all subscriptions to actions
        private void Destroy()
        {
            UserInputHandler.KeyOnePressed -= PlayAsWarrior;
            UserInputHandler.KeyTwoPressed -= PlayAsRogue;
            UserInputHandler.KeyThreePressed -= PlayAsMage;
            UserInputHandler.KeyFourPressed -= PlayAsWarlock;
            UserInputHandler.KeyQPressed -= ExitGame;
        }

        //Case user press 1 chooses warrior as playing class
        private void PlayAsWarrior()
        {
            player = characterClassManager.GetCharacterClasses()[0];
            combatOn = true;
            Console.Clear();
        }
        //Case user press 2 chooses rogue as playing class
        private void PlayAsRogue()
        {
            player = characterClassManager.GetCharacterClasses()[1];
            combatOn = true;
            Console.Clear();
        }
        //Case user press 3 chooses mage as playing class
        private void PlayAsMage()
        {
            player = characterClassManager.GetCharacterClasses()[2];
            combatOn = true;
            Console.Clear();
        }
        //Case user press 1 chooses warlock as playing class
        private void PlayAsWarlock()
        {
            player = characterClassManager.GetCharacterClasses()[3];
            combatOn = true;
            Console.Clear();
        }
        //Callback to change the flag that exits the game
        private void ExitGame()
        {
            gameOver = true;
            Print("Goodbye!!!");
        }

        //Print game's header
        private void PrintHeader()
        {
            string[] logoLines = FileHelper.ReadFileLines("Logo.txt");
            for (int i = 0; i < logoLines.Length; i++)
            {
                Print(logoLines[i], (i % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.Magenta);
            }
            Print("----------------------------- CLASS DUELS -----------------------------", ConsoleColor.Red);
            Print("");
        }

        //Prints all character combat information
        private void PrintCombatSummary(string owner, ref CharacterClass character, ref Ability ability, int damageDealt, ConsoleColor color)
        {
            Print(owner + " " + character.GetName(), color);
            Print("HP: " + character.GetRemainingLife(), color);
            Print(" Casts [" + ability.GetName() + "] - " + ability.GetDescription(), color);
            Print(" Damage: " + damageDealt, color);
        }

        //Prints message with default color
        private void Print(string message)
        {
            Print(message, ConsoleColor.Green);
        }
        //Prints message with optional color
        private void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
