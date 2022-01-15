using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 positionLand;
    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundPosition;
    public LayerMask groundMask;

    [Range(5f, 20f)] [SerializeField] private float speed = 12f;
    [Range(0f, 20f)] [SerializeField] private float speedMove = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    [SerializeField] private BMI currentBMI = BMI.Normal;
    private Vector3 velocity;
    private bool isGrounded;
    private float bmiPoint = 30f;
    private float distantFromLand;
    private enum BMI { Thin = 18, Normal = 25, Fat = 35 };
    void Start()
    {
        targetPosition = transform.position;
        distantFromLand = Mathf.Abs(positionLand.x-positionLand.y);
        transform.position = new Vector3(transform.position.x,transform.position.y,positionLand.y);
    }


    void Update()
    {
        Movement();
        UpdateStatusPlayer();
    }
    private void LateUpdate()
    {
        controller.Move(velocity * Time.deltaTime);

        if (transform.position.z == targetPosition.z)
            isMoving = false;

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, targetPosition.z), speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime;

    }
    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundPosition.position, 0.5f, groundMask);
        // if (isGrounded)
        //     velocity.y = 0;
        Debug.Log(isGrounded);
        //Controll
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > positionLand.x && !isMoving && isGrounded)
        {
            targetPosition = transform.position + Vector3.back * distantFromLand;
            isMoving = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < positionLand.z && !isMoving && isGrounded)
        {
            targetPosition = transform.position + Vector3.forward * distantFromLand;
            isMoving = true;
        }

        controller.Move(Vector3.right * speedMove * Time.deltaTime);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

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
