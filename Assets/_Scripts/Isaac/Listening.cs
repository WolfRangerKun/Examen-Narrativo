using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listening : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;
    public float speed;

    public List<GameObject> playerRefs;
    public GameObject pointref;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    RaycastHit hitListtening;
    void Start()
    {
        //playerRef = GameObject.FindGameObjectWithTag("Player");
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
             Libreta.instance.notasPalabras.Add(target.gameObject.GetComponent<FrasePersona>().palabraFea) ;
        }
        print("Escuchando");

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

   
}
