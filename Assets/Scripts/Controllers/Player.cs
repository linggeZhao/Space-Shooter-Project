using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float moveSpeed = 5f;

    void Update()
    {
        PlayerMovement();
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

        transform.position += moveSpeed * Time.deltaTime * velocity;
    }
}
