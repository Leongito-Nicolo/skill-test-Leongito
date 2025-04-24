using UnityEngine;

public class Player : Character
{
    #region Properties

    private bool _shouldJump;

    #endregion Properties

    #region Methods

    protected override void Update()
    {
        base.Update();

        MoveX = Input.GetAxisRaw("Horizontal");

        if (!_shouldJump && _isGrounded)
            _shouldJump = Input.GetButtonDown("Jump");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Anim.SetFloat("JumpBlend", Rb2d.linearVelocity.y);
        Anim.SetBool("Jump", !_isGrounded);

        if (!_isGrounded && Rb2d.linearVelocity.y < 0) DetectGround();
        if (_shouldJump) Jump();
    }

    private void Jump()
    {
        _shouldJump = false;
        _isGrounded = false;
        Rb2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    protected override void PerformAction()
    {
        throw new System.NotImplementedException();
    }

    protected override void DetectGround()
    {
        base.DetectGround();
    }

    #endregion Methods
}

