using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bowl_Script : MonoBehaviour, IDropHandler
{
    public Image BowlImage;
    public Sprite Bowl_Fill;
    public Sprite Bowl_Empty;
    public event Action BowlFull;

    //Upon having the food dropped ontop of the bowl it will change and start an action in the Dog_Script
    public void OnDrop(PointerEventData eventData)
    {
        BowlImage.sprite = Bowl_Fill;
        BowlFull.Invoke();
    }

    //bowl empty.
    public void Lickedclean()
    {
        BowlImage.sprite = Bowl_Empty;
    }
}
