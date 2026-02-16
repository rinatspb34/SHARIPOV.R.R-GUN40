using static HomeWork.Weapon;

namespace HomeWork
{
   public struct Interval
    {
        private static Random _random = new Random();
        public int Min { get; }
        public int Max { get; }

        public float Get()
        {
            return (float)(_random.NextDouble() * (Max - Min) + Min) ;
        }

        public Interval(int minValue, int maxValue)
        {
            if (minValue < 0)                                                       // Проверка на отрицательные
            {
                Console.WriteLine("Некорректные данные, устанавлииваем: 0");
                    minValue = 0;
            }

            if (maxValue < 0)
            {
                Console.WriteLine("Некорректные данные, устанавлииваем: 0");
                maxValue = 0;
            }

            if (minValue > maxValue)                                                // Если min больше max, меняем местами
            {
                Console.WriteLine("Некорректные данные, меняем местами");
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;

            }

            if ( minValue == maxValue )                                           // Увеличиваеи max при равности на 10
            {
                Console.WriteLine("Некорректные данные, увеличиваем max на 10");
                maxValue += 10;
            }
            Min = minValue;
            Max = maxValue; 
        }

    }
   
    public class Weapon
    {
        public string Name { get; set;  }
        public Interval DamageInterval { get; set; }

        public Weapon()
        {
            Name = "Unknown Weapon";
            DamageInterval = new Interval(5, 15);
        }

        public Weapon(string name)
        {
            Name = name;
            DamageInterval = new Interval(5,15);
        }

        public Weapon(string name, int minDamage, int maxDamage)
        {
            Name = name;
            DamageInterval = new Interval(minDamage, maxDamage);
        }

        public override string ToString()
        {
            return $"{Name}(урон:{DamageInterval.Min} - {DamageInterval.Max}) ";
        }

      public struct Room
        {
            public Unit Unit { get; set; }
            public Weapon Weapon { get; set; }

            public Room(Unit unit, Weapon weapon)
            {
                Unit = unit;
                Weapon = weapon;
            }
        }

       

    }

    public class Dungeon
    {
        private Room[] rooms;

        public Dungeon()
        {
            rooms = new Room[]
            {
                    new Room(new Unit("Рыцарь"), new Weapon("Меч", 10, 20)), new Room(new Unit("Лучник"), new Weapon("Лук", 5, 15)),
                    new Room(new Unit("Маг"),new Weapon("Посох", 8, 25)),  new Room(new Unit("Монстр"),new Weapon("Когти", 3, 12))
            };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine($"Unit of room {i + 1}: {room.Unit}");
                Console.WriteLine($"Weapon of room {i + 1}: {room.Weapon}");
                Console.WriteLine("---");
            }


        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();

            Console.WriteLine("\nТест Interval.Get():");
            Weapon testWeapon = new Weapon("Тест", 10, 20);
            for (int i = 0; i <3; i++)
            {
                Console.WriteLine($"Случайный урон:{testWeapon.DamageInterval.Get():F1}");
            }
        }
    }
}
