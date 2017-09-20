using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public float reloadTime = 1f;
    private bool readyToTrigger = false;

    void Awake()
    {
        StartCoroutine(WaitUtileReload());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        if (Input.GetMouseButtonDown(0) && readyToTrigger && playerController.keyPressed == "z")
        {
            Debug.Log("teleport");
            TriggerTeleport();

            // Stop moving
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Moving", false);
        }
    }

    void TriggerTeleport()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        readyToTrigger = false;
        StartCoroutine(WaitUtileReload());
    }

    IEnumerator WaitUtileReload()
    {
        yield return new WaitForSeconds(reloadTime);
        readyToTrigger = true;
    }
}
