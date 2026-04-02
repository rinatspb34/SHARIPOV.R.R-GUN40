using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();                    //

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item))
            {
                // Обычное оружие
                if (item is Weapon weapon)
                {
                    return BaseDamage + weapon.Damage;
                }
                // НОВЫЙ КИНЖАЛ (ЗАДАЧА 3)
                else if (item is Dagger dagger)
                {
                    return dagger.CalculateTotalDamage(BaseDamage);
                }
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)                                             //в случае завершения боя мы попытаемся использовать предмет 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem)
            {
                // Пытаемся экипировать. Если слот уже занят...
                if (!_equipment.TryAdd(equipItem.Slot, equipItem))
                {
                    // Находим старый предмет
                    _equipment.TryGetValue(equipItem.Slot, out var oldItem);

                    Console.WriteLine($"Slot {equipItem.Slot} is occupied by {oldItem.Name}. Replace it with {equipItem.Name}? (y/n)");
                    var input = Console.ReadLine();
                    if (input?.ToLower() == "y")
                    {
                        // ЗАДАЧА 4: ЗАМЕНА
                        _equipment.Remove(equipItem.Slot);
                        _equipment.Add(equipItem.Slot, equipItem);
                        base.AddItemToInventory(oldItem); // Старый предмет в инвентарь
                        Console.WriteLine($"{equipItem.Name} equipped. {oldItem.Name} moved to inventory.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Replacement cancelled. {equipItem.Name} added to inventory.");
                    }
                }
                else
                {
                    // Слот был свободен
                    Console.WriteLine($"{equipItem.Name} equipped!");
                    return;
                }
            }
            // Если предмет не экипировка или замену отменили, кладём в инвентарь
            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            // Лечение зельем (было)
            if (economicItem is HealthPotion healthPotion)
            {
                Health += healthPotion.HealthRestore;
                if (Health > MaxHealth) Health = MaxHealth;
                Console.WriteLine($"Used {healthPotion.Name}, restored health to {Health}");
            }

            // ЗАДАЧА 2: ТОЧИЛЬНЫЙ КАМЕНЬ (новый код)
            if (economicItem is Grindstone grindstone)
            {
                // Ищем экипированное оружие
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var weapon) && weapon is EquipItem equipWeapon)
                {
                    uint repairAmount = 20; // Можно вынести в константу
                    equipWeapon.Repair(repairAmount);
                    Console.WriteLine($"Used {grindstone.Name} on {equipWeapon.Name}. Durability restored by {repairAmount}. Current durability: {equipWeapon.Durability}");
                }
                else
                {
                    Console.WriteLine($"Cannot use {grindstone.Name}: No weapon equipped!");
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
            {
                // Рассчитываем урон с защитой
                uint reducedDamage = damage - (uint)(damage * (armour.Defence / 100f));

                // Уменьшаем прочность брони на 1 (ЗАДАЧА 1)
                armour.ReduceDurability(1);
                Console.WriteLine($"{Name}: {armour.Name} durability is now {armour.Durability}");

                // Если броня сломалась, снимаем её
                if (armour.Durability == 0)
                {
                    Console.WriteLine($"{Name}: {armour.Name} is broken and unequipped!");
                    _equipment.Remove(EquipSlot.Armour);
                }

                return reducedDamage;
            }
            return damage;
        }

        public override string ToString()                   //вывод информации о игроке 
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
