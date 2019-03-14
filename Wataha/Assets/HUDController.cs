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
    public Button wolf1;
    public Button wolf2;

    public GameObject wolfScreen;
    private Text wolfScreenTitle;
    

    // Start is called before the first frame update
    void Start()
    {
       
        wolf1.onClick.AddListener(Wolf1Clicked);
        wolf2.onClick.AddListener(Wolf2Clicked);
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
        wolfScreen.gameObject.SetActive(true);
        
    }
    void Wolf2Clicked()
    {
        wolfScreenTitle.text = "Wolf2";
        wolfScreen.gameObject.SetActive(true);

    }
}
