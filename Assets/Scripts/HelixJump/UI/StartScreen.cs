using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class StartScreen : Screen
    {
        [SerializeField] TextMeshProUGUI CurrentLevel;
        [SerializeField] TextMeshProUGUI NextLevel;
        [SerializeField] Image ProgresLevel;

        [SerializeField] TextMeshProUGUI CurentBlock;
        [SerializeField] TextMeshProUGUI BestBlock;

        [SerializeField] private GameObject startScreen;
        
        public override void HideScreen()
        {
            startScreen.SetActive(false);
        }

        public override void ShowScreen()
        {
            startScreen.SetActive(true);
        }

        public void SetProgress(float value)
        {
            if (value > 1) return;
            ProgresLevel.fillAmount = value;
        }

        public void SetCurrentLevel(int numer)
        {
            CurrentLevel.text = numer.ToString();
            NextLevel.text = (numer + 1).ToString();
        }

        public void SetBlockText(int currentBlock, int MaxBlock)
        {
            CurentBlock.text = currentBlock.ToString();
            BestBlock.text = MaxBlock.ToString();
        }
    }
}