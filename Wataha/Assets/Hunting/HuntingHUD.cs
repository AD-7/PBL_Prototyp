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
    public GameObject AnimalManager;

    public int meatHuntedd;
    public int maxMeatt;
    float timeLeft;

    bool started = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Return.onClick.AddListener(ReturnClicked);
    }
    void Start()
    {

        Info.SetActive(true);
        EndInfo.SetActive(false);

        meatHuntedd = 0;

        if (wolfHunt.resistance < 10)
        {
            timeLeft = 16.0f;
            time.text = "Time left: " + timeLeft;
        }
        else if (wolfHunt.resistance < 15)
        {
            timeLeft = 22.0f;
            time.text = "Time left: " + timeLeft;
        }

        else if (wolfHunt.resistance < 20)
        {
            timeLeft = 28.0f;
            time.text = "Time left: " + timeLeft;
        }
        else if (wolfHunt.resistance >=20)
        {
            timeLeft = 35.0f;
            time.text = "Time left: " + timeLeft;
        }

        if(wolfHunt.strength < 10)
        {
            maxMeatt = 20;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }
        else if (wolfHunt.strength < 15)
        {
            maxMeatt = 50;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }
        else if (wolfHunt.strength < 20)
        {
            maxMeatt = 100;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }
        else if (wolfHunt.strength >= 20)
        {
            maxMeatt = 250;
            maxMeat.text = "Max.meat: " + maxMeatt.ToString();
        }


        started = true;
    }

  
    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            Start();
            AnimalManager.GetComponent<AnimalSpawn>().StartP();
        }
        else
        {

            timeLeft -= Time.deltaTime;
            time.text = "Time left: " + timeLeft;
            meatHuntedText.text = "Meat hunted: " + meatHuntedd;
            meatHuntedIntheEndText.text = meatHuntedText.text;

            if (timeLeft <= 0 || maxMeatt == meatHuntedd)
            {
                AnimalManager.SetActive(false);
                foreach (GameObject animal in GameObject.FindGameObjectsWithTag("Animal"))
                {
                    GameObject.Destroy(animal);
                }
                Info.gameObject.SetActive(false);
                EndInfo.gameObject.SetActive(true);
            }
        }
    }

    public void ReturnClicked()
    {
        started = false;
        foreach (AnimalSpawn spawn in AnimalManager.GetComponentsInChildren<AnimalSpawn>())
        {
            spawn.CancelInvoke();
        }

        GameScene.GetComponentInChildren<HUDController>().Meat += meatHuntedd;

        GameScene.gameObject.SetActive(true);
        HuntScene.gameObject.SetActive(false);
    }
}
