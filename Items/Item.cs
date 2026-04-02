namespace GamePrototype.Items.EconomicItems
{
    public abstract class Item
    {
        public abstract bool Stackable { get; } //Стакается / валюта 

        public virtual uint Amount { get; protected set; }  //Длина

        public string Name { get; }           //Имя

        protected Item(string name)       // конструктор Элемент
        {
            Name = name;
            Amount = 1;
        }

        public bool TryStack(Item item)                    //публичный конструктор ВозможныйСтек            проверка являестя ли стеком/валютой 
        {
            if (!Stackable)                         //если не стакается возвращается фолс
            {
                return false;                    //если стакается увеличиваем колличество монет 
            }
            Amount++;
            return true;
        }
    }
}
