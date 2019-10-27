using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3.37f;

    private Vector3 destination;
    private new Rigidbody rigidbody = null;

    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody>();    
    }

    private void Start() 
    {
        destination = transform.position;    
    }

    private void FixedUpdate() 
    {
        if(transform.position != destination)
        {
            MoveToDestination();
        }
    }

    private void MoveToDestination()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        rigidbody.MovePosition(newPos);
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }
}
