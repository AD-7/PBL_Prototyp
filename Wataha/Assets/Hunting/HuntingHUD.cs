using System;
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
    public GameObject GameScene;
    public GameObject HuntScene;

    int meatHuntedd;
    int maxMeatt;
    float timeLeft;
    // Start is called before the first frame update
    private void Awake()
    {
        Return.onClick.AddListener(ReturnClicked);
    }
    void Start()
    {
      
        meatHuntedd = 0;

        if (wolfHunt.resistance < 10)
        {
            timeLeft = 10.0f;
            time.text = "Time left: " + timeLeft;
        }
        else if (wolfHunt.resistance < 15)
        {
            timeLeft = 15.0f;
            time.text = "Time left: " + timeLeft;
        }

        else if (wolfHunt.resistance < 20)
        {
            timeLeft = 22.0f;
            time.text = "Time left: " + timeLeft;
        }
        else if (wolfHunt.resistance >=20)
        {
            timeLeft = 35.0f;
            time.text = "Time left: " + timeLeft;
        }

        if(wolfHunt.strength < 10)
        {
            maxMeatt = 30;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }
        else if (wolfHunt.strength < 15)
        {
            maxMeatt = 80;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }
        else if (wolfHunt.strength < 20)
        {
            maxMeatt = 150;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }
        else if (wolfHunt.strength >= 20)
        {
            maxMeatt = 250;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }

    }

  




    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        time.text = "Time left: " + timeLeft;

        if(timeLeft <= 0)
        {
            Info.gameObject.SetActive(false);
            EndInfo.gameObject.SetActive(true);
        }
    }

    public void ReturnClicked()
    {

        GameScene.gameObject.SetActive(true);
        HuntScene.gameObject.SetActive(false);
    }
}
