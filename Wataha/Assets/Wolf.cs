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
        Evolution first = new Evolution(2, 1, 1, 0, 50, 0, 0);

        Evolution second = new Evolution(1, 2, 0, 0, 50, 0, 0);

        skills.Add(first);
        skills.Add(second);

        skills.Add(new Evolution(5,5,0,0,70,10,0));
        skills.Add(new Evolution(0,0,2,2,90,20,0));

        skills.Add(new Evolution(5,2,0,5,10,50,10));
        skills.Add(new Evolution(2,8,2,0,20,50,5));

        skills.Add(new Evolution(0, 0, 6, 5, 80, 20, 10));
        skills.Add(new Evolution(8, 5, 0, 0, 50, 50, 0));

        skills.Add(new Evolution(5, 2, 0, 5, 10, 50, 10));
        skills.Add(new Evolution(2, 8, 2, 0, 20, 50, 5));

        skills.Add(new Evolution(10, 2, 0, 5, 100, 30, 10));
        skills.Add(new Evolution(2, 10, 5, 0, 100, 30, 15));

        skills.Add(new Evolution(8, 12, 10, 1, 150, 20, 10));
        skills.Add(new Evolution(9, 12, 2, 15, 200, 50, 0));



    }

    void copyStat(Wolf wolf)
    {
        strength = wolf.strength;
        resistance = wolf.resistance;
        speed = wolf.speed;
        agression = wolf.agression;
        energy = wolf.energy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
