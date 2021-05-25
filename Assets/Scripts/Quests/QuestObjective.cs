using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestObjective
{
    public string objectiveName;
    public string objectiveType;
    public string itemToInteractWith;
    public int objectiveGoalAmount;
    public int objectiveCurrentAmount;
    public bool isComplete;

    public void addToCurrentAmount(string itemInteracted)
    {
        if(itemInteracted == itemToInteractWith)
        {
            objectiveCurrentAmount++;
            checkObjectiveStatus();
        }
    }

    public void checkObjectiveStatus()
    {
        if (objectiveCurrentAmount == objectiveGoalAmount)
        {
            isComplete = true;
        }
    }


}
