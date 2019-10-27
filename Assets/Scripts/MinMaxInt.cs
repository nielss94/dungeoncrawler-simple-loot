using UnityEngine;

[System.Serializable]
public class MinMaxInt
{
    public int Min;
    public int Max;

    public int Rand { get { return Random.Range(Min, Max); } }
}