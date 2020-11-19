using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.Entities.Money
{
    /// <summary> Creates a new instance of Money types </summary>
    public class MoneyFactory
    {
        /// <summary> Creates a new instance of the Coin type </summary>
        public static Money Create(Coins type)
        {
            Money money = null;
            string coin = Enum.GetName(typeof(Coins), type);

            switch (coin)
            {
                case "Gold":
                    money = new Gold();
                    break;

                case "Silver":
                    money = new Silver();
                    break;

                default:
                    break;
            }

            return money;
        }
    }
}
