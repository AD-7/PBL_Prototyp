using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{

    public List<QuestGiver> givers;
    public GameObject player;
    public GameObject questLog;

    public Button acceptButton, closeButton, questLogButton;

    public List<Toggle> wolfToggles;
    public List<Text> wolfDescribe;
    public List<Wolf> wolves;

    public Text strength, resistance, speed, agression;
    public Text title, description, reward;

    public HUDController hud;

    private QuestGiver giver;
    private QuestGiver actualQuestGiver;
    private Quest actualQuest;
    public Text ButtonInfoText;
    public Text done_all;

    private bool closeWin;
    void Start()
    {
        giver = null;
        questLog.SetActive(false);
        closeWin = true;


        acceptButton.onClick.AddListener(AcceptQuest);
        closeButton.onClick.AddListener(CloseQuestLog);
        questLogButton.onClick.AddListener(OpenActualQuestLog);

        foreach (Wolf wolf in player.GetComponentsInChildren<Wolf>())
        {
            wolves.Add(wolf);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (giver == null)
        {
            foreach (QuestGiver giverTemp in givers)
            {
              
                if (IfInRatio(giverTemp))
                {
                    giver = giverTemp;
                    break;
                }
            }
        }
        if (closeWin)
        {
            if (actualQuest != null && IfInRatio(actualQuest.questDestination) && actualQuest.questStatus == Quest.status.ACTIVE)
                ButtonInfoText.gameObject.SetActive(true);
            else
                ButtonInfoText.gameObject.SetActive(false);

            if (giver != null && !IfInRatio(giver))
            {
                questLog.SetActive(false);
                giver = null;

            }
            else if (giver != null && IfInRatio(giver) && Input.GetButton("Use") && actualQuest == null && (giver.questsNeedToStart == null || giver.questsNeedToStart.actualQuest == null))
            {
                if (giver.actualQuest != null)
                {
                    ToogleWolf();
                    SetQuestLog(giver.actualQuest);
                    done_all.text = giver.GetComponent<QuestGiver>().questCompleted.Count.ToString() + "/" + giver.GetComponent<QuestGiver>().questsList.Count.ToString();
                    questLog.SetActive(true);
                }
            }

            if (actualQuest != null && actualQuestGiver != null && CheckIfCompleted())
            {
                QuestCompleted();
            }
        }
    }


    public void ToogleWolf()
    {
        int i = 0;
        foreach (Wolf wolf in wolves)
        {
            if(wolf.GetComponent<MeshRenderer>().enabled == true)
            {
            wolfToggles[i].interactable = CheckWolf( wolf);
            i++;
            }
         
        }
    }

    public bool CheckWolf(Wolf wolf)
    {
        if (wolf.strength >= giver.actualQuest.NeedStrenght &&
            wolf.resistance >= giver.actualQuest.NeedResistance &&
            wolf.speed >= giver.actualQuest.NeedSpeed &&
            wolf.agression <= giver.actualQuest.MaxAgresion)
            return true;
        return false;
    }


    public void OpenActualQuestLog()
    {
       if(actualQuest != null)
        {
            questLog.SetActive(true);
            SetQuestLog(actualQuest);
            acceptButton.gameObject.SetActive(false);
            foreach(Toggle toogle in wolfToggles)
            {
                toogle.gameObject.SetActive(false);
            }
        }
        else
        {
            SetEmptyQuestLog();
            acceptButton.gameObject.SetActive(false);
            foreach (Toggle toogle in wolfToggles)
            {
                toogle.gameObject.SetActive(false);
            }
            questLog.SetActive(true);
        }
    }

    public void SetQuestLog(Quest quest)
    {
        title.text = quest.questTitle;
        description.text = quest.questDescription;
        reward.text = "";
        if (quest.MeatReward > 0)
            reward.text += "Meat reward: " + quest.MeatReward + "\n";
        if (quest.WhiteFangReward > 0)
            reward.text += "White Fang reward: " + quest.WhiteFangReward + "\n";
        if (quest.GoldFangReward > 0)
            reward.text += "Gold Fang reward: " + quest.GoldFangReward;

        strength.text = "STRENGTH: " + quest.NeedStrenght;
        resistance.text = "RESISTANCE: " + quest.NeedResistance;
        speed.text = "SPEED: " + quest.NeedSpeed;
        agression.text = "MAXAGRESSION: " + quest.MaxAgresion;

        int i = 0;
        foreach(Text wolfText in wolfDescribe)
        {
            wolfText.text = "STRENGTH: " + wolves[i].strength + "\n" +
                             "RESISTANCE: " + wolves[i].resistance + "\n" +
                             "SPEED: " + wolves[i].speed + "\n" +
                             "MAGRESSION: " + wolves[i].agression;
           i++;
        }
       
    }

    public void SetEmptyQuestLog()
    {
        title.text = "QUESTLOG";
        description.text = "You don't have active quest.";
        reward.text = "";
        
        strength.text = "STRENGTH: ";
        resistance.text = "RESISTANCE: ";
        speed.text = "SPEED: ";
        agression.text = "MAXAGRESSION: ";
    }

    public void AcceptQuest()
    {
        if (!wolfToggles[0].isOn && !wolfToggles[1].isOn && !wolfToggles[2].isOn &&
            !wolfToggles[3].isOn && !wolfToggles[4].isOn)
            return;
        
        else
        {
            giver.actualQuest.questStatus = Quest.status.ACTIVE;
            actualQuestGiver = giver;
            actualQuest = actualQuestGiver.actualQuest;
            CloseQuestLog();

            int i = 0;
            foreach (Wolf wolf in player.GetComponentsInChildren<Wolf>())
            {
                if (!wolfToggles[i].isOn)
                    wolf.gameObject.SetActive(false);
                i++;
            }

            giver.mark.text = " ";
            if (actualQuest.questDestination !=null)
             actualQuest.questDestination.GetComponentInChildren<TextMesh>().text = "?";

        }
    }

    public void CloseQuestLog()
    {
        closeWin = true;
        acceptButton.gameObject.SetActive(true);
        foreach (Toggle toogle in wolfToggles)
        {
            toogle.gameObject.SetActive(true);
        }

        foreach (Text text in wolfDescribe)
        {
            text.gameObject.SetActive(true);
        }

        questLog.gameObject.SetActive(false);
    }

    public bool CheckIfCompleted()
    {
        if (actualQuest.questStatus == Quest.status.SUCCED)
            return true;
        return false;
    }

    public void QuestCompleted()
    {
        actualQuest.questDestination.GetComponentInChildren<TextMesh>().text = " "; 
        closeWin = false;
        foreach (Wolf wolf in wolves)
        {
            wolf.gameObject.SetActive(true);
        }

        hud.Meat += actualQuest.MeatReward;
        hud.WhiteFangs += actualQuest.WhiteFangReward;
        hud.GoldFangs += actualQuest.GoldFangReward;

        actualQuest = null;
        int i = 0;
        foreach (Wolf wolf in wolves)
        {
            wolfToggles[i].isOn = false;
            i++;
        }

        SetEmptyQuestLog();
        title.text = "MISSION COMPLETED";
        description.text = "You have completed mission.";
        acceptButton.gameObject.SetActive(false);
        foreach (Toggle toogle in wolfToggles)
        {
            toogle.gameObject.SetActive(false);
        }
        
        foreach (Text text in wolfDescribe)
        {
            text.gameObject.SetActive(false);
        }
        questLog.SetActive(true);
    }

    private bool IfInRatio(QuestGiver giver)
    {

        if (
             (player.transform.position.x - giver.transform.position.x) < 5.0f &&
             (player.transform.position.x - giver.transform.position.x) > -5.0f &&
             (player.transform.position.z - giver.transform.position.z) < 5.0f &&
             (player.transform.position.z - giver.transform.position.z) > -5.0f)
        {
      
            ButtonInfoText.gameObject.SetActive(true);
            return true;
        }
        ButtonInfoText.gameObject.SetActive(false);
        return false;
    }

    private bool IfInRatio(GameObject giver)
    {

        if (
             (player.transform.position.x - giver.transform.position.x) < 5.0f &&
             (player.transform.position.x - giver.transform.position.x) > -5.0f &&
             (player.transform.position.z - giver.transform.position.z) < 5.0f &&
             (player.transform.position.z - giver.transform.position.z) > -5.0f)
        {

            return true;
        }
        return false;
    }



}
