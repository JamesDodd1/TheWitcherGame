using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Travel.Entities.Monsters;
using Travel.Entities.Weapons;

namespace Travel.Entities
{
    /// <summary>  </summary>
    public class User : MovingEntity, ILife
    {
        public Weapon Weapon { get; private set; }

        public int FullHealth { get; private set; }
        public int Health 
        { 
            get => this.health; 
            set
            {
                // Min health value
                if (value < 0) 
                {
                    this.health = 0;
                    return;
                }

                // Max health value
                if (value > this.FullHealth) 
                { 
                    this.health = this.FullHealth;
                    return;
                }

                this.health = value;
            } 
        }
        private int health;
        
        public int Money { get; set; }


        public bool IsAttacking { get; set; }
        private Image StandImg { get; set; }
        private Image[] AttackImg { get; set; }
        public int AttackPower { get; protected set; }


        /// <summary> Initalise a new instance of User </summary>
        public User() : base(@"Witcher\witcher.png")
        {
            this.Type = FlyingObjects.Witcher;

            // Images
            this.StandImg = Image.FromFile(@".\Images\Witcher\witcher.png");
            this.AttackImg = new Image[]
            {
                Image.FromFile(@".\Images\Witcher\witcher_attack1.png"),
                Image.FromFile(@".\Images\Witcher\witcher_attack2.png"),
            };

            // Stats
            this.FullHealth = 100;
            this.Health = this.FullHealth;
            this.Money = 0;
            this.Velocity = 5;
            this.IsAttacking = false;
            this.Facing = Direction.Right;
            this.Top = (World.Overworld.Height - this.Height) / 2;
            this.Left = (World.Overworld.Width - this.Width) / 2;
            this.Image = StandImg;

            this.Weapon = new Sword();

            SetMovementBoundary();

            this.timer.Start();
        }


        /// <summary>  </summary>
        private void SetMovementBoundary()
        {
            RightBoundary = World.Overworld.Width - this.Width;
            LeftBoundary = 0;
            TopBoundary = (int)(this.Height * 0.25);
            BottomBoundary = (int)(World.Overworld.Height - this.Height * 1.75);
        }


        protected override void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);

            // Game Paused
            if (Game.Wait) { return; }

            // Player killed
            if (Health <= 0)
            {
                Game.GameOver();
                World.Overworld.Controls.Remove(this);
                this.timer.Stop();

                return;
            }

            GameControls.KeysPressed();

            if (IsAttacking)
            {
                World.Overworld.Controls.Add(this.Weapon);
                this.Weapon.BringToFront();

                Attack();
            }

            MonsterCollision();
        }


        /// <summary>  </summary>
        private void MonsterCollision()
        {
            for (int i = 0; i < World.Monsters.Count; i++)
            {
                Monster monster = World.Monsters[i];

                // Hit by monster
                if (this.DetectCollision(monster))
                {
                    Knockback(monster.Moving, 100);
                    this.Health -= monster.AttackPower;
                }
            }
        }


        /// <summary>  </summary>
        private void Knockback(Direction direction, int distance)
        {
            switch (direction)
            {
                case Direction.Up:
                    this.Top -= distance;
                    break;

                case Direction.Left:
                    this.Left -= distance;
                    break;

                case Direction.Down:
                    this.Top += distance;
                    break;

                case Direction.Right:
                    this.Left += distance;
                    break;

                default:
                    break;
            }
        }


        /// <summary>  </summary>
        protected override void FlipImages()
        {
            this.StandImg.RotateFlip(RotateFlipType.RotateNoneFlipX);

            foreach (Image image in AttackImg)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }


        /// <summary>  </summary>
        public override void MoveEntity(Direction direction)
        {
            // Don't move when attacking
            if (IsAttacking)
                return;

            base.MoveEntity(direction);
        }


        private int count, loop;
        /// <summary>  </summary>
        public void Attack()
        {
            if (loop++ % Weapon.SwingSpeed == 0)
            {
                // Swing complete
                if (count == AttackImg.Length)
                {
                    World.Overworld.Controls.Remove(this.Weapon);
                    this.Weapon.Location = new Point(-this.Weapon.Width, -this.Weapon.Height);

                    this.Image = StandImg;
                    this.IsAttacking = false;

                    // Reset counters
                    count = 0;
                    loop = 0;

                    return;
                }

                
                // Set images
                this.Image = AttackImg[count];
                this.Weapon.Image = this.Weapon.Attack[count].SwingImg;
                
                WeaponPos();
                
                count++;
            }
        }


        /// <summary>  </summary>
        private void WeaponPos()
        {
            int posX, posY;

            Weapon.FlipImage(this.Facing);

            switch (this.Facing)
            {
                case Direction.Right:
                    posX = this.Location.X + this.Width + this.Weapon.Attack[count].Location.X;
                    posY = this.Location.Y + (this.Height / 2) + this.Weapon.Attack[count].Location.Y;
                    this.Weapon.Location = new Point(posX, posY);

                    break;

                case Direction.Left:
                    posX = this.Location.X + (this.Weapon.Attack[count].Location.X * -1) - this.Weapon.Width;
                    posY = this.Location.Y + (this.Height / 2) + this.Weapon.Attack[count].Location.Y;

                    this.Weapon.Location = new Point(posX, posY);

                    break;

                default:
                    break;
            }
        }
    }
}
