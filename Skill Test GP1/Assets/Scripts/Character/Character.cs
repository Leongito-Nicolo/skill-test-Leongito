using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
public abstract class Character : MonoBehaviour
{
    #region Properties

    public struct Health
    {
        public float maxHealth;
        public float currentHealth;
        public bool isInvincible;
    }

    [SerializeField] protected CharacterData CharacterData;
    protected Health health;
    [SerializeField] protected bool _isGrounded = true;

    public Rigidbody2D Rb2d { get; private set; }
    public Animator Anim { get; private set; }
    public SpriteRenderer Renderer { get; private set; }

    public float MoveX { get; protected set; }
    public bool IsMoving => MoveX != 0;
    public float Speed => CharacterData.movementSpeed;
    public float JumpForce => CharacterData.jumpForce;

    private BaseState _currentState;

    #endregion Properties

    #region Methods

    private void Awake()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
        _currentState = new IdleState(this);

        health.maxHealth = CharacterData.maxHealth;
        health.currentHealth = health.maxHealth;
    }

    protected virtual void Update()
    {
        _currentState.Update();
    }

    protected virtual void FixedUpdate()
    {
        _currentState.FixedUpdate();
    }

    protected abstract void PerformAction();

    public void ChangeState(BaseState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    protected virtual void DetectGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.15f, CharacterData.groundMask);

        if (hit) _isGrounded = true;
        else _isGrounded = false;
    }

    #endregion Methods
}
