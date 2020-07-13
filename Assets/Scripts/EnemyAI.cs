using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Playables;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public float killRange = 2f;
    public float noticeRange = 5f;

    public Transform player;
    private GameManager gameManager;

    public PlayableDirector timeline;

    public RoomTemplates roomTemplates;
    public float waitTime = 4f;
    public float adjacentRoomRange;

    public List<Transform> nextRooms;

    public AIDestinationSetter aiDest;

    public bool chasingPlayer = false;

    public bool readyToMove = true;

    public float chasePlayerForSeconds = 10f;

    public AudioSource audio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        timeline = GameObject.FindGameObjectWithTag("Timeline").GetComponent<PlayableDirector>();
        audio = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < killRange)
        {
            StartCoroutine(KillPlayer());
        }

        if (Vector2.Distance(transform.position, player.position) < noticeRange && !player.GetComponent<PlayerController>().hidden)
        {
            chasingPlayer = true;
            aiDest.target = player;
            chasePlayerForSeconds = 10f;
        } else if (chasingPlayer)
        {
            chasePlayerForSeconds -= Time.deltaTime;
            if (chasePlayerForSeconds <= 0)
            {
                chasingPlayer = false;
                readyToMove = true;
                UpdateNextRooms();
            }
        }

        if (waitTime <= 0 && !chasingPlayer)
        {
            UpdateNextRooms();
            waitTime = UnityEngine.Random.Range(2f, 5f);
        }
        else
        {
            if (readyToMove)
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
       

    public IEnumerator KillPlayer()
    {
        timeline.Play();
        audio.enabled = false;
        yield return new WaitForSeconds(3);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDead = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(player.position, adjacentRoomRange);
        Gizmos.DrawWireSphere(transform.position, killRange);
        Gizmos.DrawWireSphere(transform.position, noticeRange);
    }

    public void UpdateNextRooms()
    {
        nextRooms.Clear();

        for (int i = 0; i < roomTemplates.rooms.Count; i++)
        {
            if (Vector2.Distance(player.position, roomTemplates.rooms[i].transform.position) < adjacentRoomRange)
            {
                    nextRooms.Add(roomTemplates.rooms[i].transform);
            }
        }

        
        GoToNextRoom();
    }

    public void GoToNextRoom()
    {
        aiDest.target = nextRooms[UnityEngine.Random.Range(0, nextRooms.Count)];
        readyToMove = false;
        Invoke("ResetReadyToMove", UnityEngine.Random.Range(2, 8));
    }

    public void ResetReadyToMove()
    {
        readyToMove = true;
    }
}   
