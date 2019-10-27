using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Armor : Item
{
    [SerializeField] private int armor;
    public int Arm { get { return armor; } }
}
