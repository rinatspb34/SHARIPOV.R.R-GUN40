namespace HomeWork
{
   
   

    internal class Program
    {
        static void Main(string[] args)
        {
            Unit warrior = new Unit("Воин");
            Console.WriteLine($"Имя: {warrior.Name}");
            Console.WriteLine($"Здоровье: {warrior.Health}");
            Console.WriteLine($"Урон: {warrior.Damage}");
            Console.WriteLine($"Броня: {warrior.Armor}");
            Console.WriteLine($"Фактическое здоровье: {warrior.GetRealHealth()}");

            bool isDead = warrior.SetDamage(60);
            Console.WriteLine($"Атака 60: Здоровье = {warrior.Health}, Юнит мертв: {isDead}");

            isDead = warrior.SetDamage(110);
            Console.WriteLine($"Атака 110: Здоровье = {warrior.Health}, Юнит мертв: {isDead}");

            


        }
    }
}
