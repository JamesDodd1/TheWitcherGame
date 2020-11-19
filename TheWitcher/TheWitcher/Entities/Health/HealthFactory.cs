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
    public class HealthFactory
    {
        /// <summary>  </summary>
        public static Health Create(Recovery type)
        {
            Health health = null;
            string recover = Enum.GetName(typeof(Recovery), type);

            switch (recover)
            {
                case "Heart":
                    health = new Heart();
                    break;

                case "RainbowHeart":
                    health = new RainbowHeart();
                    break;

                case "BlackHeart":
                    health = new BlackHeart();
                    break;

                default:
                    break;
            }
            
            return health;
        }
    }
}
