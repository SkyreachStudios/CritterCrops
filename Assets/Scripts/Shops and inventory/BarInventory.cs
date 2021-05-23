using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarInventory : MonoBehaviour
{
    public List<Item> itemsList;
    public Canvas itemCanvas;
    private int selectedIndex = 0;

    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    private int maxSize = 6;

    public Backpack backpack;

    public Item emptyItem;

    /// <summary>
    /// functionality for the ative items actions
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        setItemsNull();
        updateSelection(true);
        //populate items in inventory bar
        updateItemsBar();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (navInpput())
        {
            navigateItemsBar();
        }
        
    }

    private void FixedUpdate()
    {
        

    }

    public void setItemsNull()
    {
        Item item = Instantiate(emptyItem);
        if (itemsList.Count == 0)
        {
            for(int i = 0; i<6; i++)
            {
                itemsList.Add(item);
            }

        }
    }

    public void updateItemsBar()
    {

            if (itemsList.Count == 0)
        {
            for (int i = 0; i < 6; i++)
            {

               itemCanvas.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().enabled = false;
               itemCanvas.transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled = false;
            }
        }

        for (int i = 0; i < itemsList.Count && i < 6; i++)
        {

            if (itemsList[i].itemName == "")
            {
                itemCanvas.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().enabled = false;
                itemCanvas.transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled = false;
                Debug.Log("Empty slot");
            }
            else
            {
                
                //set parameters
                itemCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().setName(itemsList[i].itemName);
                itemCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().setItemType(itemsList[i].itemType);
                itemCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().setQTY(itemsList[i].qty);
                itemCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().setImage(itemsList[i].itemImage);
                itemCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().setAnim(itemsList[i].itemAnim);
                itemCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().setCost(itemsList[i].cost);

                itemCanvas.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().enabled = true;
                itemCanvas.transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled = true;

                Text text = itemCanvas.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>();
                text.text = itemsList[i].getQTY().ToString();

                Image icon = itemCanvas.transform.GetChild(i).GetChild(0).GetComponent<Image>();
                icon.enabled = true;

                icon.sprite = itemsList[i].getImage();
            }
        }
    }

    public void updateSelection(bool setSelect)
    {
        if (setSelect)
        {
            Image selectedSlot = itemCanvas.transform.GetChild(selectedIndex).GetComponent<Image>();
            selectedSlot.sprite = selectedSprite;
        }
        else
        {
            Image selectedSlot = itemCanvas.transform.GetChild(selectedIndex).GetComponent<Image>();
            selectedSlot.sprite = unselectedSprite;
        }
        
    }

    public void addItem(GameObject overlapped)
    {
        int index = itemsList.FindIndex(a => a.getName() == overlapped.GetComponent<Item>().getName());

        int firstNull = itemsList.FindIndex(a => a.getName() == "");
        Item overlappedItem = overlapped.GetComponent<Item>();

        Debug.Log("Overlapped element data: \n" + overlapped.GetComponent<Item>().itemName
            + "\n" + overlapped.GetComponent<Item>().itemType
            + "\n" + overlapped.GetComponent<Item>().itemImage.ToString()
            + "\n" + overlapped.GetComponent<Item>().itemAnim.ToString()
            + "\n" + overlapped.GetComponent<Item>().qty);

        

        if (index == -1){
            Debug.Log("Adding item to bar" + index.ToString());

            itemsList[firstNull]=overlapped.GetComponent<Item>();

            Debug.Log("Added element data: \n" + itemsList[firstNull].itemName
    + "\n" + itemsList[firstNull].itemType
    + "\n" + itemsList[firstNull].itemImage.ToString()
    + "\n" + itemsList[firstNull].itemAnim.ToString()
    + "\n" + itemsList[firstNull].qty);

            updateItemsBar();
            overlapped.SetActive(false);
        }

        else if(index >-1)
        {
            foreach(Item item in itemsList)
            {

                if (item.getName() == overlappedItem.getName())
                {
                    item.setQTY(item.getQTY() + overlappedItem.getQTY());
                    overlapped.SetActive(false);
                    break;
                }
            }
            
            

        }

    }

    public void addItemShop(Item item)
    {
        int index = itemsList.FindIndex(a => a.getName() == item.getName());
        int firstNull = itemsList.FindIndex(a => a.getName() == "");
        int validIndexes=0;

        foreach(Item itemInList in itemsList)
        {
            if (itemInList.getName() != "")
            {
                validIndexes++;
            }
        }


        if (index == -1)
        {

            itemsList[firstNull] = item;
            updateItemsBar();
            
        }

        else if (index > -1)
        {
            foreach (Item newItem in itemsList)
            {
                if (newItem.getName() == item.getName())
                {
                    newItem.setQTY(newItem.getQTY() + item.getQTY());
                    updateItemsBar();
                    break;
                }
            }
        }

        else if (validIndexes == 6)
        {
            
            backpack.addItemToBackpack(item);
        }


    }

    public void addItemAtIndex(GameObject objectAdding, int indexToAdd)
    {
        if (itemsList.Count > 0)
        {


            int index = itemsList.FindIndex(a => a.getName() == objectAdding.GetComponent<Item>().getName());
            Item barItem = objectAdding.GetComponent<Item>();

            if (index == -1)
            {
                Debug.Log("Index to add item to: " + indexToAdd);
                itemsList[indexToAdd] = barItem;
                updateItemsBar();
            }

        }

        else
        {
            Item barItem = objectAdding.GetComponent<Item>();

            Debug.Log("Add item at index: Index to add item to: " + indexToAdd);
            Item emptyItem = Instantiate(barItem);

            emptyItem.itemName = "";
            emptyItem.itemType = "";
            emptyItem.qty = 0;
            emptyItem.itemImage = null;
            emptyItem.itemAnim = null;
            emptyItem.cost = 0;

            itemsList.Add(emptyItem);
            itemsList.Add(emptyItem);
            itemsList.Add(emptyItem);
            itemsList[indexToAdd] = barItem;
            updateItemsBar();
            
        }

    }

    public void useItem(int index)
    {
        Debug.Log("Invoking use item....");
        itemsList[index].qty = itemsList[index].qty - 1;

        Debug.Log("Quantity"+itemsList[index].qty);

        if (itemsList[index].qty <= 0)
        {
            GameObject nullItem = GameObject.Find("EMptyItem(Clone)");

            itemsList[index] = nullItem.GetComponent<Item>();
            updateItemsBar();
        }
        else
        {
            updateItemsBar();
        }
    }

    public void removeFromBar(string itemName)
    {
        for(int i = 0; i< itemsList.Count; i++)
        {
            if(itemsList[i].itemName == itemName)
            {
                itemsList[i] = emptyItem;
                
                
                updateItemsBar();
            }
        }
    }

    public void navigateItemsBar()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedIndex < 5)
            {
                updateSelection(false);
                selectedIndex = selectedIndex + 1;
                updateSelection(true);
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedIndex > 0)
            {
                updateSelection(false);
                selectedIndex = selectedIndex - 1;
                updateSelection(true);
            }

        }
    }

    bool navInpput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    }

    public int getMax()
    {
        return this.maxSize;
    }

    public int getSelectedIndex()
    {
        return this.selectedIndex;
    }

    public void swapItemSlots(GameObject dragged, GameObject overlapped)
    {
        Item swapItem = itemsList[dragged.transform.GetSiblingIndex()];

        itemsList[dragged.transform.GetSiblingIndex()] = itemsList[overlapped.transform.GetSiblingIndex()];

        itemsList[overlapped.transform.GetSiblingIndex()] = swapItem;

        Vector3 newlocForDragged = overlapped.transform.position;
        Vector3 newlocForOverlapped = dragged.transform.position;



        itemCanvas.transform.GetChild(overlapped.transform.GetSiblingIndex()).position = newlocForOverlapped;
        itemCanvas.transform.GetChild(dragged.transform.GetSiblingIndex()).position = newlocForDragged;


    }
}
