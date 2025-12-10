using UnityEngine;
using UnityEngine.EventSystems;

public class DogFood_Script : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public RectTransform rectTransform;
    public GameObject Food;
    public Vector3 startPos;
    public Transform canvasTransform;
    public CanvasGroup canvasGroup;
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Start()
    {
        startPos = rectTransform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject Newobject = Instantiate(Food, startPos, Quaternion.identity);
        Newobject.transform.SetParent(canvasTransform, false);
        Newobject.transform.position = startPos;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        Destroy(gameObject);
    }
    //This will of course drag the image along with the mouse but also create a copy at its original position to give the illusion of source of food your pulling from
}
