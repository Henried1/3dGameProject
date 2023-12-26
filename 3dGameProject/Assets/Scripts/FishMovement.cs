using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float rotationSpeed = 100f; // Adjust the rotation speed as needed
    private Rigidbody rb;
    void Start()
    {


        // Get or add Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Set to true if you want to control physics manually
        }
    }

    void Update()
    {
        // Move forward and backward
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

        // Turn left and right
        float horizontalInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Turn up and down
        float pitchInput = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right * -pitchInput * rotationSpeed * Time.deltaTime);

        // Lock the z-axis rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);

        // You can also add additional controls for rolling (sideways rotation)
        //float rollInput = Input.GetAxis("Mouse X");
        //transform.Rotate(Vector3.forward * rollInput * rotationSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        print("enter");
    }
    private void OnCollisionStay(Collision collision)
    {
        rb.velocity = Vector3.zero;
        print("stay");
    }
    void OnCollisionExit(Collision collision)
    {
        // Reset angular velocity to stop rotation
        rb.angularVelocity = Vector3.zero;
        print("exit");
    }


}