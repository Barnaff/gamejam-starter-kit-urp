using UnityEngine;

namespace GameJamKit.Scripts.Utils.Extensions
{
    public static class ComponentExtensions
    {
        /// <summary>
        ///     Gets or add a component. Usage example:
        ///     BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
        /// </summary>
        public static T GetOrAddComponent<T>(this Component child) where T : Component
        {
            var result = child.GetComponent<T>();
            if (result == null) result = child.gameObject.AddComponent<T>();
            return result;
        }
    }
}