using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFan : MonoBehaviour
{
    public float power = 1.0f;
    public float playerMultiplier = 1.0f;
    public float bulletMultiplier = 4.0f;
    public float radius = 1.0f;
    public float height = 1.5f;
    public Vector3 direction = Vector3.forward;
    private Vector3 worldDirection;
    void Start()
    {
        worldDirection = transform.TransformDirection(direction).normalized;
    }

    void FixedUpdate()
    {
        Vector3 Height = worldDirection * height;
        Vector3 point = transform.position + Height;
        Collider[] colliders = Physics.OverlapCapsule(point, transform.position, radius);

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (col.CompareTag("Player"))
            {
                rb.velocity += power * playerMultiplier * transform.up;
            }
            else if (col.CompareTag("Bullet"))
            {
                rb.velocity += power * bulletMultiplier * transform.up;
            }
        }
    }

    void DrawGizmoCircle(Vector3 center, Vector3 normal, float radius)
    {
        Vector3[] points = GetCirclePoints(center, normal, radius, 12);
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawLine(points[i], points[(i + 1) % points.Length]);
        }
    }

    Vector3[] GetCirclePoints(Vector3 center, Vector3 normal, float radius, int segments)
    {
        Vector3[] points = new Vector3[segments];
        Vector3 v1 = Vector3.Cross(normal, normal == Vector3.up ? Vector3.forward : Vector3.up).normalized;
        Vector3 v2 = Vector3.Cross(normal, v1);

        for (int i = 0; i < segments; i++)
        {
            float angle = i * Mathf.PI * 2f / segments;
            points[i] = center + (v1 * Mathf.Cos(angle) + v2 * Mathf.Sin(angle)) * radius;
        }
        return points;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Vector3 Height = transform.up * height;
        Vector3 top = transform.position + Height;
        Vector3 bottom = transform.position;

        DrawGizmoCircle(bottom, transform.up, radius);
        DrawGizmoCircle(top, transform.up, radius);

        Vector3[] bottomPoints = GetCirclePoints(bottom, transform.up, radius, 10);
        Vector3[] topPoints = GetCirclePoints(top, transform.up, radius, 10);
        for (int i = 0; i < 10; i++)
        {
            Gizmos.DrawLine(bottomPoints[i], topPoints[i]);
        }
    }

}
