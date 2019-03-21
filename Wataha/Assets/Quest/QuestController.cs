using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{

    public List<QuestGiver> givers;
    public GameObject player;
    public GameObject questLog;

    public Button acceptButton, closeButton;

    public List<Toggle> wolfToggles;

    public Text strength, resistance, speed, agression;
    public Text title, description, reward;

    private QuestGiver giver;

    void Start()
    {
        giver = givers[0];
        questLog.SetActive(false);

        acceptButton.onClick.AddListener(AcceptQuest);
        closeButton.onClick.AddListener(CloseQuestLog);
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

        if (giver != null && !IfInRatio(giver))
        {
            questLog.SetActive(false);
            giver = null;
            
        }
        else if (giver != null && IfInRatio(giver) && Input.GetButton("Use"))
        {
            if(giver.actualQuest != null)
            {
                ToogleWolf();
                SetQuestLog();
                questLog.SetActive(true);
            }
        }
    }


    public void ToogleWolf()
    {
        int i = 0;
        foreach (Wolf wolf in player.GetComponentsInChildren<Wolf>())
        {
            wolfToggles[i].interactable = CheckWolf( wolf);
            i++;
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

    public void SetQuestLog()
    {
        title.text = giver.actualQuest.questTitle;
        description.text = giver.actualQuest.questDescription;
        reward.text = "";
        if (giver.actualQuest.MeatReward > 0)
            reward.text += "Meat reward: " + giver.actualQuest.MeatReward + "\n";
        if (giver.actualQuest.WhiteFangReward > 0)
            reward.text += "White Fang reward: " + giver.actualQuest.WhiteFangReward + "\n";
        if (giver.actualQuest.GoldFangReward > 0)
            reward.text += "Gold Fang reward: " + giver.actualQuest.GoldFangReward;

        strength.text = "STRENGTH: " + giver.actualQuest.NeedStrenght;
        resistance.text = "RESISTANCE: " + giver.actualQuest.NeedResistance;
        speed.text = "SPEED: " + giver.actualQuest.NeedSpeed;
        agression.text = "MAXAGRESSION: " + giver.actualQuest.MaxAgresion;
    }

    public void AcceptQuest()
    {
        CloseQuestLog();

    }

    public void CloseQuestLog()
    {
        questLog.gameObject.SetActive(false);
    }

    private bool IfInRatio(QuestGiver giver)
    {

        if (
             (player.transform.position.x - giver.transform.position.x) <  5.0f &&
             (player.transform.position.x - giver.transform.position.x) > -5.0f &&
             (player.transform.position.z - giver.transform.position.z) <  5.0f &&
             (player.transform.position.z - giver.transform.position.z) > -5.0f)
            return true;
        return false;
    }


    
}
