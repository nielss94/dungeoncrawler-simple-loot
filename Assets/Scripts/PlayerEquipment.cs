using UnityEngine;

public class PlayerEquipment : MonoBehaviour {
    public Weapon Weapon = null;
    public Armor Armor = null;

    public Weapon EquipWeapon(Weapon weapon)
    {
        print("picked up " + weapon.name);
        Weapon previousWeapon = Weapon;
        Weapon = weapon;

        return previousWeapon;
    }

    public Armor EquipArmor(Armor armor)
    {
        print("picked up " + armor.name);
        Armor previousArmor = Armor;
        Armor = armor;

        return previousArmor;
    }
}