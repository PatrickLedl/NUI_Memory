using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject rockController;
    public delegate void OnButtonPress();
    public static event OnButtonPress onButtonPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(onButtonPress != null)
            {
                onButtonPress();
            }
        }
    }
}
