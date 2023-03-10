using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntajeJugador : MonoBehaviour
{
    [SerializeField] GameObject levelSelectorCanva;
    [SerializeField] GameObject formCanva;
    [SerializeField] TMP_InputField textoNombre;
    [SerializeField] TMP_InputField textoApellido;
    public static string nombreJugador;

    public void Enviar()
    {
        if(textoNombre.text == "" || textoApellido.text == "") return;
        nombreJugador = textoNombre.text + " " + textoApellido.text;
        PlayerPrefs.SetString("nombreJugador", nombreJugador);
        formCanva.SetActive(false);
        levelSelectorCanva.SetActive(true);
    }


    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
