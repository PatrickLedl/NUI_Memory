using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Tobii.G2OM;


public class GameController : MonoBehaviour, IGazeFocusable
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
    public GameObject rock1, rock2, rock3;

    RockChecker rockChecker1, rockChecker2,rockChecker3;

    public AudioSource explosionSound;

    public bool rockRed;

    float time;
    float waitingtime;

    public GameObject Spieler;
    

    // Start is called before the first frame update
    void Start()
    {
        rockRed = false;
        level = 1;
        levelPassed = false;

        posLevel1 = new Vector3(169.9f, 46f, 111.8f);
        posLevel2 = new Vector3(169.9f, 77.8f, 153.7f);
        finalPos = new Vector3(152.2f, 129.6f, 194f);
       
      

        waitingtime = 10f;
        time = 0f;

        RockController.levelPassed += UpgradeLevel;

        RockChecker.colorChanged += DestroyRock;
       

    }

    void UpgradeLevel()
    {
        levelPassed = true;
      
        changePlayerPosition();

    }

    void DestroyRock(GameObject rock)
    {
        rockRed = true;

        
            Destroy(rock);
        explosionSound.Play(0);
            rockRed = false;
            time = 0f;
        
       
    }

   void changePlayerPosition()
    {
        if (levelPassed == true)
        {
            if (level == 1)
            {
               Spieler.transform.position = posLevel2;
                level = 2;
            }
            if (level == 2)
            {
                Spieler.transform.position = finalPos;
            }
           
        }

        if ( levelPassed == false)
        {
            if (level == 1)
            {
                Spieler.transform.position = posLevel1;
            }
            if (level == 2)
            {
                Spieler.transform.position = posLevel1;
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
                RockChecker.colorChanged += DestroyRock;
            }
        }

        
       
      

    }

    public void GazeFocusChanged(bool hasFocus)
    {
        throw new System.NotImplementedException();
    }
}
