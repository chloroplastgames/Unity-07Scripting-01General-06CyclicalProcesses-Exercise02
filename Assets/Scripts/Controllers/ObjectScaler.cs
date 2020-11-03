using System;
using System.Collections;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{

    #region PRIVATE VARIABLES

    [SerializeField] private Transform _myTransform;

    private IEnumerator _myRoutine;

    [SerializeField] private ScaleGameData _gameData;

    [SerializeField] private MotionGameData _MotionData;

    #endregion 

    private void Awake()
    {
        _myTransform = transform;
        _myRoutine = ScaleSphere(_gameData);
    }

    private void Start()
    {
        StartCoroutine(_myRoutine);
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
        data.CurrentValue = _myTransform.localScale; 
        while (true)
        {
            if (data.Scale)
            {
                if (data.Transition > data.TransitionStep)
                {
                    data.TransitionStep += Time.deltaTime;

                    _myTransform.localScale = Vector3.Lerp(data.CurrentValue, data.CurrentValue * data.ScaleMultiplier, Mathf.PingPong(data.TransitionStep, 1));
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

}
