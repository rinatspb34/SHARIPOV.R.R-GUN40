using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder                                 //конструктор подземелий        ДВЕ РЕАЛИЗАЦИИ 
    {
        

        public static DungeonRoom BuildDungeon()
        { 

            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy()); //комната с монстром
            var emptyRoom = new DungeonRoom("Empty");           //пустой
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Whetstone"));
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

        public static DungeonRoom BuildDungeon(GameDifficulty difficulty)
        {
            if (difficulty == GameDifficulty.Easy)
            {
                                                            //для лёгкой используем старое подземелье
                return BuildDungeon();
            }
            else                                 
            {
                                                                                    //более опасное подземелье с сильными врагами
                var enter = new DungeonRoom("Dark Entrance");
                var hardGoblinRoom = new DungeonRoom("Goblin Camp", UnitFactoryDemo.CreateHardGoblinEnemy());
                var trapRoom = new DungeonRoom("Trap Room");
                var secondGoblinRoom = new DungeonRoom("Goblin Ambush", UnitFactoryDemo.CreateHardGoblinEnemy());
                var finalRoom = new DungeonRoom("Goblin King", UnitFactoryDemo.CreateHardGoblinEnemy());

                enter.TrySetDirection(Direction.Right, hardGoblinRoom);
                hardGoblinRoom.TrySetDirection(Direction.Forward, trapRoom);
                trapRoom.TrySetDirection(Direction.Right, secondGoblinRoom);
                secondGoblinRoom.TrySetDirection(Direction.Forward, finalRoom);

                return enter;
            }
        }



    }
}
