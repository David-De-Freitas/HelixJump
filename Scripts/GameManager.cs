using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int level = 1;
    [SerializeField] int levelCount = 1;
    int scorePerLevel = 250;

    public static GameManager Instance;
    public HudController hudController;
    public BallController ball;
    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (GameManager.Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StagePass()
    {
        score += scorePerLevel * level * ball.comboCount;
        hudController.SetScore(score);
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void Loose()
    {
        score = 0;
        hudController.SetScore(score);
        SceneManager.LoadScene("Level_" + level.ToString());
    }

    public void EndLevel()
    {
        level++;
        if (level > levelCount)
        {
            level = 1;
            SceneManager.LoadScene("Level_" + level.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
