using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public float range = 2f;

    private Transform player;
    private GameManager gameManager;

    public int sceneToLoadIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < range)
        {
            if (Input.GetKeyDown("space") && player.GetComponent<PlayerController>().hasKey)
            {
                gameManager.level++;
                if (gameManager.level == 3)
                {
                    gameManager.LoadScene(sceneToLoadIndex + 1);
                } else
                {
                    gameManager.LoadScene(sceneToLoadIndex);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
