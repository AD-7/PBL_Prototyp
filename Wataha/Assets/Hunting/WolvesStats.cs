using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolvesStats : MonoBehaviour
{
    public static WolvesStats Instance
    {
        get;
        set;
    }
    public int strength = 10;
    public int resistance = 10;
    public int speed = 10;
    public int agression = 100;
    public int energy = 100;
    void Awake()
    {
        if(Instance == null)
        {
          DontDestroyOnLoad(transform.gameObject);
        Instance = this;
        }
        else
        {
            Destroy(this);
        }
     
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
