using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AppleTrail
{
    public class Events : MonoBehaviour
    {
        public GameObject mainMenuUI;

        public GameObject newTrailUI;

        public Slider newGameYearSlider;

        public TextMeshProUGUI newGameYearNumberText;

        public GameObject mapUI;

        public World worldComponent;

        public GameObject gameUI;

        public virtual void NewTrail()
        {
            SetNewTrailYearPermitedValues();
            mainMenuUI.SetActive(false);
            newTrailUI.SetActive(true);
        }

        public virtual void SetNewTrailYearPermitedValues()
        {
            var sliderComponent = newGameYearSlider.GetComponent<Slider>();
            sliderComponent.minValue = worldComponent.year.initial;
            sliderComponent.maxValue = worldComponent.year.ending;
            sliderComponent.value = worldComponent.year.recommended;
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

        public virtual void StartGame()
        {
            newTrailUI.SetActive(false);
            worldComponent.date.year = (short)newGameYearSlider.value;
            worldComponent.SpawnColonies();
            gameUI.SetActive(true);
        }
    }
}
