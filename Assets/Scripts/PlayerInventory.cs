using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Item> inventory = new List<Item>();


    public void Add(Item item)
    {
        print("added " + item.name + " to inventory");
        inventory.Add(item);
    }
}
