using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManage : MonoBehaviour
{
        private int puntaje = 0;
        public void IncrementarPuntaje(int puntos)
        {
            puntaje += puntos; 
            Debug.Log("Puntaje actual: " + puntaje);
       }
    

}
