using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TaskSO : ScriptableObject
{
    public TaskType taskType;
    public string title;

    public int maxProgress = 1;
    public int progress;

    public int giftedCoin;

    public bool isClaimed;
    public bool canClaimed;

    protected UserData userData;
    protected Action claimedAction;


    public virtual void SetUp(Action action)
    {
        //Debug.Log(title);
        userData = GameManager.Instance.userData;
        claimedAction = action;

        isClaimed = userData.completedTasks.Contains(this);
        //Debug.Log(isClaimed);

        if (isClaimed) return;
        UpdateStat();
    }

    public virtual void ClaimTask()
    {
         GameManager.Instance.AddTask(this);
        if (claimedAction != null)
        {
            claimedAction.Invoke();
        }
        isClaimed = true;
    }

    public virtual void UpdateStat()
    {
        userData = GameManager.Instance.userData;
        switch (taskType)
        {
            case TaskType.Login:
                progress = userData.logedDay;
                break;
            case TaskType.LoginRegulary:
                progress = userData.continuousLogedDay;
                break;
            case TaskType.GainWisdom: 
                break;
            case TaskType.CompleteLevel:
                progress = userData.level;
                break;
            case TaskType.MatchBalloon:
                progress = userData.balloonMatched;
                break;
            case TaskType.UseItem:
                progress = userData.usedSpotPower + userData.usedUndoPower + userData.usedRefreshPower + userData.usedTimePower;
                break;
            case TaskType.UseItemSpot:
                progress = userData.usedSpotPower;
                break;
            case TaskType.UseItemUndo:
                progress = userData.usedUndoPower;
                break;
            case TaskType.UseItemRefresh:
                progress = userData.usedRefreshPower;
                break;
            case TaskType.UseItemTime:
                progress = userData.usedTimePower;
                break;
        }


        if(progress / maxProgress < 1)
        {
            canClaimed = false;
            isClaimed = false;
        }

        else
        {
            canClaimed = true;
        }
    }
}
 public enum TaskType
{
    Login, LoginRegulary, GainWisdom, CompleteLevel, MatchBalloon, UseItem, UseItemUndo, UseItemRefresh, UseItemSpot, UseItemTime
}