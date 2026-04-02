using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems                                  //  прочность
{
    public abstract class EquipItem : Item
    {
        private uint _durability;              // прочность 
        private uint _maxDurability;         //макс прочность 
        public uint Durability { get => _durability; protected set => _durability = value; }    // преобразование в публичный
        public override bool Stackable => false;                         //

        public abstract EquipSlot Slot { get; }                         //енум список 

        protected EquipItem(uint maxDurability, string name) : base(name) => _maxDurability = maxDurability;

        public void ReduceDurability(uint delta) => _durability -= delta;

        public void Repair(uint delta) =>                                   //публичный метод ремонт 
            _durability += _durability + delta > _maxDurability // если получилось болше
            ? _maxDurability                                        //выбираем максимальноое
            : _durability + delta;                   // если нет добавляем неизвестное значение
    }
}
