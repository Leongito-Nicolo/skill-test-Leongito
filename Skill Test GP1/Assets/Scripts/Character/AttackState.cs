public class AttackState : BaseState
{
    public AttackState(Character character) : base(character) { }

    private bool _attackFinished;

    public override void Enter()
    {
        _attackFinished = false;
        Anim.SetTrigger("Attack");
    }

    public override void FixedUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void Update()
    {
        if (_attackFinished)
        {
            if (!Char.IsMoving)
                Char.ChangeState(new IdleState(Char));
            else
                Char.ChangeState(new RunState(Char));
        }
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }

    public void OnAttackAnimationEnd()
    {
        _attackFinished = true;
    }
}
