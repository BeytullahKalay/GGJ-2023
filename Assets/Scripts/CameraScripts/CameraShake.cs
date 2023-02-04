using System;
using DG.Tweening;
using Managers;
using Player;
using UnityEngine;

namespace CameraScripts
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float shakeDuration = .25f;
        [SerializeField] private float shakeStrength = .2f;

        private GameManager _gameManager;

        private PlayerHealthSystem _playerHealthSystem;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _playerHealthSystem = _gameManager.Player.GetComponent<PlayerHealthSystem>();
        }

        private void OnEnable()
        {
            _playerHealthSystem.TakeDamage += Shake;
        }

        private void OnDisable()
        {
            _playerHealthSystem.TakeDamage -= Shake;
        }

        private void Shake(int a)
        {
            transform.DOShakePosition(shakeDuration, Vector3.one * shakeStrength);
        }
        
    }
}
