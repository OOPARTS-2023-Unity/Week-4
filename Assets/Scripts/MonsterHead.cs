using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHead : MonoBehaviour
{

    public MonsterController monsterController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerFeet"))
        {
            monsterController.Hit(5);
            collision.GetComponentInParent<PlayerController>().LaunchUp();
        }
    }
}

