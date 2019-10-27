using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemRarity
{
    Common,
    Epic,
    Legendary
}

[CreateAssetMenu()]
public class Item : ScriptableObject
{
    [SerializeField] private new string name = "";
    public string Name { get { return name; } }

    [SerializeField] private ItemRarity itemRarity;
    public ItemRarity ItemRarity { get { return itemRarity; } }
}
