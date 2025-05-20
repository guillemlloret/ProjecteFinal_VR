using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecetaAleatoria : MonoBehaviour
{
    // Enum para opciones de presentación y sabores
    public enum TipoPresentacionYogur { Cucurucho, Tarrina }
    public enum SaborPolo { Limon, Fresa }

    [System.Serializable]
    public class RecetaYogur
    {
        public TipoPresentacionYogur presentacion;
        public string descripcion;

        public override string ToString()
        {
            return $"Yogur Helado en {presentacion}";
        }
    }

    [System.Serializable]
    public class RecetaPolo
    {
        public SaborPolo sabor;
        public string descripcion;

        public override string ToString()
        {
            return $"Polo de {sabor}";
        }
    }

    // Función para crear receta de yogur helado aleatoria
    public RecetaYogur CrearYogurAleatorio()
    {
        TipoPresentacionYogur presentacion = (TipoPresentacionYogur)Random.Range(0, 2);
        return new RecetaYogur
        {
            presentacion = presentacion,
            descripcion = $"Yogur helado servido en {presentacion.ToString().ToLower()}"
        };
    }

    // Función para crear receta de polo de hielo aleatoria
    public RecetaPolo CrearPoloAleatorio()
    {
        SaborPolo sabor = (SaborPolo)Random.Range(0, 2);
        return new RecetaPolo
        {
            sabor = sabor,
            descripcion = $"Polo de hielo sabor {sabor.ToString().ToLower()}"
        };
    }

    // Prueba rápida en consola
    void Start()
    {
        var recetaYogur = CrearYogurAleatorio();
        Debug.Log(recetaYogur);

        var recetaPolo = CrearPoloAleatorio();
        Debug.Log(recetaPolo);
    }
}

