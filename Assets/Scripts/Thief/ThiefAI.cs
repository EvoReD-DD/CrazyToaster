using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ThiefAI : MonoBehaviour
{
    [SerializeField] private Animator _thiefLeftUp;
    [SerializeField] private Animator _thiefRightMiddle;
    [SerializeField] private Animator _thiefBottom;
    [SerializeField] private Animator _thiefBottom2;
    [SerializeField] private Animator _thiefMove;
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Button _buttonCatch;
    [SerializeField] private Text _countDoneToasts;
    private float _step;
    private bool _run = false;
    private int _count;
    private bool _once = true;

    private void Update()
    {
        if (_run)
        {
            _step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target, _step);
        }
    }
    public void StartThief()
    {
        if (_once)
        {
            StartCoroutine(StartAnimations());
        }
    }
    public void CatchThief()
    {
        _run = false;
        _thiefMove.SetTrigger("fall");
        _countDoneToasts.text = Convert.ToString(Convert.ToInt32(_countDoneToasts.text) + _count);
        _buttonCatch.interactable = false;
        Invoke("ResetPosition", 2.6f);
    }
    public void ResetPosition()
    {
        this.gameObject.transform.position = _startPosition;
    }
    private IEnumerator StartAnimations()
    {
        _once = false;
        _thiefLeftUp.SetTrigger("leftup");
        yield return new WaitForSeconds(6f);
        _thiefRightMiddle.SetTrigger("rightmiddle");
        yield return new WaitForSeconds(4f);
        _thiefBottom.SetTrigger("bottom");
        yield return new WaitForSeconds(5f);
        _thiefBottom2.SetTrigger("bottom2");
        yield return new WaitForSeconds(5f);
        _thiefMove.SetTrigger("thief");
        yield return new WaitForSeconds(0.5f);
        _run = true;
        _buttonCatch.interactable = true;
        _count = UnityEngine.Random.Range(1, 2);
        _countDoneToasts.text = Convert.ToString(Convert.ToInt32(_countDoneToasts.text) - _count);
        if (Convert.ToInt32(_countDoneToasts.text) < 0)
        {
            _countDoneToasts.text = "0";
        }
        yield return new WaitForSeconds(5f);
        _buttonCatch.interactable = false;
        _run = false;
        this.gameObject.transform.position = _startPosition;
        _once = true;
    }
}
