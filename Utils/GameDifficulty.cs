using GamePrototype.Dungeon;
using GamePrototype.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils
{
    public enum GameDifficulty               //уровень сложности
    {
        Easy = 1,
        Hard
    }


    public class GameDifficultySelector
    {
        public GameDifficulty Difficulty { get; private set; }
        public Unit Player { get; private set; }
        public DungeonRoom Dungeon { get; private set; }

        public void SelectAndInitialize()
        {
            Console.WriteLine("Difficulty selection");
            Console.WriteLine("1 - Easy");
            Console.WriteLine("2 - Hard");
            Console.Write("your choice: ");

            Difficulty = (GameDifficulty)int.Parse(Console.ReadLine());

            if (Difficulty == GameDifficulty.Easy)
            {
                Player = UnitFactoryDemo.CreatePlayer(GetPlayerName());
                Dungeon = DungeonBuilder.BuildDungeon();
                Console.WriteLine("Difficult Easy.\n");
            }
            else
            {
                
                Dungeon = DungeonBuilder.BuildDungeon(GameDifficulty.Hard);
                Console.WriteLine("Difficult Hard.\n");
            }
        }

        private string GetPlayerName()
        {
            Console.Write("Введите имя вашего героя: ");
            return Console.ReadLine();
        }
    }













}
