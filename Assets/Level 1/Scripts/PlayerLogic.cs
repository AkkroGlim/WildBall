using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    private float speed = 450f;
    private float jumpForce = 200f;
    
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Collider playerCol;
    [SerializeField] private Transform frontPoint;
    [SerializeField] private Transform sidePoint;
    [SerializeField] private GameObject player;


    private bool isJump;
    
    private bool isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        if (true)
        {
            //collision.collider.ClosestPoint(transform.position)
        }
        
    }
    public void Start()
    {
        
        playerBody.maxAngularVelocity = 4f;
    }
    public void FixedUpdate()
    {
        RaycastCheck();
        Move();
        jump();       
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJump = true;
        }

    }

    private void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 point = frontPoint.transform.position - transform.position;
        Vector3 point2 = sidePoint.transform.position - transform.position;
        if (vertical > 0)
        {
            playerBody.AddForceAtPosition(point * speed, transform.position, ForceMode.Force);
        }
        else if (vertical < 0)
        {
            playerBody.AddForceAtPosition(point * -1 * speed, transform.position, ForceMode.Force);
        }

        if (horizontal > 0)
        {
            playerBody.AddForceAtPosition(point2 * speed, transform.position, ForceMode.Force);
        }
        else if (horizontal < 0)
        {
            playerBody.AddForceAtPosition(point2 * -1 * speed, transform.position, ForceMode.Force);
        }

    }

    private void jump()
    {      
        if (isJump && isGrounded)
        {
            isJump = false;           
            playerBody.AddForce(new Vector3(0f, jumpForce, 0f) * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);           
        }
    }

    private void RaycastCheck()
    {
        //isGrounded = Physics.Raycast(gameObject.transform.position, Vector3.down, playerCol.bounds.extents.y + 0.01f);
        RaycastHit hit;
        isGrounded = Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, playerCol.bounds.extents.y + 0.01f);
        if (isGrounded)
        {
            player.transform.SetParent(hit.transform);
        }
        else
        {
            player.transform.SetParent(null);
        }
    }


}

   




