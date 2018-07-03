using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class PlayerMovement : MonoBehaviour
{
    #region Variabler
    [SerializeField]
    float _speed, _sprintSpeed, _jumpSpeed, _gravity;
    Vector3 _moveDirection = Vector3.zero;

    CharacterController _characterController;

    #endregion

    #region Metoder
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        print(_speed);
        if (_characterController.isGrounded) //Ifall spelaren befinner sig på marken
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _speed;

            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = _jumpSpeed;
                //Fixa dubbelhopp
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //sprint
            }

        }
        _moveDirection.x = Input.GetAxis("Horizontal") * _speed; //Tillåter spelaren strafea i x-led i luften
        _moveDirection.z = Input.GetAxis("Vertical") * _speed; //Tillåter spelaren strafea i z-led i luften

        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    #endregion
}
