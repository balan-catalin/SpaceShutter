using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ButtonHandler : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameObject.GetComponentInParent<Canvas>().gameObject.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
