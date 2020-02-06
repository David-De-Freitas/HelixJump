using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageController : MonoBehaviour
{
    List<StageShape> stageShapes = new List<StageShape>();
    public int minPassage = 1;
    public int maxPassage = 5;
    public int minDammage = 2;
    public int maxDammage = 4;
    // Start is called before the first frame update

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            stageShapes.Add(transform.GetChild(i).GetComponent<StageShape>());
        }
    }

    void Start()
    {
        int passageCount = Random.Range(minPassage, maxPassage);
        int dammageCount = Random.Range(minDammage, maxDammage);
        List<int> possibleIndex = new List<int>();

        for (int i = 0; i < transform.childCount; i++)
        {
            possibleIndex.Add(i);
        }

        for (int i = 0; i < passageCount; i++)
        {
            int index = Random.Range(0, possibleIndex.Count);
            stageShapes[possibleIndex[index]].SetState(StageShape.State.passage);
            possibleIndex.Remove(possibleIndex[index]);
        }

        for (int i = 0; i < dammageCount; i++)
        {
            int index = Random.Range(0, possibleIndex.Count);
            stageShapes[possibleIndex[index]].SetState(StageShape.State.damage);
            possibleIndex.Remove(possibleIndex[index]);
        }

    }

    public void DestroyStage()
    {
        stageShapes.ForEach(x => x.DisableShape());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
