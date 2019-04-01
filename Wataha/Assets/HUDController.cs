using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Wolf;

public class HUDController : MonoBehaviour
{
    public GameObject HuntScene;
    public GameObject GameScene;


    Evolution actualSkills1;
    Evolution actualSkills2;
    public Text numberOfMeatText;
    public Text numberOfWhiteFangsText;
    public Text numberOfGoldFangsText;
    public Text numerOfMeatConsumption;
    public int Meat = 200, WhiteFangs = 100, GoldFangs = 10;
    public Button wolf1button, wolf2button, wolf3button, wolf4button, wolf5button, huntingButton;
    public Button wolf1Hunt, wolf2Hunt, wolf3Hunt, wolf4Hunt, wolf5Hunt;
    public GameObject wolf1, wolf2, wolf3, wolf4, wolf5;
    public GameObject wolfHunt;

    public Text wolf1Desc, wolf2Desc, wolf3Desc, wolf4Desc, wolf5Desc;

    private GameObject actualWolf;
    
    public GameObject wolfScreen, huntScreen;
    public Text strength, resistance, energy, speed, agression;


    private Text wolfScreenTitle;
    public Text strengthEvo1, strengthEvo2;
    public Text resistanceEvo1, resistanceEvo2;
    public Text speedEvo1, speedEvo2;
    public Text agressionEvo1, agressionEvo2;
    public Text cost1, cost2;
    public Button choose1, choose2, close, closeHunt;
    public Text notenough;
    public Text dieInfo;
    public Text huntInfo;
    int consumption = 0;
    float counter = 0.0f;
    float dieCounter = 60.0f;
    int secondsTodie = 60;
    bool wolfHunting;
    public GameObject EndHuntInfo;
    // Start is called before the first frame update
    void Awake()
    {
        wolfHunting = false;
        wolf1button.onClick.AddListener(Wolf1Clicked);
        wolf2button.onClick.AddListener(Wolf2Clicked);
        wolf3button.onClick.AddListener(Wolf3Clicked);
        wolf4button.onClick.AddListener(Wolf4Clicked);
        wolf5button.onClick.AddListener(Wolf5Clicked);

        wolf1Hunt.onClick.AddListener(Wolf1HuntClicked);
        wolf2Hunt.onClick.AddListener(Wolf2HuntClicked);
        wolf3Hunt.onClick.AddListener(Wolf3HuntClicked);
        wolf4Hunt.onClick.AddListener(Wolf4HuntClicked);
        wolf5Hunt.onClick.AddListener(Wolf5HuntClicked);

        huntingButton.onClick.AddListener(huntingClicked);
        choose1.onClick.AddListener(choose1Clicked);
        choose2.onClick.AddListener(choose2Clicked);
        close.onClick.AddListener(CloseClicked);
        closeHunt.onClick.AddListener(CloseHuntClicked);
        numberOfMeatText.text = Meat.ToString();
        numberOfWhiteFangsText.text = WhiteFangs.ToString();
        numberOfGoldFangsText.text = GoldFangs.ToString();

        huntScreen.SetActive(false);
        wolfScreen.gameObject.SetActive(false);
        notenough.gameObject.SetActive(false);
        dieInfo.gameObject.SetActive(false);
        huntInfo.gameObject.SetActive(false);
        wolfScreenTitle = wolfScreen.GetComponentInChildren<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        //huntingCounter += Time.deltaTime;
        //Debug.Log(huntingCounter);


        if (wolfScreen.gameObject.active && (Input.GetMouseButton(1) || Input.GetButton("Cancel")))
        {
            wolfScreen.SetActive(false);
            notenough.gameObject.SetActive(false);
        }
        numberOfMeatText.text = Meat.ToString();
        numberOfWhiteFangsText.text = WhiteFangs.ToString();
        numberOfGoldFangsText.text = GoldFangs.ToString();

        #region meat consumption



        consumption = wolf1.GetComponent<Wolf>().strength + wolf2.GetComponent<Wolf>().strength + wolf3.GetComponent<Wolf>().strength + wolf4.GetComponent<Wolf>().strength + wolf5.GetComponent<Wolf>().strength;
        consumption = consumption / 7;
        consumption *= 3;

        numerOfMeatConsumption.text = "-" + consumption.ToString() + " /20s";

        if (counter >= 20)
        {
            if (Meat > 0)
            {
                Meat -= consumption;
            }
            else
            {
                Meat = 0;
            }

            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }
        if (Meat <= 0)
        {

            dieCounter -= Time.deltaTime;
            secondsTodie = (int)dieCounter;
            dieInfo.text = "Your wolves die in " + secondsTodie.ToString() + "s";
            dieInfo.gameObject.SetActive(true);

            if (secondsTodie <= 0)
            {
                Destroy(wolf1, 1);
                Destroy(wolf2, 1);
                Destroy(wolf3, 1);
                Destroy(wolf4, 1);
                Destroy(wolf5, 1);
                // GameOver();  // okno z przegraną
            }
        }
        else
        {
            dieCounter = 45.0f;
            dieInfo.gameObject.SetActive(false);
        }

        #endregion

    }

