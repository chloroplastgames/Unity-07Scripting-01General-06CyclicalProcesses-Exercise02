/// INFORMATION
///
/// Project: Ejercicio
/// Game: Ejercicio
/// Data: 03/11/2020
/// Author: Valdeir Antonio
/// Programmers: Valdeir Antonio
/// Description: ejercicio usando corrutina.
///
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Prototype/Scale Game Data")]
/// <summary>
/// Clase responsable de almacenar datos relacionados con la escala.
/// </summary>
public class ScaleGameData : ScriptableObject
{
    #region PRIVATE VARIABLES

    [SerializeField] private int _loops;

    [SerializeField] private Vector3 _currentValue;

    [SerializeField] private float _scaleMultiplier;

    [SerializeField] private float _transitionStep; 

    [SerializeField] private float _transition = 2f;

    [SerializeField] private bool _scale;

    [SerializeField] private AnimationCurve _ScaleCurve;

    #endregion

    #region PROPERTIES

    /// <value> Variable responsable de devovler el número de loops transcurrido. </value>  
    public int Loops { get => _loops; set => _loops = value; }

    /// <value> Variable responsable de devovler el tiempo transcurrido. </value> 
    public float TransitionStep { get => _transitionStep; set => _transitionStep = value; }

    /// <value> Variable responsable de devolver la position actual. </value>v
    public Vector3 CurrentValue { get => _currentValue; set => _currentValue = value; }

    /// <value> Variable responsable de devolver el multiplicador de la escala. </value>  
    public float ScaleMultiplier { get => _scaleMultiplier; private set { } }

    public bool Scale { get => _scale; set => _scale = value; }
    /// <value> Variable responsable de devolver la duracion dela transition. </value>  
    public float Transition { get => _transition; set => _transition = value; }

    /// <value> Variable responsable de devolver la curva de comportamiento. </value>  
    public AnimationCurve ScaleCurve { get => _ScaleCurve; private set { }}

    #endregion
}