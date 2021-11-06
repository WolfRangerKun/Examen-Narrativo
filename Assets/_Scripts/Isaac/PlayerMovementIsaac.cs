using UnityEngine;
using UnityEngine.Events;
using Cinemachine;


public class PlayerMovementIsaac : MonoBehaviour
{
    public static PlayerMovementIsaac instance;
    public GameObject listening, dd;
    bool isListeing;
    public float speed;
    public float jump;

    public SpriteRenderer sprite;

    Rigidbody rb;
    private Vector2 moveInput;
    public LayerMask whatIsGround;

    public Transform groundPoint;
    public bool isGrounded, canMove, changeCamera;
    public UnityEvent cameraTercera,cameraPrimera;
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CamaraChange();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActiveAudio();
        }

        if (moveInput.x < 0)
        {
            sprite.flipX = false;
        }
        else
        {
            if (moveInput.x > 0)
            {
                sprite.flipX = true;
            }
        }
       
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
            moveInput.Normalize();

            rb.velocity = new Vector3(moveInput.x * speed /**40* Time.deltaTime*/, rb.velocity.y, moveInput.y * speed/**40 * Time.deltaTime*/);
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

}
