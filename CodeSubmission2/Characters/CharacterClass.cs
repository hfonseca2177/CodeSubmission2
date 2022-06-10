using Util;
using System.Collections.Generic;
using System.Text;

namespace CodeSubmission2.Characters
{
    internal class CharacterClass
    {
        protected string name;
        protected string description;
        protected int level;
        protected Ability[] abilities;

        public Ability[] GetAbilities()
        {
            return abilities;
        }

        public Ability GetRandomAbility()
        {
            return abilities[RandomUtils.GenRandom(0, abilities.Length)];
        }

        public CharacterClass(string name, string description, int level, Ability[] abilities)
        {
            this.name = name;
            this.description = description;
            this.level = level;
            this.abilities = abilities;
        }
    }
}
