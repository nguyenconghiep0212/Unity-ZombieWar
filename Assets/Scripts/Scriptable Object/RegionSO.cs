using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RegionSO")]
public class RegionSO : ScriptableObject
{

}
[System.Serializable]
public class Region
{
    public int regionId;

}