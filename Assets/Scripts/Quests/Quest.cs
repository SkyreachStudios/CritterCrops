using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public bool isActive;
    public bool isComplete;
    public string title;
    public string descrition;
    public int currencyReward;
    public Item itemReward;
    public List<QuestObjective> objectives;

    public void checkIfValidInteractionForObjectives(string itemInteracted)
    {
        foreach (QuestObjective objective in objectives)
        {
            if (objective.itemToInteractWith ==itemInteracted)
            {
                objective.addToCurrentAmount(itemInteracted);
                checkIfQuestIsComplete();
            }
        }
    }

    public bool checkIfQuestIsComplete()
    {
        int numComplete = 0;
        foreach(QuestObjective objective in objectives)
        {
            if (objective.isComplete)
            {
                numComplete++;
            }
        }

        if (numComplete == objectives.Count)
        {
            isComplete = true;
            return true;
        }
        return false;

    }



}
