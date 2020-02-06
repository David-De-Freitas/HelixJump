using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] TrailRenderer trail;
    GameManager gameManager;
    Rigidbody rb;
    public float bounceForce = 10.0f;
    public float velocityMax = 15;
    public int comboCount = 0;
    bool comboOn = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.Instance;
        gameManager.ball = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > velocityMax)
        {
            rb.velocity = rb.velocity.normalized * velocityMax;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StageShape stageShape = other.GetComponent<StageShape>();

        if (stageShape != null)
        {
            if (comboOn)
            {
                stageShape.stageController.DestroyStage();
                comboCount = 0;
                ComboCheck();
            }

            else if (stageShape.state == StageShape.State.basic)
            {
                rb.velocity = Vector3.up * bounceForce;
                comboCount = 0;
                ComboCheck();
                particle.Emit(1);
            }
            else if (stageShape.state == StageShape.State.damage)
            {
                gameManager.Loose();
            }
        }

        if (other.CompareTag("Stage"))
        {
            gameManager.StagePass();
            comboCount++;
            ComboCheck();
        }
        else if (other.CompareTag("End"))
        {
            gameManager.EndLevel();
        }
    }

    private void ComboCheck()
    {
        comboOn = comboCount > 2;
        if (comboOn)
        {
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
    }
}
