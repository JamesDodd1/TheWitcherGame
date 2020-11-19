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
    /// <summary> Generates the Pause Menu </summary>
    public class PauseMenu
    {
        /// <summary> Initialises a new instance of PauseMenu with specified Form </summary>
        /// <param name="form">The Form the Pause Menu will be added to </param>
        public PauseMenu()
        {
            SetMenu();
            this.mainMenu = new MainMenu(this.menu);
        }


        /// <summary> Shows Pause Menu on the Form </summary>
        /// <param name="form"> Form to display the menu on </param>
        public void Show(Form form)
        {
            try
            {
                int formControlBar = 23;
                int formBorders = 8;
                int formWidth = form.Width - (formBorders * 2);
                int formHeight = form.Height - formControlBar - (formBorders * 2);

                // Positon at centre of the form
                int posX = (formWidth - this.menu.Width) / 2;
                int posY = (formHeight - this.menu.Height) / 2;
                this.menu.Location = new Point(posX, posY);


                // Display Pause Menu
                this.mainMenu.Show();
                form.Controls.Add(this.menu);
                this.menu.BringToFront();
            }
            catch (System.NullReferenceException) 
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(form), nameof(PauseMenu));
            }
        }


        /// <summary> Removes Pause Menu from the Form </summary>
        /// <param name="form"> Form to remove the menu from </param>
        public void Hide(Form form)
        {
            try 
            {
                this.mainMenu.Hide();
                form.Controls.Remove(this.menu); 
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(form), nameof(PauseMenu));
            }
        }


        /// <summary> Sets up the menu panel </summary>
        private void SetMenu()
        {
            this.menu = new MenuPanel();
            this.menu.Name = "menuPnl";
            //this.menu.Location = new Point(40, 30);
        }


        private MenuPanel menu;
        private MainMenu mainMenu;
    }
}
