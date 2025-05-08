using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemType", order = 1)]
public class ItemSpecs : ScriptableObject
{
    public string itemName;
    public string description;
    public string creature;
    public ItemTyping firstItemTyping;
    public ItemTyping secondItemTyping;

}
