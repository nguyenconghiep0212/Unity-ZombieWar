using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoosterCard : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI foodCost;

   internal Rooster rooster;
    public void InitCard(Rooster newRooster)
    {
        rooster = newRooster;
        icon.sprite = rooster.Icon;
        foodCost.text = rooster.foodCost.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerManager.Instance.SpawnUnit(rooster);
    }
}
