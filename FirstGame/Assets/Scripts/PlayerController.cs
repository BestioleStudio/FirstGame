using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigidbody;
    public Camera Camera;
    private Vector3 _target;
    private Animator anim;
    private float rotation_z;
    private Vector3 pos;
    private Vector3 difference;
    public float moveSpeed = 30f;
    public GameObject _pointer;

    // Use this for initialization
    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("Moving", false);
    }
    public void OnEnable()
    {
        if (Camera == null)
        {
            throw new InvalidOperationException("Camera not set");
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            _target = Camera.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            if (anim.GetBool("Moving") == false)
                anim.SetBool("Moving", true);

            pos = transform.position;
        }
        
        difference = _target - pos;
        difference.Normalize();
        rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (anim.GetBool("Moving")== true)
        {
            Instantiate(_pointer, _target, Quaternion.identity);
            playerRigidbody.position = Vector3.Lerp(playerRigidbody.position, _target, (moveSpeed/100) /(Vector3.Distance(playerRigidbody.position, _target)));
        }

        if (transform.position == _target)
        {
            anim.SetBool("Moving", false);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

    }
    
}