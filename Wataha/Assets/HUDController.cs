using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Wolf;

public class HUDController : MonoBehaviour
{
    Evolution actualSkills1;
    Evolution actualSkills2;
    public Text numberOfMeat;
    public Text numberOfWhiteFangs;
    public Text numberOfGoldFangs;
    public int Meat=200, WhiteFangs=100, GoldFangs=0;
    public Button wolf1button,wolf2button, wolf3button, wolf4button, wolf5button;
    public GameObject wolf1,wolf2,wolf3,wolf4,wolf5;
   private GameObject actualWolf;

    public GameObject wolfScreen;
    public Text strength,resistance,energy;

    private Text wolfScreenTitle;
    public Text strengthEvo1, strengthEvo2;
    public Text resistanceEvo1, resistanceEvo2;
    public Text cost1, cost2;
    public Button choose1, choose2 , close;
    public Text notenough;
    // Start is called before the first frame update
    void Start()
    {
       
        wolf1button.onClick.AddListener(Wolf1Clicked);
        wolf2button.onClick.AddListener(Wolf2Clicked);
        wolf3button.onClick.AddListener(Wolf3Clicked);
        wolf4button.onClick.AddListener(Wolf4Clicked);
        wolf5button.onClick.AddListener(Wolf5Clicked);
        choose1.onClick.AddListener(choose1Clicked);
        choose2.onClick.AddListener(choose2Clicked);
        close.onClick.AddListener(CloseClicked);
        numberOfMeat.text = Meat.ToString();
        numberOfWhiteFangs.text = WhiteFangs.ToString();
        numberOfGoldFangs.text = GoldFangs.ToString();
        wolfScreen.gameObject.SetActive(false);
        notenough.gameObject.SetActive(false);
        wolfScreenTitle = wolfScreen.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wolfScreen.gameObject.active && Input.GetMouseButton(1))
        {
            wolfScreen.SetActive(false);
            notenough.gameObject.SetActive(false);
        }
        numberOfMeat.text = Meat.ToString();
        numberOfWhiteFangs.text = WhiteFangs.ToString();
        numberOfGoldFangs.text = GoldFangs.ToString();
    }
    
    void Wolf1Clicked()
    {
        notenough.gameObject.SetActive(false);
        wolfScreenTitle.text = "Wolf1";
        strength.text = "STRENGTH: " + wolf1.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + wolf1.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + wolf1.GetComponent<Wolf>().energy;
        actualSkills1 = wolf1.GetComponent<Wolf>().skills[0];
        actualSkills2 = wolf1.GetComponent<Wolf>().skills[1];
        actualWolf = wolf1;
        strengthEvo1.text = "+ " + wolf1.GetComponent<Wolf>().skills[0].strength + " strength";
        resistanceEvo1.text = "+ " + wolf1.GetComponent<Wolf>().skills[0].resistance + " resistance";
        cost1.text = "cost: " + wolf1.GetComponent<Wolf>().skills[0].costM + " M  " + wolf1.GetComponent<Wolf>().skills[1].costWF + " WF  " + wolf1.GetComponent<Wolf>().skills[1].costGF + " GF";
        strengthEvo2.text = "+ " + wolf1.GetComponent<Wolf>().skills[1].strength + " strength";
        resistanceEvo2.text = "+ " + wolf1.GetComponent<Wolf>().skills[1].resistance + " resistance";
        cost2.text = "cost: " + wolf1.GetComponent<Wolf>().skills[1].costM + " M  " + wolf1.GetComponent<Wolf>().skills[1].costWF + " WF  " + wolf1.GetComponent<Wolf>().skills[1].costGF + " GF";


        wolfScreen.gameObject.SetActive(true);
        
    }
    void Wolf2Clicked()
    {
        actualWolf = wolf2;
        notenough.gameObject.SetActive(false);
        wolfScreenTitle.text = "Wolf2";
        strength.text = "STRENGTH: " + wolf2.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + wolf2.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + wolf2.GetComponent<Wolf>().energy;
        wolfScreen.gameObject.SetActive(true);

    }
    void Wolf3Clicked()
    {
        actualWolf = wolf3;
        notenough.gameObject.SetActive(false);
        wolfScreenTitle.text = "Wolf3";
        strength.text = "STRENGTH: " + wolf3.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + wolf3.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + wolf3.GetComponent<Wolf>().energy;
        wolfScreen.gameObject.SetActive(true);

    }
    void Wolf4Clicked()
    {
        actualWolf = wolf4;
        notenough.gameObject.SetActive(false);
        wolfScreenTitle.text = "Wolf4";
        strength.text = "STRENGTH: " + wolf4.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + wolf4.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + wolf4.GetComponent<Wolf>().energy;
        wolfScreen.gameObject.SetActive(true);

    }
    void Wolf5Clicked()
    {
        actualWolf = wolf5;
        notenough.gameObject.SetActive(false);
        wolfScreenTitle.text = "Wolf5";
        strength.text = "STRENGTH: " + wolf5.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + wolf5.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + wolf5.GetComponent<Wolf>().energy;
        wolfScreen.gameObject.SetActive(true);

    }
    void choose1Clicked()
    {
        if(actualSkills1.costM <= Meat && actualSkills1.costWF <= WhiteFangs && actualSkills1.costGF <= GoldFangs)
        {
            Meat -= actualSkills1.costM;
            WhiteFangs -= actualSkills1.costWF;
            GoldFangs -= actualSkills1.costGF;
            actualWolf.GetComponent<Wolf>().strength += actualSkills1.strength;
            actualWolf.GetComponent<Wolf>().resistance += actualSkills1.resistance;
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
}
