using UnityEngine;

namespace DefaultNamespace
{
    public static class Utils
    {
        public static float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
 
            float OldRange = (OldMax - OldMin);
            float NewRange = (NewMax - NewMin);
            float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
 
            return(NewValue);
        }
    
        public static Vector3 ToHorizontal(this Vector3 v)
        {
            return Vector3.ProjectOnPlane(v, Vector3.down);
        }

        public static float YComponent(this Vector3 v)
        {
            return Vector3.Dot(v, Vector3.up);
        }
        public static float XComponent(this Vector3 v)
        {
            return Vector3.Dot(v, Vector3.right);
        }
        
        public static float ZComponent(this Vector3 v)
        {
            return Vector3.Dot(v, Vector3.forward);
        }
	
        public static Vector3 TransformDirToHorizontal(this Transform t, Vector3 v)
        {
            return t.TransformDirection(v).ToHorizontal().normalized;
        }

        public static Vector3 InverseTransformDirToHorizontal(this Transform t, Vector3 v)
        {
            return t.InverseTransformDirection(v).ToHorizontal().normalized;
        }

        public static Vector3 ToOffsetAt(this Vector3 t, Vector3 normal, float boat)//otherwise it sinks
        {
            return t + normal * boat;
        }
        public static Vector3 Inverse(this Vector3 t)
        {
            var vec = new Vector3(-1, -1, -1);
            vec.Scale(t);
            return vec;
        }
        
        public static bool Between(this float num, float lower, float upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }
    }
}