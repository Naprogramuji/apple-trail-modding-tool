using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace AppleTrail
{
    public class Events : MonoBehaviour
    {
        [SerializeField]
        protected GameObject mainMenuUI;
        [SerializeField]
        protected GameObject newTrailUI;
        [SerializeField]
        protected Slider newGameYearSlider;
        [SerializeField]
        protected TextMeshProUGUI newGameYearNumberText;
        [SerializeField]
        protected GameObject mapUI;
        public virtual void NewTrail()
        {
            SetNewTrailYearPermitedValues(1492, 1762);
            mainMenuUI.SetActive(false);
            newTrailUI.SetActive(true);
        }

        protected virtual void SetNewTrailYearPermitedValues(short minValue, short maxValue)
        {
            var sliderComponent = newGameYearSlider.GetComponent<Slider>();
            sliderComponent.minValue = minValue;
            sliderComponent.maxValue = maxValue;
        }

        public virtual void SetNewTrailYearNumber()
        {
            newGameYearNumberText.SetText(newGameYearSlider.value.ToString());
        }

        public virtual void CloseMap()
        {
            mapUI.SetActive(false);
        }

        public virtual void ExitGame()
        {
            Application.Quit();
        }
    }
}
