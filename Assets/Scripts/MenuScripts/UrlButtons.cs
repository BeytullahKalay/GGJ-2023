using UnityEngine;

namespace MenuScripts
{
    public class UrlButtons : MonoBehaviour
    {
        [SerializeField] private string github;
        [SerializeField] private string linkedin;

        public void OpenGithub()
        {
            Application.OpenURL(github);
        }

        public void OpenLinkedIn()
        {
            Application.OpenURL(linkedin);
        }
    }
}
