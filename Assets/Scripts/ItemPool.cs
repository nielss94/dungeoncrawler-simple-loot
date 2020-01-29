using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ItemPool : MonoBehaviour
{
    public static ItemPool Instance { get; private set;}

    [SerializeField] private List<Item> itemPool = new List<Item>();
    [SerializeField] private RarityOptions rarityOptions = null;

    
    System.Random random;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }    
    }

    private void Start() 
    {
        random = new System.Random(); 
    }

    public Item GetRandomItem()
    {
        float randomResult = (float)random.NextDouble();
        IEnumerable<Item> eligibleItems = null;

        if(randomResult > rarityOptions.legendaryChance.Min)
        {
            eligibleItems = itemPool.Where(item => item.ItemRarity == ItemRarity.Legendary);
        } 
        else if (randomResult > rarityOptions.epicChance.Min)
        {
            eligibleItems = itemPool.Where(item => item.ItemRarity == ItemRarity.Epic);
        }
        else if (randomResult > rarityOptions.commonChance.Min)
        {
            eligibleItems = itemPool.Where(item => item.ItemRarity == ItemRarity.Common);
        }

        if(eligibleItems == null || eligibleItems.Count() == 0)
            return null;

        int randomIndex = UnityEngine.Random.Range(0, eligibleItems.Count());
        return eligibleItems.ToArray()[randomIndex];
    }
}
