using AbstractClasses;
using UnityEngine;

public class HealCollectible : MonoBehaviour
{
    [SerializeField] private int healAmount = 10;
    [SerializeField] private GameObject healVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthSystem>().Heal(healAmount);
            Debug.Log(other.GetComponent<HealthSystem>().Health);
            Instantiate(healVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
