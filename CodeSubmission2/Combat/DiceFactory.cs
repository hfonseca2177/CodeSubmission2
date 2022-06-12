
namespace Combat
{
    //Factory to return instance of a implementation of IDice based on number of faces
    internal class DiceFactory
    {

        public static IDice GenerateDice(int faces)
        {
            IDice dice = null;

            switch (faces)
            {
                case 4:
                    {
                        dice = new D4Dice();
                        break;
                    }
                case 6:
                    {
                        dice = new D6Dice();
                        break;
                    }
                case 8:
                    {
                        dice = new D8Dice();
                        break;
                    }
                case 12:
                    {
                        dice = new D12Dice();
                        break;
                    }
                case 20:
                    {
                        dice = new D20Dice();
                        break;
                    }
            }
            return dice;
        }
    }
}
