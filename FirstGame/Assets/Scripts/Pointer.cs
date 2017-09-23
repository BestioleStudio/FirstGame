using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Pointer : MonoBehaviour {

    //public GameObject player;
    private Animator animPlayer;
    //public System.Object pl;

    // Use this for initialization
    void Start () {
        animPlayer = GameObject.Find("Player").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1) || animPlayer.GetBool("Moving") == false)
            GameObject.Destroy(this.gameObject);
	}
}
