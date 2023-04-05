using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class MonsterController : MonoBehaviour
{
    public float Acceleration;
    public float MoveInterval;
    public float maxHp;
    public float monsterDmg;
    public MonsterSpawner mSpawner;

    private GameObject player;
    private Rigidbody2D rgbody;
    private SpriteRenderer spRenderer;
    private Animator anim;

    private float currentInterval;
    private float currentHp;

    private Vector2 playerMonsterDif;
    public void Init()
    {
        currentInterval = 0f;
        currentHp = maxHp;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rgbody = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Init();
    }

    private void OnEnable()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        currentHp -= Time.deltaTime;

        if (currentHp <= 0)
        {
            Die();
        }

        //playerMonsterDif = player.transform.localPosition - gameObject.transform.localPosition;

        //spRenderer.flipX = playerMonsterDif.x > 0;

        //currentInterval += Time.deltaTime;
        //if (currentInterval > MoveInterval)
        //{
        //    rgbody.velocity = new Vector2(Math.Sign(playerMonsterDif.x) * Acceleration, rgbody.velocity.y);
        //    currentInterval = 0;
        //}
        //anim.SetFloat("speed", Math.Abs(rgbody.velocity.x));
    }

    public void Hit(float hitDmg)
    {
        //currentHp -= hitDmg;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerController>().Hit(Math.Sign(playerMonsterDif.x), monsterDmg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
        //mSpawner.monsterDead(gameObject);
    }
}

