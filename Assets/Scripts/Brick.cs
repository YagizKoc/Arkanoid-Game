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
