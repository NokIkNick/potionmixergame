using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public ItemSpecs itemSpecs {get; set;}
    private TextMeshProUGUI nameText;

    public Item(ItemSpecs itemSpecs){
        this.itemSpecs = itemSpecs;
    }

    void Start()
    {
        nameText = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        nameText.text = itemSpecs.itemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ItemTyping {
    LIQUID,
    FOOD,
    MAGICAL, 
    LIVING,
    DEAD,
    UNDEAD,
    RAINBOW,
    FLAMMABLE,
    MEAT,
    BONE
}
