using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMamanger : Singleton<EnemyMamanger>
{
    [SerializeField] Level currentLevel;

    private List<Unit> totalUnits;
    private int currentWave = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitLevel()
    {
        currentWave = 0;
    }

    public void CheckWave()
    {
        if (currentWave == currentLevel.waves.Count)
        {
            Victory();
            return;
        }

        if (totalUnits.Count <= 0)
        {
            NextWave();
        }
    }

    private void Victory()
    {

    }

    public void NextWave()
    {
        currentWave++;
        WaveSpawner(currentLevel.waves[currentWave]);
    }

    public void WaveSpawner(Wave currentWave)
    {

    }
}
