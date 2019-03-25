using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveGoldFang : Quest
{
    public int hoManyGoldFang;
    private GameObject wataha;
    public HUDController hud;

    void Start()
    {        
        wataha = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hud.GoldFangs >= 10)
        { 
            if (IfInRatioFinish() && Input.GetButton("Use") && questStatus == status.ACTIVE)
            {
                questSucced();
                hud.GoldFangs -= hoManyGoldFang;
            }

        }


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
