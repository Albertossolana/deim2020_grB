using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColisionNave : MonoBehaviour
{
    [SerializeField] MeshRenderer VisionNave;

    [SerializeField] Text TextPlayAgain;
    [SerializeField] Text TextShowFinalDistance;

    public GameObject SpaceShip;
    SpaceshipMove spaceshipMove;

    void Start() 
    {
        SpaceShip = GameObject.Find("Spaceship");
        spaceshipMove = SpaceShip.GetComponent<SpaceshipMove>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "obstacle")
        { 
        print("Ha colisionado");

         
        VisionNave.enabled = false;
        spaceshipMove.speed = 0f;
        
        //TextShowFinalDistance.text = "Distancia" + n;
        TextPlayAgain.text = "PLAY AGAIN";
        }
     
    }

}
