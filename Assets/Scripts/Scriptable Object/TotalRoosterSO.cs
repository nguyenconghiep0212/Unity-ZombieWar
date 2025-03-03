using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TotalRoosterSO")]
public class TotalRoosterSO : ScriptableObject
{
    public List<Rooster> totalRoosters;
}

[System.Serializable]
public class Rooster
{
    public Unit unit;
    public bool isUsed;
    public bool isUnlocked;
    public bool isPurchased;
}

