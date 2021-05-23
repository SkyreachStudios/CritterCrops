using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemType;
    public int qty;
    public Sprite itemImage;
    public Animator itemAnim;
    public int cost;

    public Item(string itemName, string itemType, int qty, Sprite itemImage)
    {
        this.itemName = itemName;
        this.itemType = itemType;
        this.qty = qty;
        this.itemImage = itemImage;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItemType(string type)
    {
        this.itemType = type;
    }

    public string getItemType()
    {
        return this.itemType;
    }

    public string getName()
    {
        return this.itemName;
    }


    public void setName(string name)
    {
        this.itemName = name;
    }

    public int getCost()
    {
        return this.cost;
    }


    public void setCost(int cost)
    {
        this.cost = cost;
    }


    public int getQTY()
    {
        return this.qty;
    }

    public void setQTY(int num)
    {
        this.qty = num;
    }

    public Sprite getImage()
    {
        return this.itemImage;
    }

    public void setImage(Sprite image)
    {
        this.itemImage = image;
    }

    public Animator getAnim()
    {
        return this.itemAnim;
    }
    public Animator setAnim(Animator newAnim)
    {
        return this.itemAnim = newAnim;
    }


}
