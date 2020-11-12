using System.Collections;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField]
    private int _loops;

    [SerializeField]
    private float _scaleMultiplier;

    [SerializeField]
    private float _transition;

    private PointsMovement _pointsMovement;

    private void Awake()
    {
        _pointsMovement = GetComponent<PointsMovement>();
    }

    private void Start()
    {

        StartCoroutine(DoCheckLoops());
    }


    private IEnumerator DoCheckLoops()
    {
        yield return new WaitUntil(() => _pointsMovement.Loops % _loops == 0);

        yield return StartCoroutine(DoScale());

        StartCoroutine(DoCheckLoops());
    }

    private IEnumerator DoScale()
    {
        Vector3 _current = transform.localScale;

        Vector3 _next = _current * _scaleMultiplier;

        yield return StartCoroutine(DoTransition(_current, _next));
       
        yield return StartCoroutine(DoTransition(_next, _current));
    }

    private IEnumerator DoTransition(Vector3 current, Vector3 next)
    {
        float _transitionStep = 0;

        while (_transition > _transitionStep)
        {
            _transitionStep += Time.deltaTime;

            float step = _transitionStep / _transition;

            transform.localScale = Vector3.Lerp(current, next, step);

            yield return null;
        }
    }
}
