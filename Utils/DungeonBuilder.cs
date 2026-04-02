using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder                                 //конструктор подземелий    
    {
        public static DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy()); //комната с монстром
            var emptyRoom = new DungeonRoom("Empty");           //пустой
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);              //праваМонстр
            enter.TrySetDirection(Direction.Left, emptyRoom);               //левоПусто

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);        //вперёд Лут
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);         //назад Пусто

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);        //вперед Точилльный камень

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);           //вперед Финальная комната
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);       

            return enter;
        }
    }
}
