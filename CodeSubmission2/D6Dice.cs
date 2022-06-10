
namespace ConsoleApp6
{
    //D6 dice implementation
    internal class D6Dice : BaseDice
    {
        public override int Roll()
        {
            return GenerateRandom(1, 6);
        }
    }
}
