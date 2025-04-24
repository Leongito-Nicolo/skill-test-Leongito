using UnityEngine;

public class Enemy : Character
{
    public Transform PointA;
    public Transform PointB;
    public Transform playerPos;
    private bool isPlayerDetected = false;
    private bool movingToPointB = true;
    private Vector2 targetPosition;

    [SerializeField] private float attackDistance;

    protected override void PerformAction()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        targetPosition = PointA.position;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (!isPlayerDetected)
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            Rb2d.linearVelocity = direction * Speed;
            MoveX = Rb2d.linearVelocity.x;
        }
    }


    protected override void Update()
    {
        base.Update();

        if (isPlayerDetected)
        {
            Rb2d.linearVelocity = Vector2.zero;
            MoveX = Rb2d.linearVelocity.x;
        }
        else
        {
            MoveBetweenPoints();
        }

        CheckPlayerDetection();
    }

    private void MoveBetweenPoints()
    {

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (movingToPointB)
            {
                targetPosition = PointB.position;
            }
            else
            {
                targetPosition = PointA.position;
            }

            movingToPointB = !movingToPointB;
        }
    }

    private void CheckPlayerDetection()
    {
        if (playerPos == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerPos.position);

        if (distanceToPlayer <= attackDistance)
        {
            isPlayerDetected = true;
        }
        else
        {
            isPlayerDetected = false;
        }
    }
}
