namespace GamePrototype.Items.EconomicItems
{
    public sealed class HealthPotion : EconomicItem             // зелье здоровья
    {
        public uint HealthRestore => 7;                      //востановить
        public override bool Stackable => false;

        public HealthPotion(string name) : base(name)
        {
        }      
    }
}
