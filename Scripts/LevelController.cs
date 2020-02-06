using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject stagePb;

    float startPosY = 85;
    float endPosY;

    public float rotationSpeed = 0.05f;

    public int stageCount = 10;
    public float stageDistance = 2.5f;

    float startRotationY;
    float advencement = 0;



    Vector2 startMouse;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < stageCount; i++)
        {
            StageController stageController = Instantiate(stagePb, new Vector3(0, startPosY - stageDistance * i, 0), Quaternion.identity, transform).GetComponent<StageController>();
            if (i == 0)
            {
                stageController.minDammage = 0;
                stageController.maxDammage = 0;
            }
        }
        endPosY = startPosY - stageDistance * (stageCount + 1);
    }

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMouse = Input.mousePosition;
            startRotationY = transform.eulerAngles.y;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMouse = Input.mousePosition;
            transform.rotation = Quaternion.Euler(0, startRotationY + (startMouse.x - currentMouse.x) * rotationSpeed, 0);
        }
        float newAdvencement = ((startPosY - endPosY) - (gameManager.ball.transform.position.y - endPosY)) / (float)(startPosY - endPosY);
        advencement = Mathf.Max(advencement, newAdvencement);
        gameManager.hudController.SetAdvencement(advencement);
    }
}
