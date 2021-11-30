using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isMenu;
    public bool levelOneComplete;
    public bool lastarriasOne;

    public GameObject triggerFinalNivel, triggerLastUno;
    public AudioSource bgm;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMenu)
        {
            Cursor.visible = true;

        }
        if (levelOneComplete)
        {
            triggerFinalNivel.SetActive(true);
            levelOneComplete = false;
        }
        if (lastarriasOne)
        {
            triggerLastUno.SetActive(true);
            lastarriasOne = false;
        }
    }


    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
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
