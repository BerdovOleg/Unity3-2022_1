using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerControl control;
    [SerializeField] Player player;
    [SerializeField] ScreenManager screenManager;

    [SerializeField] private AudioClip clip;
    [SerializeField] SoundManger soundManger;

    public int Level;
    public int CurrentBlock;
    public int MaxBlock;

    private Vector3 finishPoint;
    private Vector3 startPoint;
    float distance;
    float complited;


    Vector3 PlayerStartPos;
    Vector3 CameraStartPos;
    List<Platform> platforms;


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
        control.enabled = false;
        screenManager.Loss((int)complited, MaxBlock);
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playng) return;
         
        CurrentState = State.Won;
        control.enabled = false;
        screenManager.Win(Level);
    }

    private void Start()
    {
        Level = 1;
        CurrentBlock = 0;
        MaxBlock = 0;
        complited = 0;
        startPoint = GetComponentInChildren<StartPlatform>().StartPoint;
        finishPoint = GetComponentInChildren<FinishPlatform>().FinishPoint;

        OnStartGame();
        distance = Vector3.Distance(startPoint, finishPoint);

        PlayerStartPos = player.transform.position;
        CameraStartPos = Camera.main.transform.position;
        platforms = new List<Platform>();
        platforms.AddRange(GetComponentsInChildren<Platform>());
    }

    private void Update()
    {
        ProgressLevel();
        ProgressBlock();
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
        foreach (var platform in platforms)
        {
            platform.gameObject.SetActive(true);
        }

        player.transform.position = PlayerStartPos;
        Camera.main.transform.position = CameraStartPos;
        CurrentBlock = 0;
        screenManager.Restart();
        OnStartGame();
    }

}
