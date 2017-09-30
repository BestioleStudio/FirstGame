using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellManager : MonoBehaviour
{
    private KeyCode keyPressed = KeyCode.Joystick8Button19;
    public float offset; 

    [SerializeField]
    private GameObject[] spells = new GameObject[6];

    [SerializeField]
    private GameObject[] spellsIcon = new GameObject[6];

    [SerializeField]
    private KeyCode[] shortcuts = new KeyCode[6];

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            for ( int i = 0; i<shortcuts.Length; i++ )
            {
                if (Input.GetKeyDown(shortcuts[i]))
                {
                    keyPressed = shortcuts[i];
                    break;
                }
            }
        }

        // Check if you can cast
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < shortcuts.Length; i++)
            {
                if (!keyPressed.Equals(KeyCode.Joystick8Button19) && keyPressed == shortcuts[i])
                {
                    CooldownCashScript cooldownCashScript = spellsIcon[i].GetComponent<CooldownCashScript>();

                    if (cooldownCashScript.isCooldown.Equals(false))
                    {
                        CastSpell(spells[i]);

                        cooldownCashScript.isCooldown = true;
                        cooldownCashScript.cooldownCash.fillAmount = 1;
                        keyPressed = KeyCode.Joystick8Button19;
                    }
                }
            }
        }
    }

    void CastSpell(GameObject spell)
    {
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 normaliseVector = (mousePosition - (Vector2)transform.position).normalized;
        // to make the player not hurting himself
        Vector2 offsetVector = normaliseVector * offset;

        switch (spell.name)
        {
            case "BaseSpell1-1":
                GameObject go = (GameObject)Instantiate(spell, (Vector2)transform.position + offsetVector, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(normaliseVector.x * 5f, normaliseVector.y * 5f);
                break;

            case "Teleport-1":
                transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Transform sprite = transform.Find("PlayerSprite");

                // Stop moving
                Animator anim = sprite.GetComponent<Animator>();
                anim.SetBool("Moving", false);
                break;

            default:
                break;
        }

        // Creation of the spell
        

        //readyToShoot = false;
    }
}
