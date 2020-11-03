/// INFORMATION
///
/// Project: Ejercicio
/// Game: Ejercicio
/// Data: 03/11/2020
/// Author: Valdeir Antonio
/// Programmers: Valdeir Antonio
/// Description: ejercicio usando corrutina.
///
using System;
using System.Collections; 
using UnityEngine;

/// <summary>
/// Clase encargada de realizar la lógica relacionada con el color de la esfera.
/// </summary>
public class ChangeColor : MonoBehaviour
{ 

    #region PRIVATE VARIABLES

    private Renderer _myRenderer;

    private IEnumerator _myRoutine;

    [SerializeField] private ColorGameData _gameData;

     

    #endregion 
     
    #region UNITY METHODS

    private void Awake()
    {
        SetupVariables();
    }
     
    private void Start()
    {
        RunCoroutine();
    } 

    void Update()
    {
        
    }
    #endregion

    #region COROUTINES

    /// <summary>
    /// Corrutina responsable de cambiar el color de la esfera con el tiempo.
    /// </summary>
    /// <param name="data"> ScriptableObject que contiene datos relacionados con la lógica aplicada al color de la esfera.</param>
    /// <returns>Devuelve un IEnumerator</returns>
    /// <exception cref="NullReferenceException">Si no se detectan las dependencias</exception>
    private IEnumerator ColorSphere(ColorGameData data)
    {

        if (_myRenderer == null || _gameData == null)
        {
            throw new  NullReferenceException("Una de las dependencias no fue encontrado"); 
        }


        data.CurrentValue = data.CurrentValue;

        while (true)
        {

            if (data.Transition > data.TransitionStep)
            {
                data.TransitionStep += Time.deltaTime;

                float step = data.TransitionStep / data.Transition;

                _myRenderer.material.color = Color.Lerp(data.CurrentValue, data.Values[data.ValueIndex], step);
            }
            else
            {
                data.TransitionStep = 0;

                data.CurrentValue = data.Values[data.ValueIndex];

                data.ValueIndex = (data.ValueIndex + 1) % data.Values.Count;

                _gameData.Loops++; 
            }
            yield return null;
        } 
    }

    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método responsable de configurar las variables del objeto.
    /// </summary>
    private void SetupVariables()
    {
        _myRenderer = GetComponent<Renderer>();

        _myRoutine = ColorSphere(_gameData);
    }

    /// <summary>
    /// Método responsable de iniciar la Corrutina.
    /// </summary>
    public void RunCoroutine()
    {
        try
        {
            StopCoroutine(_myRoutine);
            StartCoroutine(_myRoutine);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Método responsable de parar la Corrutina.
    /// </summary>
    public void StopCoroutine()
    {
        StopCoroutine(_myRoutine);
        _gameData.Loops = 0;
    }

    #endregion
}
