using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5f;
    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float _horizontalMove = Input.GetAxisRaw("Horizontal");
        float _verticalMove = Input.GetAxisRaw("Vertical");

        ChangeSideAndAnimation(_horizontalMove, _verticalMove);

        Vector3 moveDirection = new Vector3(_horizontalMove, 0f, _verticalMove);
        moveDirection.Normalize();

        WalkPlayer(moveDirection);

        
        
    }

    private void RotateCharacter(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }

    private void WalkPlayer(Vector3 moveDirection)
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }

    private void ChangeSideAndAnimation(float _horizontalMove, float _verticalMove)
    {
        if (_horizontalMove > 0)
        {
            RotateCharacter(Vector3.right);
            animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));
        }
        else if (_horizontalMove < 0)
        {
            RotateCharacter(Vector3.left);
            animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));
        }

        else if (_verticalMove > 0)
        {
            RotateCharacter(Vector3.forward);
            animator.SetFloat("Speed", Mathf.Abs(_verticalMove));
        }

        else if (_verticalMove < 0)
        {
            RotateCharacter(Vector3.back);
            animator.SetFloat("Speed", Mathf.Abs(_verticalMove));
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
