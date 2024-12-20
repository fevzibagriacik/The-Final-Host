using System;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private Vector2 _playerInput = Vector2.zero;
    private Animator _animator;

    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("[NewPlayerController] Rigidbody component is missing!");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();
        UpdateAnimatorParameters();
        MoveCharacterWithRigidbody();
    }


    private void HandleInput()
    {
        // Reset input values
        _playerInput = Vector2.zero;

        // Capture WASD input
        if (Input.GetKey(KeyCode.W))
            _playerInput.y = 1;
        if (Input.GetKey(KeyCode.S))
            _playerInput.y = -1;
        if (Input.GetKey(KeyCode.A))
            _playerInput.x = -1;
        if (Input.GetKey(KeyCode.D))
            _playerInput.x = 1;
    }

    private void UpdateAnimatorParameters()
    {
        if (_animator == null)
            return;

        // Update Animator parameters based on input
        _animator.SetFloat(Horizontal, _playerInput.x);
        _animator.SetFloat(Vertical, _playerInput.y);

        // Check if character should transition to walking or idle
        bool isWalking = Mathf.Abs(_playerInput.x) > 0.1f || Mathf.Abs(_playerInput.y) > 0.1f;
        _animator.SetBool("IsWalking", isWalking);
    }

    private void MoveCharacterWithRigidbody()
    {
        Vector3 movement = new Vector3(_playerInput.x, 0, _playerInput.y).normalized;
        _rigidbody.velocity = movement * movementSpeed;

        if (movement.sqrMagnitude > 0.01f)
        {
            transform.forward = movement; // Hareket yönüne döndür
        }
    }



}
