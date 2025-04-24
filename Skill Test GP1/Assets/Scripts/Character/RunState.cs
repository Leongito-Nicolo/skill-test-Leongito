using UnityEngine;

public class RunState : BaseState
{
    public RunState(Character character) : base(character) { }

    public override void Enter()
    {
        Anim.SetBool("Run", true);
    }

    public override void FixedUpdate()
    {
        //throw new NotImplementedException();
    }

    public override void Update()
    {
        Renderer.flipX = Char.MoveX != 0 ? Char.MoveX < 0 : Renderer.flipX;

        if (!Char.IsMoving)
            Char.ChangeState(new IdleState(Char));
        else
            Move();
    }

    private void Move()
    {
        Rb2d.linearVelocity = new Vector2(Vector2.right.x * Char.MoveX * Char.Speed, Rb2d.linearVelocity.y);
    }

    public override void Exit()
    {
        Anim.SetBool("Run", false);
    }
}
