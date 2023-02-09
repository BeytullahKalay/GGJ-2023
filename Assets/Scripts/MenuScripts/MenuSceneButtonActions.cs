using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuScripts
{
    public class MenuSceneButtonActions : MonoBehaviour
    {
        [SerializeField] private GameObject howToPlayPanel;
        [SerializeField] private GameObject menuPanel;
        public void Play()
        {
            Debug.Log("Load Next scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void HowToPlay()
        {
            Debug.Log("How To Play");
            menuPanel.SetActive(false);
            howToPlayPanel.SetActive(true);
        }

        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        public void Back()
        {
            howToPlayPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }
}