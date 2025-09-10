using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] BricksData BrickData;
    private int bricksHealth;
    private void Start()
    {
        bricksHealth = BrickData.brickHealth;
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = BrickData.brickColor;
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Ball")
        {
            bricksHealth -= 1;
            BrickHealthCheck();
        }
    }
    void BrickHealthCheck() 
    {
        if (bricksHealth <= 0) 
        {
            Destroy(gameObject);
            int roll = GameManager.Instance.GenerateRandomN(100);
            Debug.Log("brick rolled " + roll);
            GameManager.Instance.InsantiatePowerUp();

        }
    }
}
