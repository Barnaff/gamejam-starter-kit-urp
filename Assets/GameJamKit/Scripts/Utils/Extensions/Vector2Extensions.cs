using UnityEngine;

namespace GameJamKit.Scripts.Utils.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 SetX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }
	
        public static Vector2 SetY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }
	
        public static Vector3 ToVector3(this Vector2 v)
        {
            return new Vector3(v.x, v.y, 0);
        }
   
    }
}