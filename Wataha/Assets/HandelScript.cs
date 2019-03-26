using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandelScript : MonoBehaviour
{
    private bool isOpened;
    public GameObject canvas;
    public int Fangs = 5, MeatToWhiteFangs = 20, MeatToGoldFangs = 30;
    public Text buttonInfoC;
    public Text buttonInfoV;
    private HUDController controller;
    void Start()
    {
        isOpened = false;
        controller = canvas.GetComponent<HUDController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpened) {
           
            if (Input.GetKeyDown(KeyCode.C)) {
                if (controller.Meat >= MeatToWhiteFangs ) {
                    controller.WhiteFangs += Fangs;
                    controller.Meat -= MeatToWhiteFangs;
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (controller.Meat >= MeatToGoldFangs)
                {
                    controller.GoldFangs += Fangs;
                    controller.Meat -= MeatToGoldFangs;

                }

            }


        }
      
    }
    
    private void OnTriggerEnter(Collider other)
    {
        buttonInfoC.gameObject.SetActive(true);
        buttonInfoV.gameObject.SetActive(true);
        Debug.Log("enter");
        if (!isOpened) {
            isOpened = true;
            OpenHandelWindow();
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        isOpened = false;
        buttonInfoC.gameObject.SetActive(false);
        buttonInfoV.gameObject.SetActive(false);
    }

    private void OpenHandelWindow() {

    }

    private void ExitHandelWindow() {
        
    }
}
