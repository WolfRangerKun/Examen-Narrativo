using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene intance;
    public int NumeroDeEscena;
    public AudioSource click;

    public GameObject fondoPantallaDeCarga;
    public Slider Slider;
    public AudioSource musicaNivel;

    private void Awake()
    {
        intance = this;
    }
    private void Start()
    {
       
    }
    public void CargarNivel(int NumeroDeEscena)
    {
        click.Play();
        StartCoroutine(CargarAsync(NumeroDeEscena));
    }
    public void MainMenu(int NumeroDeEscena)
    {
        click.Play();
        StartCoroutine(CargarAsync(NumeroDeEscena));
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator CargarAsync(int NumerodeEscena)
    {

        AsyncOperation Operation = SceneManager.LoadSceneAsync(NumerodeEscena);
        //
        //SetactiveFalse
        //
        StartCoroutine (GameManager.instance.StartFade(musicaNivel, 2, .1f));
        fondoPantallaDeCarga.SetActive(true);

        while (!Operation.isDone)
        {
            float Progreso = Mathf.Clamp01(Operation.progress / .9f);
            Slider.value = Progreso;

            yield return null;
        }
    }
}