using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.Entities.Health
{
    /// <summary> A rare powerful recover item </summary>
    public class RainbowHeart : Health
    {
        /// <summary> Initalise a new instance of RainbowHeart </summary>
        public RainbowHeart() : base(@"heart-rainbow.png")
        {
            Random random = new Random();

            this.Recover = Recovery.RainbowHeart;
            this.Heal = 50;
            this.Velocity = random.Next(5, 10);
        }

        
        /// <summary>  </summary>
        public static int Rarity { get => 10; }
    }
}
