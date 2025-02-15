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
    public Action onActionChangeStar;
    public void SetStarUser(int value)
    {
        userData.star = value;
        onActionChangeStar?.Invoke();
    }
    public int GetStarUser()
    {
        return userData.star;
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
                userData.level++;
                userData.levelToday++;
                break;
            case GameStates.Lose:
                userData.health--;
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
     

    public void AddHear(int heart)
    {
        userData.AddHeath(heart);
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
