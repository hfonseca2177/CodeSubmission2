
namespace Combat
{
    //D4 implementation
    internal class D4Dice : BaseDice
    {
        public override int Roll()
        {
            return GenerateRandom(1, 4);
        }
    }
}
