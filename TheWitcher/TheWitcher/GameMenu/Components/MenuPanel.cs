using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.GameMenu.Components
{
    /// <summary> Creates a new Panel for the Pause Menu </summary>
    public class MenuPanel : Panel
    {
        /// <summary> Initalises a new instance of MenuPanel </summary>
        public MenuPanel()
        {
            // Default settings
            this.Size = new Size(450, 450);
            this.BackColor = Color.Black;

            this.BringToFront();

            // Event controls
            this.Paint += MenuPanel_Paint;
        }


        /// <summary> Draws a border </summary>
        protected virtual void MenuPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Orange, ButtonBorderStyle.Solid);
        }
    }
}
