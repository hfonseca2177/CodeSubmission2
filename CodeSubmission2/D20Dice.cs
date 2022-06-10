using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    //D20 dice implementation
    internal class D20Dice : BaseDice
    {

        public override int Roll()
        {
            return GenerateRandom(1, 20);
        }

        protected override int GenerateSeed()
        {
            return base.GenerateSeed() + 20;
        }
    }
}
