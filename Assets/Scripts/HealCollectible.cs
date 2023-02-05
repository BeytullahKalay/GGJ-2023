using AbstractClasses;
using UnityEngine;

public class HealCollectible : MonoBehaviour
{
    [SerializeField] private int healAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthSystem>().Heal(healAmount);
            Debug.Log(other.GetComponent<HealthSystem>().Health);
            Destroy(gameObject);
        }
    }
}
