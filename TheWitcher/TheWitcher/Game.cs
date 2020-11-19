using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Travel.GameMenu;

namespace Travel
{
    /// <summary> Builds and displays the witcher game world </summary>
    public class Game
    {
        public Game() 
        {
            World.Create();
            Application.Run(World.Overworld);
        }


        /// <summary> Starts a brand new game </summary>
        public static void Begin() 
        {
            pauseMenu.Hide(World.Overworld);

            Start = true;
            Wait = false;

            World.Overworld.Reset();
            World.Overworld.Start();
        }


        /// <summary> Ends current game </summary>
        public static void End() 
        {
            Start = false;
            Wait = false;

            World.Overworld.Stop();
        }


        public static void GameOver()
        {
            End();

            pauseMenu = new PauseMenu();
            pauseMenu.Show(World.Overworld);
        }


        /// <summary> Freezes the current game and displays pause menu </summary>
        public static void Pause() 
        {
            Wait = true;

            pauseMenu = new PauseMenu();
            pauseMenu.Show(World.Overworld);
        }


        /// <summary> Closes pause menu and unpauses the game </summary>
        public static void Resume() 
        {
            pauseMenu.Hide(World.Overworld);

            Wait = false;
        }


        /// <summary> Gets or sets whether the game has started  </summary>
        /// <returns> <see langword="true" /> if the game is running, otherwise <see langword="false" /> </returns>
        public static bool Start { get; set; }


        /// <summary> Gets or sets whether the game is paused  </summary>
        /// <returns> <see langword="true" /> if the game is paused, otherwise <see langword="false" /> </returns>
        public static bool Wait { get; set; }


        private static PauseMenu pauseMenu;
    }
}
