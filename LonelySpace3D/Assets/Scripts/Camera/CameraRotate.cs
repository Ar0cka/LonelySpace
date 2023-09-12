using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target; // Ссылка на целевой объект (персонаж)

    [Header("Settings mouse")]
    [SerializeField] private float sensitivity = 2.0f; // Чувствительность мыши
    [SerializeField] private float smoothing = 2.0f; // Сглаживание движения камеры

    [Header("Layers")]
    [SerializeField] private LayerMask collisionLayer; // Слои для блокирования движения камеры сквозь объекты
    [SerializeField] private float collisionOffset = 0.2f;

    private Vector2 currentRotation = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));  // Получаем ввод от мыши

        input = Vector2.Scale(input, new Vector2(sensitivity * smoothing, sensitivity * smoothing));  // Умножаем ввод на чувствительность и сглаживаем его

        // Сглаживаем движение камеры
        currentRotation.x = Mathf.Lerp(currentRotation.x, input.x, 1f / smoothing);
        currentRotation.y = Mathf.Lerp(currentRotation.y, input.y, 1f / smoothing);

        // Применяем вращение камеры
        transform.localRotation *= Quaternion.Euler(-currentRotation.y, currentRotation.x, 0);

        // Ограничиваем вертикальный угол обзора
        transform.localRotation = ClampRotation(transform.localRotation);

        // Расстояние от персонажа
        Vector3 desiredPosition = target.position - transform.forward * 3.0f;

        // Проверяем коллизии
        CheckCollisions(desiredPosition);

        // Применяем новую позицию
        transform.position = desiredPosition;
    }

    // Ограничение вертикального угла обзора
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
    private void CheckCollisions(Vector3 desiredPosition)
    {
        RaycastHit hit;

        if (Physics.Linecast(target.position, desiredPosition, out hit, collisionLayer))
        {
            // Если есть коллизия, корректируем позицию камеры
            desiredPosition = hit.point + hit.normal * collisionOffset;
        }
    }
}

