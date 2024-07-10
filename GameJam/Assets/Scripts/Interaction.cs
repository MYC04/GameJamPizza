using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    List<Collider> Others;
    private void Awake()
    {
        Others = new List<Collider>();
    }
    void Update()
    {
        List<Collider> toBeRemoved = new List<Collider>();
        foreach (var other in Others) 
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
 
                
                other.GetComponent<ObjectInGame>().PickedUp();
                toBeRemoved.Add(other);
            }
           
        }
        foreach (var item in toBeRemoved)
        {
            Others.Remove(item);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("pickable"))
        {
            Others.Add(other);
        
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("pickable"))
        {
            Others.Remove(other);


        }
    }
   


}
