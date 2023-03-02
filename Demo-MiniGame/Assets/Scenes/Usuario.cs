using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Usuario 
{
    public string nombreUsuario;
    public Usuario()
    {
        nombreUsuario = PuntajeJugador.nombreJugador;
    }

}
