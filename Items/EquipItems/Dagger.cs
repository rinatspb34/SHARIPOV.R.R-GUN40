using GamePrototype.Utils;



namespace GamePrototype.Items.EquipItems
{
    public sealed class Dagger : EquipItem
    {
        public uint Damage { get; }
        private readonly double _doubleStrikeChance = 0.3; 

        public Dagger(uint damage, uint durability, string name) : base(durability, name)
        {
            Damage = damage;
        }

        
        public uint CalculateTotalDamage(uint baseDamage)
        {
            uint totalDamage = baseDamage + Damage;

            Random random = new Random();
            if (random.NextDouble() <= _doubleStrikeChance)
            {
                Console.WriteLine($"*** {Name} наносит двойной удар! ***");
                totalDamage += (baseDamage + Damage);
            }
            return totalDamage;
        }

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}