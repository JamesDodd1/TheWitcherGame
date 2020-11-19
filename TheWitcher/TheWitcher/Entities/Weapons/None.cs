using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities.Weapons
{
    /// <summary>  </summary>
    public class None : Weapon
    {
        /// <summary>  </summary>
        public None() : base(@"")
        {
            this.Tool = Weaponary.None;
            this.AttackPower = 0;
            this.SwingSpeed = 0;
        }
    }
}