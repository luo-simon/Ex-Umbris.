using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public float range = 2f;

    private Transform player;
    private GameManager gameManager;

    public Sprite vacant;
    public Sprite occupied;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < range)
        {
            if (Input.GetKeyDown("space"))
            {
                ToggleHidePlayer();
            }
        }
    }

    public void ToggleHidePlayer()
    {
        player.GetComponent<PlayerController>().hidden = !player.GetComponent<PlayerController>().hidden;

        if (player.GetComponent<PlayerController>().hidden)
        {
            GetComponent<SpriteRenderer>().sprite = occupied;
        } else
        {
            GetComponent<SpriteRenderer>().sprite = vacant;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
