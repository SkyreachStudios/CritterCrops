using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropIntoBackpack : MonoBehaviour, IDropHandler
{
    public GameObject backpackContent;

    public void OnDrop(PointerEventData eventData)
    {
        
        if(eventData.pointerDrag != null)
        {
            for (int i= 0; i<backpackContent.transform.childCount; i++)
            {
                if (backpackContent.transform.GetChild(i).GetComponent<Item>().itemName == eventData.pointerDrag.GetComponent<Item>().itemName)
                {
                    string itemName = eventData.pointerDrag.GetComponent<Item>().getName();
                   
                    backpackContent.transform.GetChild(i).gameObject.SetActive(true);
                    eventData.pointerDrag.GetComponent<Item>().setName("");
                    GameObject.Find("Player").GetComponent<BarInventory>().removeFromBar(itemName);
                    break;
                }
                else
                {
                    Debug.Log("No such item in inventory...\n backpack transform child name: " + backpackContent.transform.GetChild(i).GetComponent<Item>().itemName + "\n pointer child name: "+ eventData.pointerDrag.GetComponent<Item>().itemName);
                }

            }
        }

    }

}
