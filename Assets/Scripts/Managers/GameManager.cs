using UnityEngine;

namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private Transform player;


        
        
        
        public Transform Player => player;
    }
}
