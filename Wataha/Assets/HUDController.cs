using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    public Text numberOfMeat;
    public Text numberOfWhiteFangs;
    public Text numberOfGoldFangs;
    public int Meat=200, WhiteFangs=100, GoldFangs=0;
    public Button wolf1button;
    public Button wolf2button;
    public GameObject wolf1,wolf2;
   

    public GameObject wolfScreen;
    public Text strength,resistance,energy;

    private Text wolfScreenTitle;
    

    // Start is called before the first frame update
    void Start()
    {
       
        wolf1button.onClick.AddListener(Wolf1Clicked);
        wolf2button.onClick.AddListener(Wolf2Clicked);
        numberOfMeat.text = Meat.ToString();
        numberOfWhiteFangs.text = WhiteFangs.ToString();
        numberOfGoldFangs.text = GoldFangs.ToString();
        wolfScreen.gameObject.SetActive(false);
        wolfScreenTitle = wolfScreen.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        numberOfMeat.text = Meat.ToString();
        numberOfWhiteFangs.text = WhiteFangs.ToString();
        numberOfGoldFangs.text = GoldFangs.ToString();
    }
    
    void Wolf1Clicked()
    {
        wolfScreenTitle.text = "Wolf1";
        strength.text = "STRENGTH: " + wolf1.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + wolf1.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + wolf1.GetComponent<Wolf>().energy;
        wolfScreen.gameObject.SetActive(true);
        
    }
    void Wolf2Clicked()
    {
        wolfScreenTitle.text = "Wolf2";
        strength.text = "STRENGTH: " + wolf2.GetComponent<Wolf>().strength;
        resistance.text = "RESISTANCE: " + wolf2.GetComponent<Wolf>().resistance;
        energy.text = "ENERGY: " + wolf2.GetComponent<Wolf>().energy;
        wolfScreen.gameObject.SetActive(true);

    }
}
