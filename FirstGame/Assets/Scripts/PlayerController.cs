using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D playerRigidbody;
    public Camera Camera;
    private bool FollowMouse;
    private Vector3 _target;
    private bool ShipAccelerates;
    private Vector3 mousePosition;
    private Animator anim;
    private bool flag;
    private bool moving;

    //NavMeshAgent agent;
    private Vector3 endPoint;
    public float duration = 20f;

    // Use this for initialization
    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
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

        //anim.SetBool("Moving", false);

        /*if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
		{
			//transform.Translate (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);
			playerRigidbody.velocity = new Vector2(Input.GetAxisRaw ("Horizontal") * moveSpeed, playerRigidbody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) 
		{
			//transform.Translate (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f);
			playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
		}
        */

        //if (Input.GetMouseButton(1))
        //{
        //    anim.SetBool("Moving",true);
        //    mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        //    mousePosition = Camera.ScreenToWorldPoint(mousePosition);
        //    //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        //    playerRigidbody.velocity = Vector2.Lerp(playerRigidbody.velocity, mousePosition - transform.position, moveSpeed);
        //    Vector3 difference = mousePosition - transform.position;
        //    difference.Normalize();
        //    float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        //    //playerRigidbody.angularVelocity = rotation_z/(Time.deltaTime);          
        //}

        //if (Input.GetMouseButton(1))
        //{
        //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // .main.ScreenToWorldPoint(mousePosition);
        //    transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(mousePosition), moveSpeed);

        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //difference.Normalize();
        //float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        //}


        //if (Input.GetMouseButtonDown(1))
        //{
        //    //while ((mousePosition - transform.position) != new Vector3(0f, 0f, 0f))

        //    anim.SetBool("Moving", true);
        //    mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        //    mousePosition = Camera.ScreenToWorldPoint(mousePosition);
        //    //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        //    playerRigidbody.velocity = Vector2.Lerp(playerRigidbody.velocity, mousePosition - transform.position, moveSpeed);
        //    Vector3 difference = mousePosition - transform.position;
        //    difference.Normalize();
        //    float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        //    //while ((mousePosition - transform.position) != new Vector3(0f, 0f, 0f))
        //    //{

        //    //}

        //    //playerRigidbody.velocity = new Vector2(0f, 0f);
        //    //playerRigidbody.angularVelocity = 0f;
        //    //anim.SetBool("Moving", true);
        //}

        //if ((mousePosition - transform.position) != new Vector3(0f, 0f, 0f))
        //{
        //    playerRigidbody.velocity = new Vector2(0f, 0f);
        //    anim.SetBool("Moving", false);
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    RaycastHit hit;

        //    if (Physics.Raycast(Camera.ScreenPointToRay(Input.mousePosition), out hit))
        //    {
        //        //playerRigidbody.velocity = new Vector2(hit.point.x*moveSpeed, hit.point.y*moveSpeed);
        //        //playerRigidbody.velocity = Vector2.Lerp(playerRigidbody.velocity, hit.point, moveSpeed);
        //        endPoint = hit.point;
        //        if (!Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        //        {
        //            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, moveSpeed);
        //        }
        //    }


            //          ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) 
            //{
            //	playerRigidbody.velocity = new Vector2 (0f, playerRigidbody.velocity.y);
            //}

            //if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) 
            //{
            //	playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, 0f);
            //}


        //}

        //check if the screen is touched / clicked   
        //if (Input.GetMouseButtonDown(1))
        //{
        //    //declare a variable of RaycastHit struct
        //    RaycastHit hit;
        //    //Create a Ray on the tapped / clicked position
        //    Ray ray;
        //    //for unity editor
        //    //#if UNITY_EDITOR
        //    ray = Camera.ScreenPointToRay(Input.mousePosition);
        //    ////for touch device
        //    //#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
        //    //ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    //#endif

        //    //Check if the ray hits any collider
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        //set a flag to indicate to move the gameobject
        //        flag = true;
        //        //save the click / tap position
        //        endPoint.x = hit.point.x;
        //        endPoint.y = hit.point.y;
        //        endPoint.z = 0f;
        //        //as we do not want to change the y axis value based on touch position, reset it to original y axis value
        //        //endPoint.y = yAxis;
        //        Debug.Log(endPoint);
        //    }

        //}
        ////check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
        //if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        //{ //&& !(V3Equal(transform.position, endPoint))){
        //  //move the gameobject to the desired position
        //    transform.position = Vector3.Lerp(transform.position, endPoint, moveSpeed);
        //    //playerRigidbody.velocity = Vector2.Lerp(playerRigidbody.velocity, mousePosition - transform.position, moveSpeed);
        //}
        ////set the movement indicator flag to false if the endPoint and current gameobject position are equal
        //else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        //{
        //    flag = false;
        //    Debug.Log("I am here");
        //}

        if (Input.GetMouseButtonDown(1))
        {
            _target = Camera.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            if (moving == false)
                moving = true;
            anim.SetBool("Moving", true);
        }

        if (moving == true)
        {
            //transform.position = Vector3.MoveTowards(transform.position, _target, moveSpeed);
            //playerRigidbody.velocity = Vector2.Lerp(playerRigidbody.velocity, _target, moveSpeed);
            //playerRigidbody.velocity = new Vector2(_target.x* moveSpeed, _target.y*moveSpeed);
            //transform.position = Vector3.Lerp(transform.position, _target, 1 / (duration * (Vector3.Distance(transform.position, _target))));
            //transform.position = Vector3.Lerp(transform.position, _target, moveSpeed*Time.deltaTime);
            //playerRigidbody.velocity = Vector2.Lerp(playerRigidbody.velocity, _target, moveSpeed);
            playerRigidbody.position = Vector3.Lerp(playerRigidbody.position, _target, 1 / (duration * (Vector3.Distance(playerRigidbody.position, _target))));
            Vector3 difference = _target - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        }

        if (transform.position == _target)
        {
            anim.SetBool("Moving", false);
        }
    }
    
}