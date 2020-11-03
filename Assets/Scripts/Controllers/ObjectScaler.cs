using System;
using System.Collections;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{

    #region PRIVATE VARIABLES

    private Transform _myTransform;

    private IEnumerator _myRoutine;

    [SerializeField] private MotionGameData _gameData;

    #endregion
    private PointsMovement _pointsMovement;    

    private void Awake()
    {
        _pointsMovement = GetComponent<PointsMovement>();
    }

    private void Start()
    {
      
    }

    void Update()
    {
      
    } 
    private IEnumerator ScaleSphere(ScaleGameData data)
    {
        if (_myTransform == null || _gameData == null)
        {
            throw new NullReferenceException("Una de las dependencias no fue encontrado");
        }
        yield break;

    }

}
