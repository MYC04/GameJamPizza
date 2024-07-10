using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInGame : MonoBehaviour
{


    [SerializeField] public Texture Picture;

    public  void PickedUp()
    {   
        if(gameObject)
        {

            InventoryManager.Manager.AddInventory(gameObject);
            Destroy(gameObject);
        }

    }
 

  
}
