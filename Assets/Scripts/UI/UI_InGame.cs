using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : UIElement
{
    public override bool ManualHide => true;

    public override bool DestroyOnHide => false;

    public override bool UseBehindPanel => false;

    [SerializeField] GridLayoutGroup roosterSpawner;
    [SerializeField] GameObject foodDisplay;
    [SerializeField] GameObject gearDisplay;

    List<RoosterCard> roosterDeck = new List<RoosterCard>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitRoosterCards(List<Rooster> newRoosterList)
    {
        foreach (Rooster rooster in newRoosterList)
        {
            RoosterCard card = Instantiate(GameManager.Instance.roosterCardPrefab, roosterSpawner.transform);
            card.InitCard(rooster);
            roosterDeck.Add(card);
        }
    }
}
