using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Wolf : MonoBehaviour
{

     public int strength = 10;
    public int resistance = 10;
    public int speed = 10;
    public int agression = 100;
    public int energy= 100;
    System.Random rand = new System.Random();
    public struct Evolution
    {
        public int strength;
        public int resistance;
        public int speed; 
        public int agression;
        public int costM;
        public int costWF;
        public int costGF;

        public Evolution(int strength, int resistance, int speed, int agression, int costM, int costWF, int costGF)
        {
            this.strength = strength;
            this.resistance = resistance;
            this.speed = speed;
            this.agression = agression;
            this.costM = costM;
            this.costWF = costWF;
            this.costGF = costGF;
        }
    }

    public  List<Evolution> skills= new List<Evolution>();

    // Start is called before the first frame update
    void Start()
    {
        Evolution first = new Evolution(2, 1, 1, 1, 50, 0, 0);

        Evolution second = new Evolution(1, 2, 1, 1, 50, 0, 0);
        skills.Add(first);
        skills.Add(second);
     
        for(int i=0; i < 20; i++)
        {
            for(int j=0; j < 2; j++)
            {
               
                 int tmp = rand.Next(0, 2);
                int tmp2 = rand.Next(0, 5);
                int tmp3 = rand.Next(0, 1);
                int tmp4 = rand.Next(0, 3);
                skills.Add(new Evolution(((skills[skills.Count - 1].strength ) + (tmp2*tmp)), ((skills[skills.Count - 1].resistance ) + (tmp2 * tmp)), ((skills[skills.Count - 1].speed ) + (tmp3* tmp4)), ((skills[skills.Count - 1].agression ) + (tmp4 * tmp3)), skills[skills.Count - 1].costM* (tmp + 1), skills[skills.Count - 1].costWF * (tmp + 1), skills[skills.Count - 1].costGF * (tmp+1)));
            }
          

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
