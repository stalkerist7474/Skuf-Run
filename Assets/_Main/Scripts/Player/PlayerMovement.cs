using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Camera mainCamera;

    [SerializeField] private Rigidbody rb;
    private Vector3 touchStartPos;
    private float lastTouchTime;
    private int touchCount = 0;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    lastTouchTime = Time.time;
                    touchCount++;
                    break;
                case TouchPhase.Moved:
                    if (touchCount == 1)
                    {

                        Vector3 touchPosition3D = new Vector3(touch.position.x, touch.position.y, 0);

                        // Преобразуйте touchStartPos в Vector3
                        Vector3 touchStartPos3D = new Vector3(touchStartPos.x, touchStartPos.y, 0);

                        // Вычислите touchDelta
                        Vector3 touchDelta = touchPosition3D - touchStartPos3D;

                        // Свайп вправо
                        if (touchDelta.x > 50)
                        {
                            rb.AddForce(mainCamera.transform.right * speed, ForceMode.VelocityChange);
                        }

                        // Свайп влево
                        if (touchDelta.x < -50)
                        {
                            rb.AddForce(-mainCamera.transform.right * speed, ForceMode.VelocityChange);
                        }

                        // Свайп вверх (перемещение вперед)
                        if (touchDelta.y > 50)
                        {
                            rb.AddForce(mainCamera.transform.forward * speed, ForceMode.VelocityChange);
                        }

                        // Свайп вниз (перемещение назад)
                        if (touchDelta.y < -50)
                        {
                            rb.AddForce(-mainCamera.transform.forward * speed, ForceMode.VelocityChange);
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    if (touchCount == 1)
                    {
                        // Проверка двойного касания
                        if (Time.time - lastTouchTime < 0.3f)
                        {
                            // Действие
                            Debug.Log("Действие");
                            touchCount = 0;
                        }
                        else
                        {
                            // Прыжок
                            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                            touchCount = 0;
                        }
                    }
                    break;
            }
        }
    }
}
