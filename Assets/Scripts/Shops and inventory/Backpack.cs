using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Backpack : MonoBehaviour
{
    public List<Item> items;
    public int money;
    public GameObject currencyCounter;

    public int maxBagSize = 8;

    public GameObject backpackCanvas;
    public GameObject itemButton;
    public List<GameObject> itemButtons;
    GameObject player;

    bool isOpen;
    /// <summary>
    /// Backpack/hidden inventory manipulation
    /// </summary>
    private void Start()
    {
        player = GameObject.Find("Player");
        moneyUpdate();
    }

    private void Update()
    {
        moneyUpdate();
        if (inputI())
        {
            openMenu();
        }
    }

    public void moneyUpdate()
    {
        currencyCounter.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = money.ToString();
    }

    public void addItemToBackpack(Item item)
    {
        int index = items.FindIndex(a => a.getName() == item.getName());


        if (index == -1 && items.Count < maxBagSize)
        {
            items.Add(item);
            

        }

        else if (index > -1)
        {
            foreach (Item newItem in items)
            {
                if (newItem.getName() == item.getName())
                {
                    newItem.setQTY(newItem.getQTY() + item.getQTY());
                    break;
                }
            }
        }

        else if (items.Count == maxBagSize)
        {
            //do an error or drop 
        }


    }

    public void openMenu()
    {
        if (isOpen == false)
        {
            isOpen = true;
            player.GetComponent<playerMovement>().setMove(false);
            player.GetComponent<interaction>().openMenus.Add(backpackCanvas);
            setEnabled();
            for (int i = 0; i < items.Count; i++)
            {
                addButton(i);
            }
            
        }

    }

    public void closeMenu()
    {
        this.isOpen = false;
        this.backpackCanvas.SetActive(false);

    }

    public void addButton(int indexToAdd)
    {
        List<string> itemsInInv = new List<string>();

        foreach (Transform child in backpackCanvas.transform.GetChild(0).GetChild(0).GetChild(0))
        {
            itemsInInv.Add(child.gameObject.GetComponent<Item>().getName());
        }

        if (itemsInInv.Contains(items[indexToAdd].getName()))
        {

        }
        else
        {
            GameObject newButton = Instantiate(itemButton);
            newButton.transform.SetParent(backpackCanvas.transform.GetChild(0).GetChild(0).GetChild(0));

            //sets the button item parameters
            newButton.GetComponent<Item>().setName(items[indexToAdd].getName());
            newButton.GetComponent<Item>().setItemType(items[indexToAdd].getItemType());
            newButton.GetComponent<Item>().setQTY(items[indexToAdd].getQTY());
            newButton.GetComponent<Item>().setImage(items[indexToAdd].getImage());
            newButton.GetComponent<Item>().setCost(items[indexToAdd].getCost());
            newButton.GetComponent<Item>().setAnim(items[indexToAdd].getAnim());

            //sets button image
            newButton.transform.GetChild(0).GetComponent<Image>().sprite = newButton.GetComponent<Item>().getImage();
            newButton.transform.GetChild(1).GetComponent<Text>().text = newButton.GetComponent<Item>().qty.ToString();

            //add button to list
            itemButtons.Add(newButton);
        }



    }

    public void setEnabled()
    {
        this.backpackCanvas.SetActive(true);
    }

    bool inputI()
    {
        return Input.GetKeyDown(KeyCode.I);
    }

    public void removeFromBackpack(GameObject dragged)
    {
        backpackCanvas.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(dragged.transform.GetSiblingIndex()).gameObject.SetActive(false);
    }

    public void swapItemSlots(GameObject dragged, GameObject overlapped)
    {
        Item swapItem = items[dragged.transform.GetSiblingIndex()];

        items[dragged.transform.GetSiblingIndex()] = items[overlapped.transform.GetSiblingIndex()];

        items[overlapped.transform.GetSiblingIndex()] = swapItem;

        int newIndexForDragged = overlapped.transform.GetSiblingIndex();
        int newIndexForOverlapped = dragged.transform.GetSiblingIndex();
        backpackCanvas.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(overlapped.transform.GetSiblingIndex()).SetSiblingIndex(newIndexForOverlapped);
        backpackCanvas.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(dragged.transform.GetSiblingIndex()).SetSiblingIndex(newIndexForDragged);

        
    }


}
