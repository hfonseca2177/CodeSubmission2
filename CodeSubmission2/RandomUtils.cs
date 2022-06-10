using System;


namespace ConsoleApp6
{
    public class RandomUtils
    {
        
        protected Random random;
        public RandomUtils()
        {   
            random = new Random(GetRandomSeed());
        }

        protected int GetRandomSeed()
        {
            return DateTime.Now.Millisecond;
        }

        public int GenRandom(int min, int max)
        {
            return this.random.Next(min, max+1);
        }
    }
}
