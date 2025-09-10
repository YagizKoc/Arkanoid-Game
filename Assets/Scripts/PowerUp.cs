using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float speed = 0.5f;
    [SerializeField] PowerUpData powerUpData;
    [SerializeField] GameObject ballPrefab;
    private Ball sideBallScript;
    private Ball mainBallScript;
    private GameObject mainBall;

    private void Start()
    {
        mainBall = GameObject.FindGameObjectWithTag("Ball");
        mainBallScript = mainBall.GetComponent<Ball>();
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player power-up aldı!");
            Destroy(gameObject);
            PowerUpActive();
        }
    }

    public void PowerUpActive() 
    {
        //Speed PowerUp
        Player.Instance.speed = powerUpData.playerSpeed;

        //Ball Number
        for (int i = 1; i < powerUpData.ballNumber; i++)
        {
            Instantiate(ballPrefab, new Vector3(mainBall.transform.position.x - (0.075f* i), mainBall.transform.position.y, -1), Quaternion.identity);

            //Getting SideBalls Scripts
            sideBallScript = GameObject.FindGameObjectWithTag("Side Ball").GetComponent<Ball>();
            //Then Adjusting prefabs vectors
            sideBallScript.ballVector.x = mainBallScript.ballVector.x;
            sideBallScript.ballVector.y = mainBallScript.ballVector.y;
        }

        //Ball Speed
        if (sideBallScript != null) 
        {
            sideBallScript.ballVector.y *= powerUpData.ballSpeed;
        }
        if (mainBallScript != null)
        {
            mainBallScript.ballVector.y *= powerUpData.ballSpeed;
        }
        
        

    }
}
