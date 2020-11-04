using System;
using System.Collections; 
using UnityEngine;

/// <summary>
/// /// Clase encargada de realizar la lógica relacionada con la escala de la esfera. 
/// </summary>
public class ObjectScaler : MonoBehaviour
{

    #region PRIVATE VARIABLES

    [SerializeField] private Transform _myTransform;

    private IEnumerator _myRoutine;

    [SerializeField] private ScaleGameData _gameData;

    [SerializeField] private MotionGameData _MotionData;

    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        SetupVariables();
    } 
    
    private void Start()
    {
        StartCoroutine(_myRoutine);
    }

    #endregion

    #region COROUTINES
    /// <summary>
    /// Corrutina responsable de cambiar la escala de la esfera con el tiempo.
    /// </summary>
    /// <param name="data"> ScriptableObject que contiene datos relacionados con la lógica aplicada a la escala de la esfera.</param>
    /// <returns>Devuelve un IEnumerator</returns>
    /// <exception cref="NullReferenceException">Si no se detectan las dependencias</exception>
    private IEnumerator ScaleSphere(ScaleGameData data)
    {
        if (_myTransform == null || _gameData == null)
        {
            throw new NullReferenceException("Una de las dependencias no fue encontrado");
        }
        data.CurrentValue = _myTransform.localScale; 
        while (true)
        {
            if (data.Scale)
            {
                if (data.Transition > data.TransitionStep)
                {
                    data.TransitionStep += Time.deltaTime;

                    _myTransform.localScale = Vector3.Lerp(data.CurrentValue, data.CurrentValue * data.ScaleMultiplier, data.ScaleCurve.Evaluate(Mathf.PingPong(data.TransitionStep, 1)));
                }
                else
                {
                    data.TransitionStep = 0;
                    data.Scale = false;
                }
            }
            else if( _MotionData.Loops % data.Loops == 0)
            {
                data.Scale = true;
            }
            yield return null;
        }
    }

    #endregion

    #region OWN METHODS
    private void SetupVariables()
    {
        _myTransform = transform;
        _myRoutine = ScaleSphere(_gameData);
    }

    #endregion

}
