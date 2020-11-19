using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.Entities
{
    public class MovingEntity : Entity, IGameEntity
    {
        protected Timer timer = new Timer();


        public MovingEntity(string image) : base(image)
        {
            Timer();
        }


        private void Timer()
        {
            this.timer = new Timer();
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.timer.Interval = 10;
        }


        /// <summary> Hello World! </summary>
        protected virtual void Timer_Tick(object sender, EventArgs e)
        {
            // Game finished
            if (!Game.Start)
            {
                this.timer.Stop();
                return;
            }
        }


        /// <summary>  </summary>
        public void Stop()
        {
            this.timer.Stop();
            this.timer = new Timer();
        }


        protected int TopBoundary { get; set; }
        protected int LeftBoundary { get; set; }
        protected int BottomBoundary { get; set; }
        protected int RightBoundary { get; set; }


        /// <summary>  </summary>
        public virtual void MoveEntity(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    MoveLeft();
                    break;

                case Direction.Right:
                    MoveRight();
                    break;

                case Direction.Up:
                    MoveUp();
                    break;

                case Direction.Down:
                    MoveDown();
                    break;

                default:
                    break;
            }
        }


        /// <summary>  </summary>
        protected virtual void MoveRight()
        {
            // Flip when reverse direction
            if (this.Facing == Direction.Left)
                FlipImages();

            this.Moving = Direction.Right;
            this.Facing = Direction.Right;


            // Move right
            int newPosition = this.Location.X + this.Velocity;
            if (newPosition < RightBoundary)
                Left += Velocity;
        }


        /// <summary>  </summary>
        protected virtual void MoveLeft()
        {
            // Flip when reverse direction
            if (this.Facing == Direction.Right)
                FlipImages();

            this.Moving = Direction.Left;
            this.Facing = Direction.Left;


            // Move left
            int newPosition = this.Location.X + this.Velocity;
            if (newPosition > LeftBoundary)
                this.Left -= this.Velocity;
        }


        /// <summary>  </summary>
        protected virtual void MoveUp()
        {
            this.Moving = Direction.Up;

            // Move up
            int newPosition = this.Location.Y + this.Velocity;
            if (newPosition > TopBoundary)
                this.Top -= this.Velocity;
        }


        /// <summary>  </summary>
        protected virtual void MoveDown()
        {
            this.Moving = Direction.Down;

            // Move down
            int newPosition = this.Location.Y + this.Velocity;
            if (newPosition < BottomBoundary)
                this.Top += this.Velocity;
        }


        /// <summary>  </summary>
        protected virtual void FlipImages()
        {
            this.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
    }
}
