using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitalSpeed = 10f;
    public float radius = 3f;
    private float nowAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, orbitalSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        nowAngle += speed * Time.deltaTime; 
        Vector3 newPosition = target.position + new Vector3(Mathf.Cos(nowAngle), Mathf.Sin(nowAngle), 0) * radius;
        transform.position = newPosition;

        Vector3 toPlanet = target.position - transform.position;
        float angleToPlanet = Mathf.Atan2(toPlanet.y, toPlanet.x) * Mathf.Rad2Deg;

    }
}
