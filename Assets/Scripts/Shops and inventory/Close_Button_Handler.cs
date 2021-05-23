using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Button_Handler : MonoBehaviour
{

    GameObject player;
    public void closeMenus()
    {
        player = GameObject.Find("Player");

        player.GetComponent<interaction>().closeMenus();
    }
}
