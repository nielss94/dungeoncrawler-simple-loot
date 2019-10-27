using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private float openingRange = 2f;
    [SerializeField] private MinMaxInt itemMinMax = null;
    [SerializeField] private Texture2D cursorImage = null;
    [SerializeField] private ItemDrop itemDropPrefab = null;
    [SerializeField] private float openingTime = .5f;

    private bool available = true;
    private Player player = null;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    private void Awake() 
    {
        player = FindObjectOfType<Player>();
    }

    private void OnMouseEnter() {
        Cursor.SetCursor(cursorImage,hotSpot,cursorMode);
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(1) && available && Vector3.Distance(transform.position, player.transform.position) < openingRange)
        {
            Open();
        }
    }

    private void OnMouseExit() {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    private void Open()
    {
        available = false;

        int itemAmount = itemMinMax.Rand;
        
        //Potentially a hashset if we want unique values
        List<Item> itemsToDrop = new List<Item>();

        for (int i = 0; i < itemAmount; i++)
        {
            Item newItem = ItemPool.Instance.GetRandomItem();
            itemsToDrop.Add(newItem);    
        }

        StartCoroutine(DropItems(itemsToDrop));
    }

    private IEnumerator DropItems(IEnumerable<Item> items)
    {
        yield return new WaitForSeconds(openingTime);
        
        Item[] itemArray = items.ToArray();
        for (int i = 0; i < itemArray.Length; i++)
        {
            yield return new WaitForSeconds(.2f);
            DropItem(itemArray[i], i);
        }
    }

    private void DropItem(Item item, int index)
    {
        ItemDrop itemDrop = Instantiate(itemDropPrefab, transform.position, Quaternion.identity);
        itemDrop.Item = item;

        Vector3 force = transform.forward * (index * 1.1f + 1);

        itemDrop.Burst(force);
    }
}
