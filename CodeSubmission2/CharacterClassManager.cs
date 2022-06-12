using System;

using CodeSubmission2.Characters;
using Combat;

namespace CodeSubmission2
{
    /*
     * Load all classes configurations and instantiate the character classes available for the game
     */
    internal class CharacterClassManager
    {
        const string ABILITIES_FILE = "_abilities.txt";
        const string TOKEN_SEPARATOR = ",";
        string[] availableClasses = { "warrior","rogue","mage","warlock"};
        
        private CharacterClass[] characters;

        //Load all character classes
        public void InitCharacterClasses()
        { 
            //Initialize the characterClasses array to receive each one parsed
            characters = new CharacterClass[availableClasses.Length];
            //load each class
            for (int i = 0; i < availableClasses.Length; i++)
            {
                characters[i] = LoadClass(availableClasses[i]);
            }
        }

        //Load a characterClass descriptor
        public CharacterClass LoadClass(string className)
        {
            //Read the CharacterClass configuration file
            string[] abilitesInfo = Util.FileHelper.ReadFileLines(className + ABILITIES_FILE);
            //Prepare array to assign the abilities
            Ability[] abilities = new Ability[abilitesInfo.Length];
            //instantiate each ability
            for (int i = 0; i < abilitesInfo.Length; i++)
            {
                //splits text to get each class information
                string[] tokens = abilitesInfo[i].Split(TOKEN_SEPARATOR);
                //parse the damage dice used assigned to the ability
                int diceFaces = Int16.Parse(tokens[2]);
                //Retrieves a corresponding instance to be used on combat
                IDice combatDice = DiceFactory.GenerateDice(diceFaces);
                //Instantiate the ability
                abilities[i] = new Ability(tokens[0], tokens[1], combatDice);
            }
            //instantiate the characterClass parsed
            CharacterClass characterClass = new CharacterClass(className, abilities);
            return characterClass;
        }

        

        //Return the list of character classes available
        public CharacterClass[] GetCharacterClasses()
        {
           return characters;
        }
    }
}
