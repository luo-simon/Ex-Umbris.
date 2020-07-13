using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;
	public GameObject monster;
	public GameObject key;

	public int keyRoomIndex;

	void Start()
    {
		StartCoroutine(LateStart(1));
	}
	void Update()
	{

		if (waitTime <= 0 && spawnedBoss == false)
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if (i == rooms.Count - 1)
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
				}

				if (i == keyRoomIndex)
                {
					Instantiate(key, rooms[i].transform.position, Quaternion.identity);
					Instantiate(monster, rooms[i].transform.position, Quaternion.identity);
				}
			}

			// A star scan
			AstarPath.active.Scan();
			spawnedBoss = true;
		}
		else
		{
			waitTime -= Time.deltaTime;
		}
	}

	public IEnumerator LateStart(float secs)
    {
		yield return new WaitForSeconds(secs);
		keyRoomIndex = UnityEngine.Random.Range(0, rooms.Count - 2);
		UnityEngine.Debug.Log(keyRoomIndex);
	}
}