using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance {get; private set;}

    private int damage = 5;
    [SerializeField] List<Item> inventory;


    private void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


    }


    public void AddToInventory(Item item){
        if(inventory == null){
            inventory = new List<Item>();
        }

        inventory.Add(item);
    }

    public void AddListToInventory(List<Item> items){
        if(inventory == null){
            inventory = new List<Item>();
        }

        foreach(Item i in items){
            inventory.Add(i);
        }
    }

    public void RemoveItemFromInventory(Item item){
        Item objectToRemove = inventory.Find(i => i.GetComponent<ItemSpecs>().itemName == item.GetComponent<ItemSpecs>().itemName);
        inventory.Remove(objectToRemove);
    }


    public int GetDamage(){
        return this.damage;
    }

    public List<Item> GetInventory(){
        return this.inventory;
    }
}
