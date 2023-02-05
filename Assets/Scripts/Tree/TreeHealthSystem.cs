using AbstractClasses;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Tree
{
    public class TreeHealthSystem : HealthSystem
    {
        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);
            transform.DOShakeScale(.2f, Vector3.one * 2);
        }

        public override void Die()
        {
            base.Die();
            Debug.Log("Game Over");
            EventManager.LevelCompleted?.Invoke();
        }
    }
}