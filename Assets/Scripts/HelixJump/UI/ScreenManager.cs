using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI {

    public class ScreenManager : MonoBehaviour
    {
        public List<Screen> Screens;

        [SerializeField] GameObject Confiti;
        GameObject _confiti;

        private void Start()
        {
            Screens = new List<Screen>();
            Screens.AddRange(GetComponentsInChildren<Screen>());

            foreach (var screen in Screens)
            {
                if (screen is StartScreen)
                {
                    ((StartScreen)screen).ShowScreen();
                }
                else
                {
                    screen.HideScreen();
                }
               
            }
        }

        public void LevelCountSet(float value, int number)
        {
            foreach (var screen in Screens)
            {
                if (screen is StartScreen)
                {
                    ((StartScreen)screen).SetProgress(value);
                    ((StartScreen)screen).SetCurrentLevel(number);
                    break;
                }
            }
        }

        public void Loss(int progress, int newRecord)
        {
            foreach (var screen in Screens)
            {
                if (screen is RestartScreen)
                {
                    _confiti = Instantiate(Confiti);
                    ShowScreen(screen);
                    ((RestartScreen)screen).SetText(progress, newRecord);
                    break;
                }
            }
        }   

        public void Win(int level)
        {
            foreach (var screen in Screens)
            {
                if (screen is WinScreen)
                {
                    _confiti = Instantiate(Confiti);
                    ShowScreen(screen);
                    ((WinScreen)screen).LevelDone(level);
                    break;
                }
            }
        }

        public void SetTextBlock(int currentBlock, int MaxBlock)
        {
            foreach (var screen in Screens)
            {
                if (screen is StartScreen)
                {
                    ((StartScreen)screen).SetBlockText(currentBlock, MaxBlock);
                    break;
                }
            }
        }

        private void ShowScreen(Screen screen)
        {
            screen.ShowScreen();
        }
        private void HideScreen(Screen screen)
        {
            screen.HideScreen();
        }
    }
}