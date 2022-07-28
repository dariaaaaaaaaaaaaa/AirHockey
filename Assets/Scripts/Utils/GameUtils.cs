using UnityEngine;

namespace Utils
{
    public static class GameUtils
    {
        public static bool IsInBounds(float value, float min, float max, bool debug = false)
        {
            if (debug)
            {
                Debug.Log($"V: {value}; Min: {min}; Max{max}; Is: {value > min && value < max}");
            }
            return value > min && value < max;
        }
    
        public static bool IsInBounds(Vector2 value, Vector2 min, Vector2 max)
        {
            return IsInBounds(value.x, min.x, max.x) && IsInBounds(value.y, min.y, max.y); 
        }
        
        public static bool IsInBounds(Vector2 value, Limit xLimit, Limit yLimit)
        {
            return IsInBounds(value.x, xLimit.Min, xLimit.Max) && IsInBounds(value.y, yLimit.Min, yLimit.Max);
        }
    }
}