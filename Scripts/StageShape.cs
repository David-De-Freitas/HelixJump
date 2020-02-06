using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageShape : MonoBehaviour
{
    public enum State
    {
        basic,
        damage,
        passage
    }
    // Start is called before the first frame update
    public StageController stageController;

    public State state;
    MeshCollider meshCollider;
    MeshRenderer meshRenderer;
    Material material;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }

    void Start()
    {
        stageController = GetComponentInParent<StageController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableShape()
    {
        meshRenderer.enabled = false;
        meshCollider.enabled = false;
    }
   public void SetState(State _state)
    {
        state = _state;
        switch (_state)
        {
            case State.basic:
                break;
            case State.damage:
                material.SetColor("_Color", Color.red);
                break;
            case State.passage:
                meshRenderer.enabled = false;
                meshCollider.enabled = false;
                break;
            default:
                break;
        }
    }
}
