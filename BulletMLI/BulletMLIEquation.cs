using BulletMLI.Equationator;
using System;
using System.Diagnostics;

namespace BulletMLI
{
    /// <summary>
    /// This is an equation used in BulletML nodes.
    /// This is an easy way to set up the grammar for all our equations.
    /// </summary>
    public class BulletMLIEquation : Equation
    {
        /// <summary>
        /// A randomizer for getting random values.
        /// </summary>
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);

        public BulletMLIEquation()
        {
            // Add the specific functions we will use for BulletML grammar.
            AddFunction("rand", RandomValue);
            AddFunction("rank", GameDifficulty);
            AddFunction("sign", RandomSign);
        }

        /// <summary>
        /// used as a callback function in bulletml euqations
        /// </summary>
        /// <returns>The value.</returns>
        private double RandomValue()
        {
            // This value is "$rand", return a random number
            return Configuration.RandomNextFloat();
        }

        private double GameDifficulty()
        {
            // This number is "$rank" which is the game difficulty.
            Debug.Assert(GameManager.GameDifficulty != null);

            return GameManager.GameDifficulty();
        }

        /// <summary>
        /// used as a callback function in bulletml euqations
        /// </summary>
        /// <returns>The value.</returns>
        private double RandomSign()
        {
            // This value is "$rand", return a random sign (-1 or 1)
            return Configuration.RandomNextInt(0, 2) * 2 - 1;
        }
    }
}