using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameJamKit.Scripts.Utils.Singleton
{
    /**
 * Utility class for handling singleton ScriptableObjects for data management
 */
    public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
    {
        private static string FileName => typeof(T).Name;

#if UNITY_EDITOR
        private static string AssetPath => "Assets/Resources/" + FileName + ".asset";
#endif

        private static string ResourcePath => FileName;

        public static T Instance
        {
            get
            {
                if (cachedInstance == null) cachedInstance = Resources.Load(ResourcePath) as T;
#if UNITY_EDITOR
                if (cachedInstance == null) cachedInstance = CreateAndSave();
#endif
                if (cachedInstance == null)
                {
                    Debug.LogWarning("No instance of " + FileName + " found, using default values");
                    cachedInstance = CreateInstance<T>();
                    cachedInstance.OnCreate();
                }

                return cachedInstance;
            }
        }

        private static T cachedInstance;

#if UNITY_EDITOR
        protected static T CreateAndSave()
        {
            var instance = CreateInstance<T>();
            instance.OnCreate();
            //Saving during Awake() will crash Unity, delay saving until next editor frame
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                EditorApplication.delayCall += () => SaveAsset(instance);
            else
                SaveAsset(instance);
            return instance;
        }

        private static void SaveAsset(T obj)
        {
            var dirName = Path.GetDirectoryName(AssetPath);
            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);
            AssetDatabase.CreateAsset(obj, AssetPath);
            AssetDatabase.SaveAssets();
            Debug.Log("Saved " + FileName + " instance");
        }
#endif

        protected virtual void OnCreate()
        {
            // Do setup particular to your class here
        }
    }
}