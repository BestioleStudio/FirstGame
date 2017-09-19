﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithSpell : MonoBehaviour {

    public float reloadTime = 1f;
    public int damage = 10;
    public float velocity = 5;
    private bool readyToShoot = false;
    public GameObject spell;
    public float offset = 1f;

    public string keyToTrigger;

    // Use this for initialization
    void Awake()
    {
        StartCoroutine(waitUtileReload());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && readyToShoot)
        {
            Debug.Log("fire");
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 normaliseVector = (mousePosition - (Vector2)transform.position).normalized;
        // to make the player not hurting himself
        Vector2 offsetVector = normaliseVector * offset;

        // Creation of the spell
        GameObject go = (GameObject)Instantiate(spell, (Vector2)transform.position + offsetVector, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(normaliseVector.x * velocity, normaliseVector.y * velocity);

        readyToShoot = false;
        StartCoroutine(waitUtileReload());
    }

    IEnumerator waitUtileReload()
    {
        yield return new WaitForSeconds(reloadTime);
        readyToShoot = true;
    }
}
