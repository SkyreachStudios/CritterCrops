using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Buy : MonoBehaviour
{
    GameObject player;
    GameObject shopMenu;
    /// <summary>
    /// controller for button press of shop buttons
    /// </summary>
    private void Start()
    {
        player = GameObject.Find("Player");
        shopMenu = GameObject.Find("Shop");
    }
    public void purchaseItem()
    {
        if(player.GetComponent<Backpack>().money >= this.GetComponent<Item>().getCost())
        {

            player.GetComponent<Backpack>().money = player.GetComponent<Backpack>().money - this.GetComponent<Item>().getCost();

            Item itemToAdd = Instantiate(this.GetComponent<Item>());
            itemToAdd.itemName = this.GetComponent<Item>().itemName;
            itemToAdd.itemType = this.GetComponent<Item>().itemType;
            itemToAdd.qty = this.GetComponent<Item>().qty;
            itemToAdd.itemImage = this.GetComponent<Item>().itemImage;
            itemToAdd.itemAnim = this.GetComponent<Item>().itemAnim;
            itemToAdd.cost = this.GetComponent<Item>().cost;
            player.GetComponent<BarInventory>().addItemShop(itemToAdd);
            shopMenu.GetComponent<Shop_Controller>().closeMenu();
            shopMenu.GetComponent<Shop_Controller>().openMenu();

        }

    }
}
