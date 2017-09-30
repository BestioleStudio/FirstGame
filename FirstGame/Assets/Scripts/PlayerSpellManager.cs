using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellManager : MonoBehaviour
{
    private int selectedSpellNumber = 999999;
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
                if (Input.GetKeyDown(shortcuts[i]) && spells[i] != null)
                {
                    if (selectedSpellNumber != 999999)
                    {
                        CooldownCashScript previouscooldownCashScript = spellsIcon[selectedSpellNumber].GetComponent<CooldownCashScript>();
                        previouscooldownCashScript.selected.color = new Color(1f, 1f, 1f, 0f);
                    }

                    CooldownCashScript cooldownCashScript = spellsIcon[i].GetComponent<CooldownCashScript>();
                    cooldownCashScript.selected.color = new Color(1f, 1f, 1f, 1f);

                    selectedSpellNumber = i;
                    break;
                }
            }
        }

        // Check if you can cast
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedSpellNumber != 999999)
            {
                CooldownCashScript cooldownCashScript = spellsIcon[selectedSpellNumber].GetComponent<CooldownCashScript>();

                if (cooldownCashScript.isCooldown.Equals(false))
                {
                    CastSpell(spells[selectedSpellNumber]);

                    cooldownCashScript.isCooldown = true;
                    cooldownCashScript.cooldownCash.fillAmount = 1;

                    CooldownCashScript previouscooldownCashScript = spellsIcon[selectedSpellNumber].GetComponent<CooldownCashScript>();
                    previouscooldownCashScript.selected.color = new Color(1f, 1f, 1f, 0f);

                    selectedSpellNumber = 999999;
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
    }
}
