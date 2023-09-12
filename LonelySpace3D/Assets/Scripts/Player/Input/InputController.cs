using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5f;
    [SerializeField] Animator animator;
    private Transform cameraTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform; // Получаем трансформ камеры
    }

    private void Update()
    {
        float _horizontalMove = Input.GetAxisRaw("Horizontal");
        float _verticalMove = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(_horizontalMove, 0f, _verticalMove);
        moveDirection.Normalize();

        // Получаем направление вперед от камеры
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f; // Не учитываем вертикальное направление

        // Поворачиваем направление движения игрока на основе камеры
        moveDirection = Quaternion.LookRotation(cameraForward) * moveDirection;

        Vector3 lookDirection = moveDirection;

        if (moveDirection != Vector3.zero)
        {
            RotateCharacter(lookDirection);
        }

        WalkPlayer(moveDirection);

        float moveMagnitude = moveDirection.magnitude;
        animator.SetFloat("Speed", moveMagnitude);
    }

    private void RotateCharacter(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

    private void WalkPlayer(Vector3 moveDirection)
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }
}
