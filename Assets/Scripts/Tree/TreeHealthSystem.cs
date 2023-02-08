using AbstractClasses;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Tree
{
    public class TreeHealthSystem : HealthSystem
    {
        [Header("Shake Values")]
        [SerializeField] private float shakeStrength = .75f;
        [SerializeField] private float shakeDuration = .15f;
        
        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);
            transform.DOShakeScale(shakeDuration, Vector3.one * shakeStrength);
        }

        public override void Die()
        {
            base.Die();
            Debug.Log("Game Over");
            EventManager.GameOver?.Invoke();
        }
    }
}