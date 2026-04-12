using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Units;

namespace GamePrototype.Units
{
    public class HardGoblin : Goblin
    {
        public HardGoblin() : base(GameConstants.Goblin, 25, 25, 5) // Больше здоровья и урона
        {
        }

    }
}
