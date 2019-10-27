using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory), typeof(PlayerEquipment))]
public class PlayerPickUpHandler : MonoBehaviour
{
    private PlayerInventory inventory = null;
    private PlayerEquipment equipment = null;

    private void Awake() 
    {
        inventory = GetComponent<PlayerInventory>();
        equipment = GetComponent<PlayerEquipment>();    
    }

    private void PickUp(Item item)
    {
        if(item is Weapon)
        {
            Weapon weapon = (Weapon)item;
            if(equipment.Weapon == null)
            {
                equipment.EquipWeapon(weapon);
            }
            else if(weapon.Attack > equipment.Weapon.Attack)
            {
                Weapon previousWeapon = equipment.EquipWeapon(weapon);
                if(previousWeapon != null)
                {
                    inventory.Add(previousWeapon);
                }
            }
        }
        else if (item is Armor)
        {
            Armor armor = (Armor)item;
            if(equipment.Armor == null)
            {
                equipment.EquipArmor(armor);
            }
            else if(armor.Arm > equipment.Armor.Arm)
            {
                Armor previousArmor = equipment.EquipArmor(armor);
                if(previousArmor != null)
                {
                    inventory.Add(previousArmor);
                }
            }
        }
        else
        {
            inventory.Add(item);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Item item = other.gameObject.GetComponent<ItemDrop>().Item;
            PickUp(item);
            Destroy(other.gameObject);
        }
    }
}
