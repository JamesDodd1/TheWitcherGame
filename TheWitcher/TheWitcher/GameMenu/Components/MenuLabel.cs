using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.GameMenu.Components
{
    /// <summary> Specifies the style the text will be </summary>
    public enum TextStyle
    {
        Title,
        Normal,
    }


    /// <summary> Creates a new Label for the Pause Menu </summary>
    public class MenuLabel : Label
    {
        /// <summary> Initialises a new instance of MenuLabel </summary>
        public MenuLabel()
        {
            // Default settings
            this.Style = TextStyle.Normal;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.AutoSize = false;
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
        }


        /// <summary> Gets and sets the text style </summary>
        public TextStyle Style
        {
            get => this.style;
            set
            {
                switch (value)
                {
                    case TextStyle.Normal:
                        this.Font = new Font("Arial", 10, FontStyle.Regular);
                        this.Size = new Size(400, 20);
                        break;

                    case TextStyle.Title:
                        this.Font = new Font("Arial", 20, FontStyle.Underline);
                        this.Size = new Size(400, 40);
                        break;

                    default:
                        break;
                }

                this.style = value;
            }
        }
        private TextStyle style;
    }
}
