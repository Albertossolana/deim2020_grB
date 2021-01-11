using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    [SerializeField] Transform Tarjet;
    [SerializeField] float smoothVelocity = 0.8f;
    private Vector3 camaraVelocity = Vector3.zero;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Tarjet);
        Vector3 camPosition = new Vector3(Tarjet.position.x, Tarjet.position.y + 1, Tarjet.position.z - 5);
        transform.position = Vector3.SmoothDamp(transform.position, camPosition, ref camaraVelocity, smoothVelocity);
    }
}
