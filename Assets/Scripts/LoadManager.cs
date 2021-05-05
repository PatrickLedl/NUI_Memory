
using UnityEngine;

public class LoardManager : MonoBehaviour
{
    public GameObject gameManager;

    private void Awake()
    {
        if (GameManager.instance == null)

            Instantiate(gameManager);
        
    }
}
