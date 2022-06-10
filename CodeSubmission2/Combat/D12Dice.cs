using System;

namespace Combat
{
    //D12 dice implementation
    internal class D12Dice : BaseDice
    {
        
        public override int Roll()
        {
            return GenerateRandom(1, 12);
        }

        protected override int GenerateSeed()
        {
            return Environment.TickCount;
        }
    }
}
