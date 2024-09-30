using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime = 1;
    private float pastTime = 0;
    private int startStar = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = starTransforms[startStar].position;
        Vector3 endPosition;
        if (startStar == starTransforms.Count - 1)
        {
            endPosition = starTransforms[0].position; 
        }
        else
        {
            endPosition = starTransforms[startStar + 1].position; 
        }
        pastTime += Time.deltaTime;
        if (pastTime < drawingTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.yellow);
        }
        else
        {
            startStar += 1;
            if (startStar >= starTransforms.Count)
            {
                startStar = 0;
            }
            pastTime = 0f;
        }
    }
}
