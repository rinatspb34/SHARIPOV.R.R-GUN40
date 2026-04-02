using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo                    //фабрика юнитов 
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Dagger(10, 15, "Sword")); //оружие
            player.AddItemToInventory(new Armour(10, 15, "Armour")); //броня
            player.AddItemToInventory(new HealthPotion("Potion"));  //зелье 
            return player;
        }

        public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);            //создание Гоблинов
    }
}
