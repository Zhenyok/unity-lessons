using UnityEngine;

namespace Runtime
{
    public class Player: Person
    {
        public int Experience { get; }
        
        public Player(string name, int experience) : base(name)
        {
            Experience = experience;
        }
        
        public override void TakeDamage(int damageValue) {
            Heath -= damageValue;
            Debug.Log($"I am {Name}: damage was {damageValue} My health: {Heath}");
        }

        public override void ShowStat() {
            Debug.Log($"{Name} have {Heath} ->  HP {Experience} -> XP");
        }
    }
}