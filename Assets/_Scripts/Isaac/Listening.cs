using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listening : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;
    public float speed;

    public GameObject[] playerRefs;
    public GameObject cameraLisening;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        playerRefs = GameObject.FindGameObjectsWithTag("Persona");
    }
    private void Update()
    {
        if (canSeePlayer && Input.GetKeyDown(KeyCode.Return))
        {
            Escuchando();
        }
    }

    private void FixedUpdate()
    {
        FieldOfViewCheck();
    }
    void Escuchando()
    {
        if (target.gameObject.GetComponent<FrasePersona>())
        {
            Libreta.instance.CompararPalabras(target.gameObject.GetComponent<FrasePersona>().palabraFea, target.gameObject.GetComponent<FrasePersona>().palabraSignififcado);
            StartCoroutine("Escuchar");
        }
    }
    Transform target;
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {

            target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget,distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    public AudioSource fondo, talk;

    public IEnumerator Escuchar()
    {
        print("Corrutina");
        PlayerMovementIsaac.instance.canMove = false;
        StartCoroutine(StartFade(fondo, 1, .1f));
        cameraLisening.transform.position = target.transform.position;
        cameraLisening.SetActive(true);
        yield return new WaitForSeconds(2);
        talk.Play();
        yield return new WaitForSeconds(3f);
        StartCoroutine(StartFade(fondo, 1, 1f));
        cameraLisening.SetActive(false);

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
