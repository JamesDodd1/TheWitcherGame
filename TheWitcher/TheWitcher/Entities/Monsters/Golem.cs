using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Travel.Entities.Monsters
{
    /// <summary>  </summary>
    public class Golem : Monster
    {
        /// <summary>  </summary>
        public Golem() : base(@"iceGolem.png")
        {
            Random random = new Random();

            this.Creature = Creatures.IceGolem;
            this.Health = 30;
            this.AttackPower = random.Next(8, 10);
            this.Velocity = random.Next(2, 5);
        }

        
        /// <summary>  </summary>
        public static int Rarity { get => 80; }
    }
}
