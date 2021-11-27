using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Cinemachine;
using DG.Tweening;




public class PlayerMovementIsaac : MonoBehaviour
{
    public static PlayerMovementIsaac instance;
    public GameObject listening, dd;
    bool isListeing;
    public float speed;
    public float jump;
    public AutoFlip book;

    public SpriteRenderer sprite;

    Rigidbody rb;
    private Vector2 moveInput;
    public LayerMask whatIsGround;

    public Transform groundPoint;
    public bool isGrounded, canMove, changeCamera;
    public UnityEvent cameraTercera,cameraPrimera;

    public GameObject left, right,posUp,posDown, libreta;
    bool showLibro;
    bool canChangeCamera = true;
    bool canChangeAudio = true;
    bool canLibrito = true;
    bool canPlayLibrito;
    bool isInOtherSide;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }

    public void Update()
    {

        //RaycastHit hit;
        //if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .01f, whatIsGround))
        //{
        //    isGrounded = true;
        //}
        //else
        //{
        //    isGrounded = false;
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canMove)
        //{
        //    rb.velocity += new Vector3(0, jump /**40* Time.deltaTime*/, 0);
        //}

        Controls();

        SpriteAndCameraAxis();
    }
    
    private void FixedUpdate()
    {
        if (canMove)
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
            moveInput.Normalize();

            if (isInOtherSide)
            {
                rb.velocity = new Vector3(moveInput.x * speed /**40* Time.deltaTime*/, rb.velocity.y, moveInput.y * speed /**40 * Time.deltaTime*/);
            }
            else
            {
                rb.velocity = new Vector3(moveInput.x * speed * -1 /**40* Time.deltaTime*/, rb.velocity.y, moveInput.y * speed * -1/**40 * Time.deltaTime*/);
            }
        }
    }

    public void ChangeMovementAxis()
    {
        StartCoroutine(Pasara());
    }
    
    IEnumerator Pasara()
    {
        yield return new WaitForSeconds(.6f);
        isInOtherSide = !isInOtherSide;
    }

    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && canLibrito)
        {
            Librito();
            StartCoroutine(ActiveLibrito());
            canLibrito = false;
        }

        if (Input.GetKeyDown(KeyCode.O) && canPlayLibrito)
        {
            book.FlipLeftPage();
        }

        if (Input.GetKeyDown(KeyCode.P) && canPlayLibrito)
        {
            book.FlipRightPage();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canChangeCamera)
        {
            CamaraChange();
            StartCoroutine(ActiveCameraBool());
            canChangeCamera = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && canChangeAudio)
        {
            ActiveAudio();
            StartCoroutine(ActiveAudioBool());
            canChangeAudio = false;
        }
    }

    IEnumerator ActiveCameraBool()
    {
        yield return new WaitForSeconds(1.5f);
        canChangeCamera = true;
    }
    IEnumerator ActiveAudioBool()
    {
        yield return new WaitForSeconds(1.5f);
        canChangeAudio = true;
    }
    IEnumerator ActiveLibrito()
    {
        yield return new WaitForSeconds(1f);
        canLibrito = true;
    }
    void SpriteAndCameraAxis()
    {
        switch (isInOtherSide)
        {
            case true:
                if (moveInput.x < 0)
                {
                    sprite.flipX = true;
                    right.SetActive(false);
                    left.SetActive(true);
                    sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                }
                else
                {
                    if (moveInput.x > 0)
                    {
                        sprite.flipX = false;
                        right.SetActive(true);
                        left.SetActive(false);
                        sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);

                    }
                    else
                    {
                        if (moveInput.y != 0)
                        {
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                        }
                        else
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);

                    }
                }
                break;
            case false:

                if (moveInput.x < 0)
                {
                    sprite.flipX = false;
                    right.SetActive(true);
                    left.SetActive(false);
                    sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                }
                else
                {
                    if (moveInput.x > 0)
                    {
                        sprite.flipX = true;
                        right.SetActive(false);
                        left.SetActive(true);
                        sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);

                    }
                    else
                    {
                        if (moveInput.y != 0)
                        {
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                        }
                        else
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);

                    }
                }
                break;
        }

    }
    void CamaraChange()
    {
        changeCamera = !changeCamera;

        if (changeCamera)
        {
            StartCoroutine(VolumeManager.instance.ObsFiltroIn());
            cameraPrimera?.Invoke();
            canMove = false;
        }
        else
        {
            if (!changeCamera)
            {
                StartCoroutine(VolumeManager.instance.ObsFiltroOut());
                canMove = true;
                cameraTercera?.Invoke();
            }
        }
    }
    void ActiveAudio()
    {
        isListeing = !isListeing;
        if (isListeing)
        {
            StartCoroutine(VolumeManager.instance.LiseningFiltroIn());
            dd.SetActive(true);
            canMove = false;
        }
        else
        {
            if (!isListeing)
            {


                StartCoroutine(VolumeManager.instance.LiseningFiltroOut());

                canMove = true;

                dd.SetActive(false);

            }
        }
    }


    void Librito()
    {
        showLibro = !showLibro;

        if (showLibro)
        {
            StartCoroutine(VolumeManager.instance.LibroFiltroIn());

            canPlayLibrito = true;
            libreta.transform.DOMove(posDown.transform.position, 1f);
        }
        else
        {
            if (!showLibro)
            {
                StartCoroutine(VolumeManager.instance.LibroFiltroOut());

                canPlayLibrito = false;

                libreta.transform.DOMove(posUp.transform.position, 1f);
                StartCoroutine(CerrarLibro());
            }
        }
    }

    IEnumerator CerrarLibro()
    {
        yield return new WaitForSeconds(1);
        libreta.GetComponent<BookPro>().CurrentPaper = 0;
        yield break;
    }
}
