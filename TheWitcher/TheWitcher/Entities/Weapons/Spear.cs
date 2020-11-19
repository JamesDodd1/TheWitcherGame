using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities.Weapons
{
    /// <summary>  </summary>
    public class Spear : Weapon
    {
        /// <summary>  </summary>
        public Spear() : base(@"") 
        {
            this.Tool = Weaponary.Spear;
            this.AttackPower = 5;
            this.SwingSpeed = 5;
        }
    }
}
