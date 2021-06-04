using UnityEngine;
using System;
using System.Linq;

namespace AppleTrail
{
    public class World : MonoBehaviour
    {
        [Tooltip("GPS coordinates of min and max latitude and longitude for calculation of colonies location on the map")]
        public Borders borders;

        [Tooltip("Initial and ending years where new game take place")]
        public Year year;

        [Tooltip("Actual game date")]
        public Date date;

        [Tooltip("Colony UI gameobject")]
        public GameObject colonyUI;

        [Tooltip("List of colonies")]
        public GameObject[] colonies;

        [Serializable]
        public struct Date
        {
            [Tooltip("Actual game year")]
            public short year;

            // Todo: month, day and time
        }

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

        [Serializable]
        public struct MinMax
        {
            [Tooltip("Minimum value")]
            public double minimum;

            [Tooltip("Maximum value")]
            public double maximum;
        }

        [Serializable]
        public struct GpsPositionCoeficients
        {
            [Tooltip("Latitude GPS position coeficient")]
            public float latitude;

            [Tooltip("Longitude GPS position coeficient")]
            public float longitude;
        }

        [Serializable]
        public struct Borders
        {
            [Tooltip("Rect transform component to borders")]
            public RectTransform bordersTransform;

            [Tooltip("Latitude of map borders")]
            public MinMax latitude;

            [Tooltip("Longitude of map borders")]
            public MinMax longitude;

            [Tooltip("GPS position coeficients")]
            public GpsPositionCoeficients gpsPositionCoeficients;
        }

        [Serializable]
        public struct ColonyPosition
        {
            [Tooltip("Colony horizontal position on the map")]
            public double x;

            [Tooltip("Colony vertical position on the map")]
            public double y;
        }

        public virtual void Start()
        {

            CalculateGpsPositionCoeficients();
        }

        public virtual void CalculateGpsPositionCoeficients()
        {
            borders.gpsPositionCoeficients.latitude = (borders.bordersTransform.rect.width) / (Mathf.Abs((float)borders.latitude.maximum - (float)borders.latitude.minimum));
            borders.gpsPositionCoeficients.longitude = (borders.bordersTransform.rect.height) / (Mathf.Abs((float)borders.longitude.maximum - (float)borders.longitude.minimum));
        }

        public virtual ColonyPosition GetColonyPosition(double latitude, double longitude)
        {
            return new ColonyPosition
            {
                x = (Mathf.Abs((float)(borders.latitude.maximum - latitude))) * (borders.gpsPositionCoeficients.latitude),
                y = (borders.longitude.maximum - longitude) * borders.gpsPositionCoeficients.longitude * -1
            };
        }

        public virtual void SpawnColonies()
        {
            foreach (GameObject colonyGameObject in colonies)
            {
                var colonyComponent = colonyGameObject.GetComponent<Colony>();
                var actualYear = this.date.year;

                if (colonyComponent.foundedDate.year <= actualYear && colonyComponent.abandonedDate.year > actualYear)   // Todo: Month & Day
                {
                    var colonyAlreadyInstantiated = false;

                    foreach (Transform colonyUITransform in borders.bordersTransform)
                    {
                        if (colonyUITransform.gameObject.GetComponent<ColonyUI>().colony.GetComponent<Colony>().initialName == colonyComponent.initialName)
                        {
                            colonyAlreadyInstantiated = false;
                        }
                    }

                    if (colonyAlreadyInstantiated == false)
                    {
                        Debug.Log("Instantiating of colony" + colonyComponent.initialName + "...");
                        var instantiatedColonyUI = Instantiate(colonyUI, borders.bordersTransform);

                        instantiatedColonyUI.GetComponent<ColonyUI>().colony = colonyGameObject;
                    }
                    else
                    {
                        Debug.Log(colonyComponent.initialName + " already instantiated. Skipping...");
                    }
                }
            }
        }
    }
}
