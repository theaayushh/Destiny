using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    [TextArea] public string itemDescription;
    public Sprite itemIcon;

    public bool isCurrency;
    public int stackSize = 2;

    [Header("Item Stats")]
    public int damage;
    public int maxHealth;
    public int currentHealth;
    public int speed;

    [Header("For Temporary Items")]
    public float duration;

}
