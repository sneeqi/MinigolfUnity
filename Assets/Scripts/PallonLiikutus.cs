using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallonLiikutus : MonoBehaviour
{
    // Asettaa lyönnin voimakkuuden ([SerializedField] laittaa, että arvoa voidaan muokata unitystä)
    [SerializeField] private float shotPower; 
     // rigidbody antaa objectille unityn fysiikka ominaisuudet
    private Rigidbody myRigidbody;
    private float shotForce;
    // Vector3 on vektori luokka eli se antaa objectille (x,y,z) suunnat.
    private Vector3 startPos, endPos, direction; // Aloitus/lopetuspaikka ja suunta
    private bool canShoot = true; // Määrittää, että voiko palloa lyödä.


    private void Start()
    {
        // Alustetaan rigidbody pelin alussa
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        // Jos hiireä ei ole painettu
        if (Input.GetMouseButtonDown(0))
        {
            startPos = MousePosition();
        }
        // Jos hiireä on painettu
        if (Input.GetMouseButton(0))
        {
            endPos = MousePosition();
        }
        // Kun hiiren painaminen lopetetaan
        if (Input.GetMouseButtonUp(0))
        {
            canShoot = false;
        }
    }

    private void FixedUpdate() 
    {
        if (!canShoot)
        {
            // Suunta mihin voidaan lyödä palloa
            direction = startPos - endPos;
            // Lisätään palloon kohdistuva voima
            myRigidbody.AddForce(direction * shotPower, ForceMode.Impulse);
            // Resetoidaan aloitus/lopetuspaikka
            startPos = endPos = Vector3.zero;
        }
    }

    // Hiiren sijainti
    private Vector3 MousePosition() 
    {
        Vector3 position = Vector3.zero;
        // Luo säteen kamerasta hiiren sijaintiin
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit(); 

        // Jos säde osuu, asetetaan osuman sijainti
        if (Physics.Raycast(ray, out hit))
        {
            position = hit.point;
        }
        // Palauta sijainti
        return position;
    }










}
