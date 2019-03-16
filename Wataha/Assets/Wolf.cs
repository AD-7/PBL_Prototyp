using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{

     public int strength = 10;
    public int resistance = 10;
    
    public int energy= 100;

    public struct Evolution
    {
        public int strength;
        public int resistance;
        public int costM;
        public int costWF;
        public int costGF;

        public Evolution(int strength, int resistance, int costM, int costWF, int costGF)
        {
            this.strength = strength;
            this.resistance = resistance;
            this.costM = costM;
            this.costWF = costWF;
            this.costGF = costGF;
        }
    }

    public  List<Evolution> skills= new List<Evolution>();

    // Start is called before the first frame update
    void Start()
    {
      
        skills.Add(new Evolution(2, 0,50,0,0));
        skills.Add(new Evolution(0, 2,50,10,0));
        skills.Add(new Evolution(5, 1,50,50,0));
        skills.Add(new Evolution(1, 5,70,50,0));
        skills.Add(new Evolution(10, 0, 50, 50, 1));
        skills.Add(new Evolution(3, 8, 100, 50, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
