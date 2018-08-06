using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class PlayerMovement : MonoBehaviour
{
    //Script som hanterar spelarens rörelser.

    #region Variabler

    [SerializeField]
    float _speed, _sprintSpeed, _jumpSpeed, _gravity;

    float _normalSpeed; //Håller koll på ursprungshastigheten av spelaren

    bool _doubleJump, _inrange, _ableToSprint, _boosted;

    Vector3 _moveDirection = Vector3.zero;

    CharacterController _characterController;

    Hook _hs;

    #endregion

    #region Propeties

    public Vector3 MoveDirection
    {
        get { return _moveDirection; }
        set { _moveDirection = value; }
    }

    public float Gravity
    {
        get { return _gravity; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float NormalSpeed
    {
        get { return _normalSpeed; }
    }

    public bool AbleToSprint
    {
        get { return _ableToSprint; }
        set { _ableToSprint = value; }
    }

    public bool Boosted
    {
        get { return _boosted; }
        set { _boosted = value; }
    }

    #endregion

    #region Metoder

    void Start()
    {
        _hs = GameObject.Find("Player/Hook").GetComponent<Hook>();
        _characterController = GetComponent<CharacterController>();
        _normalSpeed = _speed;
        _ableToSprint = true; //Bool som används för att spelaren inte ska kunna sprinta när spelaren befinner sig på en speedlane eftersom att hastigheten ska vara statisk under den tiden
    }

    void OnTriggerEnter(Collider other) //Kollar ifall spelaren är i range för kunna använda sin hook
    {
        if (other.tag == "Hookable")
        {
            _inrange = true;
        }
    }

    void OnTriggerExit(Collider other)  //Kollar ifall spelaren är i range för kunna använda sin hook
    {
        if (other.tag == "Hookable")
        {
            _inrange = false;
        }
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && _inrange) //Hooka
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "Hookable") //Ifall det spelaren klickar på är ett objekt som spelaren kan "hooka" sig fast vid
                {
                    _hs.Destination = hitInfo.transform.gameObject; //sätter det valda objektet som mål för "hooken"
                    _hs.LR.enabled = true;
                    _hs.LR.SetPosition(1, _hs.Destination.transform.position); //sätter repets slutposition till det valda objektet
                    _hs.CreateRope = true;
                }
            }
        }

        if (_boosted)
        {
            transform.Translate(_moveDirection.x * _speed, 0, _speed);
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

            if (Input.GetButton("Sprint") && _ableToSprint) //Springa
            {
                _speed = _sprintSpeed;
            }

            if (Input.GetButtonUp("Sprint") && _ableToSprint) //Sluta springa
            {
                _speed = _normalSpeed;
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
        _moveDirection.y -= _gravity * Time.deltaTime; //Tillämpar gravitation
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
    #endregion
}

