using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Travel.Entities
{
    /// <summary>  </summary>
    public enum FlyingObjects
    {
        Health,
        Money, 
        Monster,
        Weapon,
        Witcher,
    }


    /// <summary>  </summary>
    public class Entity : PictureBox
    {

        public FlyingObjects Type { get; protected set; }
        public Direction Moving { get; protected set; }
        public Direction Facing { get; protected set; }
        public int Velocity { get; protected set; }


        /// <summary> Initalises a new instance of Entity </summary>
        protected Entity(string image)
        {
            this.Image = Image.FromFile(@".\Images\" + image);
            this.SizeMode = PictureBoxSizeMode.StretchImage;   //stretches image
            //((Bitmap)this.Image).MakeTransparent(((Bitmap)this.Image).GetPixel(1, 1)); // Causes some images to not display
            this.BackColor = Color.Transparent;
            this.Height = 50; //height of players object
            this.Width = 50;  //width of players object

            this.Facing = Direction.Left;
        }


        /// <summary> Checks if the current entity overlaps with another </summary>
        /// <returns> <see langword="true" /> if the entity intersect, otherwise <see langword="false" /> </returns>
        public bool DetectCollision(Entity entity)
        {
            Rectangle self = new Rectangle(this.Left, this.Top, this.Width, this.Height);  //dectects collision of player
            Rectangle obj = new Rectangle(entity.Left, entity.Top, entity.Width, entity.Height); //dectects collision of object
            
            self.Intersect(obj); //player intersects object

            return !(self == Rectangle.Empty); // player is not equal to empty object
        }
    }
}