    void Wolf1Clicked()
    {
        notenough.gameObject.SetActive(false);
        wolfScreenTitle.text = "Wolf1";
        actualWolf = wolf1;
        actualSkills1 = wolf1.GetComponent<Wolf>().skills[0];
        actualSkills2 = wolf1.GetComponent<Wolf>().skills[1];

        ProceedActualWolf();
        wolfScreen.gameObject.SetActive(true);

    }
    void Wolf2Clicked()
    {
        wolfScreenTitle.text = "Wolf2";
        actualWolf = wolf2;
        actualSkills1 = wolf2.GetComponent<Wolf>().skills[0];
        actualSkills2 = wolf2.GetComponent<Wolf>().skills[1];
        notenough.gameObject.SetActive(false);
        ProceedActualWolf();

        wolfScreen.gameObject.SetActive(true);

    }
    void Wolf3Clicked()
    {
        wolfScreenTitle.text = "Wolf3";
        actualWolf = wolf3;
        actualSkills1 = wolf3.GetComponent<Wolf>().skills[0];
        actualSkills2 = wolf3.GetComponent<Wolf>().skills[1];
        notenough.gameObject.SetActive(false);
        ProceedActualWolf();
        wolfScreen.gameObject.SetActive(true);

    }
    void Wolf4Clicked()
    {
        wolfScreenTitle.text = "Wolf4";
        actualWolf = wolf4;
        actualSkills1 = wolf4.GetComponent<Wolf>().skills[0];
        actualSkills2 = wolf4.GetComponent<Wolf>().skills[1];

        notenough.gameObject.SetActive(false);
        ProceedActualWolf();
        wolfScreen.gameObject.SetActive(true);

    }
    void Wolf5Clicked()
    {
        wolfScreenTitle.text = "Wolf5";
        actualWolf = wolf5;
        actualSkills1 = wolf5.GetComponent<Wolf>().skills[0];
        actualSkills2 = wolf5.GetComponent<Wolf>().skills[1];

        notenough.gameObject.SetActive(false);
        ProceedActualWolf();
        wolfScreen.gameObject.SetActive(true);

    }

    //void huntingClicked()
    //{
    //    if (!wolfHunting && !wolf5OnlyinQuest())
    //    {
    //        wolfHunting = true;
    //        StartCoroutine(StartCountdown());
    //    }
    //}

    void huntingClicked()
    {
        huntScreen.SetActive(true);
        setDescribe(wolf1.GetComponent<Wolf>(), wolf1Desc);
        setDescribe(wolf2.GetComponent<Wolf>(), wolf2Desc);
        setDescribe(wolf3.GetComponent<Wolf>(), wolf3Desc);
        setDescribe(wolf4.GetComponent<Wolf>(), wolf4Desc);
        setDescribe(wolf5.GetComponent<Wolf>(), wolf5Desc);
    }

