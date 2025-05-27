using UnityEngine;

namespace Runtime
{
    public class Dragon: Person
    {
        public Dragon(string name) : base(name)
        {
        }

        public override void TakeDamage(int damageValue) {
            Heath -= damageValue;
            
            Debug.Log($"{Name}: damage = {damageValue} My health = {Heath}");
        }
    }
}