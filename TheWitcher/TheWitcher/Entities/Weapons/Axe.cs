using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities.Weapons
{
    /// <summary>  </summary>
    public class Axe : Weapon
    {
        /// <summary>  </summary>
        public Axe() : base(@"")
        {
            this.Tool = Weaponary.Axe;
            this.AttackPower = 20;
            this.SwingSpeed = 20;
        }
    }
}
