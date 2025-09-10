using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "ScriptableObjects/PowerUpData")]
public class PowerUpData : ScriptableObject
{
    public string Name;
    public GameObject prefab;
    public float playerSpeed;
    public int ballNumber;
    public float playerLength;
    public bool ballOfSteel;
    public float ballSpeed;


}

