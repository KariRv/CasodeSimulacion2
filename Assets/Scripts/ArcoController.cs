using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcoController : MonoBehaviour
{
    [SerializeField]
    string color;
    private GameManage gameManager;
    private string colorAnterior;
    private static List<string> coloresPasados = new List<string>();
    int puntosPorArco = 1;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManage>();
        colorAnterior = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            Debug.Log(colorAnterior);
            Debug.Log(PuedePasar());

            if (PuedePasar())
            {
                gameManager.IncrementarPuntaje(puntosPorArco);

                coloresPasados.Add(color);

                GameObject.Destroy(gameObject);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }

        }
    }

    private bool PuedePasar()
    {
        // Valida que el avion pueda pasar por el arco
        switch (color)
        {
            case "Verde":
                // Puede pasar si no ha pasado por ningún arco o si el último arco pasado fue verde
                return coloresPasados.Count == 0 || coloresPasados[coloresPasados.Count - 1] == "Verde";
            case "Amarillo":
                // Puede pasar si el último arco pasado fue verde
                return coloresPasados[coloresPasados.Count - 4] == "Verde";
            case "Rojo":
                // Puede pasar si el último arco pasado fue amarillo
                return coloresPasados[coloresPasados.Count - 4] == "Amarillo";
            case "Azul":
                // Puede pasar si el último arco pasado fue rojo
                return coloresPasados[coloresPasados.Count - 4] == "Rojo";
            default:
                return false;
        }
    }
}