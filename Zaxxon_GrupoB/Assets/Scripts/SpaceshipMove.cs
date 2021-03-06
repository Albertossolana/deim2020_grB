﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed;

    private bool RangoMovX = true;
    private bool RangoMovY = true;
    
    public float moveSpeed = 3f;
    //Variable que determina si estoy en los márgenes
   

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    [SerializeField] Text TextSpeed;
    [SerializeField] Text TextShowFinalDistance;
    //AudioSource
    private AudioSource audioSource;
  
    [SerializeField] MeshRenderer VisionNave;
    [SerializeField] GameObject CanvasFinalJuego;
    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //speed = 1f;
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
       TextShowFinalDistance.text = " ";
        CanvasFinalJuego.SetActive(false);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();
        
            
        
    }
    
   
   
    
//Colision de la nave y consecuencias
 private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "obstacle")
        { 
        //print("Ha colisionado");
        
        StopCoroutine("Distancia");
        VisionNave.enabled = false;
        Instantiate(explosion, transform);
        moveSpeed = 0f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
            
        speed = 0f;
        audioSource.Stop();
        audioSource.PlayOneShot(explosionSound);
        Invoke("GameOver", 2.0f);
            moveSpeed = 0f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
private void GameOver()
   {
        TextShowFinalDistance.text = TextDistance.text;
        CanvasFinalJuego.SetActive(true);
   }
     
    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n++)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n*speed;
            TextSpeed.text = "VELOCIDAD: " + speed;
            //Aumento de la velocidad segun el tiempo
        if (speed <= 40f)
        {
              speed = speed + 0.5f;
        }
            
         //Aumento de la velocidad según ciertas distancias
           /*if ( n <20)
            {
                speed = 5;
            }
           else if (n >= 20 && n < 100)
            {
                speed = 10;
            }
           else if (n >= 100 && n< 500)
            {
                speed = 15;
            }
           else 
            {
                speed = 20;
            }
          */
            //Ejecuto cada ciclo esperando medio segundo
            yield return new WaitForSeconds(0.5f);    
        }
        
    }
   
    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        float MyPosX = transform.position.x;
        float MyPosY = transform.position.y;

        //print("DesplX: " + desplX + " - MyposX" + MyPosX);
     
        if(MyPosX < -6 && desplX < 0)
        {
            RangoMovX = false;
        }
        else if(MyPosX < -6 && desplX > 0)
        {
            RangoMovX = true;
        }
        else if(MyPosX > 5.6 && desplX > 0)
        {
            RangoMovX = false;
        }
        else if(MyPosX > 5.6 && desplX < 0)
        {
            RangoMovX = true;
        }
      

        if (MyPosY < 0 && desplY < 0)
        {
            RangoMovY = false;
        }
        else if (MyPosY < 0 && desplY > 0)
        {
            RangoMovY = true;
        }
        else if (MyPosY > 4.8 && desplY > 0)
        {
            RangoMovY = false;
        }
        else if (MyPosY > 4.8 && desplY < 0)
        {
            RangoMovY = true;
        }


        if (RangoMovX)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX, Space.World);
            

            //rotacion += new Vector3 (rotX * -5000, y, rotZ * -10000) * me;
            //transform.eulerAngles = rotacion;
        }
        if (RangoMovY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY, Space.World);
        
        }

            transform.rotation = Quaternion.Euler(0,0, desplX * -20);

        
    }
}
