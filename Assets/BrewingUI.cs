using UnityEngine;

public class BrewingUI : MonoBehaviour
{
    [SerializeField] private GameObject content;
    private PlayerStats playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerStats = PlayerStats.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenInventory(){
        UpdateInventory();
    }

    void UpdateInventory(){
        foreach(Item item in playerStats.GetInventory()){
            
        }
    }
}
