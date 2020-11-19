using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Travel.GameMenu.Components;

namespace Travel.GameMenu
{
    /// <summary> Generates the Customise Menu </summary>
    public class CustomiseMenu
    {
        /// <summary> Initialises a new instance of Customise with specified panel </summary>
        /// <param name="panel"> The Panel the Customisation Menu will be added to </param>
        public CustomiseMenu(Panel panel)
        {
            this.panel = panel;

            this.weapons = new SelectWeapon(this.panel);
            this.armour = new SelectArmour(this.panel);

            SetCustomiseMenuLayout();
        }


        /// <summary> Shows the Customisation Menu on the Menu Panel </summary>
        public void Show()
        {
            try
            {
                this.panel.Controls.Add(this.title);
                this.weapons.Show();
                this.armour.Show();
                this.panel.Controls.Add(this.back);
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(CustomiseMenu));
            }
        }


        /// <summary> Removes the Customisation Menu from the Menu Panel </summary>
        public void Hide()
        {
            try
            {
                this.panel.Controls.Remove(this.title);
                this.weapons.Hide();
                this.armour.Hide();
                this.panel.Controls.Remove(this.back);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(CustomiseMenu));
            }
        }


        /// <summary> Sets up the Customisation Menu layout </summary>
        private void SetCustomiseMenuLayout()
        {
            // Panel height
            int newHeight = 420;
            int posY = this.panel.Location.Y + (this.panel.Height - newHeight) / 2;
            this.panel.Location = new Point(this.panel.Location.X, posY);
            this.panel.Height = newHeight;
            this.panel.Invalidate();


            // Title label
            this.title = new MenuLabel();
            this.title.Name = "titleLbl";
            this.title.Text = "CUSTOMISATION";
            this.title.Style = TextStyle.Title;
            this.title.Location = new Point(25, 25);


            // Back button
            this.back = new OptionButton();
            this.back.Name = "backBtn";
            this.back.Text = "BACK";
            this.back.Location = new Point(25, 345);
            this.back.Click += this.BackBtn_Click;
        }


        /// <summary> Returns to Main Menu when the Back button clicked </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainMenu(this.panel).Show();
        }


        private Panel panel;
        private SelectWeapon weapons;
        private SelectArmour armour;
        private MenuLabel title;
        private OptionButton back;
    }
}
