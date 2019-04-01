using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntingHUD : MonoBehaviour
{
    public Wolf wolfHunt;
    public Text time;
    public Text maxMeat;
    public Text meatHuntedText;
    public Text meatHuntedIntheEndText;
    public Text EnergyLoss;
    public Button Return;
    public GameObject EndInfo;
    public GameObject Info;

    int meatHuntedd;
    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        meatHuntedd = 0;

        if(wolfHunt.resistance < 11)
        {
            timeLeft = 10.0f;
            time.text = "Time left: " + timeLeft;
        }



    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        time.text = "Time left: " + timeLeft;

        if(timeLeft <= 0)
        {
            Info.SetActive(false);
            EndInfo.SetActive(true);
        }
    }
}
