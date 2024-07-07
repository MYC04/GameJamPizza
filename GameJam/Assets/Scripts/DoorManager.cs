using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    private bool doorLock = false;
    [SerializeField]
    private GameObject doorTrigger;
    [SerializeField]
    private GameObject key;
    private DoorTrigger inTrigger;
    private KeyTrigger keyTrig;


    void Start()
    {
        inTrigger = doorTrigger.GetComponent<DoorTrigger>();
        keyTrig = key.GetComponent<KeyTrigger>();
    }

    void Update()
    {
        if(inTrigger.inTrigger == true && Input.GetKeyDown(KeyCode.P) && (keyTrig.keyPickedUp == true || doorLock == false))
        {
            Debug.Log("DoorOpen");
        }   
    }
}
