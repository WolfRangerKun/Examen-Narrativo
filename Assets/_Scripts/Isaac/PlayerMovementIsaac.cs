using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class PlayerMovementIsaac : MonoBehaviour
{
    public float speed;
    public float jump;

    Rigidbody rb;
    private Vector2 moveInput;
    public LayerMask whatIsGround;

    public Transform groundPoint,followPoint;
    bool isGrounded, canMove, changeCamera;
    public UnityEvent cameraTercera,cameraPrimera;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }

    private void Update()
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

}
