using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] internal Transform holdingLine;


    public float food = 10;
    public float gear = 5;

    public float foodGenerationRate
    {
        get { return GameManager.Instance.userData.foodGenerationRate; }
        private set { }
    }
    public float gearGenerationRate
    {
        get { return GameManager.Instance.userData.gearGenerationRate; }
        private set { }
    }

    public List<Unit> totalUnits;
    Coroutine foodCoroutine;
    Coroutine gearCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        GameUI.Instance.Get<UI_InGame>().Show();
        InitRooster();

        InitFoodGeneration();
        InitGearGeneration();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitFoodGeneration()
    {
        foodCoroutine = StartCoroutine(FoodGeneration());
        IEnumerator FoodGeneration()
        {
            while (food < GameManager.Instance.userData.maxFood)
            {
                yield return new WaitForSeconds(1);
                food += foodGenerationRate;
            }
            food = GameManager.Instance.userData.maxFood;
        }

    }
    void InitGearGeneration()
    {
        gearCoroutine = StartCoroutine(InitGearGeneration());
        IEnumerator InitGearGeneration()
        {
            while (gear < GameManager.Instance.userData.maxGear)
            {
                yield return new WaitForSeconds(1);
                gear += gearGenerationRate;
            }
            gear = GameManager.Instance.userData.maxGear;
        }
    }

    void InitRooster()
    {
        GameUI.Instance.Get<UI_InGame>().InitRoosterCards(GameManager.Instance.userData.currentRoosters);
    }

    public void SpawnUnit(Rooster selectedRooster)
    {
        if (food > selectedRooster.foodCost)
        {
            Unit newUnit = Instantiate(selectedRooster.unit, transform);
            totalUnits.Add(newUnit);

            food -= selectedRooster.foodCost;
        }
    }

    public void FlushUnitTarget()
    {
        foreach (Unit unit in totalUnits)
        {
            unit.targets.RemoveAll(item => item == null || item.isDead);
            unit.targetsInRange.RemoveAll(item => item == null || item.isDead);
        }
    }
    public void KillThisUnit(Unit unitToKill)
    {
        totalUnits.Remove(unitToKill);
    }
}
