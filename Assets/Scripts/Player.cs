using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _characterController;

    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = 9.81f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.LogError("Character Controller is NULL!");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0);
        Vector3 velocity = direction * _speed;

        if(_characterController.isGrounded == true)
        {
            //do nothing atm
        }else
        {
            velocity.y -= _gravity;
        }

        _characterController.Move(velocity * Time.deltaTime);
    }
}
