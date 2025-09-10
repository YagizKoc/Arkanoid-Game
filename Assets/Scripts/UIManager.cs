using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] GameObject Ball;
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

    public void ResetBallButton() 
    {
        Ball.transform.position = new Vector3(0.0f, -0.3f, -1.0f);
        
    }
}
