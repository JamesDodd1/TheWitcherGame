using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.GameMenu.Components
{
    /// <summary> Creates a new Picture Box for the Pause Menu </summary>
    public class WeaponPictureBox : PictureBox
    {
        /// <summary> Initalises a new instance of WeaponPictureBox </summary>
        public WeaponPictureBox()
        {
            // Default settings
            this.Size = new Size(75, 75);
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.TabStop = false;

            this.selected = false;

            // Event controls
            this.Paint += Weapon_Paint;
        }


        /// <summary> Draws a border onto the Picture Box </summary>
        protected virtual void Weapon_Paint(object sender, PaintEventArgs e)
        {
            int thickness = 3;

            Rectangle top = new Rectangle(0, 0, this.Width, thickness);
            Rectangle left = new Rectangle(0, 0, thickness, this.Height);
            Rectangle bottom = new Rectangle(0, this.Height - thickness - 2, this.Width, thickness);
            Rectangle right = new Rectangle(this.Width - thickness - 2, 0, thickness, this.Height);

            if (this.Selected)
            {
                DrawEdgeBorder(e, top, Color.Orange);
                DrawEdgeBorder(e, left, Color.Orange);
                DrawEdgeBorder(e, bottom, Color.Orange);
                DrawEdgeBorder(e, right, Color.Orange);
            }
        }


        /// <summary> Draws one edge's border </summary>
        /// <param name="edge"> Coordinates of where to draw </param>
        private void DrawEdgeBorder(PaintEventArgs e, Rectangle edge, Color colour)
        {
            ControlPaint.DrawBorder(e.Graphics, edge, colour, ButtonBorderStyle.None);
            e.Graphics.FillRectangle(new SolidBrush(colour), edge);
        }


        /// <summary> Sets and gets whether this is selected </summary>
        /// <returns> <see langword="true" /> if the Picture Box is selected, otherwise <see langword="false" /> </returns>
        public bool Selected
        {
            get => this.selected;
            set
            {
                this.selected = value;
                this.Invalidate();
            }
        }
        private bool selected;
    }
}
