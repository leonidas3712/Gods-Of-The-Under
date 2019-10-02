using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Heal : MonoBehaviour
{

    int blood = 0;
    [SerializeField] int maxBlood;
    PlayerHp hp;
    Text bloodText;
    public static Heal playerHeal;
    bool airborneHit = false;
    Rigidbody2D rig;

    private void Start()
    {
        PlayerInput.playerActions.Player.Heal.performed += Action;
        rig = GetComponent<Rigidbody2D>();
        hp = GetComponent<PlayerHp>();
        playerHeal = this;
        bloodText = GameObject.Find("blood").GetComponent<Text>();
        syncBlood();
    }
    void Update()
    {
        if (Gravity.grounded) airborneHit = false;
    }
    void Action(InputAction.CallbackContext con)
    {
        if (blood > 0)
        {
            hp.HealHp(blood / 2);
            blood = 0;
            syncBlood();
        }
        else
        {
            PlayerHp.playerHp.TakeDamage(1, Vector3.zero);
        }

    }
    public void IncreaseStack(int amount)
    {
        if (!airborneHit) airborneHit = true;
        else
        {
            if (blood + amount > maxBlood) blood = maxBlood;
            else
                blood += amount;
            syncBlood();
        }
    }
    public void TakeDamage(int damage, Vector3 dir)
    {
        blood -= damage * 2;
        if (blood < 0)
        {
            blood = 0;
        }
        syncBlood();
    }
    void syncBlood()
    {
        bloodText.text = "";
        for (int i = 0; i < blood; i++)
        {
            bloodText.text += "<3 ";
        }
    }
}
