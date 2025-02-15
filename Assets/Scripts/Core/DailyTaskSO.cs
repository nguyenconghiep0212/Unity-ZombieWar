using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DailyTaskSO : TaskSO
{
    public override void SetUp(Action action)
    {
        userData = GameManager.Instance.userData;
        claimedAction = action;

        isClaimed = userData.completedDailyTasks.Contains(this);

        if (isClaimed) return;
        if (taskType == TaskType.LoginRegulary) taskType = TaskType.Login;
        if (taskType == TaskType.Login) maxProgress = 1;

        CheckTimeToReset();

    }

    public override void UpdateStat()
    {  
        CheckTimeToReset();
    }

    void Stat()
    {
        switch (taskType)
        {
            case TaskType.Login:
                progress = userData.logedToday;
                break;
            case TaskType.LoginRegulary:

                break;
            case TaskType.GainWisdom:
                progress = userData.wisdomToday;
                break;
            case TaskType.CompleteLevel:
                progress = userData.levelToday;
                break;
            case TaskType.MatchBalloon:
                progress = userData.balloonMatchedToday;
                break;
            case TaskType.UseItem:
                progress = userData.usedSpotPowerToday + userData.usedUndoPowerToday + userData.usedRefreshPowerToday + userData.usedTimePowerToday;
                break;
            case TaskType.UseItemSpot:
                progress = userData.usedSpotPowerToday;
                break;
            case TaskType.UseItemUndo:
                progress = userData.usedUndoPowerToday;
                break;
            case TaskType.UseItemRefresh:
                progress = userData.usedRefreshPowerToday;
                break;
            case TaskType.UseItemTime:
                progress = userData.usedTimePowerToday;
                break;
        }

        if (progress / maxProgress < 1)
        {
            canClaimed = false;
            isClaimed = false;
        }

        else
        {
            canClaimed = true;
        }
    }
    public override void ClaimTask()
    {
       
        GameManager.Instance.AddDailyTask(this);
        if (claimedAction != null)
        {
            claimedAction.Invoke();
        }
        isClaimed = true;
    }
    void CheckTimeToReset()
    {
        //Debug.Log("Check");
        DateTime lastExitDateTime;
        if (DateTime.TryParse(userData.lastExitTime, out lastExitDateTime))
        {
            DateTime now = DateTime.Now;
            DateTime today = now.Date;
            DateTime lastExitDate = lastExitDateTime.Date;

            if (lastExitDate == today)
            {
                Stat();
            }
            else 
            {
                ResetStat();
                Stat();
            }
        }
        else
        {
            Stat();
        }
    }

    private void ResetStat()
    {
        progress = 0;
        isClaimed = false;
    }
}
