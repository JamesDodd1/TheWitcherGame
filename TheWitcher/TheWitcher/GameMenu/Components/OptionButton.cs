using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel.GameMenu.Components
{
    /// <summary> Creates a new Button for Pause Menu options </summary>
    public class OptionButton : Button
    {
        /// <summary> Initalises a new instance of OptionButton </summary>
        public OptionButton()
        {
            // Default settings
            this.Font = new Font("Arial", 10, FontStyle.Regular);
            this.Size = new Size(400, 40);
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Black;
            this.TabStop = false;

            this.SetStyle(ControlStyles.Selectable, false); // Keyboard controls cannot be used
            this.enable = true;

            // Event controls
            this.MouseEnter += MenuButton_MouseEnter;
            this.MouseLeave += MenuButton_MouseLeave;
        }


        /// <summary> Change button text when mouse hovers over button </summary>
        protected virtual void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.ForeColor = Color.Orange;
            this.BackColor = Color.FromArgb(30, 30, 30); // Dark Grey
        }


        /// <summary> Change button text when mouse leaves the button </summary>
        protected virtual void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font, FontStyle.Regular);
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
        }


        /// <summary> Set whether button is enabled </summary>
        /// <returns> <see langword="true" /> if the button is enabled, otherwise <see langword="false" /> </returns>
        public bool Enable 
        {
            get => this.enable;
            set
            {
                if (value)
                {
                    this.ForeColor = Color.White;

                    // Add event controls
                    this.MouseEnter += MenuButton_MouseEnter;
                    this.MouseLeave += MenuButton_MouseLeave;
                }
                else
                {
                    this.ForeColor = Color.Gray;

                    // Remove event controls
                    this.MouseEnter -= MenuButton_MouseEnter;
                    this.MouseLeave -= MenuButton_MouseLeave;
                }

                this.enable = value;
            }
        }
        private bool enable;
    }
}
