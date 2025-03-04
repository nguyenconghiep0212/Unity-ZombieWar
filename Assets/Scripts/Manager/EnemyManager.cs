
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMamanger : Singleton<EnemyMamanger>
{
    [SerializeField] Level currentLevel;

    public List<Unit> totalUnits = new List<Unit>();
    private int currentWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitLevel()
    {
        currentWave = -1;
        NextWave();
    }

    public void CheckWave()
    {


        if (totalUnits.Count <= 0)
        {
            NextWave();
        }
    }

    private void Victory()
    {
        print("Victory");
    }

    public void NextWave()
    {
        if (currentWave == currentLevel.waves.Count)
        {
            Victory();
            return;
        }

        currentWave++;
        WaveSpawner(currentLevel.waves[currentWave]);
    }

    public void WaveSpawner(Wave currentWave)
    {
        StartCoroutine(CountDown());

        IEnumerator CountDown()
        {
            yield return new WaitForSeconds(currentWave.delayTime);

            for (int i = 0; i < currentWave.roosterSpawnRate.Count; i++)
            {
                StartCoroutine(SpawnEnemy(currentWave.roosterSpawnRate[i]));
            }

        }
        IEnumerator SpawnEnemy(RoosterSpawnRate roosterSpawnRate)
        {
            for (int i = 0; i < roosterSpawnRate.number; i++)
            {
                Unit newEnemy = Instantiate(roosterSpawnRate.enemy, transform);
                float parentHeight = GetComponent<RectTransform>().rect.height;
                float randomPoint = Random.Range(1f, 2f);
                bool isNeg = Random.Range(0, 10) <= 5;
                newEnemy.transform.localPosition = new Vector3(0, (isNeg ? 1 : -1) * (parentHeight / 2 / randomPoint), 0);
                totalUnits.Add(newEnemy);
                yield return new WaitForSeconds(roosterSpawnRate.timeBetween);
            }

        }
    }
}
