using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alienMovement : MonoBehaviour
{
    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    public Rigidbody rb;
    public float rotationSpeed = 2.0f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 1.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
{

        rb.useGravity = true;
        controller = gameObject.AddComponent<CharacterController>();
    
    GetReferences();

}
    private void Update()
    {
        MoveToTarget();
        float translation = Input.GetAxis("Vertical") * playerSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
    }
    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}

