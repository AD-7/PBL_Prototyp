using System.Collections;
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
        mushroomsLeft = this.questItems.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (IfInRatio())
        {
            buttonInfo.gameObject.SetActive(true);
        }

   }

public bool IfInRatio()
    {
        for(int i =0; i<4; i++)
        {
         if(
            (wataha.transform.position.x - questItems[i].transform.position.x) < 3.0f &&
            (wataha.transform.position.x - questItems[i].transform.position.x) > -3.0f &&
              (wataha.transform.position.x - questItems[i].transform.position.x) < 3.0f &&
                (wataha.transform.position.x - questItems[i].transform.position.x) > -3.0f)
            {
                return true;
            }

            
        }
        return false;
    }

}
