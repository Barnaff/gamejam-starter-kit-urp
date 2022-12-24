using UnityEngine;

namespace GameJamKit.Scripts.Utils
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}