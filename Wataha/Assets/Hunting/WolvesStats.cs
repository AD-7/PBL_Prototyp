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
    public Wolf wolf1;
    public Wolf wolf2;
    public Wolf wolf3;
    public Wolf wolf4;
    public Wolf wolf5;
    public int wolvesPositionX;
    public int wolvesPositionZ;
    public int wolvesRotationY;
    public int meat;
    public int wf;
    public int gf;
 
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
