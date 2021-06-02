using UnityEngine;
using System;

namespace AppleTrail
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Name of person")]
        protected string name;

        [SerializeField]
        [Tooltip("Gender of person")]
        protected Gender gender;

        [SerializeField]
        [Tooltip("Titles of person")]
        protected Title[] titles;
    }

    [Serializable]
    public struct Title
    {
        [Tooltip("Date of obtaining a title")]
        public TitleObtainingDate titleObtainingDate;

        [Tooltip("Name of the title")]
        public string title;
    }

    [Serializable]
    public struct TitleObtainingDate
    {
        [Tooltip("Year of obtaining of the title")]
        public short year;

        [Tooltip("Month of obtaining of the title (obtained Jan 1st when zero)")]
        public byte month;

        [Tooltip("Day of obtaining of the title (obtained 1st day in month or Jan 1st when zero)")]
        public byte day;
    }
}
