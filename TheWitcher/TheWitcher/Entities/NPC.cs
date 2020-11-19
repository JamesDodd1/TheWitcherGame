using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities
{
    /// <summary>  </summary>
    public class NPC : MovingEntity
    {
        private Random random = new Random();

        /// <summary>  </summary>
        public bool IsActive { get; protected set; }


        /// <summary>  </summary>
        protected NPC(string image) : base(image)
        {
            this.IsActive = true;
            SpawnLoc();
            SetBoundaries();

            this.timer.Start();
        }


        /// <summary>  </summary>
        private void SetBoundaries()
        {
            RightBoundary = World.Overworld.Width + this.Width;
            LeftBoundary = -this.Width;
            TopBoundary = -this.Height;
            BottomBoundary = World.Overworld.Height + this.Height;
        }


        /// <summary>  </summary>
        private void SpawnLoc()
        {
            // Random edge
            switch (random.Next(0, 4))
            {
                case 0:
                    RightSpawn();
                    break;

                case 1:
                    LeftSpawn();
                    break;

                case 2:
                    TopSpawn();
                    break;

                case 3:
                    BottomSpawn();
                    break;

                default:
                    break;
            }
        }


        /// <summary>  </summary>
        private void RightSpawn()
        {
            Moving = Direction.Left;

            World.Points edge = World.Overworld.SpawnRightEdge;

            int top = edge.Start.Y;
            int bottom = edge.End.Y - this.Height;

            this.Left = edge.Start.X;
            this.Top = random.Next(top, bottom);
        }


        /// <summary>  </summary>
        private void LeftSpawn()
        {
            Moving = Direction.Right;

            World.Points edge = World.Overworld.SpawnLeftEdge;

            int top = edge.Start.Y;
            int bottom = edge.End.Y - this.Height;

            this.Left = edge.Start.X - this.Width;
            this.Top = random.Next(top, bottom);
        }


        /// <summary>  </summary>
        private void TopSpawn()
        {
            Moving = Direction.Down;

            World.Points edge = World.Overworld.SpawnTopEdge;

            int left = edge.Start.X;
            int right = edge.End.X - this.Width;

            this.Left = random.Next(left, right);
            this.Top = -this.Height;
        }


        /// <summary>  </summary>
        private void BottomSpawn()
        {
            Moving = Direction.Up;

            World.Points edge = World.Overworld.SpawnBottomEdge;

            int left = edge.Start.X;
            int right = edge.End.X - this.Width;

            this.Left = random.Next(left, right);
            this.Top = edge.Start.Y;
        }




        /// <summary>  </summary>
        protected override void MoveRight()
        {
            base.MoveRight();

            if (IsOutOfBounds())
                this.IsActive = false;
        }


        /// <summary>  </summary>
        protected override void MoveLeft()
        {
            base.MoveLeft();

            if (IsOutOfBounds())
                this.IsActive = false;
        }


        /// <summary>  </summary>
        protected override void MoveUp()
        {
            base.MoveUp();

            if (IsOutOfBounds())
                this.IsActive = false;
        }


        /// <summary>  </summary>
        protected override void MoveDown()
        {
            base.MoveDown();

            if (IsOutOfBounds())
                this.IsActive = false;
        }


        /// <summary>  </summary>
        protected bool IsOutOfBounds()
        {
            if (this.Moving == Direction.Up && this.Bottom <= 0) { return true; }
            if (this.Moving == Direction.Left && this.Right <= 0) { return true; }
            if (this.Moving == Direction.Down && this.Top >= World.Overworld.Height) { return true; }
            if (this.Moving == Direction.Right && this.Left >= World.Overworld.Width) { return true; }

            return false;
        }
    }
}
