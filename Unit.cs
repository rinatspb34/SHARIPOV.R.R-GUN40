using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    public class Unit
    {
       public string Name { get;  }                          // Свойства
        private float _health ;
        public float Health => _health;

        public int Damage {  get; }
        public float Armor { get; }


        public Unit() : this("Unknown Unit")                     // Конструкторы
        {

        }

        public Unit(string name)
        {
            _health = 100f;
            Name = name;
            Damage = 5;
            Armor = 0.6f;
        }


        public float GetRealHealth()
        {
            return _health * (1f + Armor);
        }

        public bool SetDamage(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }


            _health -= value * Armor;
            return _health <= 0f;
        }


      
    }
}

