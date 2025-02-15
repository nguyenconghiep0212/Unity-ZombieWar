using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData : SavePlayerPrefs
{
    //Stats
    public string name;
    public int level;
    public int wisdom;
    public int health;
    public int coin;
    public int star;

    public string lastExitTime;

    public bool firstOpen = true;
    public bool isTutorial = false;

    //Booster
    public float infiniteHeathTime;

    //Power Up
    public int undoPower;
    public int refreshPower;
    public int spotPower;
    public int timePower;

    //Task
    public int logedDay;
    public int continuousLogedDay;
    public int balloonMatched;
    public int usedUndoPower;
    public int usedRefreshPower;
    public int usedSpotPower;
    public int usedTimePower;

    //Daily Task
    public int logedToday;
    public int wisdomToday;
    public int levelToday;
    public int balloonMatchedToday;
    public int usedUndoPowerToday;
    public int usedRefreshPowerToday;
    public int usedSpotPowerToday;
    public int usedTimePowerToday;

    public List<TaskSO> completedTasks = new(); 
    public List<DailyTaskSO> completedDailyTasks = new();

    //Chest Gift
    public int chestStarIndex;
    public int chestLevelIndex;

    //Settings
    public bool soundOn;
    public bool musicOn;
    public bool vibrateOn;
    public void Init()
    {
        name = "You";
        health = 5;
        logedDay = 1;
        continuousLogedDay = 1;
        ResetDailyTask();
        firstOpen = false;
    }

    public void CheckLogin()
    {
        DateTime lastExitDateTime;
        if (DateTime.TryParse(lastExitTime, out lastExitDateTime))
        {
            DateTime now = DateTime.Now;
            DateTime today = now.Date;
            DateTime lastExitDate = lastExitDateTime.Date;
           
            Debug.Log(lastExitDateTime.ToString());
            Debug.Log(now.ToString());

            if (lastExitDate == today)
            {
                //Already Login Today
                Debug.Log("Sign in Today");
            }
            else if (lastExitDate == today.AddDays(-1))
            {
                Debug.Log("Last Signed in is Yesterday");
                continuousLogedDay++;
                logedDay++;
                ResetDailyTask();
            }
            else
            {
                Debug.Log("Last Signed in is not Yesterday");
                continuousLogedDay = 0;
                logedDay++;
                ResetDailyTask();
            }
        }
        else
        {
            Debug.Log("Have not Sign in");
        }
    }

    void ResetDailyTask()
    {
        logedToday = 1;
        balloonMatchedToday = 0;
        usedUndoPowerToday = 0;
        usedRefreshPowerToday = 0;
        usedSpotPowerToday = 0;
        usedTimePowerToday = 0;
        levelToday = 0;
        wisdomToday = 0;
        completedDailyTasks.Clear();
    }

    public void AddCoin(int coin) { this.coin += coin; }
    public void AddBalloon(int balloon) { this.balloonMatched += balloon; }
    public void AddStar(int star) { this.star += star; }

    public void AddHeath(int heart) { this.health += heart; }
}

[Serializable]

public class DailyBonus
{
    public string dateTracking = DateTime.Now.ToString();
    public int currentIndex = -1;
}




[Serializable]
public class TutorialsData
{
    public bool script2;
    public bool script3;
    public bool script4;
    public bool script5;
    public bool script6;
    public bool script8WakeUpDoctor;
    public bool script9;//het thuoc
    public bool script10;//het thuoc2
    public bool script11;//lay giay vs
    public bool script12;
    //public bool script12b;
    public bool script13;
    public bool script14;//anh da den be hom
    public bool script15;//atm
    public List<int> CompletedTutoS = new();
    public bool tutorialDropMoney;
    public bool hasCreateMoneyItemAtPlayerPos = false;
    public bool hasCreateSpeedItemAtPlayerPos = false;
    public bool hasFreeSpeedItem = false;
    //WareHouse show item
    public bool hasShowItemMedince;
    public bool hasShowItemToiletPaper;
    public bool hasShowItemThermometer;

    public bool hasActiceArrow;

   
}

[Serializable]
public class DataTrackingFirebase
{
    public string timeStartReward = string.Empty;
    public string timeStartIntern = string.Empty;
    public string timeStartAppOpen = string.Empty;
    public string timeCanShowOpenADS = DateTime.Now.ToString();
    public List<int> trackingTimeIncrementalProgressGame = new();

    public int currentDataMapIndex = 0;
    public List<DataSession> dataMaps =
    new List<DataSession> { new DataSession(), new DataSession(), new DataSession(), new DataSession(), new DataSession(), new DataSession() };

   public int currentDataSession = 0;
    public List<DataSession> dataSessionS =
   new List<DataSession> { new DataSession(), new DataSession(), new DataSession(), new DataSession(), new DataSession()};


   
}

[Serializable]
public class DataSession
{
    public float minutes;
    public bool completed;
    public bool status;

    public DataSession(float minutes=0, bool completed=false, bool status=false)
    {
        this.minutes = minutes;
        this.completed = completed;
        this.status = status;
    }
}