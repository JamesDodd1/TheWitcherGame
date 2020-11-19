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
    /// <summary> Generates the Main Menu for the Pause Menu </summary>
    public class MainMenu
    {
        /// <summary> Initialises a new instance of MainMenu with specified Panel </summary>
        /// <param name="panel"> The Panel the Main Menu will be added to </param>
        public MainMenu(Panel panel)
        {
            this.panel = panel;

            SetMainMenuLayout();
        }


        /// <summary> Shows Main Menu on the Panel </summary>
        public void Show()
        {
            try
            {
                this.panel.Controls.Add(this.title);
                this.panel.Controls.Add(this.newGame);
                this.panel.Controls.Add(this.resume);
                this.panel.Controls.Add(this.customise);
                this.panel.Controls.Add(this.quit);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(MainMenu));
            }
        }


        /// <summary> Removes Main Menu from the Panel </summary>
        public void Hide()
        {
            try
            {
                this.panel.Controls.Remove(this.title);
                this.panel.Controls.Remove(this.newGame);
                this.panel.Controls.Remove(this.resume);
                this.panel.Controls.Remove(this.customise);
                this.panel.Controls.Remove(this.quit);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(MainMenu));
            }
        }


        /// <summary> Sets up the Main Menu layout </summary>
        private void SetMainMenuLayout()
        {
            // Panel height
            int newHeight = 320;
            int posY = this.panel.Location.Y + (this.panel.Height - newHeight) / 2;
            this.panel.Location = new Point(this.panel.Location.X, posY);
            this.panel.Height = newHeight;
            this.panel.Invalidate();


            // Title label
            this.title = new MenuLabel();
            this.title.Name = "titleLbl";
            this.title.Text = "MAIN MENU";
            this.title.Style = TextStyle.Title;
            this.title.Location = new Point(25, 25);


            // New Game button
            this.newGame = new OptionButton();
            this.newGame.Name = "newGameBtn";
            this.newGame.Text = "NEW GAME";
            this.newGame.Location = new Point(25, 80);
            this.newGame.Click += NewGameBtn_Click;


            // Resume button
            this.resume = new OptionButton();
            this.resume.Name = "resumeBtn";
            this.resume.Text = "RESUME";
            this.resume.Location = new Point(25, 135);
            this.resume.Enable = Game.Start && Game.Wait; // True if both true
            if (this.resume.Enable) 
                this.resume.Click += Resume_Click;


            // Customise button
            this.customise = new OptionButton();
            this.customise.Name = "customiseBtn";
            this.customise.Text = "CUSTOMISATION";
            this.customise.Location = new Point(25, 190);
            this.customise.Click += CustomiseBtn_Click;


            // Quit button
            this.quit = new OptionButton();
            this.quit.Name = "quitBtn";
            this.quit.Text = "QUIT";
            this.quit.Location = new Point(25, 245);
            this.quit.Click += QuitBtn_Click;
        }


        /// <summary> Starts a new game when New Game button clicked </summary>
        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            Game.End();
            Game.Begin();
        }


        /// <summary> Resumes current game when Resume option button clicked </summary>
        private void Resume_Click(object sender, EventArgs e)
        {
            Game.Resume();
        }


        /// <summary> Displays Customisation Menu when Customise option button clicked </summary>
        private void CustomiseBtn_Click(object sender, EventArgs e)
        {
            Hide();

            new CustomiseMenu(this.panel).Show();
        }


        /// <summary> Closes game when Quit option button clicked </summary>
        private void QuitBtn_Click(object sender, EventArgs e)
        {
            World.Overworld.Close();
        }


        private Panel panel;
        private MenuLabel title;
        private OptionButton newGame;
        private OptionButton resume;
        private OptionButton customise;
        private OptionButton quit;
    }
}
