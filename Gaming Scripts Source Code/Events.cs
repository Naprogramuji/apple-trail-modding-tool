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
        public virtual void NewTrail()
        {
            mainMenuUI.SetActive(false);
            newTrailUI.SetActive(true);
        }

        public virtual void SetNewTrailYearNumber()
        {
            newGameYearNumberText.SetText(newGameYearSlider.value.ToString());
        }

        public virtual void ExitGame()
        {
            Application.Quit();
        }
    }
}
