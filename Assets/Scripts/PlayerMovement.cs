using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundPosition;
    public LayerMask groundMask;

    [Range(5f, 20f)] [SerializeField] private float speed = 12f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    [SerializeField]private BMI currentBMI = BMI.Normal;
    private Vector3 velocity;
    private bool isGrounded;
    private float bmiPoint = 30f;
    private enum BMI { Thin = 18, Normal = 25, Fat = 35 };
    void Start()
    {
        targetPosition = transform.position;
    }


    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.I))
            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z * 1.5f);
    UpdateStatusPlayer();
    }
    private void LateUpdate()
    {
        if (transform.position.z == targetPosition.z)
            isMoving = false;

        if (isMoving)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundPosition.position, 0.1f, groundMask);
        if (isGrounded)
            velocity.y = 0;
        //Controll
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > 0 && !isMoving && isGrounded)
        {
            targetPosition = transform.position + Vector3.back * 2f;
            isMoving = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < 4 && !isMoving && isGrounded)
        {
            targetPosition = transform.position + Vector3.forward * 2f;
            isMoving = true;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    private void UpdateStatusPlayer()
    {
        switch (currentBMI)
        {
            case BMI.Thin:
                jumpHeight = 2.5f;
                gravity = -10f;
                break;
            case BMI.Normal:
                jumpHeight = 2f;
                gravity = -15f;
                break;
            case BMI.Fat:
                jumpHeight = 1f;
                gravity = -25f;
                break;
        }

    }
}
