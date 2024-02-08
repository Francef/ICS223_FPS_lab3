using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private float gravity = -9.8f;
    private float speed = 9.0f;
    [SerializeField]
    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);

        // clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.09f);

        // take speed into account
        movement *= speed;

        movement.y = gravity;

        // make movement processor independent
        movement *= Time.deltaTime;

        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);

        charController.Move(movement);
    }
}
