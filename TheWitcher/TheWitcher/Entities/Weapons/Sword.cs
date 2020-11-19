using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities.Weapons
{
    /// <summary>  </summary>
    public class Sword : Weapon
    {
        /// <summary>  </summary>
        public Sword() : base(@"sword_swing1.png")
        {
            this.Attack = new WeaponAttack[]
            {
                new WeaponAttack(Image.FromFile(@".\images\witcher\sword_swing1.png"), new Point(-10, -15)),
                new WeaponAttack(Image.FromFile(@".\images\witcher\sword_swing2.png"), new Point(-10, 5)),
            };


            this.Tool = Weaponary.Sword;
            this.AttackPower = 10;
            this.SwingSpeed = 10;
        }
    }
}
