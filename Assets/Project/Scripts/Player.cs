using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _velocity, _direction = Vector3.zero;
    float _acceleration = 200, _maxSpeed = 5, _rotationSpeed = 720, _gravity = -200;
    private Animator anim;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isGrounded = _characterController.isGrounded;

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -0.5f;
        }

        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        _velocity.y += _gravity * Time.deltaTime;

        _velocity = Vector3.SmoothDamp(_velocity, _direction * _maxSpeed, ref _velocity, _maxSpeed / _acceleration);

        _characterController.Move(_velocity * Time.deltaTime);

        if (_direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
}
