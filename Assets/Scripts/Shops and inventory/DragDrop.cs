using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private GameObject canvas;
    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    private Vector2 startingPos;

    private GameObject player;

   public GameObject self;


    /// <summary>
    /// Functionality for the drag and drop of items within the backpack
    /// </summary>

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        player = GameObject.Find("Player");
        canvas = GameObject.Find("Backpack");
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        canvas.GetComponent<Canvas>().sortingOrder = 1;
        startingPos = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
        Debug.Log("OnBeginDrag triggered!!!");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        canvas.transform.GetChild(0).GetChild(0).GetComponent<Mask>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("---------OnDrag Handler------------");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvas.GetComponent<Canvas>().sortingOrder = 0;
        canvas.transform.GetChild(0).GetChild(0).GetComponent<Mask>().enabled = true;
        transform.localPosition = startingPos;
        Debug.Log("OnEndDrag triggered!!!");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown triggered!!!");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("**********************Item was dropped here!!!**************************");

        //if element being dragged is not null
        if (eventData.pointerDrag != null) { }
        {
            Debug.Log("Dragged item index: " + eventData.pointerDrag.transform.GetSiblingIndex() + "Dropped item index: " + self.transform.GetSiblingIndex());

            player.GetComponent<Backpack>().swapItemSlots(eventData.pointerDrag,self);


            //Vector2 newPos = GetComponent<RectTransform>().anchoredPosition;
            //GetComponent<RectTransform>().anchoredPosition = startingPos;
           // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = newPos;
        }
    }
}
