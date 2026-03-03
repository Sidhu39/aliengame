
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float rotationSpeed = 2.0f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 1.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;


    void Start()
    {
        rb.useGravity = true;
        controller = gameObject.AddComponent<CharacterController>();
    }

    
    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back);
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.LeftShift))
            rb.AddForce(Vector3.down);
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
}
