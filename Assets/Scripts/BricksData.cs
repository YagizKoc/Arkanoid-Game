using UnityEngine;

[CreateAssetMenu(fileName = "BrickData", menuName = "ScriptableObjects/BrickData")]
public class BricksData : ScriptableObject
{
    public Color brickColor;
    public int brickHealth;
    public int brickPoint;
}
