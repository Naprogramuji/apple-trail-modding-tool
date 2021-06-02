using UnityEngine;
using System;

namespace AppleTrail
{
    public class World : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Initial and ending years where new game take place")]
        protected Year year;
    }

    [Serializable]
    public struct Year
    {
        [Tooltip("Minimum possible year for new game")]
        public short initial;
        [Tooltip("Maximum possible year for new game")]
        public short ending;
    }
}
