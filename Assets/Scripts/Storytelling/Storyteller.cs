using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Storytelling
{
    public class Storyteller : MonoBehaviour
    {
        [SerializeField] private float waitTimeForALetterHolder = .02f;

        [SerializeField] private GameObject clickToContinue;
        [SerializeField] private TMP_Text _tmpText;

        [SerializeField] private List<string> sentences = new List<string>();

        [SerializeField] private float animationDuration = 1f;
        [SerializeField] private float moveYPos = 2;

        private Vector3 _startPosition;

        private bool _isSentenceEnd;

        private int _index;

        private Tween _tween;

        private void Start()
        {
            _startPosition = _tmpText.transform.position;
            StartCoroutine(Type());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextSentence();
            }
        }


        private IEnumerator Type()
        {
            _isSentenceEnd = false;
            clickToContinue.SetActive(false);

            _tween = _tmpText.transform.DOMoveY(moveYPos, animationDuration).From();

            foreach (var letter in sentences[_index].ToCharArray())
            {
                _tmpText.text += letter;
                yield return new WaitForSeconds(waitTimeForALetterHolder);
            }

            _isSentenceEnd = true;
            clickToContinue.SetActive(true);
        }

        private void NextSentence()
        {
            if (!_isSentenceEnd)
            {
                _tween?.Kill();
                _tmpText.transform.position = _startPosition;
                _tmpText.text = sentences[_index];
                _isSentenceEnd = true;
                StopAllCoroutines();
                clickToContinue.SetActive(true);
            }
            else
            {
                if (_index < sentences.Count - 1)
                {
                    _index++;
                    _tmpText.text = "";
                    StartCoroutine(Type());
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    _tmpText.text = "";
                }
            }
        }
    }
}