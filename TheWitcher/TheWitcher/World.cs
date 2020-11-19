using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Travel.Entities;
using Travel.Entities.Health;
using Travel.Entities.Money;
using Travel.Entities.Monsters;

namespace Travel
{
    /// <summary> Implements the world form and game features </summary>
    public partial class World : Form
    {
        /// <summary> Instantiates the World form </summary>
        public static void Create()
        {
            if (Overworld == null)
                Overworld = new World();
        }


        /// <summary> Initialises a new instance of World </summary>
        private World()
        {
            InitializeComponent();
            
            SpawnBorders();
        }


        /// <summary> Display Pause Menu when World form loaded </summary>
        private void World_Load(object sender, EventArgs e)
        {
            Game.Pause();
        }


        /// <summary> Add player to game and starts game timer </summary>
        public void Start()
        {
            this.Controls.Add(Player);
            gameTimer.Enabled = true;
        }


        /// <summary> Sets up entity variables </summary>
        private void Setup()
        {
            Player = new User();

            Monsters = new List<Monster>();
            Money = new List<Money>();
            Health = new List<Health>();
        }


        /// <summary> Stops all entities </summary>
        public void Stop()
        {
            // Stop anything still running
            if (Player != null && Monsters != null && Money != null && Health != null)
            {
                Player.Stop();
                this.Controls.Remove(Player);

                foreach (Monster monster in World.Monsters) 
                { 
                    monster.Stop(); 
                    this.Controls.Remove(monster); 
                }

                foreach (Money money in World.Money) 
                { 
                    money.Stop(); 
                    this.Controls.Remove(money); 
                }

                foreach (Health health in World.Health) 
                { 
                    health.Stop(); 
                    this.Controls.Remove(health); 
                }
            }
        }


        /// <summary> Stops game and sets up entity variables </summary>
        public void Reset()
        {
            Stop();
            Setup();
        }


        /// <summary> Timer loops every 10 ticks, updating the world </summary>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Game Paused
            if (Game.Wait) { return; }


            // After 1 second (1,000 ticks)
            if (this.tickCount++ % 100 == 0)
                SpawnEntity();


            // Update Labels
            StatusBar();
        }


        /// <summary> Displays the Player's status on the status bar </summary>
        private void StatusBar()
        {
            healthLbl.Text = ((double)Player.Health / Player.FullHealth * 100).ToString() + "%"; 
            coinsLbl.Text = Player.Money.ToString("D3"); // Display three digits
        }


        /// <summary> Spawns a random entity in the world </summary>
        public void SpawnEntity()
        {
            NPC entity = null;
            
            switch (random.Next(0, 3)) // Number is >= 0 and < 3
            {
                // Monster
                case 0:
                    entity = RandomMonster();
                    Monsters.Add((Monster)entity);
                    this.Controls.Add(entity);
                    break;

                // Money
                case 1:
                    entity = RandomMoney();
                    Money.Add((Money)entity);
                    this.Controls.Add(entity);
                    break;

                // Health
                case 2:
                    entity = RandomHealth();
                    Health.Add((Health)entity);
                    this.Controls.Add(entity); 
                    break;

                default:
                    break;
            }
        }


        /// <summary> Creates a random Monster entity </summary>
        private Monster RandomMonster()
        {
            // Array of Creatures enum
            Creatures[] creatures = Enum.GetValues(typeof(Creatures)).Cast<Creatures>().ToArray(); 

            int maxVal = creatures.Sum(x => (int)x);
            int randNum = random.Next(0, maxVal);
            int totalRarity = 0;


            // Loop until monster selected 
            foreach (Creatures creature in creatures)
            {
                int rarity = (int)creature;

                // Return Monster entity if selected
                if (randNum < rarity + totalRarity)
                    return MonsterFactory.Create(creature);

                totalRarity += rarity;
            }


            return null;
        }


        /// <summary> Creates a random Money entity </summary>
        private Money RandomMoney()
        {
            // Array of Coins enum
            Coins[] coins = Enum.GetValues(typeof(Coins)).Cast<Coins>().ToArray();

            int maxVal = coins.Sum(x => (int)x);
            int randNum = random.Next(0, maxVal);
            int totalRarity = 0;


            // Loop until monster selected 
            foreach (Coins coin in coins)
            {
                int rarity = (int)coin;

                // Return Money entity if selected 
                if (randNum < rarity + totalRarity)
                    return MoneyFactory.Create(coin);

                totalRarity += rarity;
            }


            return null;
        }


        /// <summary> Creates a random Health entity </summary>
        private Health RandomHealth()
        {
            // Array of Recovery enum
            Recovery[] recovery = Enum.GetValues(typeof(Recovery)).Cast<Recovery>().ToArray(); 
            
            int maxVal = recovery.Sum(x => (int)x);
            int randNum = random.Next(0, maxVal);
            int totalRarity = 0;


            // Loop until monster selected 
            foreach (var recover in recovery)
            {
                int rarity = (int)recover;

                // Return Health entity if selected 
                if (randNum < rarity + totalRarity)
                    return HealthFactory.Create(recover);

                totalRarity += rarity;
            }


            return null;
        }


        /// <summary> Sets the areas where entitys can spawn from </summary>
        private void SpawnBorders()
        {
            int spacing = 25;

            SpawnRightEdge = new Points
            {
                Start = new Point(this.Width, spacing),
                End = new Point(this.Width, this.Height - spacing),
            };


            SpawnLeftEdge = new Points
            {
                Start = new Point(0, spacing),
                End = new Point(0, this.Height - spacing),
            };


            SpawnTopEdge = new Points
            {
                Start = new Point(spacing, 0),
                End = new Point(this.Width - spacing, 0),
            };


            SpawnBottomEdge = new Points
            {
                Start = new Point(spacing, this.Height),
                End = new Point(this.Width - spacing, this.Height),
            };
        }


        /// <summary> Sets two different points </summary>
        public class Points
        {
            /// <summary> Gets and sets the starting location </summary>
            public Point Start { get; set; }

            /// <summary> Gets and sets the ending location </summary>
            public Point End { get; set; }
        }


        /// <summary> Gets or privately sets the World form instance </summary>
        public static World Overworld { get; private set; }


        /// <summary> Gets or privately sets a User instance </summary>
        public static User Player { get; private set; }


        /// <summary> Gets or privately sets a list of Monsters </summary>
        public static List<Monster> Monsters { get; private set; }


        /// <summary> Gets or privately sets a list of Money </summary>
        public static List<Money> Money { get; private set; }


        /// <summary> Gets or privately sets a list of Health </summary>
        public static List<Health> Health { get; private set; }


        /// <summary> Gets and privately sets the right edge spawn area </summary>
        public Points SpawnRightEdge { get; private set; }


        /// <summary> Gets and privately sets the left edge spawn area </summary>
        public Points SpawnLeftEdge { get; private set; }


        /// <summary> Gets and privately sets the top edge spawn area </summary>
        public Points SpawnTopEdge { get; private set; }


        /// <summary> Gets and privately sets the bottom edge spawn area </summary>
        public Points SpawnBottomEdge { get; private set; }


        private int tickCount = 0;
        private Random random = new Random();
    }
}
