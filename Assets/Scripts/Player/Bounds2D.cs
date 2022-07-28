using UnityEngine;
using Utils;

namespace Player
{
    public class Bounds2D : MonoBehaviour
    {
        [Header("Bounds")]
        [SerializeField] private Limit xLimit;
        [SerializeField] private Limit yLimit;
        
        [Space, Header("Gismos")]
        [SerializeField] private bool hasGizmos;
        [SerializeField] private Color gizmosColor;

        public Limit XLimit => xLimit;
        public Limit YLimit => yLimit;

        public bool IsInside(Vector2 value)
        {
            return GameUtils.IsInBounds(value, xLimit, yLimit);
        }

        public Vector2 Clamp(Vector2 value)
        {
            return new Vector2
            {
                x = Mathf.Clamp(value.x, xLimit.Min, xLimit.Max), 
                y = Mathf.Clamp(value.y, yLimit.Min, yLimit.Max)
            };
        }
        
        private void OnDrawGizmos()
        {
            if (!hasGizmos)
            {
                return;
            }
            Gizmos.color = gizmosColor;
            Gizmos.DrawLine(new Vector2(xLimit.Min, yLimit.Min), new Vector2(xLimit.Min, yLimit.Max));
            Gizmos.DrawLine(new Vector2(xLimit.Min, yLimit.Min), new Vector2(xLimit.Max, yLimit.Min));
            Gizmos.DrawLine(new Vector2(xLimit.Max, yLimit.Max), new Vector2(xLimit.Max, yLimit.Min));
            Gizmos.DrawLine(new Vector2(xLimit.Max, yLimit.Max), new Vector2(xLimit.Min, yLimit.Max));
        }

    }
}