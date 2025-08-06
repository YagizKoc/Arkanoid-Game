using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 downwardsForce = new Vector3(-10.0f, -1.0f, 0.0f);
    public Vector3 upwardsForce = new Vector3(0.0f, 1.0f, 0.0f);
    public float speed = 1.0f;
    public bool ballDirection;
    public Vector3 ballVector = new Vector3(0.0f, -1.0f, 0.0f);
    private Vector3 ballPosition;
    private Vector3 playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballDirection = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        AppliedForce();
    }

    public void DownwardsForce() 
    {
        rb.linearVelocity = downwardsForce * speed;
    }

    public void UpwardsForce()
    {
        rb.linearVelocity = upwardsForce * speed;
    }

    public void AppliedForce() 
    {
        rb.linearVelocity = ballVector * speed;
    }

    //Ball Movement
    private void OnCollisionEnter(Collision collision)
    {
        ballPosition = gameObject.transform.position;
        playerPosition = Player.Instance.gameObject.transform.position;
        
        if (ballVector.x == 0.0f && collision.gameObject.name == "Player") //Start of the Game
        {
            if ((playerPosition.x - ballPosition.x < 0.06 && playerPosition.x - ballPosition.x > 0))
                ballVector = new Vector3(1, -ballVector.y, 0);
            else if(((playerPosition.x - ballPosition.x > -0.06 && playerPosition.x - ballPosition.x < 0)))
                ballVector = new Vector3(-1, -ballVector.y, 0);
        }
        else if (ballVector.x != 0.0f && collision.gameObject.name == "Player") 
        {
            if ((playerPosition.x - ballPosition.x < 0.06 && playerPosition.x - ballPosition.x > 0))
            {
                ballVector = new Vector3(1, -ballVector.y, 0);
                Debug.Log("innerZone contact");
                Debug.Log(playerPosition.x - ballPosition.x);
            }
            else if (((playerPosition.x - ballPosition.x > -0.06 && playerPosition.x - ballPosition.x < 0)))
            {
                ballVector = new Vector3(-1, -ballVector.y, 0);
                Debug.Log("innerZone contact");
                Debug.Log(playerPosition.x - ballPosition.x);
            }
            else if (playerPosition.x - ballPosition.x > 0.06)
            {
                ballVector = new Vector3(-1, -ballVector.y, 0);
                Debug.Log("outerZone contact");
                Debug.Log(playerPosition.x - ballPosition.x);
            }
            else if (playerPosition.x - ballPosition.x < 0.06)
            {
                ballVector = new Vector3(1, -ballVector.y, 0);
                Debug.Log("outerZone contact");
                Debug.Log(playerPosition.x - ballPosition.x);
            }

        }
        if (collision.gameObject.tag == "Side Wall") 
        {
            ballVector = new Vector3(-ballVector.x, ballVector.y, 0);

        }
        if (collision.gameObject.tag == "Upper Wall")
        {
            ballVector = new Vector3(ballVector.x, -ballVector.y, 0);
        }
        if (collision.gameObject.tag == "Brick") 
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector3 normal = contact.normal;

                if (Mathf.Abs(normal.y) > Mathf.Abs(normal.x) && Mathf.Abs(normal.y) > Mathf.Abs(normal.z))
                {
                    if (normal.y < 0)
                    {
                        Debug.Log("Alttan çarptı"); 
                        ballVector = new Vector3(ballVector.x, -ballVector.y, 0);
                    }
                    else
                    {
                        Debug.Log("Üstten çarptı");
                        ballVector = new Vector3(ballVector.x, -ballVector.y, 0);
                    }
                }
                else if (Mathf.Abs(normal.x) > Mathf.Abs(normal.z))
                {
                    if (normal.x > 0)
                    {
                        Debug.Log("Soldan çarptı");
                        ballVector = new Vector3(-ballVector.x, ballVector.y, 0);
                    }
                    else
                    {
                        Debug.Log("Sağdan çarptı");
                        ballVector = new Vector3(-ballVector.x, ballVector.y, 0);
                    }
                }
               
            }
        }
    }
}
