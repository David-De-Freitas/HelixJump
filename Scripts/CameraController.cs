using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.y < transform.position.y -4)
        {
            transform.position = new Vector3(transform.position.x, ball.position.y +4, transform.position.z);
        }
    }
}
