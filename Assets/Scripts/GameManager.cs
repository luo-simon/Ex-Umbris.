using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int level = 0;

    public bool isDead = false;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                level = 0;
                isDead = false;
                LoadScene(0);
            }
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
