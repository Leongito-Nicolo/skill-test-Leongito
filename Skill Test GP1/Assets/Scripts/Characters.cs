using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public struct Health
    {
        [SerializeField] private float maxHealth;
        private float currentHealth;
        private bool isInvincible;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move()
    {
        rb.AddForce(Vector2.right);
    }

    public abstract void PerformAction();
}
