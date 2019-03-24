﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{

    public List<Quest> questsList;
    public List<Quest> questCompleted;
    public Quest actualQuest;

    void Start()
    {
        actualQuest = questsList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(actualQuest!=null)
            if (actualQuest.questStatus.Equals(Quest.status.SUCCED))
                CompletedQuest();
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