using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Proyecto26;
using UnityEngine.SceneManagement;

public class PuntajeJugador : MonoBehaviour
{
    public TMP_InputField textoNombre;
    public static string nombreJugador;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Enviar()
    {
        nombreJugador = textoNombre.text;
        PlayerPrefs.SetString("nombreJugador", nombreJugador);
        EnviarPorPost();
        NextScene();
    }

    public void EnviarPorPost()
    {
        Usuario usuario = new Usuario();
        RestClient.Post("https://fir-minigame-default-rtdb.firebaseio.com/.json", usuario);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Main");
    }
}
