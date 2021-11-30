using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isMenu;
    public bool levelOneComplete;
    public bool lastarriasOne, lastarriaTwo;
    public bool gameRunning;
    public bool canPause = true;
    public GameObject pasuePanel;
    public Transform fin, inicio;

    public GameObject triggerFinalNivel, triggerLastUno, termina;
    public AudioSource bgm;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        if (isMenu)
        {
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        if (lastarriaTwo)
        {
            termina.SetActive(true);
            lastarriaTwo = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            ChangedGameRunningState();
        }
    }

    IEnumerator CorridaFlaite()
    {
        yield return new WaitForSeconds(1);
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

    public void ChangedGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            PlayerMovementIsaac.instance.MouseState();
            StartCoroutine(VolumeManager.instance.LibroFiltroOut());

            DOTween.defaultTimeScaleIndependent = true;
            pasuePanel.transform.DOMove(inicio.position, 1 ) ;

            PlayerMovementIsaac.instance.canMove = true;
            Time.timeScale = 1f;

        }
        else
        {
            PlayerMovementIsaac.instance.MouseState();

            StartCoroutine(VolumeManager.instance.LibroFiltroIn());

            DOTween.defaultTimeScaleIndependent = true;

            pasuePanel.transform.DOMove(fin.position, 1);
            PlayerMovementIsaac.instance.canMove = false;

            Time.timeScale = 0f;
        }
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }

    public void CargarNivel(int numeroDeEscena)
    {
        SceneManager.LoadScene(numeroDeEscena);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
