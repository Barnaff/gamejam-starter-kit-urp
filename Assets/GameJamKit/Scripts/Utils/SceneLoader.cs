using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJamKit.Scripts.Utils
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}