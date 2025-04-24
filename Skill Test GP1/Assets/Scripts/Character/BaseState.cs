using UnityEngine;

public abstract class BaseState
{
    #region Properties

    protected Character Char;
    protected Rigidbody2D Rb2d => Char.Rb2d;
    protected Animator Anim => Char.Anim;
    protected SpriteRenderer Renderer => Char.Renderer;

    #endregion Properties

    #region Methods

    public BaseState(Character character)
    {
        Char = character;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();

    #endregion Methods
}