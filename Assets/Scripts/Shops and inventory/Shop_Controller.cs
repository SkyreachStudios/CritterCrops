using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Controller : MonoBehaviour
{
    public List<Item> allItems;
    public List<int> availableItemIndexes;
    public List<GameObject> itemButtons;

    public GameObject shopMenu;
    public GameObject itemButton;

    bool isOpen;

    /// <summary>
    /// Crop Shop controller.
    /// </summary>
    public void openMenu()
    {
        if(isOpen == false)
        {
            


            isOpen = true;
            setEnabled();
            for (int i = 0; i < availableItemIndexes.Count; i++)
            {
                addButton(i);
            }
            //shopMenu.transform.GetChild(0).GetComponent<Animator>().SetBool("opening?",true);
        }         
        
    }

    public void closeMenu()
    {
        this.isOpen = false;
        this.shopMenu.SetActive(false);
        itemButtons.Clear();

        foreach(Transform child in this.shopMenu.transform.GetChild(0).GetChild(0).GetChild(0))
        {
            GameObject.Destroy(child.gameObject);
        }
        // shopMenu.transform.GetChild(0).GetComponent<Animator>().SetBool("opening?", false);
        //StartCoroutine(disableShop());
    }

    

    public void setEnabled()
    {
        this.shopMenu.SetActive(true);
    }


    public void addButton(int indexToAdd)
    {
        
        GameObject newButton = Instantiate(itemButton);
        newButton.transform.SetParent( shopMenu.transform.GetChild(0).GetChild(0).GetChild(0));


        //sets the button item parameters
        newButton.GetComponent<Item>().setName(allItems[indexToAdd].getName());
        newButton.GetComponent<Item>().setItemType(allItems[indexToAdd].getItemType());
        newButton.GetComponent<Item>().setQTY(allItems[indexToAdd].getQTY());
        newButton.GetComponent<Item>().setImage(allItems[indexToAdd].getImage());
        newButton.GetComponent<Item>().setCost(allItems[indexToAdd].getCost());
        newButton.GetComponent<Item>().setAnim(allItems[indexToAdd].getAnim());

        //sets button image
        newButton.transform.GetChild(0).GetComponent<Image>().sprite = newButton.GetComponent<Item>().getImage();
        newButton.transform.GetChild(1).GetComponent<Text>().text = "$"+ newButton.GetComponent<Item>().getCost().ToString();


        GameObject player = GameObject.Find("Player");
        if (player.GetComponent<Backpack>().money < newButton.GetComponent<Item>().getCost())
        {
            newButton.GetComponent<Button>().interactable = false;
            newButton.transform.GetChild(1).GetComponent<Text>().color = new Color(1, 0, 0, 1);
        }
        else
        {
            newButton.GetComponent<Button>().interactable = true;
            newButton.transform.GetChild(1).GetComponent<Text>().color = new Color(0,1, 0, 1);
        }
        

        //add button to list
        itemButtons.Add(newButton);

        
    }
    IEnumerator disableShop()
    {

        yield return new WaitForSeconds(1.04f);
        this.shopMenu.SetActive(false);
    }
}
