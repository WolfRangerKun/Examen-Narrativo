using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager instance;
    public Volume volumeLisening, volumeObsevacion, volumeLibrito;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator LiseningFiltroIn()
    {
        while (volumeLisening.weight < 1 && true)
        {
            volumeLisening.weight += .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator LiseningFiltroOut()
    {
        while (volumeLisening.weight > 0 && true)
        {
            volumeLisening.weight -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator ObsFiltroIn()
    {
        while (volumeObsevacion.weight < 1 && true)
        {
            volumeObsevacion.weight += .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator ObsFiltroOut()
    {
        while (volumeObsevacion.weight > 0 && true)
        {
            volumeObsevacion.weight -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator LibroFiltroIn()
    {
        while (volumeLibrito.weight < 1 && true)
        {
            volumeLibrito.weight += .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }

    public IEnumerator LibroFiltroOut()
    {
        while (volumeLibrito.weight > 0 && true)
        {
            volumeLibrito.weight -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }
}
