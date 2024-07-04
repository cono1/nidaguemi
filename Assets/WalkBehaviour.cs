using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float speed = 10f;

    private Vector2 desiredDirection;

    private void Start()
    {
        if(rigidBody == null) 
            rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 horizontalMovement = new Vector2(desiredDirection.x * speed, 0);

        if (rigidBody != null)
            rigidBody.AddForce(horizontalMovement);
    }

    public void Move(Vector2 direction)
    {
        desiredDirection = direction;
    }
}
