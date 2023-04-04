using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    private GameObject monster;
    public Queue<GameObject> monsterQueue = new Queue<GameObject>();

    public float spawnCycle;
    float spawnCooldown;

    void Awake()
    {
        monster = (GameObject)Resources.Load("Prefabs/Monster/slimeBlue", typeof(GameObject));
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject t = Instantiate(monster, this.gameObject.transform);
            monsterQueue.Enqueue(t);
            t.GetComponent<MonsterController>().mSpawner = this;
            t.SetActive(false);
        }
        spawnCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown += Time.deltaTime;
        if (monsterQueue.Count > 0 && spawnCooldown > spawnCycle)
        {
            spawnMonster();
            spawnCooldown = 0;
        }
    }

    void spawnMonster()
    {
        float xPos = Random.Range(-2, 2);
        Vector3 varVector = new Vector3(xPos, 0f, 0f);
        GameObject t = monsterQueue.Dequeue();
        t.SetActive(true);
        t.transform.position = gameObject.transform.position + varVector;
    }

    public void monsterDead(GameObject t)
    {
        t.SetActive(false);
        monsterQueue.Enqueue(t);
        spawnCooldown = 1;
    }
}
