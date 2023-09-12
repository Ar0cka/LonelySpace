using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target; // ������ �� ������� ������ (��������)

    [Header("Settings mouse")]
    [SerializeField] private float sensitivity = 2.0f; // ���������������� ����
    [SerializeField] private float smoothing = 2.0f; // ����������� �������� ������
    [Header("Layers")]
    [SerializeField] private LayerMask collisionLayer; // ���� ��� ������������ �������� ������ ������ �������
    [SerializeField] private float collisionOffset = 0.2f;

    private Vector2 currentRotation = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));  // �������� ���� �� ����

        input = Vector2.Scale(input, new Vector2(sensitivity * smoothing, sensitivity * smoothing));  // �������� ���� �� ���������������� � ���������� ���

        // ���������� �������� ������
        currentRotation.x = Mathf.Lerp(currentRotation.x, input.x, 1f / smoothing);
        currentRotation.y = Mathf.Lerp(currentRotation.y, input.y, 1f / smoothing);

        // ��������� �������� ������
        transform.localRotation *= Quaternion.Euler(-currentRotation.y, currentRotation.x, 0);

        // ������������ ������������ ���� ������
        transform.localRotation = ClampRotation(transform.localRotation);

        // ���������� �� ���������
        Vector3 desiredPosition = target.position - transform.forward * 2f;
        
        CheckCollisions(ref desiredPosition);

        // ��������� ����� �������
        transform.position = desiredPosition;
    }

    // ����������� ������������� ���� ������
    private Quaternion ClampRotation(Quaternion rotation)
    {
        rotation.x /= rotation.w;
        rotation.y /= rotation.w;
        rotation.z = 0;
        rotation.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(rotation.x);
        angleX = Mathf.Clamp(angleX, -25, 25);

        rotation.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return rotation;
    }

    private void CheckCollisions(ref Vector3 desiredPosition)
    {

        if (Physics.Linecast(target.position, desiredPosition, out RaycastHit hit, collisionLayer))
        {
            // ���� ���� ��������, ������������ ������� ������
            desiredPosition = hit.point + hit.normal * collisionOffset;
        }
    }
}

