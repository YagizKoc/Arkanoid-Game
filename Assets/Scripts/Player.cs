using UnityEngine;

public class Player : MonoBehaviour
{
    private float verticalInput;
    public float speed;
    public Rigidbody rb;
    public Vector3 movement;
    public static Player Instance { get; private set; }
    private void Awake()
    {
        //Singleton check
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        


    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;
        if (movement.x == 0)
        {
            moveCharacter(new Vector3(0, 0, 0));

        }
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
        
    }

    void moveCharacter(Vector3 direction)
    {
        rb.linearVelocity = direction * speed;
    }


}
