using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragActiveItemBar : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    [SerializeField] private GameObject canvas;
    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    private Vector2 startingPos;

    private GameObject player;

    public GameObject self;
    public GameObject image;
    public int childIndex;
    private int dropIndex;


    /// <summary>
    /// Controller for dragging elements on the active items bar.
    /// </summary>
    private void Awake()
    {
        childIndex = self.transform.GetSiblingIndex();
        rectTransform = image.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        
        canvas.GetComponent<Canvas>().sortingOrder = 1;
        startingPos = image.GetComponent<RectTransform>().anchoredPosition;
        Debug.Log("OnBeginDrag triggered!!!");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        canvas.transform.GetChild(0).GetChild(0).GetComponent<Mask>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        canvas.transform.GetChild(5).SetSiblingIndex(childIndex);
        self.transform.SetSiblingIndex(5);
        
        Debug.Log("---------OnDrag Handler------------");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvas.GetComponent<Canvas>().sortingOrder = 0;
        
        image.transform.localPosition = startingPos;
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
        //self.transform.SetSiblingIndex(childIndex);
        Debug.Log("**********************Item was dropped here!!!**************************");

        //if element being dragged is not null
        if (eventData.pointerDrag != null&& eventData.pointerDrag.GetComponent<DragActiveItemBar>()!=null)
        {
            eventData.pointerDrag.transform.SetSiblingIndex(eventData.pointerDrag.GetComponent<DragActiveItemBar>().childIndex);
            this.transform.SetSiblingIndex(childIndex);
            Debug.Log("Dragged item index: " + eventData.pointerDrag.transform.GetSiblingIndex() + "Dropped item index: " + self.transform.GetSiblingIndex());

            player.GetComponent<BarInventory>().swapItemSlots(eventData.pointerDrag, self);

        }
        else
        {
            Debug.Log("Dragged item index: " + eventData.pointerDrag.transform.GetSiblingIndex() + "Dropped item index: " + self.transform.GetSiblingIndex());

            player.GetComponent<BarInventory>().addItemAtIndex(eventData.pointerDrag.gameObject,self.transform.GetSiblingIndex());
        }
    }
}
