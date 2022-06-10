using System;

namespace ConsoleApp6
{
    internal class D8Dice : BaseDice
    {
        public override int Roll()
        {
            return GenerateRandom(1,8);
        }

        protected override void InstantiateGenerator()
        {
            this.randomGenerator = new Random(Guid.NewGuid().GetHashCode());
        }
    }
}
