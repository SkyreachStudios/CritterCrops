using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onDropBar : MonoBehaviour, IDropHandler
{
    private GameObject player;
    
    /// <summary>
    /// functionality when an item is dropped onto the active items bar slot
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.gameObject.GetComponent<CanvasGroup>().alpha = 1f;

        eventData.pointerDrag.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        int slotIndex = this.transform.GetSiblingIndex();
        player.GetComponent<Backpack>().removeFromBackpack(eventData.pointerDrag);
        player.GetComponent<BarInventory>().addItemAtIndex(eventData.pointerDrag,slotIndex);

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
