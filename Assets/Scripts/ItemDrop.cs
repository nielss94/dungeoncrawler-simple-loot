using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Item Item;
    [SerializeField] private float forcePower = 3f;
    
    [SerializeField] private new Rigidbody rigidbody = null;

    public void Burst(Vector3 dir)
    {
        dir.y += forcePower * 2;
        rigidbody.AddForce(dir * forcePower, ForceMode.Impulse);
    }
}
