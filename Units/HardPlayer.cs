using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Units;



namespace GamePrototype.Units
{
    public class HardPlayer : Player
    {
        public HardPlayer(string name) : base(name, 20, 20, 4) // Меньше здоровья и урона
        {
        }

         

    }
}
