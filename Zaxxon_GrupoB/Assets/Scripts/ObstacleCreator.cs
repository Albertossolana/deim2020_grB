using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{

    //Variable que contendré el prefab con el obstáculo
    [SerializeField] GameObject Columna;

    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumber;
    Vector3 RandomPos;

    //Distancia a la que se crean las columnas iniciales
    [SerializeField] int distanciainicial = 5;
    [SerializeField] float distanciaSeparacion = 1.1f;
    //Para acceder a la velocidad de la nave
    public GameObject Nave;
    private SpaceshipMove spaceshipMove;

    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a los componentes del script de la nave
        spaceshipMove = Nave.GetComponent<SpaceshipMove>();
        //Este es el bucle que habia hecho yo para las columnas iniciales
        /*for (int n=0; n>-10; n--)
        {
            randomNumber = Random.Range(-4f, 7f);
            Vector3 PosColIn = InitPos.position + new Vector3(randomNumber, 0, n*distanciainicial);
            Instantiate(Columna, PosColIn, Quaternion.identity);
        }
        */
        //Se crean las columnas iniciales
        for(int n = 1; n<=30; n++)
        {
            CrearColumna(-n * distanciainicial);
        }
        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");

    }

    //Función que crea una columna en una posición Random
    void CrearColumna(float posZ = 0f)
    {
        randomNumber = Random.Range(-3f, 5f);
        RandomPos = new Vector3(randomNumber, 0, posZ);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos * distanciaSeparacion;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            CrearColumna();
            float interval = 4 / spaceshipMove.speed;
            yield return new WaitForSeconds(interval);
        }

    }


}
