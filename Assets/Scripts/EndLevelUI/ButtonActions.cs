using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndLevelUI
{
    public class ButtonActions : MonoBehaviour
    {
        public void Quit()
        {
            Application.Quit();
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}