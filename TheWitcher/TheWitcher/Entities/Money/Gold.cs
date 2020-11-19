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
    public class Gold : Money
    {
        /// <summary>  </summary>
        public Gold() : base(@"gold.png")
        {
            ((Bitmap)this.Image).MakeTransparent(((Bitmap)this.Image).GetPixel(1, 1));

            Random random = new Random();

            this.Coin = Coins.Gold;
            this.Value = 5;
            this.Velocity = random.Next(3, 5);
        }


        /// <summary>  </summary>
        public static int Rarity { get => 30; }
    }
}
