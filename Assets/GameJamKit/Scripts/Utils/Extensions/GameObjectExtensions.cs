using UnityEngine;

namespace GameJamKit.Scripts.Utils.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        ///     Gets or add a component. Usage example:
        ///     BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (result == null) result = gameObject.AddComponent<T>();
            return result;
        }
    }
}