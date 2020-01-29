using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellSpeed
{
    Slow,
    Medium,
    Fast
}

public enum SpellTarget
{
    AOE,
    Single
}

[CreateAssetMenu()]
public class Spell : Item
{
    [SerializeField] private int damage;
    public int Damage { get { return damage; } }

    [SerializeField] private SpellSpeed spellSpeed;
    public SpellSpeed SpellSpeed { get { return spellSpeed; } }

    [SerializeField] private SpellTarget spellTarget;
    public SpellTarget SpellTarget { get { return spellTarget; } }
}
