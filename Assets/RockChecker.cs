using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockChecker : MonoBehaviour
{

    public Color HighlightColor = Color.red;

    private Renderer _renderer;
    private Color _originalColor;
    private Color _targetColor;

    float time;
    float waitingTime;

   public bool focussed;
    public GameObject thisRock;

    public delegate void ColorChanged(GameObject rock);
    public static event ColorChanged colorChanged;

    public GameObject gameController;
    GameController _gameController;

    IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        _targetColor = _originalColor;
        focussed = false;
        time = 0f;
        waitingTime = 1.2f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_renderer.material.color != _originalColor)
        {
            time += Time.deltaTime;


            if (colorChanged != null)
            {
                if (time > waitingTime)
                {

                    colorChanged(thisRock);

                }
                }
        }

        if(_renderer.material.color == _originalColor)
        {
            focussed = false;
        }
    }

    
    
}
