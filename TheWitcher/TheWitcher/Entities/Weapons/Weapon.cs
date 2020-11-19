using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities.Weapons
{
    public enum Weaponary 
    {
        Axe,
        None,
        Sword,
        Spear,
    }


    /// <summary>  </summary>
    public class Weapon : Entity
    {
        /// <summary>  </summary>
        public Weapon(string image) : base(@"Witcher\" + image)
        {
            this.BackColor = Color.Transparent;
            this.Height = 30;
            this.Width = 30;


            this.Location = new Point(-this.Width, -this.Height);
            this.Facing = Direction.Right;
        }


        /// <summary>  </summary>
        public class WeaponAttack
        {
            public WeaponAttack(Image swingImg, Point position)
            {
                this.SwingImg = swingImg;
                this.Location = position;
            }

            public Image SwingImg { get; protected set; }
            public Point Location { get; protected set; }
        }


        /// <summary>  </summary>
        public void FlipImage(Direction direction)
        {
            if (this.Facing != direction)
            {
                this.Facing = direction;

                foreach (WeaponAttack attack in Attack)
                {
                    attack.SwingImg.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
            }
        }


        /// <summary>  </summary>
        public void Position(int posX, int posY)
        {
            switch (this.Facing)
            {
                case Direction.Right:
                    foreach (WeaponAttack attack in this.Attack)
                    {
                        posX = posX + attack.Location.X;
                        posY = posY + attack.Location.Y;
                        this.Location = new Point(posX, posY);
                    }
                    break;

                case Direction.Left:
                    foreach (WeaponAttack attack in this.Attack)
                    {
                        posX = posX - attack.Location.X - this.Width;
                        posY = posY + attack.Location.Y;
                        this.Location = new Point(posX, posY);
                    }
                    break;

                default:
                    break;
            }
        }


        /// <summary>  </summary>
        public Weaponary Tool { get; protected set; }

        /// <summary>  </summary>
        public WeaponAttack[] Attack { get; protected set; }

        /// <summary>  </summary>
        public int AttackPower { get; protected set; }
        
        /// <summary>  </summary>
        public int SwingSpeed { get; protected set; }
    }
}
