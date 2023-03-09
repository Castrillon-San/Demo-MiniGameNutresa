using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Proyecto26;
using UnityEngine.SceneManagement;

public class PuntajeJugador : MonoBehaviour
{
    [SerializeField] GameObject levelSelectorCanva;
    [SerializeField] GameObject formCanva;
    public TMP_InputField textoNombre;
    public static string nombreJugador;

    public void Enviar()
    {
        if(textoNombre.text == "") return;
        nombreJugador = textoNombre.text;
        PlayerPrefs.SetString("nombreJugador", nombreJugador);
        //EnviarPorPost();
        formCanva.SetActive(false);
        levelSelectorCanva.SetActive(true);
    }

    //public void EnviarPorPost()
    //{
    //    Usuario usuario = new Usuario();
    //    RestClient.Post("https://fir-minigame-default-rtdb.firebaseio.com/.json", usuario);
    //}


    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
