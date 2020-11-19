using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.Entities.Health
{
    /// <summary>  </summary>
    public class BlackHeart : Health
    {
        /// <summary>  </summary>
        public BlackHeart() : base(@"heart-black.png")
        {
            Random random = new Random();

            this.Recover = Recovery.BlackHeart;
            this.Heal = -20;
            this.Velocity = random.Next(1, 3);
        }


        /// <summary>  </summary>
        public static int Rarity { get => 10; }
    }
}
