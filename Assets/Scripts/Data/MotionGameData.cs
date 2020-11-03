/// INFORMATION
///
/// Project: Ejercicio
/// Game: Ejercicio
/// Data: 03/11/2020
/// Author: Valdeir Antonio
/// Programmers: Valdeir Antonio
/// Description: ejercicio usando corrutina.
///
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="Prototype/Motion Game Data")]
/// <summary>
/// Clase responsable de almacenar datos relacionados con el movimiento.
/// </summary>
public class MotionGameData: ScriptableObject
{
    #region PRIVATE VARIABLES

    [SerializeField] private int _loops;

    [SerializeField] private Vector3 _currentValue;

    [SerializeField] private float _transitionStep;

    [SerializeField] private int _valueIndex;

    [SerializeField] private List<Vector3> _values;

    [SerializeField] private float _transition = 2f;

    [SerializeField] private AnimationCurve _moveCurve;

    #endregion

    #region PROPERTIES

    /// <value> Variable responsable de devovler el número de loops transcurrido. </value>  
    public int Loops { get => _loops; set => _loops = value; }

    /// <value> Variable responsable de devovler el tiempo transcurrido. </value> 
    public float TransitionStep { get => _transitionStep; set => _transitionStep = value; }

    /// <value> Variable responsable de devolver la position actual. </value>v
    public Vector3 CurrentValue { get => _currentValue; set => _currentValue = value; }

    /// <value> Variable responsable de devolver el índice de la lista de posiciones. </value> 
    public int ValueIndex { get => _valueIndex; set => _valueIndex = value; }

    /// <value> Variable responsable de devolver la lista de posiciones. </value> 
    public List<Vector3> Values { get => _values; private set { } }

    /// <value> Variable responsable de devolver la duracion dela transition. </value>  
    public float Transition { get => _transition; set => _transition = value; }

    /// <value> Variable responsable de devolver la curva de comportamiento. </value>  
    public AnimationCurve MoveCurve { get => _moveCurve; private set { }}

    #endregion
}