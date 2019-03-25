using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public QuestGiver questsNeedToStart;

    public List<Quest> questsList;
    public List<Quest> questCompleted;
    public Quest actualQuest;
    public GameObject reward;

    void Start()
    {
        if(questsList.Count > 0)
            actualQuest = questsList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(actualQuest!=null)
            if (actualQuest.questStatus.Equals(Quest.status.SUCCED))
                CompletedQuest();

        if (actualQuest == null && reward != null)
            reward.SetActive(false);
    }

    public void CompletedQuest()
    {
        questCompleted.Add(actualQuest);
        if ((questsList.IndexOf(actualQuest) + 1) < questsList.Count)
        {
            actualQuest = questsList[questsList.IndexOf(actualQuest) + 1];
        }
        else
        {
            actualQuest = null;
        }
    }
}
