using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player; 
    public float maxSpeed = 5f; 
    public float accelerationTime = 3f; 
    public float decelerationTime = 2f; 
    private float currentSpeed = 0f;
    public float shieldRadius = 1f;  
    public int shieldCircle = 20;
    private int shieldUses = 3; 
    public bool shieldActive = true;

    private void Update()
    {
        EnemyMovement();
        if (shieldActive)
        {
            EnemyShield();  
        }
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
    public void EnemyShield()
    {
        Vector3 enemyPosition = transform.position;

        for (int i = 0; i < shieldCircle; i++)
        {
            float currentAngle = i * (360f / shieldCircle);
            float nextAngle = (i + 1) * (360f / shieldCircle);

            float currentAngleRad = currentAngle * Mathf.Deg2Rad;
            float nextAngleRad = nextAngle * Mathf.Deg2Rad;

            Vector3 currentPoint = new Vector3(Mathf.Cos(currentAngleRad) * shieldRadius, Mathf.Sin(currentAngleRad) * shieldRadius, 0) + enemyPosition;
            Vector3 nextPoint = new Vector3(Mathf.Cos(nextAngleRad) * shieldRadius, Mathf.Sin(nextAngleRad) * shieldRadius, 0) + enemyPosition;

            Debug.DrawLine(currentPoint, nextPoint, Color.red);
        }
    }

    public void ShieldHit()
    {
        if (shieldActive)
        {
            shieldUses--; 
            if (shieldUses <= 0)
            {
                shieldActive = false;
            }
        }
    }

    public void EnemyHit()
    {
        if (!shieldActive)
        {
            Destroy(gameObject); 
        }
    }
}
