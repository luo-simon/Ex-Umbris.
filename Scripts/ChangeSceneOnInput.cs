using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnInput : MonoBehaviour
{

    public int loadSceneIndex = 1;
    public Blackout blackout;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {

            StartCoroutine(blackout.Fade());
            StartCoroutine("LoadAfterSeconds", 2);
            StartCoroutine(StartFade(GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>(), 2, 0));
        }
    }

    public IEnumerator LoadAfterSeconds(float secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(loadSceneIndex);
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