    void setDescribe(Wolf wolf, Text text)
    {
        text.text = "STRENGTH: " + wolf.strength + "\n" +
                    "RESISTANCE: " + wolf.resistance + "\n" +
                    "SPEED: " + wolf.speed + "\n" +
                    "MAGRESSION: " + wolf.agression + "\n" +
                    "ENERGY: " + wolf.energy;
    }

bool wolf5OnlyinQuest()
    {
        if (wolf5.active == true && wolf1.active == false &&
           wolf2.active == false && wolf3.active == false &&
           wolf4.active == false)
            return true;
        return false;
    }

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        
        MeshRenderer m = wolf5.GetComponent<MeshRenderer>();
        m.enabled = false;
        GameObject text = m.gameObject.GetComponentInChildren<TextMesh>().gameObject;
        text.SetActive(false);
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(2.0f);
            currCountdownValue--;
        }

        Meat += 10 * wolf5.GetComponent<Wolf>().strength;
        m.enabled = true;
        text.SetActive(true);
        wolfHunting = false;

        huntInfo.gameObject.SetActive(true);
        huntInfo.text = "Hunting was successfull, your pack earned " + 10 * wolf5.GetComponent<Wolf>().strength + " meat";       

        float currCountdownValue2 = 4;
        while (currCountdownValue2 > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue2--;
        }
        huntInfo.gameObject.SetActive(false);

      

    }



    public void Wolf1HuntClicked()
    {
        Wolf.copyStat(wolfHunt.GetComponent<Wolf>(), wolf1.GetComponent<Wolf>());
       HuntScene.gameObject.SetActive(true);
       GameScene.gameObject.SetActive(false);
        EndHuntInfo.gameObject.SetActive(false);
    }

    public void Wolf2HuntClicked()
    {
        Wolf.copyStat(wolfHunt.GetComponent<Wolf>(), wolf2.GetComponent<Wolf>());
        HuntScene.gameObject.SetActive(true);
        GameScene.gameObject.SetActive(false);
        EndHuntInfo.gameObject.SetActive(false);
    }

    public void Wolf3HuntClicked()
    {
        Wolf.copyStat(wolfHunt.GetComponent<Wolf>(), wolf3.GetComponent<Wolf>());
        HuntScene.gameObject.SetActive(true);
        GameScene.gameObject.SetActive(false);
        EndHuntInfo.gameObject.SetActive(false);
    }
    public void Wolf4HuntClicked()
    {
        Wolf.copyStat(wolfHunt.GetComponent<Wolf>(), wolf4.GetComponent<Wolf>());
        HuntScene.gameObject.SetActive(true);
        GameScene.gameObject.SetActive(false);
        EndHuntInfo.gameObject.SetActive(false);
    }
        public void Wolf5HuntClicked()
    {
        Wolf.copyStat(wolfHunt.GetComponent<Wolf>(), wolf5.GetComponent<Wolf>());
        HuntScene.gameObject.SetActive(true);
        GameScene.gameObject.SetActive(false);
        EndHuntInfo.gameObject.SetActive(false);
    }

    void ProceedActualWolf()
    {
        strength.text = "STRENGTH: " + actualWolf.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + actualWolf.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + actualWolf.GetComponent<Wolf>().energy;
        speed.text = "SPEED: " + actualWolf.GetComponent<Wolf>().speed;
        agression.text = "AGRESSION: " + actualWolf.GetComponent<Wolf>().agression;
        strengthEvo1.text = "+ " + actualWolf.GetComponent<Wolf>().skills[0].strength + " strength";
        resistanceEvo1.text = "+ " + actualWolf.GetComponent<Wolf>().skills[0].resistance + " resistance";
        speedEvo1.text = "+ " + actualWolf.GetComponent<Wolf>().skills[0].speed + " speed";
        agressionEvo1.text = "- " + actualWolf.GetComponent<Wolf>().skills[0].agression + " agression";
        cost1.text = "cost: " + actualWolf.GetComponent<Wolf>().skills[0].costM + " M  " + actualWolf.GetComponent<Wolf>().skills[1].costWF + " WF  " + actualWolf.GetComponent<Wolf>().skills[1].costGF + " GF";
        strengthEvo2.text = "+ " + actualWolf.GetComponent<Wolf>().skills[1].strength + " strength";
        resistanceEvo2.text = "+ " + actualWolf.GetComponent<Wolf>().skills[1].resistance + " resistance";
        speedEvo2.text = "+ " + actualWolf.GetComponent<Wolf>().skills[0].speed + " speed";
        agressionEvo2.text = "- " + actualWolf.GetComponent<Wolf>().skills[0].agression + " agression";

        cost2.text = "cost: " + actualWolf.GetComponent<Wolf>().skills[1].costM + " M  " + actualWolf.GetComponent<Wolf>().skills[1].costWF + " WF  " + actualWolf.GetComponent<Wolf>().skills[1].costGF + " GF";


    }
    void choose1Clicked()
    {
        if (actualSkills1.costM <= Meat && actualSkills1.costWF <= WhiteFangs && actualSkills1.costGF <= GoldFangs)
        {
            Meat -= actualSkills1.costM;
            WhiteFangs -= actualSkills1.costWF;
            GoldFangs -= actualSkills1.costGF;
            actualWolf.GetComponent<Wolf>().strength += actualSkills1.strength;
            actualWolf.GetComponent<Wolf>().resistance += actualSkills1.resistance;
            actualWolf.GetComponent<Wolf>().speed += actualSkills1.speed;
            if (actualWolf.GetComponent<Wolf>().agression <= 0)
            {
                actualWolf.GetComponent<Wolf>().agression = 0;
            }
            else
            {
                actualWolf.GetComponent<Wolf>().agression -= actualSkills1.agression;
            }
            actualWolf.GetComponent<Wolf>().skills.RemoveAt(0);
            actualWolf.GetComponent<Wolf>().skills.RemoveAt(0);
            wolfScreen.gameObject.SetActive(false);

        }
        else
        {
            notenough.gameObject.SetActive(true);
        }

    }
    void choose2Clicked()
    {
        if (actualSkills2.costM <= Meat && actualSkills2.costWF <= WhiteFangs && actualSkills2.costGF <= GoldFangs)
        {
            Meat -= actualSkills2.costM;
            WhiteFangs -= actualSkills2.costWF;
            GoldFangs -= actualSkills2.costGF;
            actualWolf.GetComponent<Wolf>().strength += actualSkills2.strength;
            actualWolf.GetComponent<Wolf>().resistance += actualSkills2.resistance;
            actualWolf.GetComponent<Wolf>().speed += actualSkills2.speed;
            if (actualWolf.GetComponent<Wolf>().agression <= 0)
            {
                actualWolf.GetComponent<Wolf>().agression = 0;
            }
            else
            {
                actualWolf.GetComponent<Wolf>().agression -= actualSkills2.agression;
            }

            actualWolf.GetComponent<Wolf>().skills.RemoveAt(0);
            actualWolf.GetComponent<Wolf>().skills.RemoveAt(0);
            wolfScreen.gameObject.SetActive(false);
        }
        else
        {
            notenough.gameObject.SetActive(true);
        }
    }

    void CloseClicked()
    {

        notenough.gameObject.SetActive(false);
        wolfScreen.gameObject.SetActive(false);
    }

    void CloseHuntClicked()
    {
         huntScreen.gameObject.SetActive(false);
    }


}
