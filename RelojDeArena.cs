using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelojDeArena : MonoBehaviour
{
    public GameObject circuloPrefab;
    public Transform ParedDerecha;
    public Transform ParedIzquierda;
    public Transform Contenedor;

    private Queue<GameObject> circuloPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject circulo = Instantiate(circuloPrefab, new Vector3(
                Random.Range(ParedIzquierda.position.x, ParedDerecha.position.x),
                ParedDerecha.position.y, 0), Quaternion.identity);
            circulo.SetActive(false);
            circuloPool.Enqueue(circulo);
        }

        InvokeRepeating("SpawnCirculo", 1f, 1f);
    }

    void SpawnCirculo()
    {
        if (circuloPool.Count > 0)
        {
            GameObject circuloToReuse = circuloPool.Dequeue();
            circuloToReuse.transform.position = new Vector3(
                Random.Range(ParedIzquierda.position.x, ParedDerecha.position.x),
                ParedDerecha.position.y, 0);
            circuloToReuse.SetActive(true);
            circuloToReuse.transform.SetParent(Contenedor);
            circuloPool.Enqueue(circuloToReuse);
        }
    }
}