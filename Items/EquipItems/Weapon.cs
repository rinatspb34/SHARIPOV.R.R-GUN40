using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Weapon : EquipItem                   //оружие 
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public uint Damage { get; }                                                //ДАМАГ                  НУЖНО СДЕЛАТЬ ПОСЛЕ УРОНА МИНУС ОДИН ПУНКТ ПРОЧНОСТИ

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
    public sealed class RangeWeapon : EquipItem           // диапозон оружия 
    {
        public RangeWeapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public uint Damage { get; }

        public override EquipSlot Slot => EquipSlot.RangeWeapon;
    }
}


