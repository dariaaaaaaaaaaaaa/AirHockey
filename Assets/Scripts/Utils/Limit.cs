using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class Limit
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min => min;
        public float Max => max;

        public Limit(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
}