using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Joystick joy;
    float horizontalMove = 0;
    float verticalMove = 0;
    public float runSpeedHorizontal = 3;
    public float runSpeedVertical = 3;
    public float runSpeed = 0;

    Rigidbody2D rig2D;
    
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        verticalMove = joy.Vertical * runSpeedVertical;
        horizontalMove = joy.Horizontal * runSpeedHorizontal;

        transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime * runSpeed;
    }
}
