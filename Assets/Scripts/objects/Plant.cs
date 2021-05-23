using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public string plantName;
    public int plantAge;
    public int ageToSapling;
    public int ageToHarvest;
    public Item item;

    public Plant(string plantName, int plantAge, int ageToSapling, int ageToHarvest, Item item)
    {
        this.plantName = plantName;
        this.plantAge = plantAge;
        this.ageToSapling = ageToSapling;
        this.ageToHarvest = ageToHarvest;
        this.item = item;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItem(Item setItemValue)
    {
        this.item = setItemValue;
    }

    public Item getItem()
    {
        return this.item;
    }

    public void setToSap(int age)
    {
        this.ageToSapling = age;
    }

    public int getToSapling()
    {
        return this.ageToSapling;
    }

    public void setToHarvest(int age)
    {
        this.ageToHarvest = age;
    }

    public int getToHarvest()
    {
        return this.ageToHarvest;
    }
}
