using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities.Weapons
{
    public class WeaponFactory
    {
        private WeaponFactory() { }


        /// <summary>  </summary>
        public static Weapon Create(Weaponary type) 
        {
            Weapon weapon = null;
            string weaponary = Enum.GetName(typeof(Weaponary), type);

            switch (weaponary) 
            {
                case "Axe":
                    weapon = new Axe();
                    break;
                
                case "None":
                    weapon = new None();
                    break;

                case "Spear":
                    weapon = new Spear();
                    break;

                case "Sword":
                    weapon = new Sword();
                    break;
                
                default:
                    break;
            }

            return weapon;
        }
    }
}