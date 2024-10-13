using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float maxSpeed = 5f;
    public float accelerationTime = 3f;
    public float decelerationTime = 2f;
    private float currentSpeed = 0f;
    public float radius = 3f;
    public int circlePoints = 30;

    void Update()
    {
        PlayerMovement();
        EnemyRadar(radius, circlePoints);
    }

    void PlayerMovement()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
        }
        if (velocity != Vector3.zero)
        {
            velocity.Normalize(); 

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
        Vector3 currentVelocity = currentSpeed * velocity;
        transform.position += currentVelocity * Time.deltaTime;
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Vector3 playerPosition = transform.position; 
        bool isEnemyInRadius = Vector3.Distance(playerPosition, enemyTransform.position) <= radius;

        Color radarColor;
        if (isEnemyInRadius)
        {
            radarColor = Color.red;
        }
        else
        {
            radarColor = Color.green;
        }

        for (int i = 0; i < circlePoints; i++)
        {
            float nowAngle = i * (360f / circlePoints); 
            float nextAngle = (i + 1) * (360f / circlePoints); 
            float nowAngleRad = nowAngle * Mathf.Deg2Rad; 
            float nextAngleRad = nextAngle * Mathf.Deg2Rad; 

            Vector3 nowPoint = new Vector3(Mathf.Cos(nowAngleRad) * radius, Mathf.Sin(nowAngleRad) * radius, 0) + playerPosition;
            Vector3 nextPoint = new Vector3(Mathf.Cos(nextAngleRad) * radius, Mathf.Sin(nextAngleRad) * radius, 0) + playerPosition;

            Debug.DrawLine(nowPoint, nextPoint, radarColor); 
        }
    }
}
