using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player; 
    public float maxSpeed = 5f; 
    public float accelerationTime = 3f; 
    public float decelerationTime = 2f; 
    private float currentSpeed = 0f;

    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, player.position) > 2f)
        {
            float acceleration = maxSpeed / accelerationTime;
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed); 
        }
        else
        {
            float deceleration = maxSpeed / decelerationTime;
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed); 
        }
        transform.position += direction * currentSpeed * Time.deltaTime;

    }
}
