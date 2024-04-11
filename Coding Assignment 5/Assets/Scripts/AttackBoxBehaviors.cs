using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxBehaviors : MonoBehaviour
{
    public GameController controller;
    public int objectLifetime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < objectLifetime)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            controller.HitPlayer1();
        }else if (collision.gameObject.layer == 7)
        {
            controller.HitPlayer2();
        }
    }
}

