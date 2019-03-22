using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Quest : MonoBehaviour
{


    public enum status : int { INACTIVE, ACTIVE, FAILD, SUCCED };

    [Header("Quest Details")]
    public int questId;
    public string questTitle;
    public string questDescription;

    [Header("Quest Params")]
    public status questStatus;
    public int questStage;
    public int questFinalStage;
    public int questCollectedItems;

    [Header("Quest Needer")]
    public int NeedStrenght;
    public int NeedResistance;
    public int NeedSpeed;
    public int MaxAgresion;

    [Header("Quest Prize")]
    public int MeatReward;
    public int WhiteFangReward;
    public int GoldFangReward;
    public GameObject[] questItems;

    void Start()
    {
        questStage = 0;
        questCollectedItems = 0;
        questStatus = status.INACTIVE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void questActive()
    {
        this.questStatus = status.ACTIVE;
    }

    public void questFaild()
    {
        this.questStatus = status.FAILD;
    }

    public void questSucced()
    {
        this.questStatus = status.SUCCED;
    }

    public void itemCollected()
    {
        questCollectedItems++;
    }
}
