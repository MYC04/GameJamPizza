using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public  class InventoryManager : MonoBehaviour
{
    
    Canvas Canvas;
    GameObject Inventory;
    GameObject[] SlotParents;
    GameObject[] SlotObjects;
    int CurrentIndex;//Index OF empty slot 
    //Çalıntı kod
    private static InventoryManager _Manager;
    public static InventoryManager Manager
    {  get 
        { 
            if (_Manager == null)
            {
                GameObject inventoryObject = new GameObject("InventoryManager");
                _Manager = inventoryObject.AddComponent<InventoryManager>();
                DontDestroyOnLoad(inventoryObject);
            }
            return _Manager;
        
        } 
    }
    private void Awake()
    {
        CurrentIndex = 0;
        if (_Manager == null)
        {
            _Manager = this;
            DontDestroyOnLoad(gameObject); // Make persistent
        }
        else if (_Manager != this)
        {
            Destroy(gameObject); // Enforce singleton pattern
        }
    }


    private void Start()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Inventory = Canvas.transform.Find("Inventory").gameObject;
        SlotParents = new GameObject[Inventory.transform.childCount];
        SlotObjects = new GameObject[Inventory.transform.childCount];
        for (int i = 0; i < SlotParents.Length; i++)
        {
            SlotParents[i] = Inventory.transform.GetChild(i).gameObject;
        }
    }

    public void CreateInventory()
    { }
    public void CheckInventory(string Object) { }

    public int UpdateInventory(int index)
    {
        if (SlotObjects[index+1] != null)
        {
            SlotObjects[index] = SlotObjects[index + 1];
            SlotParents[index].transform.GetChild(0).GetComponent<RawImage>().texture = SlotParents[index].transform.GetChild(0).GetComponent<ObjectInGame>().Picture;
        }
        return index + 1;
       

    }
    public void AddInventory(GameObject Object) 
    {
        RawImage InventoryRawImage = SlotParents[CurrentIndex].transform.GetChild(0).GetComponent<RawImage>();
        SlotObjects[CurrentIndex] = Object;
        InventoryRawImage.texture = SlotObjects[CurrentIndex].GetComponent<ObjectInGame>().Picture;
        InventoryRawImage.enabled = true;

        CurrentIndex++;
    }
    public void RemoveInventory(GameObject Object, int Index) 
    {
        CurrentIndex = Index;
        RawImage InventoryRawImage = SlotParents[CurrentIndex].transform.GetChild(0).GetComponent<RawImage>();
        SlotObjects[CurrentIndex] = null;
        InventoryRawImage.texture = null;
        InventoryRawImage.enabled = false;
        CurrentIndex = UpdateInventory(CurrentIndex);

    }

    public void SelectInventory(int Index) { }

    public void ClearInventory() { }







}
