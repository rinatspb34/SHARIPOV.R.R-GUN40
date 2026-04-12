using GamePrototype.Items.EconomicItems;
using GamePrototype.Units;

namespace GamePrototype.Dungeon
{
    public sealed class DungeonRoom                                           //комната подземелья
    {      
        public readonly string Name;
        public readonly Unit Enemy;
        public readonly Item Loot;
        public readonly Dictionary<Direction, DungeonRoom> Rooms = new();                           //словарь<направление, комнатаПодземелья> Комнаты = новый()
        public bool IsFinal => Rooms.Count == 0;            //финал если комнат нету

        public DungeonRoom(string name) => Name = name;                   //ПУСТАЯ КОМНАТА

        public DungeonRoom(string name, Unit enemy)                          //КОМНАТА С ЮНИТОМ
        {
            Name = name;
            Enemy = enemy;
        }

        public DungeonRoom(string name, Item item)                       //КОМНАТА С ПРЕДМЕТОМ
        {
            Name = name;
            Loot = item;
        }

        public bool TrySetDirection(Direction direction, DungeonRoom room)     //попробовать установить Словарь  ПЕРЕДВИЖЕНИЕ 
        {
            if (Rooms.ContainsKey(direction))                                                    //если Комната существует
            {
                Console.WriteLine($"Room {Name} already has room for {direction.ToString()}"); //вывод ошибку 
                return false;
            }
            Rooms.Add(direction, room);                              //если нет добавит комнату
            return true;
        }
    }
}
