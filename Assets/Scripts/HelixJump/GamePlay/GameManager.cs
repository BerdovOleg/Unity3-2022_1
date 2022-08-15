using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] AutoCreatedLevel Factory;
    [SerializeField] PlayerControl control;
    [SerializeField] Player player;
    [SerializeField] GameObject CoreLevel;
    [SerializeField] ScreenManager screenManager;
    [SerializeField] SaveSystem saveSystem;

    [SerializeField] private AudioClip clip;
    [SerializeField] SoundManger soundManger;

    public int Level;
    public int CurrentBlock;
    public int MaxBlock;

    private Vector3 finishPoint;
    private Vector3 startPoint;
    float distance;
    float complited;
    bool startGame = false;


    Vector3 PlayerStartPos = new Vector3(0f, 2f, -4.5f);
    Vector3 CameraStartPos= new Vector3(0f, 10f, -20f);


    public enum State{
    Playng,
    Won,
    Loss,
    }

    public State CurrentState { get; private set; }

    public void OnStartGame()
    {
        if (CurrentState != State.Playng) return;

        CurrentState = State.Playng;
        control.enabled = true;
    }

    public void OnPlayerDie()
    {
        if (CurrentState != State.Playng) return;

        CurrentState = State.Loss;
        saveSystem.SaveGame(Level, MaxBlock);
        control.enabled = false;
        screenManager.Loss((int)complited, MaxBlock);
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playng) return;
         
        CurrentState = State.Won;
        saveSystem.SaveGame(Level + 1, MaxBlock);
        control.enabled = false;
        screenManager.Win(Level);
    }
    private void Start()
    {
        startGame = false;
        Level = saveSystem.CurrentLevel;
        CurrentBlock = 0;
        MaxBlock = saveSystem.RecordBlock;
        complited = 0;
        StartLevel(Level);
    }

    private void StartLevel(int level)
    {
        player.transform.position = PlayerStartPos;
        Camera.main.transform.position = CameraStartPos;
        CurrentBlock = 0;
        CoreLevel.transform.Rotate(new Vector3(0, 0, 0));
        Level = level;
        Factory.CollectingLevel(level);
        OnStartGame();
    }

    private void Update()
    {
        ProgressLevel();
        ProgressBlock();
        if (!startGame)
        {
            startPoint = GetComponentInChildren<StartPlatform>().StartPoint;
            finishPoint = GetComponentInChildren<FinishPlatform>().FinishPoint;
            distance = Vector3.Distance(startPoint, finishPoint);
            startGame = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            saveSystem.ResetData();
        }
    }

    private void ProgressBlock()
    {
        MaxBlock = MaxBlock < CurrentBlock ? CurrentBlock : MaxBlock;

        screenManager.SetTextBlock(CurrentBlock, MaxBlock);
    }

    private void ProgressLevel()
    {
        
        var currentPos = Math.Abs(Vector3.Distance(player.CurrentPlatform.transform.position, finishPoint) - distance);
        complited = (currentPos) / ((distance) / 100);
        var posotoin = complited / 100;
        screenManager.LevelCountSet(posotoin, Level);
    }

    public void BlocksAdd()
    {
        CurrentBlock += 5;
        soundManger.PlaySound(clip);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
