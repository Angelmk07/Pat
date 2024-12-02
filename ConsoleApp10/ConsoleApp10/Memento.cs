using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Memento
    {
        public class PlayerState
        {
            public int Health { get; private set; }
            public int Mana { get; private set; }

            public PlayerState(int health, int mana)
            {
                Health = health;
                Mana = mana;
            }
        }

        public class StatefulPlayer : Player
        {
            public StatefulPlayer(int health, int mana) : base(health, mana) { }

            public PlayerState SaveState()
            {
                Console.WriteLine("Состояние игрока сохранено.");
                return new PlayerState(Health, Mana);
            }

            public void RestoreState(PlayerState state)
            {
                Console.WriteLine("Состояние игрока восстановлено.");
                typeof(Player).GetProperty("Health").SetValue(this, state.Health);
                typeof(Player).GetProperty("Mana").SetValue(this, state.Mana);
            }
        }

        public class PlayerHistory
        {
            private readonly Stack<PlayerState> _history = new Stack<PlayerState>();

            public void Save(PlayerState state)
            {
                _history.Push(state);
            }

            public PlayerState Restore()
            {
                if (_history.Count == 0)
                    throw new InvalidOperationException("Нет сохранённых состояний.");
                return _history.Pop();
            }
        }
        public class Player
        {

            public int Health { get; private set; }
            public int Mana { get; private set; }

            public Player(int health, int mana)
            {
                Health = health;
                Mana = mana;
            }



        }
    }
}
