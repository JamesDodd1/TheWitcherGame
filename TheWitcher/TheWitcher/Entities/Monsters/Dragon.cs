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
    public class Dragon : Monster
    {
        /// <summary>  </summary>
        public Dragon() : base(@"dragon.png")
        {
            Random random = new Random();

            this.Creature = Creatures.Dragon;
            this.Health = 50;
            this.AttackPower = random.Next(15, 20);
            this.Velocity = random.Next(1, 3);
        }


        /// <summary>  </summary>
        public static int Rarity { get => 20; }
    }
}
