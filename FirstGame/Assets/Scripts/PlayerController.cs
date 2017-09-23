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
    public String keyPressed;

    // Use this for initialization
    void Start()
    {
        Transform sprite = transform.Find("PlayerSprite");

        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = sprite.GetComponent<Animator>();
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
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown("a"))
            {
                keyPressed = "a";
            } else if (Input.GetKeyDown("z"))
            {
                keyPressed = "z";
            }
        }

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
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
            playerRigidbody.position = Vector3.Lerp(playerRigidbody.position, _target, (moveSpeed/100) /(Vector3.Distance(playerRigidbody.position, _target)));
        }

        if (Input.GetMouseButtonUp(1))
        {
            Instantiate(_pointer, _target, Quaternion.identity);
        }

        if (transform.position == _target)
        {
            anim.SetBool("Moving", false);
        }

        Transform sprite = transform.Find("PlayerSprite");

        sprite.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

    }
    
}