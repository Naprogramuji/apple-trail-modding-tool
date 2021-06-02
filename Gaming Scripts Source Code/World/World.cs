using UnityEngine;
using System;

namespace AppleTrail
{
    public class World : MonoBehaviour
    {
        [Tooltip("Initial and ending years where new game take place")]
        public Year year;

        [Serializable]
        public struct Year
        {
            [Tooltip("Minimum possible year for new game")]
            public short initial;

            [Tooltip("Recommended year for new game")]
            public short recommended;

            [Tooltip("Maximum possible year for new game")]
            public short ending;
        }
    }
}
