using AbstractClasses;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 13f;
    [SerializeField] private float destroyAfterSeconds = 4f;
    [SerializeField] private float detectRadius = .75f;

    public int Damage;

    public Vector3 MoveDirection;
    public LayerMask HitLayer;

    private bool _destroyed;

    private void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
        Invoke("TryDestroy", destroyAfterSeconds);
    }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, detectRadius,HitLayer);
        if (colliders.Length <= 0) return;
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out HealthSystem healthSystem))
            {
                healthSystem.TakeDamage?.Invoke(Damage);
                _destroyed = true;
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position += MoveDirection * (moveSpeed * Time.fixedDeltaTime);
    }

    private void TryDestroy()
    {
        if (_destroyed) return;

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}