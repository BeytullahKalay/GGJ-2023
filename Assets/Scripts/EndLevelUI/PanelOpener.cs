using EndLevelUI.Abstract;
using Managers;
using UnityEngine;

namespace EndLevelUI
{
    public class PanelOpener : MonoBehaviour
    {
        [SerializeField] private Callable winCallable;
        [SerializeField] private Callable loseCallable;

        private void OnEnable()
        {
            EventManager.LevelCompleted += OpenWinCallable;
            EventManager.GameOver += OpenLoseCallable;
        }

        private void OnDisable()
        {
            EventManager.LevelCompleted -= OpenWinCallable;
            EventManager.GameOver -= OpenLoseCallable;
        }

        private void OpenWinCallable()
        {
            winCallable.gameObject.SetActive(true);
            winCallable.Action?.Invoke();
        }

        private void OpenLoseCallable()
        {
            loseCallable.gameObject.SetActive(true);
            loseCallable.Action?.Invoke();
        }
    }
}
