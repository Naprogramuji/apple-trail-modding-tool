using UnityEngine;
using System;

namespace AppleTrail
{
    public class Colony : MonoBehaviour
    {
        [Tooltip("Initial name of colony (serving as identificator)")]
        public string initialName;

        [Tooltip("Actual name of colony")]
        public string actualName;

        [Tooltip("Founder faction of the colony")]
        public Faction faction;

        [Tooltip("Date of establishment of colony (colony appears in this year)")]
        public FoundedDate foundedDate;

        [Tooltip("Date of abandoning of colony (Used for population grown simulation. Trading with historicaly abandoned colonies can save it.)")]
        public Abandoned abandonedDate;

        [Tooltip("List of colony governers")]
        public GovernorsList[] governors;

        [Tooltip("Population of colony during time (Used for population grown simulation. Trading with historicaly abandoned colonies can save it.))")]
        public Population population;

        [Tooltip("Rumors for certain colony events. (Shown as dialog text. Randomly generated rumor will appear when missing. It takes few weeks to months before rumor spreads across country.)")]
        public Rumors rumors;

        [Tooltip("GPS location of colony for placing onto the game map (omit any value for random range)")]
        public Position position;

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
        public struct FoundedDate
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
        public struct PopulationHistory
        {
            [Tooltip("Year of known population size")]
            public short year;

            [Tooltip("Number of population to this year")]
            public int number;
        }

        [Serializable]
        public struct Population
        {
            [Tooltip("History of population")]
            public PopulationHistory[] populationHistory;

            [Tooltip("Graph of population")]
            public AnimationCurve populationGraph;
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

        public virtual void PopulatePopulationGraph()
        {
            foreach (var populationPoint in population.populationHistory)
            {
                population.populationGraph.AddKey(populationPoint.year, populationPoint.number);
            }
        }

        public virtual int GetPopulation(float year)
        {
            return Mathf.CeilToInt(population.populationGraph.Evaluate(year));
        }

        public void Start()
        {
            PopulatePopulationGraph();
        }
    }
}
