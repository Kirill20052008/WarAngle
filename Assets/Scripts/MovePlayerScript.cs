using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerScript : MonoBehaviour
{
    public float RotationSercetivity;
    public Transform CameraTransform;
    private float _xRotation;

    public Rigidbody _rigidbody;
    public FixedJoystick _joystick;

    public float Speed;
    public float JumpForce;

    public bool Grounded;

    void Update()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * RotationSercetivity;
        _xRotation = Mathf.Clamp(_xRotation, -50f, 50f);
        CameraTransform.localEulerAngles = new Vector3(_xRotation, 0f, 0f);

        transform.Rotate(0, Input.GetAxis("Mouse X") * RotationSercetivity, 0);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                _rigidbody.AddForce(0, JumpForce, 0, ForceMode.Impulse);
            }
            
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        float dot = Vector3.Dot(normal, Vector3.up);

        if (dot > 0.5f)
        {
            Grounded = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }

    private void FixedUpdate()
    {
        // Ввод (-1..1) по осям
        float h = Input.GetAxis("Horizontal"); // A/D, стрелки влево/вправо
        float v = Input.GetAxis("Vertical");   // W/S, стрелки вверх/вниз

        // Вектор движения в локальных осях X/Z
        Vector3 input = new Vector3(h, 0f, v);

        // Переводим его в мировой с учётом поворота объекта
        Vector3 moveDir = transform.TransformDirection(input) * Speed;

        // Сохраняем вертикальную скорость (гравитация и прыжки)
        moveDir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = moveDir;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 1.3f;
        }

        else
        {
            Speed = 3.5f;
        }
    }



}
