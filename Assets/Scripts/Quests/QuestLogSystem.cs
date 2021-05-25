using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestLogSystem : MonoBehaviour
{
    public List<Quest> questLog;
    public List<Quest> completedQuestLog;


    public Backpack backpack;


    public GameObject activeQuestsCanvas;
    public List<GameObject> activeQuestBubbles;
    public GameObject questPanel;
    public GameObject progressBar;
    public GameObject objectiveText;

    public void addQuest(Quest questToAdd)
    {
        if (questLog.Count > 0 && !questLog.Contains(questToAdd))
        {
            this.questLog.Add(questToAdd);
        }
        else if (questLog.Count < 1)
        {
            this.questLog.Add(questToAdd);
            addQuestBubble(questToAdd);
        }

    }

    public void checkQuests(string itemInteracted)
    {
        foreach(Quest quest in questLog)
        {
            
            quest.checkIfValidInteractionForObjectives(itemInteracted);
            updateQuestUi();

            if (quest.checkIfQuestIsComplete())
            {
                int indexToRemove = questLog.IndexOf(quest);
                GameObject.Destroy(activeQuestBubbles[indexToRemove]);
                activeQuestBubbles.RemoveAt(indexToRemove);

                //
                giveRewards(quest);
                completedQuestLog.Add(quest);
                questLog.Remove(quest);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {

    }

    private void Update()
    {

    }

    public void giveRewards(Quest quest)
    {
        if(quest.itemReward != null)
        {
            backpack.addItemToBackpack(quest.itemReward);
            backpack.money = backpack.money + quest.currencyReward;
        }
        else
        {
            backpack.money = backpack.money + quest.currencyReward;
        }
    }

    public void addQuestBubble(Quest questToAdd)
    {
        GameObject newBubble = Instantiate(questPanel);
        newBubble.transform.GetChild(0).GetComponent<Text>().text = questToAdd.title;
        newBubble.transform.SetParent(activeQuestsCanvas.transform);
        foreach(QuestObjective objective in questToAdd.objectives)
        {
            GameObject newProgress = Instantiate(progressBar);

            newProgress.GetComponent<Slider>().maxValue = objective.objectiveGoalAmount;
            newProgress.GetComponent<Slider>().value = objective.objectiveCurrentAmount;
            newProgress.transform.GetChild(4).GetComponent<Text>().text = objective.objectiveCurrentAmount + "/"+ objective.objectiveGoalAmount;

            GameObject newObjectiveText = Instantiate(objectiveText);
            newObjectiveText.GetComponent<Text>().text = objective.objectiveName;
            newObjectiveText.transform.SetParent(newBubble.transform);
            newProgress.transform.SetParent(newBubble.transform);
        }
        activeQuestBubbles.Add(newBubble);
    }

    public void updateQuestUi()
    {
        for(int i = 0; i<questLog.Count; i++)
        {
            for (int q = 0; q<questLog[i].objectives.Count; q++)
            {

                    Debug.Log("setting variables for :" + questLog[i].objectives[q].objectiveName);
                    this.activeQuestBubbles[i].transform.GetChild(2 * (q + 1)).GetComponent<Slider>().value = questLog[i].objectives[q].objectiveCurrentAmount;
                    this.activeQuestBubbles[i].transform.GetChild(2 * (q + 1)).GetChild(4).GetComponent<Text>().text = questLog[i].objectives[q].objectiveCurrentAmount + "/" + questLog[i].objectives[q].objectiveGoalAmount;
                

            }
        }
    }
}
