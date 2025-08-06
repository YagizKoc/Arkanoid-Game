using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] BricksData BrickData;
    private int bricksHealth;
    private void Start()
    {
        bricksHealth = BrickData.brickHealth;
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.name == "Ball") 
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
        }
    }
}
