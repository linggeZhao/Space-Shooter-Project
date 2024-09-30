using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 2;
    public float arrivalDistance = 1;
    public float maxFloatDistance = 5;
    private Vector3 position1;
    // Start is called before the first frame update
    void Start()
    {
        NewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, position1, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, position1) < arrivalDistance)
        {
            NewPosition();
        }
    }

    private void NewPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * maxFloatDistance;
        position1 = transform.position + randomPosition;
    }
}
