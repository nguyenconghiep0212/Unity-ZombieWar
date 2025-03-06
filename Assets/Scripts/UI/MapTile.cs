using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapTile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Level level;
    public bool isHidden;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    } 
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.15f).SetEase(Ease.Linear);
        if (level != null)
        {
            print("Load Level");
        }
        else
        {
            print("Not A Level");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.15f).SetEase(Ease.Linear);
    }
}
