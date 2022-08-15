using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace UI
{

    public class RestartScreen : Screen
    {
        [SerializeField] GameObject restartScreen;
        [SerializeField] TextMeshProUGUI Progress;
        [SerializeField] TextMeshProUGUI Record;

        [SerializeField] private AudioClip clip;
        [SerializeField] SoundManger soundManger;

        public override void HideScreen()
        {
            restartScreen.SetActive(false);
        }

        public  override  void ShowScreen()
        {
            restartScreen.SetActive(true);
            soundManger.PlaySound(clip);
        }

        public void SetText(int progress, int newRecord)
        {
            Progress.text = progress+"% COMPLITED";
            Record.text = "NEW RECORD: " + newRecord;
        }
    }
}