using UnityEngine;

[System.Serializable]
public class MinMaxFloat
{
    public float Min;
    public float Max;

    public float Rand { get { return Random.Range(Min, Max); } }
}