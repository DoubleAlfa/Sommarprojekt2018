using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Av Andreas de Freitas
public class Hook : MonoBehaviour
{

    #region Variabler

    [SerializeField]
    GameObject _testRope;

    [SerializeField]
    float _ropeWidth;

    GameObject _destination;

    #endregion

    #region Properties 

    public GameObject TestRope
    {
        get
        {
            return _testRope;
        }
    }

    public GameObject Destination
    {
        get
        {
            return _destination;
        }

        set
        {
            _destination = value;
        }
    }
    #endregion

    #region Metoder

    public void CreateRope()
    {

        var between = (_destination.transform.position - transform.position); //Kollar avståndet mellan "hooken" och dit spelaren "hookar"
        var distance = between.magnitude; //Räknar ut längden mellan objekten

        _testRope.transform.localScale = new Vector3(_ropeWidth, _ropeWidth, distance); //Skapar repet i de angivna skalorna
        _testRope.transform.position = _destination.transform.position - (between / 2.0f); //Placerar ut repet mellan spelarens "hookpistol" och objektet spelaren vill hook till

        _testRope.transform.LookAt(transform.position); //Får repet att rikta sig emot "hookpistolen"
        transform.LookAt(_destination.transform.position); //Får "hookpistolen" att rikta sig emot objektet
    }
    #endregion
}
