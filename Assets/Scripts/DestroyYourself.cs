using UnityEngine;

public class DestroyYourself : MonoBehaviour
{
    [SerializeField] private float destroyAfterSeconds = 1f;
    private void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);
    }
}
