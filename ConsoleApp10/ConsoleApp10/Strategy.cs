using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Strategy
    {
       
    

        public interface IAttackStrategy
        {
            void Attack();
        }

        public class MeleeAttack : IAttackStrategy
        {
            public void Attack()
            {
                Console.WriteLine("удар мечом");
            }
        }

        public class RangedAttack : IAttackStrategy
        {
            public void Attack()
            {
                Console.WriteLine("стреляет из лука");
            }
        }

        public class MagicAttack : IAttackStrategy
        {
            public void Attack()
            {
                Console.WriteLine("использует огненный шар");
            }
        }

        public class Player
        {
            private IAttackStrategy _attackStrategy;

            public void SetAttackStrategy(IAttackStrategy strategy)
            {
                _attackStrategy = strategy;
            }

            public void PerformAttack()
            {
                if (_attackStrategy == null)
                {
                    Console.WriteLine("Игрок не выбрал стратегию");
                    return;
                }
                _attackStrategy.Attack();
            }


        }
    }


 
}
