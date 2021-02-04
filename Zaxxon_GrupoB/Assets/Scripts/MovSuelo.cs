using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSuelo : MonoBehaviour
{
    Renderer render;
    [SerializeField] Vector2 despl;
   [SerializeField] SpaceshipMove spaceshipMove;
    [SerializeField] float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();

        
        spaceshipMove = GameObject.Find("SpaceshipMove").GetComponent<SpaceshipMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        scrollSpeed = spaceshipMove.speed / 108;
        float offset = Time.time * scrollSpeed;
        Vector2 despl = new Vector2(offset, 0);
        render.material.SetTextureOffset("_MainTex", despl);
        
    }
}
