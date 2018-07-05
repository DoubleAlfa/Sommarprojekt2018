using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class PlayerMovement : MonoBehaviour
{
    #region Variabler

    [SerializeField]
    float _speed, _sprintSpeed, _jumpSpeed, _gravity;

    float _normalSpeed; //Håller koll på ursprungshastigheten av spelaren

    bool _doubleJump = false;

    Vector3 _moveDirection = Vector3.zero;

    CharacterController _characterController;

    Hook _hs;

    #endregion

    #region Metoder

    void Start()
    {
        _hs = GameObject.Find("Hook").GetComponent<Hook>();
        _characterController = GetComponent<CharacterController>();
        _normalSpeed = _speed;
    }

    void Update()
    {
        _speed = _normalSpeed;

        if (Input.GetButtonDown("Fire1")) //Hooka
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "Hookable") //Ifall det spelaren klickar på är ett objekt som spelaren kan "hooka" sig fast vid
                {
                    _hs.Destination = hitInfo.transform.gameObject; //sätter det valda objektet som mål för "hooken"
                    _hs.CreateRope();
                }
            }
        }

        if (_characterController.isGrounded) //Ifall spelaren befinner sig på marken
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _speed;

            if (Input.GetButtonDown("Jump")) //Hoppa
            {
                _moveDirection.y = _jumpSpeed;
                _doubleJump = true;
            }

            if (Input.GetButton("Sprint")) //Springa
            {
                _speed = _sprintSpeed;
            }
        }

        else
        {
            if (Input.GetButtonDown("Jump") && _doubleJump) //Dubbelhopp
            {
                _moveDirection.y = _jumpSpeed;
                _doubleJump = false;
            }
        }

        _moveDirection.x = Input.GetAxis("Horizontal") * _speed; //Tillåter spelaren strafea i x-led i luften
        _moveDirection.z = Input.GetAxis("Vertical") * _speed; //Tillåter spelaren strafea i z-led i luften
        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    #endregion
}

