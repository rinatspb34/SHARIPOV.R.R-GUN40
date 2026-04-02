namespace GamePrototype.Items.EconomicItems
{
    public sealed class Grindstone : EconomicItem                 //точильный камень 
    {
        public override bool Stackable => false;

        public Grindstone(string name) : base(name)
        {
        }    
    }
}
