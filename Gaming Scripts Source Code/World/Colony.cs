using UnityEngine;
using System;

namespace AppleTrail
{
    public class Colony : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Initial name of colony (serving as identificator)")]
        protected string initialName;

        [SerializeField]
        [Tooltip("Actual name of colony")]
        protected string actualName;

        [SerializeField]
        [Tooltip("Founder faction of the colony")]
        protected Faction faction;

        [SerializeField]
        [Tooltip("Date of establishment of colony (colony appears in this year)")]
        protected Founded foundedDate;

        [SerializeField]
        [Tooltip("Date of abandoning of colony (Used for population grown simulation. Trading with historicaly abandoned colonies can save it.)")]
        protected Abandoned abandonedDate;

        [SerializeField]
        [Tooltip("List of colony governers")]
        protected GovernorsList[] governors;

        [SerializeField]
        [Tooltip("Population of colony during time (Used for population grown simulation. Trading with historicaly abandoned colonies can save it.))")]
        protected Population[] population;

        [SerializeField]
        [Tooltip("Rumors for certain colony events. (Shown as dialog text. Randomly generated rumor will appear when missing. It takes few weeks to months before rumor spreads across country.)")]
        protected Rumors rumors;

        [SerializeField]
        [Tooltip("GPS location of colony for placing onto the game map (omit any value for random range)")]
        protected Position position;
    }

    [Serializable]
    public struct Position
    {
        [Tooltip("GPS latitude")]
        public double latitude;

        [Tooltip("GPS longitude")]
        public double longitude;
    }


    [Serializable]
    public struct Rumors
    {
        [Tooltip("Rummor appearing when establishing of colony")]
        public string establishing;

        [Tooltip("Rummor appearing when abandoning of colony")]
        public string abandoning;
    }

    [Serializable]
    public struct Founded
    {
        [Tooltip("Year of establishment of colony")]
        public short year;

        [Tooltip("Month of establishment of colony (Zero for establishing at January.)")]
        public byte month;

        [Tooltip("Day of establishment of colony (Zero for establishing at 1st day of month or year.)")]
        public byte day;
    }

    [Serializable]
    public struct Abandoned
    {
        [Tooltip("Year of abandoning of colony (Zero for not abandoning)")]
        public short year;

        [Tooltip("Month of abandoning of colony (Zero for abandoning at January of year when set.)")]
        public byte month;

        [Tooltip("Day of abandoning of colony (Zero for abandoning at January of year when set or at 1st day of month when set)")]
        public byte day;
    }

    [Serializable]
    public struct Population
    {
        [Tooltip("Year of known population size")]
        public short year;

        [Tooltip("Number of population to this year")]
        public int number;
    }

    [Serializable]
    public struct GovernorsList
    {
        [Tooltip("Governor GameObject")]
        public Person governor;
        [Tooltip("Date of appoitment")]
        public DateOfAppoitment dateOfAppoitment;
        [Tooltip("DateOfRevocation")]
        public DateOfRevocation dateOfRevocation;
    }

    [Serializable]
    public struct DateOfAppoitment
    {
        [Tooltip("Year of governor's appoitment")]
        public short year;

        [Tooltip("Month of governor's appoitment (Zero for appoitment at January of year when set.)")]
        public byte month;

        [Tooltip("Day of governor's appoitment (Zero for appoitment at 1st day of January of year when set or at 1st day of month when set)")]
        public byte day;
    }

    [Serializable]
    public struct DateOfRevocation
    {
        [Tooltip("Year of governor's revocation")]
        public short year;

        [Tooltip("Month of governor's revocation (Zero for abdication at January of year when set.)")]
        public byte month;

        [Tooltip("Day of governor's revocation (Zero for abdication at 1st day of January of year when set or at 1st day of month when set)")]
        public byte day;
    }
}
