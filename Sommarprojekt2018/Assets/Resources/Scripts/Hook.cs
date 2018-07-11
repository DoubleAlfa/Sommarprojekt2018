using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Av Andreas de Freitas
public class Hook : MonoBehaviour
{

    #region Variabler

    [SerializeField]
    GameObject _rope, _player;

    [SerializeField]
    float _ropeWidth;

    float _maxRopeScaleMagnitude;

    bool _createRope = false;

    GameObject _destination;

    PlayerMovement _pm;

    Vector3 _maxRopeScale;

    Renderer _rend;

    #endregion

    #region Properties 

    public GameObject Rope
    {
        get { return _rope; }
    }

    public GameObject Destination
    {
        get { return _destination; }
        set { _destination = value; }
    }

    public bool CreateRope
    {
        get { return _createRope; }
        set { _createRope = value; }
    }

    #endregion

    #region Metoder

    void Start()
    {
        _pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _maxRopeScale = new Vector3(_ropeWidth, _ropeWidth, 20);
        _maxRopeScaleMagnitude = _maxRopeScale.magnitude;
    }


    void Update() //Skapar samt uppdaterar repets position
    {
        if (_createRope)
        {
            var between = (_destination.transform.position - transform.position); //Kollar avståndet mellan "hooken" och dit spelaren "hookar"
            var distance = between.magnitude; //Räknar ut längden mellan objekten

            if (distance <= _maxRopeScaleMagnitude) //Ifall spelaren är i "hook" range
            {
                _rope.transform.localScale = new Vector3(_ropeWidth, _ropeWidth, distance); //Skapar repet i de angivna skalorna
                _rope.transform.position = _destination.transform.position - (between / 2.0f); //Placerar ut repet mellan spelarens "hookpistol" och objektet spelaren vill hook till  

                _rope.transform.LookAt(transform.position); //Får repet att rikta sig emot "hookpistolen"
                transform.LookAt(_destination.transform.position); //Får "hookpistolen" att rikta sig emot objektet


                if (Input.GetButton("Fire2")) //Får spelaren att klättra på repet
                {
                    float speed = 0.1f;
                    _player.transform.position = Vector3.MoveTowards(_player.transform.position, _destination.transform.position, speed);
                    _pm.MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                    if (Input.GetButton("Jump")) //Tar bort repet när spelaren är i luften
                    {
                        _createRope = false;
                        _rope.transform.position = new Vector3(-60, -60, -60);
                        _pm.MoveDirection -= new Vector3(_player.transform.position.x, _pm.Gravity * Time.deltaTime, _player.transform.position.z);
                    }

                }
            }
        }
        else
        {
            _createRope = false;
            _rope.transform.position = new Vector3(-60, -60, -60);
        }
    }
}

#endregion

