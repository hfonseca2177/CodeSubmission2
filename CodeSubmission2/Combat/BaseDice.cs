using System;

namespace Combat
{
    /*
     * Base implementation for Dice rolls
     */
    abstract class BaseDice : IDice
    {
        //Provided random implementation
        protected Random randomGenerator;

        //virtual base implementation for seeding random generator
        protected virtual int GenerateSeed()
        {
            return DateTime.Now.Millisecond;
        }
        //Create instance for the Random object
        protected virtual void InstantiateGenerator()
        {
            this.randomGenerator = new Random(GenerateSeed());
        }
        //Constructor
        public BaseDice()
        {
            InstantiateGenerator();
        }
        //Generate random number within the range (inclusive)
        protected int GenerateRandom(int min, int max)
        {
            return this.randomGenerator.Next(min, max + 1);
        }

        //Method to be overriden for each Dice implementation
        public abstract int Roll();
    }
}
