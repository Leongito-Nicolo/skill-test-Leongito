using UnityEngine;

public class IdleState : BaseState
{
    #region Methods

    public IdleState(Character character) : base(character) { }

    public override void Enter()
    {
        Anim.SetBool("Idle", true);
        Rb2d.linearVelocity = Vector2.zero;
    }

    public override void FixedUpdate()
    {
        //throw new NotImplementedException();
    }

    public override void Update()
    {
        if (Char.IsMoving)
            Char.ChangeState(new RunState(Char));
    }

    public override void Exit()
    {
        Anim.SetBool("Idle", false);
    }

    #endregion Methods
}
