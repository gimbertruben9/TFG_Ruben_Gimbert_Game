using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // para acceder al componente XR Grab Interactable

public class FireBulletOnActivate : MonoBehaviour
{

    public GameObject bullet; // the bullet that will be spawned
    public Transform spawnPoint; // the transform position it will spawn
    public float fireSpeed = 20; // the fire speed for the pistol

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>(); // accedemos al componente XR Grab Interactable
        grabbable.activated.AddListener(FireBullet); // añadimos el evento y le indicamos la funcion que se llamara cuando se produzca
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // la funcion necesita un parametro de tipo ActivateEventArgs, que nos puede ser util en ocasiones para 
    // obtener informacion sobre el interactor y el interactable
    public void FireBullet(ActivateEventArgs arg)
    {   // creamos la bala 
        GameObject spawnedBullet = Instantiate(bullet); 
        // le asignamos la posicion donde aparecera la bala
        spawnedBullet.transform.position = spawnPoint.position; 
        // le asignamos la velocidad al rigid body en la direccion hacia adelante (forward axis)
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed; 
        // hacemos desaparecer las balas a los 5 segundos
        Destroy(spawnedBullet, 5); 
    }
}
