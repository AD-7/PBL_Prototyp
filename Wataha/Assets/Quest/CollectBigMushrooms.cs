﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBigMushrooms : Quest
{
    public Text buttonInfo;
    private GameObject wataha;
    private int mushroomsLeft;
    // Start is called before the first frame update
    void Start()
    {
        buttonInfo.gameObject.SetActive(false);
        wataha = GameObject.FindGameObjectWithTag("Player");
        mushroomsLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mushroomsLeft);
        if (mushroomsLeft > 0)
        {
            if (IfInRatio() && questStatus == status.ACTIVE)
            {
                
                if (Input.GetKey(KeyCode.E))
                {
                    if(ObjectInRatio().active)
                    mushroomsLeft -= 1;
                    ObjectInRatio().SetActive(false);
                    buttonInfo.gameObject.SetActive(false);
                }


            }
            else
            {
                buttonInfo.gameObject.SetActive(false);
            }
        }
        else
        {
            buttonInfo.gameObject.SetActive(false);
            if (IfInRatioFinish() && Input.GetButton("Use") && questStatus == status.ACTIVE)
            {
                questSucced();
            }
            
        }
      

   }

public bool IfInRatio()
    {
        for(int i =0; i<5; i++)
        {
            if(
            (wataha.transform.position.x - questItems[i].transform.position.x) < 3.0f &&
            (wataha.transform.position.x - questItems[i].transform.position.x) > -3.0f &&
              (wataha.transform.position.z - questItems[i].transform.position.z) < 3.0f &&
                (wataha.transform.position.z - questItems[i].transform.position.z) > -3.0f)
            {
                if(questItems[i].active)
                   buttonInfo.gameObject.SetActive(true);
                return true;
            }

            
        }
        return false;
    }

    public GameObject ObjectInRatio()
    {
        for (int i = 0; i < 5; i++)
        {
            if (
            (wataha.transform.position.x - questItems[i].transform.position.x) < 3.0f &&
            (wataha.transform.position.x - questItems[i].transform.position.x) > -3.0f &&
              (wataha.transform.position.z - questItems[i].transform.position.z) < 3.0f &&
                (wataha.transform.position.z - questItems[i].transform.position.z) > -3.0f)
            {
                return questItems[i];
            }


        }
        return null;
    }

    public bool IfInRatioFinish()
    {

        if (
             (wataha.transform.position.x - questDestination.transform.position.x) < 5.0f &&
             (wataha.transform.position.x - questDestination.transform.position.x) > -5.0f &&
             (wataha.transform.position.z - questDestination.transform.position.z) < 5.0f &&
             (wataha.transform.position.z - questDestination.transform.position.z) > -5.0f)
        {

            return true;
        }

        return false;
    }

}
