using Util;


namespace CodeSubmission2.Characters
{
    /*
     * Character class type descriptor with abilities
     */
    internal class CharacterClass
    {   
        protected string name;
        protected Ability[] abilities;
        protected int maxHitPoints = 100;
        protected int currentHitPoints = 100;

        public Ability[] GetAbilities()
        {
            return abilities;
        }
        //Return randomically one of its abilities
        public Ability GetRandomAbility()
        {
            return abilities[RandomUtils.GenRandom(0, abilities.Length-1)];
        }

        public CharacterClass(string name, Ability[] abilities)
        {
            this.name = name;
            this.abilities = abilities;
        }

        public string GetName()
        {
            return this.name;
        }

        //Reset character hit points
        public void ResetHitPoints()
        {
            currentHitPoints = maxHitPoints; 
        }
        //Checks if character still has hit points
        public bool IsAlive()
        {
            return currentHitPoints > 0;
        }
        //Assimilates the damage taken to the hit points
        public void TakeDamage(int damage)
        {
            currentHitPoints -= damage;
        }

        //Return current life
        public int GetRemainingLife()
        {
            return currentHitPoints > 0 ? currentHitPoints : 0;
        }
    }
}
