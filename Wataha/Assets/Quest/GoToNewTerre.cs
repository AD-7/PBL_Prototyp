using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNewTerre : Quest
{
    private GameObject wataha;

    void Start()
    {
        wataha = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (IfInRatio() && Input.GetButton("Use") && questStatus == status.ACTIVE)
            this.questStatus = status.SUCCED;
    }


    public bool IfInRatio()
    {

        if (
             (wataha.transform.position.x - questDestination.transform.position.x) < 5.0f &&
             (wataha.transform.position.x - questDestination.transform.position.x) > -5.0f &&
             (wataha.transform.position.z - questDestination.transform.position.z) < 5.0f &&
             (wataha.transform.position.z - questDestination.transform.position.z) > -5.0f)
            return true;
        return false;
    }
}
