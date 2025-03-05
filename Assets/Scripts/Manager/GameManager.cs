using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    public UserData userData
    {
        get; private set;
    }

    [Header("SO")]
    [SerializeField] internal TotalRoosterSO totalRoosterSO;
    [SerializeField] internal RegionSO regionSO;
    [SerializeField] internal LevelSO levelSO;

    [Header("In-Level Data")]
    [SerializeField] internal PlayerBase playerBase;

    [Header("Prefab")]
    [SerializeField] internal RoosterCard roosterCardPrefab;
    protected override void Awake()
    {
        base.Awake();
        Game.Launch();
        userData = Game.Data.Load<UserData>();
        if (userData.firstOpen)
        {
            userData.Init();
        }

        userData.CheckLogin();
    }

    void Start()
    {

        //UILoading loading = GameUI.Instance.Get<UILoading>();
        //loading.Load(null, (Action)(() =>
        //{
        //    loading.Hide();
        //    GameUI.Instance.Get<UIHome>().Show();
        //}));

        //GameUI.Instance.EnableAllSliderElement();
    }
 

    void Update()
    {

    }

    [SerializeField] private GameStates _state = GameStates.Start;
    public void ChangeState(GameStates newState)
    {
        if (newState == _state) return;
        ExitCurrentState();
        _state = newState;
        EnterNewState();
    }
    private void EnterNewState()
    {

        switch (_state)
        {
            case GameStates.Tutorial:
                break;
            case GameStates.Home:
                //LoadNamesFromJson();
                //PushDataRanking();
                //PushDataQuest();

                //GameUI.Instance.Get<UIHome>().Show();
                //GameUI.Instance.Get<UIPopUpCoin>().Show();

                break;
            case GameStates.Start:
                break;
            case GameStates.Play:

                break;
            case GameStates.Pause:
                break;
            case GameStates.Win: 
                break;
            case GameStates.Lose: 
                break;
            default:
                break;
        }
    }

    private void ExitCurrentState()
    {
        switch (_state)
        {
            case GameStates.Tutorial:
                break;
            case GameStates.Home:
                break;
            case GameStates.Start:
                break;
            case GameStates.Play:
                //GameUI.Instance.Get<UITask>().TaskUpdate();
                break;
            case GameStates.Pause:
                break;
            case GameStates.Win:
                break;
            case GameStates.Lose:
                break;
            default:
                break;
        }
    } 

    public void AddTask(TaskSO task)
    {
        userData.completedTasks.Add(task);
    }

    public void AddDailyTask(DailyTaskSO dailyTask)
    {
        userData.completedDailyTasks.Add(dailyTask);
    }
     

    public void AddHear(int energy)
    {
        userData.AddEnergy(energy);
    }

    public void ChangePlayerName(string name)
    {
        userData.name = name;
    }
}

public enum GameStates
{
    Play, Win, Lose, Home, Tutorial, Start, Pause
}
