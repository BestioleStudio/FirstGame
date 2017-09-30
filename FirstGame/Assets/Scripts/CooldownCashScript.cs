using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownCashScript : MonoBehaviour {

    public Image cooldownCash;
    public float cooldown;
    public bool isCooldown;

    private void Start()
    {
        isCooldown = true;
        cooldownCash.fillAmount = 1;
    }

    void Update () {
		if (isCooldown)
        {
            cooldownCash.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (cooldownCash.fillAmount <= 0)
            {
                isCooldown = false;
            }
        }
	}
}
