using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public float range = 2f;

    private Transform player;
    private GameManager gameManager;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < range)
        {
            if (Input.GetKeyDown("space"))
            {
                PickUp();
            }
        }
    }

    public void PickUp()
    {
        player.GetComponent<PlayerController>().hasKey = true;
        GetComponent<SpriteRenderer>().enabled = false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
