using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandelScript : MonoBehaviour
{
    private bool isOpened;
    public GameObject canvas;
    public int WhiteFangsNumb = 1, GoldFangsNumb = 1, MeatNumb = 10;

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
            if (Input.GetKeyDown(KeyCode.F)) {
                if (controller.WhiteFangs >= WhiteFangsNumb && controller.GoldFangs >= GoldFangsNumb) {
                    controller.WhiteFangs -= WhiteFangsNumb;
                    controller.GoldFangs -= GoldFangsNumb;
                    controller.Meat += MeatNumb;
                    Debug.Log("sold");
                }
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpened) {
            isOpened = true;
            OpenHandelWindow();
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        isOpened = false;
    }

    private void OpenHandelWindow() {

    }

    private void ExitHandelWindow() {
        
    }
}
