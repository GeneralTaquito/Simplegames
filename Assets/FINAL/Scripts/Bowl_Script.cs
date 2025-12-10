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

    public void OnDrop(PointerEventData eventData)
    {
        BowlImage.sprite = Bowl_Fill;
        BowlFull.Invoke();
    }
    public void Lickedclean()
    {
        BowlImage.sprite = Bowl_Empty;
    }
}
