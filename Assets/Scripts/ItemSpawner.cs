using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Dictionary<int,ItemSpecs> items = new();
    [SerializeField] ItemSpecs[] itemSpecs;
    public GameObject itemPrefab;
    void Start()
    {
        //Loading all scriptable objects in items folder:
        itemSpecs = Resources.LoadAll<ItemSpecs>("Items");
        
        for(int i = 0; i< itemSpecs.Length; i++){
            items.Add(i, itemSpecs[i]);
        }
        
    }

    
    void Update()
    {
        
    }


    public void SpawnRandomItem(){
        GameObject created = Instantiate(itemPrefab, new Vector3(0,0,0), transform.rotation);
        created.GetComponent<Item>().itemSpecs = items[Random.Range(0,2)];
    }
}
