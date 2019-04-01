using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HuntingHUD : MonoBehaviour
{

    public Text time;
    private float timeForHunting;

    WolvesStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = WolvesStats.Instance;
        if (stats.wolf1.resistance < 11)
        {
            timeForHunting = 9.99f;
        }
        time.text = "Time left: " + timeForHunting.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        timeForHunting -= Time.deltaTime;
        time.text = "Time left: " + timeForHunting.ToString();

        if(timeForHunting <= 0)
        {
            timeForHunting = 0;
            SceneManager.LoadScene("SampleScene");
        }

    }
}
