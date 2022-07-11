using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 50f;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] GameObject thirdPersonCamera;
    [SerializeField] GameObject firstPersonCamera;
    private bool isThirdPerson = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moves vehicle forwards or backwards based on vertical input
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates vehicle  based on horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("test");
            ToggleCamera();
        }
    }

    void ToggleCamera()
    {
        if (isThirdPerson)
        {
            thirdPersonCamera.SetActive(false);
            firstPersonCamera.SetActive(true);

        }
        else
        {
            thirdPersonCamera.SetActive(true);
            firstPersonCamera.SetActive(false);
        }
        isThirdPerson = !isThirdPerson;
    }
}
