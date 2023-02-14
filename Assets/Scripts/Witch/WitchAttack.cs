using AbstractClasses;
using Unit;
using Unity.Mathematics;
using UnityEngine;

namespace Witch
{
    [RequireComponent(typeof(MinionFindOpponent))]
    public class WitchAttack : AttackSystem
    {
        [SerializeField] private GameObject bullet;

        [SerializeField] private float timeBetweenAttacks = 2f;

        private MinionFindOpponent _minionFindOpponent;

        private Transform _closestOpponent;

        public float NextAttackTime { get; set; }


        private void Awake()
        {
            _minionFindOpponent = GetComponent<MinionFindOpponent>();
            NextAttackTime = float.MinValue;
        }

        private void Start()
        {
            _closestOpponent = _minionFindOpponent.FindClosestOpponent();
        }

        public override void Attack()
        {
            InitializeSpawnBullet(attackPoint.position);
        }


        private void InitializeSpawnBullet(Vector3 spawnPosition)
        {
            var obj = Instantiate(bullet, spawnPosition, quaternion.identity);
            var bulletScript = obj.GetComponent<Bullet>();
            bulletScript.HitLayer = WhatIsHitLayer;
            bulletScript.MoveDirection = (_closestOpponent.position - transform.position).normalized;
            bulletScript.Damage = damage;
        }

        public void SetNextAttackTime()
        {
            NextAttackTime = Time.time + timeBetweenAttacks;
        }
    }
}