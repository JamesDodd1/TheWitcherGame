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
    public enum Coins : int
    {
        // Name | Rarity
        Gold = 3,
        Silver = 7,
    }


    /// <summary>  </summary>
    public abstract class Money : NPC
    {
        /// <summary>  </summary>
        protected Money(string image) : base(@"Money\" + image)
        {
            this.Type = FlyingObjects.Money; 
        }


        /// <summary>  </summary>
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);

            // Game Paused
            if (Game.Wait) { return; }

            // Remove entity
            if (!IsActive || IsOutOfBounds())
            {
                World.Money.Remove(this);
                World.Overworld.Controls.Remove(this);

                timer.Stop();
                
                return;
            }


            MoveEntity(this.Moving);


            // Collected by player
            if (this.DetectCollision(World.Player))
            {
                World.Player.Money += this.Value;
                this.IsActive = false;
            }
        }


        /// <summary>  </summary>
        public Coins Coin { get; protected set; }

        
        /// <summary>  </summary>
        public int Value { get; protected set; }
    }
}
