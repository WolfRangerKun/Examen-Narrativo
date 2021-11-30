using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
public class VolumeManager : MonoBehaviour
{
    public static VolumeManager instance;
    public Volume volumeLisening, volumeObsevacion, volumeLibrito;
    public AudioSource zoomIn1, zoomOut1, zoomIn2, zoomOut2, zoomIn3, zoomOut3;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator LiseningFiltroIn()
    {
        zoomIn1.Play();
        while (volumeLisening.weight < 1 && true)
        {
            volumeLisening.weight += .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator LiseningFiltroOut()
    {
        zoomOut1.Play();

        while (volumeLisening.weight > 0 && true)
        {
            volumeLisening.weight -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator ObsFiltroIn()
    {
        zoomIn2.Play();

        while (volumeObsevacion.weight < 1 && true)
        {
            volumeObsevacion.weight += .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator ObsFiltroOut()
    {
        zoomOut2.Play();

        while (volumeObsevacion.weight > 0 && true)
        {
            volumeObsevacion.weight -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator LibroFiltroIn()
    {
        
        zoomIn3.Play();

        while (volumeLibrito.weight < 1 && true)
        {
            volumeLibrito.weight += .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator LibroFiltroOut()
    {
        zoomOut3.Play();

        while (volumeLibrito.weight > 0 && true)
        {
            volumeLibrito.weight -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }
}
