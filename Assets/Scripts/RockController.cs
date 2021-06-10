using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Transform prefabRock1;
    public Transform prefabRock2;
    public Transform prefabRock3;
    public GameObject Rock1, Rock2, Rock3;
    public Transform spawnPosition;
    private IEnumerator coroutine;
    float counter;
    float waitingTime1;
    float waitingTime2;
    float waitingTime3;
    float time1;
    float time2;
    float time3;
    float levelUpTime;
    bool buttonPressed;
    public GameObject gameController;
    bool rocksAvailable;

    public delegate void LevelPassed();
    public static event LevelPassed levelPassed;


    // Start is called before the first frame update

    private void Start()
    {
        buttonPressed = false;
        waitingTime1 = 2f;
        waitingTime2 = 1.5f;
        waitingTime3 = 1.3f;
        rocksAvailable = false;

        levelUpTime = 0f;

        GameController.startRockys += changeBool;
        GameController.nextLevel += setCounterDown;
         
     }

    void setCounterDown()
    {
        counter = 0;
    }

    void changeBool()
    {
        if (buttonPressed == false)
        {
            buttonPressed = true;
        }

        else
            buttonPressed = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (buttonPressed == true)
        {
            time1 += Time.deltaTime;
            time2 += Time.deltaTime;
            time3 += Time.deltaTime;

            if (counter <= 10)
            {
                if (time1 > waitingTime1)
                {
                    Instantiate(prefabRock1);
                    counter++;
                    time1 = -2;
                }

                if (time2 > waitingTime2)
                {
                    Instantiate(prefabRock2);
                    counter++;
                    time2 = -3;
                }

                if (time3 > waitingTime3)
                {
                    Instantiate(prefabRock3);
                    counter++;
                    time3 = -1.5f;
                }

                
            }

            if (counter == 10)
            {
                if(levelPassed != null)
                {
                    
                    levelPassed();
                }
            }

        }

        
    }
}
