using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




public class PlayerLogic : MonoBehaviour
{
    private float speed = 450f;
    private float jumpForce = 200f;

    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Collider playerCol;
    [SerializeField] private Transform frontPoint;
    [SerializeField] private Transform sidePoint;
    [SerializeField] private GameObject player;
    private Vector3 groundPoint = Vector3.down;
    private bool isJump;
    private bool isGrounded;
    private float raycastMaxDistance = 0.1f;



    private void OnCollisionStay(Collision collision)
    {
        if (playerCol.ClosestPoint(collision.contacts[collision.contacts.Length - 1].point).y < transform.position.y - playerCol.bounds.extents.y / 2)
        {
            groundPoint = playerCol.ClosestPoint(collision.contacts[collision.contacts.Length - 1].point) - transform.position;
        }
        else
        {
            groundPoint = Vector3.down;
        }



    }
    public void Start()
    {
        LevelsFeatures();
        
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
        RaycastHit hit;
        isGrounded = Physics.Raycast(gameObject.transform.position, groundPoint, out hit, playerCol.bounds.extents.y + raycastMaxDistance);
        if (isGrounded && hit.transform.tag.Equals("Ground"))
        {
            player.transform.SetParent(hit.transform);
        }
        else
        {
            player.transform.SetParent(null);
        }
    }

    private void LevelsFeatures()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level 3":
                jumpForce = 300f;
                playerBody.mass = 50;
                raycastMaxDistance = 0.5f;
                break;
            case "Level 4":
                jumpForce = 230f;
                raycastMaxDistance = 0.2f;
                break;
        }
    }

}






