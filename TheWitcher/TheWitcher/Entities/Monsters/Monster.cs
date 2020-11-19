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
    public enum Creatures: int
    {
        // Name | Rarity
        Dragon = 2,
        IceGolem = 8,
    }


    /// <summary>  </summary>
    public abstract class Monster : NPC
    {
        /// <summary>  </summary>
        protected Monster(string image) : base(@"Monsters\" + image)
        {
            this.Type = FlyingObjects.Monster;
            this.AttackPower = 0;
        }


        /// <summary>  </summary>
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);

            // Game Paused
            if (Game.Wait) { return; }

            if (this.Health <= 0 || !IsActive || IsOutOfBounds())
            {
                World.Monsters.Remove(this);
                World.Overworld.Controls.Remove(this);

                timer.Stop();

                return;
            }


            MoveEntity(this.Moving);


            // Hit by player's weapon
            if (this.DetectCollision(World.Player.Weapon))
            {
                Knockback(World.Player.Weapon.Facing, 100);
                this.Health -= World.Player.Weapon.AttackPower;
            }
        }


        /// <summary>  </summary>
        private void Knockback(Direction direction, int distance)
        {
            if (Direction.Left == direction)
                this.Left -= distance;
            else if (Direction.Right == direction)
                this.Left += distance;
        }


        /// <summary>  </summary>
        public Creatures Creature { get; protected set; }


        /// <summary>  </summary>
        public int Health 
        {
            get => this.health;
            protected set
            {
                if (this.health < 0)
                    this.health = 0;

                this.health = value;
            }
        }
        private int health;


        /// <summary>  </summary>
        public int AttackPower { get; protected set; }
    }
}
