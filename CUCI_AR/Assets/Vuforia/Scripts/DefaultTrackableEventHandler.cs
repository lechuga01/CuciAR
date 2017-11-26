/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS


    public GameObject boton1;//es el Canvas de la esena sin el no se mostrara la tarjeta
    public bool cambio = true;
    GameObject x;
    protected virtual void Start()
    {
        x = boton1.transform.Find("BtnDetalles").gameObject;//obtienes el hijo del canvaz que tiene el nombre designado
           
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
   

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        boton1.SetActive(true);//activa la visualizacion del canvas
        // Enable rendering:
        foreach (var component in rendererComponents)
        {
            component.enabled = true;

        }

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;


        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");//devemos poner en el archivo la gerarquia de nombres cuando se suba a vuforia para su obtencion
        //se va a modificar par ahacer un filtro dependiendo de el objeto trckable que obtengamos para poder asi hacer un filtro y desplegar o eliminar botones en pantalla
        //hace que el boton se aparesca al ser vista la acarta con el nombre del objeto
        GameObject vista = GameObject.Find(mTrackableBehaviour.TrackableName);

        if (vista.CompareTag("Aula"))//Las aulas llevan su tag de Aula
        {
            Debug.Log("-----------"+vista.tag);
            x.SetActive(true);//activa la visibilidad del boton en pantalla
                              //Directamente activa el canvas de la imagen activa que se le a otorgado
           // cambio = x.GetComponent<ActivadorBotonVista>().getCambio();
            Debug.Log(cambio);
            GameObject vistaNormal = vista.transform.Find("Plano").gameObject;
            GameObject vistaDetallada = vista.transform.Find("Detalles").gameObject;
            x.GetComponent<ActivadorBotonVista>().setVistas(vistaNormal,vistaDetallada);//se envian los gameObject de las vistas al boton para poderse interactuar
                

        }
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;


        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

            boton1.SetActive (false);//desactiva el canvas que tiene toda la interfaz grafica
            
    }
   

    #endregion // PRIVATE_METHODS
}
