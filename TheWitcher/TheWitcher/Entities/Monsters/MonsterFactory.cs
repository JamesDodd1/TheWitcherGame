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
    public class MonsterFactory
    {
        private MonsterFactory() { }


        /// <summary>  </summary>
        public static Monster Create(Creatures type)
        {
            Monster monster = null;
            string creature = Enum.GetName(typeof(Creatures), type);

            switch (creature)
            {
                case "Dragon":
                    monster = new Dragon();
                    break;

                case "IceGolem":
                    monster = new Golem();
                    break;

                default:
                    break;
            }

            return monster;
        }
    }
}
