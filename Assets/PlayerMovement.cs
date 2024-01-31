using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float horizInput;
    private float vertInput;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5.0f;
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        /*

        transform.Translate(movement);*/

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizInput, 0, vertInput) * speed * Time.deltaTime * 100;
        //rb.MovePosition(movement);
        rb.velocity = movement;
    }

}
