using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Scrollbar scrollbar;

    // Start is called before the first frame update
    
    void Awake()
    {
        GetComponentInParent<GameManager>().hudController = this; 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetAdvencement(float value)
    {
        scrollbar.value = value;
    }

    public void SetScore(int value)
    {
        scoreText.text = value.ToString();
    }

}
