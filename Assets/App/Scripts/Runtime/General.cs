using UnityEngine;

namespace Runtime
{
    public class General : MonoBehaviour
    {
        void Start()
        {
            var player = new Player("Player 123 ", 90);
            
            player.GetName();
            player.TakeDamage(10);
            player.ShowStat();
            
            var dragon = new Dragon("Dragon");
            
            dragon.GetName();
            dragon.TakeDamage(20);
            dragon.ShowStat();
        }
    }
}
