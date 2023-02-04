using Player;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private PlayerHealthSystem playerHealthSystem;
    [SerializeField] private int damage = 25;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealthSystem.TakeDamage?.Invoke(damage);
        }
    }
}
