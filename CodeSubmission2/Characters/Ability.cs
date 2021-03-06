using Combat;


namespace CodeSubmission2.Characters
{
    //Class ability with damge Dice
    internal class Ability
    {
        protected string name;
        protected string description;
        protected IDice damage;

        public Ability(string name, string description, IDice damage)
        {
            this.name = name;
            this.description = description;
            this.damage = damage;
        }

        public IDice GetDamage()
        {
            return damage;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
