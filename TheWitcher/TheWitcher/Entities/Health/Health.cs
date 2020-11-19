using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.Entities.Health
{
    /// <summary> Type of recovery hearts </summary>
    public enum Recovery
    {
        // Name | Rarity
        BlackHeart = 2,
        Heart = 7,
        RainbowHeart = 1,
    }


    /// <summary>  </summary>
    public abstract class Health : NPC
    {
        /// <summary> Initalise a new instance of Health </summary>
        protected Health(string image) : base(@"Health\" + image)
        {
            this.Type = FlyingObjects.Health;
        }


        
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);

            // Game Paused
            if (Game.Wait) { return; }


            // Remove entity
            if (!IsActive || IsOutOfBounds())
            {
                World.Health.Remove(this);
                World.Overworld.Controls.Remove(this);

                timer.Stop();

                return;
            }


            MoveEntity(this.Moving);


            // Collected by player
            if (this.DetectCollision(World.Player))
            {
                World.Player.Health += this.Heal;
                this.IsActive = false;
            }
        }


        /// <summary>  </summary>
        public Recovery Recover { get; protected set; } 


        /// <summary>  </summary>
        public int Heal { get; protected set; }
    }
}
