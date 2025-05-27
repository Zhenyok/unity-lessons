using UnityEngine;

namespace Runtime
{
    public abstract class Person
    {
        protected string Name { get; }
        
        private int _health = 100;
        public int Heath {
            get => _health;
            set {
                _health = value;
                _health = Mathf.Clamp(_health, 0, 100);

                if (_health == 0)
                {
                    Debug.Log("No health");
                } 
                else if (_health == 100)
                {
                    Debug.Log("Health is full");
                }
            }
        }
        
        protected Person(string name) {
            Name = name;
        }

        public abstract void TakeDamage(int damageValue);

        public virtual void ShowStat() {
            Debug.Log($"{Name} with {_health} health");
        }
        
        public void GetName() {
            Debug.Log($"My name is {Name}");
        }
    }
}