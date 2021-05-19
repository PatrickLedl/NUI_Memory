using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject rockController;
    public Transform player;
    public delegate void OnButtonPress();
    public static event OnButtonPress onButtonPress;
    public delegate void StartRockys();
    public static event StartRockys startRockys;
    float level;
    Vector3 posLevel1, posLevel2, posLevel3,finalPos;
    bool levelPassed;
    
    

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        levelPassed = false;
        posLevel1 = new Vector3(95.9f, 10.8f, -105f);
        posLevel2 = new Vector3(102.4f, 71.5f, -47f);
        posLevel3 = new Vector3(-95f, 115f, 8f);
        player.transform.position = posLevel1;
        RockController.levelPassed += UpgradeLevel;
    }

    void UpgradeLevel()
    {
        levelPassed = true;
        changePlayerPosition();

    }

    void changePlayerPosition()
    {
        if (levelPassed == true)
        {
            if (level == 1)
            {
                player.transform.position = posLevel2;
            }
            if (level == 2)
            {
                player.transform.position = posLevel3;
            }
            if (level == 3)
            {
                player.transform.position = finalPos;
            }
        }

        if ( levelPassed == false)
        {
            if (level == 1)
            {
                player.transform.position = posLevel1;
            }
            if (level == 2)
            {
                player.transform.position = posLevel2;
            }
            if (level == 3)
            {
                player.transform.position = posLevel3;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(startRockys != null)
            {
                startRockys();
            }
        }
    }
}
