 using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelSO")]
public class LevelSO : ScriptableObject
{
    public List<Level> levelMapping;
    public int regionId;
} 

[System.Serializable]
public class Level
{
    public int id;
    public int energyCost;
    public List<Wave> waves;
    public InGameReward reward;
    public bool isWon;
    public int starRating;
}

[System.Serializable]
public class InGameReward
{
    public int coin;
    public int dollar;
    public int upgradePoint;
}

[System.Serializable]
public class Wave
{
    public float delayTime;
    public List<RoosterSpawnRate> roosterSpawnRate;
}
[System.Serializable]
public class RoosterSpawnRate
{
    public Unit enemy;
    public int number;
    public float timeBetween;
}
