using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigitbody;

    [SerializeField]
    [Range(0f, 8f)]
    private float _jumpPower;

    [Header("Events")]
    public UnityEvent Died;

    private bool _onGround = true;

    private bool _doubleJump = false;

    private string position = "Center";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Jump_Left();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Jump_Right();
    }

   

    private void Jump()
    {
        if (_onGround || (!_onGround && !_doubleJump)) 
            _rigitbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            
        if (!_onGround && !_doubleJump)
            _doubleJump = true;
    }

    private void Jump_Left()
    {
        if (position == "Center")
        {
            position = "Left";
            transform.Translate(new Vector3(-2, 0, 0));
        }
        else if (position == "Right")
        {
            position = "Center";
            transform.Translate(new Vector3(-2, 0, 0));
        }
        else return;
       // _rigitbody.AddForce(Vector3.left * 5, ForceMode.Impulse);
    }
    private void Jump_Right()
    {
        if (position == "Center")
        {
            position = "Right";
            transform.Translate(new Vector3(2, 0, 0));
        }
        else if (position == "Left")
        {
            position = "Center";
            transform.Translate(new Vector3(2, 0, 0));
        }
        else return;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Puh!");
            Died.Invoke();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Pums");
            _onGround = true;
            _doubleJump = false;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            return;

        _onGround = false;
    }
}
