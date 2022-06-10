using Combat;
using System.Collections.Generic;
using System.Text;

namespace CodeSubmission2.Characters
{
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
    }
}
