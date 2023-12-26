using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float rotationSpeed = 100f; // Adjust the rotation speed as needed


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

        // You can also add additional controls for rolling (sideways rotation)
        //float rollInput = Input.GetAxis("Mouse X");
        //transform.Rotate(Vector3.forward * rollInput * rotationSpeed * Time.deltaTime);
    }

}