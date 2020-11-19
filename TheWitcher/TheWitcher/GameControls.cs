using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Travel.World;

namespace Travel
{
    /// <summary> Specifies the cardinal directions </summary>
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
    }


    /// <summary> Declares game controls  </summary>
    public class GameControls
    {
        private GameControls() { }


        /// <summary> Runs game control actions if controls pressed </summary>
        public static void KeysPressed()
        {
            GameStateKeys();
            MovementKeys();
            BattleKeys();
        }


        /// <summary> Runs game state actions if game state controls pressed </summary>
        protected static void GameStateKeys()
        {
            if (Keyboard.IsKeyDown(Key.Enter)) { Game.Pause(); }
        }


        /// <summary> Runs player movement actions if movement controls pressed </summary>
        protected static void MovementKeys()
        {
            if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))    { Player.MoveEntity(Direction.Up);    }
            if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))  { Player.MoveEntity(Direction.Left);  }
            if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))  { Player.MoveEntity(Direction.Down);  }
            if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right)) { Player.MoveEntity(Direction.Right); }
        }


        /// <summary> Runs battle actiokns if battle controls pressed </summary>
        protected static void BattleKeys()
        {
            if (Keyboard.IsKeyDown(Key.Space) && !World.Player.IsAttacking) { Player.IsAttacking = true; }
        }
    }
}
