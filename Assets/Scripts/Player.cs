using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _characterController;
    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _jumpHeight = 15f;
    private float _yVelocity;

    private int _coin;

    private bool _canDoubleJump;

    private Vector3 _respawnPoint;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.LogError("Character Controller is NULL!");

        UIManager.Instance.UpdateLivesText(_lives);

        _respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_characterController.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;// * Time.deltaTime;

        _characterController.Move(velocity * Time.deltaTime);
    }

    public void UpdateCoinAmount()
    {
        _coin++;
        UIManager.Instance.UpdateCoinText(_coin);
    }

    public void Damage()
    {
        Debug.Log("Player got hurt");
        _lives--;

        _characterController.enabled = false;
        transform.position = _respawnPoint;
        StartCoroutine(CharacterControllerRoutine());

        if(_lives <= 0)
        {
            GameManager.Instance.RestartScene();
        }

        UIManager.Instance.UpdateLivesText(_lives);
    }

    IEnumerator CharacterControllerRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _characterController.enabled = true;
    }
}
