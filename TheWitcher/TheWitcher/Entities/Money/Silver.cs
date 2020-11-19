using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.Entities.Money
{
    /// <summary>  </summary>
    public class Silver : Money
    {
        /// <summary>  </summary>
        public Silver() : base(@"silver.png")
        {
            Random random = new Random();

            this.Coin = Coins.Silver;
            this.Value = 1;
            this.Velocity = random.Next(5, 10);
        }


        /// <summary>  </summary>
        public static int Rarity { get => 70; }
    }
}
