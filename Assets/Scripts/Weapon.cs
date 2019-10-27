using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Weapon : Item
{
    [SerializeField] private int attack;
    public int Attack { get { return attack; } }

    [SerializeField] private bool isProjectile;
    public bool IsProjectile { get { return isProjectile; } }
}
