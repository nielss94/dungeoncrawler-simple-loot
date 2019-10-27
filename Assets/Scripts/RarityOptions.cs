using UnityEngine;

[CreateAssetMenu()]
public class RarityOptions : ScriptableObject
{
    public MinMaxFloat commonChance = null;
    public MinMaxFloat epicChance = null;
    public MinMaxFloat legendaryChance = null;
}