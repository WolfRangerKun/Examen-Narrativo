using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Cinemachine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Librito();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            book.FlipLeftPage();

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            book.FlipRightPage();

        }
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .01f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canMove)
        {
            rb.velocity += new Vector3(0, jump /**40* Time.deltaTime*/, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CamaraChange();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveAudio();
        }

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
    void SpriteAndCameraAxis()
    {
        switch (isInOtherSide)
        {
            case true:
                print("ppp");
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
                print("qqq");

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
            cameraPrimera?.Invoke();
            canMove = false;
        }
        else
        {
            if (!changeCamera)
            {
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
            dd.SetActive(true);
            canMove = false;

        }
        else
        {
            if (!isListeing)
            {
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
            libreta.transform.DOMove(posDown.transform.position, 1f);
        }
        else
        {
            if (!showLibro)
            {
                libreta.transform.DOMove(posUp.transform.position, 1f);

            }
        }
    }
}
