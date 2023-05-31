using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nube;
    public GameObject obstaculo;
    public GameObject moneda;
    public List<GameObject> obstaculos;
    public List<GameObject> nubes;
    public List<GameObject> monedas;
    public float speed = 4;


    public Renderer fondo;
    // Start is called before the first frame update
    void Start()
    {
        //Crear obstaculo 
        obstaculos.Add(Instantiate(obstaculo, new Vector2(8, -3), Quaternion.identity));
        obstaculos.Add(Instantiate(obstaculo, new Vector2(16, -3), Quaternion.identity));
        //Crear nubes
        nubes.Add(Instantiate(nube, new Vector2(6, 4), Quaternion.identity));
        nubes.Add(Instantiate(nube, new Vector2(14, 4), Quaternion.identity));
        //Crear monedas
        nubes.Add(Instantiate(moneda, new Vector2(10, 2), Quaternion.identity));
        nubes.Add(Instantiate(moneda, new Vector2(14, 2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
        // Movimiento Obstaculos
        for (int i = 0; i < obstaculos.Count; i++)
        {
            if (obstaculos[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(11, 18);
                obstaculos[i].transform.position = new Vector3(randomObs, -4, 0);
            }
            obstaculos[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }
        // Movimiento nubes
        for (int i = 0; i < nubes.Count; i++)
        {
            if (nubes[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(6, 11);
                nubes[i].transform.position = new Vector3(randomObs,4, 0);
            }
            nubes[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }
        // Movimiento monedas

        for (int i = 0; i < monedas.Count; i++)
        {
            if (monedas[i].transform.position.x <= -10)
            {
                float randomY = Random.Range(16, 4);
                monedas[i].transform.position = new Vector3(0, randomY, 0);
            }
            monedas[i].transform.position = new Vector3(0,-1, 0)*Time.deltaTime*speed;
        }


    }
   
}
