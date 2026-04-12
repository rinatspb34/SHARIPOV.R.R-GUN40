using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;
using System.ComponentModel;

namespace GamePrototype.Utils
{
    //public abstract class UnitFactory
    //{
    //    public abstract Player CreatePlayer();
    //    public abstract Goblin CreateEnemy(string name);

    //}

    



    

   
    public class UnitFactoryDemo                  //фабрика юнитов                    
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Dagger(15, 20, "Sword")); //оружие
            player.AddItemToInventory(new Armour(15, 20, "Armour")); //броня
            player.AddItemToInventory(new HealthPotion("Potion"));  //зелье 
            return player;
        }

        public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);            //создание Гоблинов
    }

    public static Unit CreateHardPlayer(string name) => new HardPlayer(name);

        public static Unit CreateHardGoblinEnemy() => new HardGoblin();




    }
