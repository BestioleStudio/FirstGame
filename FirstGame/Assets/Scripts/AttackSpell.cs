using System.Collections;
using UnityEngine;

public class AttackSkill : MonoBehaviour {

    public float reloadTime = 1f;
    public int damage = 10;
    public float velocity;
    public bool readyToShoot = false;

    public string keyToTrigger;

	// Use this for initialization
	void Start () {
        waitUtileReload();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && readyToShoot) {
            Shoot();
        }
	}

    void Shoot () {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 playerPosition = GameObject.Find("MainCharacter").transform.position;

        readyToShoot = false;
        waitUtileReload();
    }

    IEnumerator waitUtileReload ()
    {
        yield return new WaitForSeconds(reloadTime);
        readyToShoot = true;
    }
}
