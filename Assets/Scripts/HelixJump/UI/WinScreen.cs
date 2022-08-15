using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class WinScreen : Screen
    {
        [SerializeField] GameObject winScreen;

        [SerializeField] TextMeshProUGUI levelComplited;

        [SerializeField] private AudioClip clip;
        [SerializeField] SoundManger soundManger;

        public override void HideScreen()
        {
            winScreen.SetActive(false);
        }

        public override void ShowScreen()
        {
            winScreen.SetActive(true);
            soundManger.PlaySound(clip);
        }

        public void LevelDone(int level)
        {
            levelComplited.text = "LEVEL " + level + " PASED";
        }
    }
}