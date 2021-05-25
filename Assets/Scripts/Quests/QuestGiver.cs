using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestLogSystem questLog;


    private void Update()
    {
        if (giveQuest())
        {
            questLog.addQuest(quest);
        }
    }

    //this will need to be rewritten
    public bool giveQuest()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
