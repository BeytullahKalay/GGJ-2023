using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class HealthSystem : MonoBehaviour, IHealthSystem
    {

        [SerializeField] protected int maxHealth = 100;
        [SerializeField] private Slider slider;

        public int Health { get; set; }

        public Action<int> TakeDamage;
        public Action OnDead;

        protected Rigidbody rb;
        protected Collider coll;

        protected virtual void OnEnable()
        {
            TakeDamage += GetDamage;
            OnDead += Die;
        }

        protected virtual void OnDisable()
        {
            TakeDamage -= GetDamage;
            OnDead -= Die;
        }

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            coll = GetComponent<Collider>();
        }

        public virtual void Start()
        {
            Health = maxHealth;
            slider.value = Health / maxHealth;
        }

        public virtual void GetDamage(int damage)
        {
            Health -= damage;
            Health = Mathf.Clamp(Health, 0, maxHealth);
            slider.value = (float)Health / maxHealth;
            if (Health <= 0) OnDead.Invoke();
        }

        public virtual void Die()
        {
            rb.isKinematic = true;
            coll.enabled = false;
            slider.gameObject.SetActive(false);
            Debug.Log( transform.name +" is Dead");
        }

        public virtual void Heal(int healAmount)
        {
            Health += healAmount;
            Health = Mathf.Clamp(Health, 0, maxHealth);
            slider.value = (float)Health / maxHealth; 
        }

        public virtual void Knockback(Transform attackTransform, float knocbackForce)
        {
            var dir = (transform.position - attackTransform.position).normalized;
            rb.AddForce(dir * knocbackForce, ForceMode.Impulse);
        }
    }
}