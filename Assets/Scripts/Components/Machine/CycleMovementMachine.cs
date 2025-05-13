using UnityEngine;

public class LinearLoopMovement : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.forward;
    public float movementDistance = 5f;
    public float speed = 2f;
    public float startDelay = 2f;
    public Color selfcolor;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingToTarget = true;
    private float delayTimer;
    private bool isDelaying = true;
    private Renderer rend;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + movementDirection.normalized * movementDistance;
        delayTimer = 0f;
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = selfcolor;
        }
    }

    private void Update()
    {
        if (isDelaying)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= startDelay)
            {
                isDelaying = false;
            }
            return;
        }

        Vector3 destination = movingToTarget ? targetPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.001f)
        {
            movingToTarget = !movingToTarget;
        }
    }
}