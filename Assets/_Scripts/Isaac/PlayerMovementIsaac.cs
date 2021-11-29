using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

    public GameObject left, right,posUp,posDown, libreta, miraObs;
    public List<GameObject> shadows;
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
        else
        {
            moveInput.x = 0;
            moveInput.y = 0;
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
        yield return new WaitForSeconds(1.5f);
        canLibrito = true;
    }
    bool playAudio = true;
    public AudioSource steps;
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
                    shadows[0].SetActive(false);
                    shadows[1].SetActive(true);
                    sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                    if (playAudio)
                    {
                        steps.Play();
                        playAudio = false;
                    }
                }
                else
                {
                    if (moveInput.x > 0)
                    {
                        sprite.flipX = false;
                        right.SetActive(true);
                        left.SetActive(false);
                        shadows[1].SetActive(false);
                        shadows[0].SetActive(true);
                        sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);

                        if (playAudio)
                        {
                            steps.Play();
                            playAudio = false;
                        }

                    }
                    else
                    {
                        if (moveInput.y > 0 || moveInput.y < 0)
                        {
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);

                            if (playAudio)
                            {
                                steps.Play();
                                playAudio = false;
                            }
                        }
                        else
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);
                            steps.Stop();
                            playAudio = true;

                    }
                }
                break;
            case false:

                if (moveInput.x < 0)
                {
                    sprite.flipX = false;
                    right.SetActive(true);
                    left.SetActive(false);
                    shadows[1].SetActive(false);
                    shadows[0].SetActive(true);

                    sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                    if (playAudio)
                    {
                        steps.Play();
                        playAudio = false;
                    }
                }
                else
                {
                    if (moveInput.x > 0)
                    {
                        sprite.flipX = true;
                        right.SetActive(false);
                        left.SetActive(true);
                        sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                        shadows[0].SetActive(false);
                        shadows[1].SetActive(true);
                        if (playAudio)
                        {
                            steps.Play();
                            playAudio = false;
                        }
                    }
                    else
                    {
                        if (moveInput.y > 0 || moveInput.y < 0)
                        {
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
                            if (playAudio)
                            {
                                steps.Play();
                                playAudio = false;
                            }
                        }
                        else
                            sprite.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);
                            steps.Stop();
                            playAudio = true;
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
            GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

            StartCoroutine(VolumeManager.instance.ObsFiltroIn());
            canMove = false;
            canLibrito = false;
            canChangeAudio = false;
            cameraPrimera?.Invoke();
            miraObs.SetActive(true);

            
        }
        else
        {
            if (!changeCamera)
            {
                GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

                StartCoroutine(VolumeManager.instance.ObsFiltroOut());
                canMove = true;
                canLibrito = true;
                canChangeAudio = true;
                miraObs.SetActive(false);

                cameraTercera?.Invoke();
                
            }
        }
    }
    void ActiveAudio()
    {
        isListeing = !isListeing;
        if (isListeing)
        {
            GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

            StartCoroutine(VolumeManager.instance.LiseningFiltroIn());
            dd.SetActive(true);
            canMove = false;
            canLibrito = false;
            canChangeCamera = false;
        }
        else
        {
            if (!isListeing)
            {
                GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

                StartCoroutine(VolumeManager.instance.LiseningFiltroOut());

                canMove = true;
                canLibrito = true;
                canChangeCamera = true;
                dd.SetActive(false);

            }
        }
    }


    void Librito()
    {
        showLibro = !showLibro;

        if (showLibro)
        {
            GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

            StartCoroutine(VolumeManager.instance.LibroFiltroIn());
            canMove = false;

            canPlayLibrito = true;
            libreta.transform.DOMove(posDown.transform.position, 1f);
            canChangeCamera = false;
            canChangeAudio = false;
        }
        else
        {
            if (!showLibro)
            {
                GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

                StartCoroutine(VolumeManager.instance.LibroFiltroOut());
                canMove = true;

                canPlayLibrito = false;
                canChangeCamera = true;
                canChangeAudio = true;
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
