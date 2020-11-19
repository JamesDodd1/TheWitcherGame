using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.Entities.Health
{
    /// <summary> A common generic recovery item </summary>
    public class Heart : Health
    {
        /// <summary> Initalises a new instance of Heart </summary>
        public Heart() : base(@"heart.png")
        {
            Random random = new Random();

            this.Recover = Recovery.Heart;
            this.Heal = 5;
            this.Velocity = random.Next(3, 5);
        }

        
        /// <summary>  </summary>
        public static int Rarity { get => 80; }
    }
}