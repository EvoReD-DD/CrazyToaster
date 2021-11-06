using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeatTost : MonoBehaviour
{
    [SerializeField] private GameObject _toast1;
    [SerializeField] private GameObject _toast2;
    [SerializeField] private GameObject _armFryst;
    [SerializeField] private Vector3 _activeArm;
    [SerializeField] private Vector3 _deactiveArm;
    [SerializeField] private Renderer _toastHeatColor1;
    [SerializeField] private Renderer _toastHeatColor2;
    [SerializeField] private Text _needHoldToDone;
    [SerializeField] private Text _doneTime;
    private Rigidbody _rb1;
    private Rigidbody _rb2;
    private Transform _arm;
    private float _force;
    private float _forceBad;
    private float _t = 0f;
    private int _defaultHoldTime = 2;
    private int _maximumHoldTime = 5;
    private float _accuracy = 0.3f;
    private bool _needSetTime = true;
    private float _reset = 0;

    private void Start()
    {
        _arm = _armFryst.GetComponent<Transform>();
        _rb1 = _toast1.GetComponent<Rigidbody>();
        _rb2 = _toast2.GetComponent<Rigidbody>();
        _toastHeatColor1 = _toast1.GetComponent<Renderer>();
        _toastHeatColor2 = _toast2.GetComponent<Renderer>();
        _doneTime.text = Convert.ToString(_defaultHoldTime);
    }
    private void OnMouseDrag()
    {
        if (_needSetTime)
        {
            _doneTime.text = SetNeedTimeHold();
        }
        _needHoldToDone.text = Convert.ToString(_t);
        _t += Time.deltaTime;
        _arm.localPosition = _activeArm;
        _toastHeatColor1.material.color = Color.Lerp(Color.white, Color.red, _t / Convert.ToInt32(_doneTime.text));
        _toastHeatColor2.material.color = Color.Lerp(Color.white, Color.red, _t / Convert.ToInt32(_doneTime.text));
    }
    private void OnMouseUp()
    {
        _arm.localPosition = _deactiveArm;
        _needSetTime = true;
        CheckDoneTime();
    }
    private void CheckDoneTime()
    {
        float roundTime = Mathf.Round(_t);
        if (roundTime == Convert.ToInt32(_doneTime.text))
        {
            Debug.Log("WIN");
            _t = _reset;
            ToastPushDone();
        }
        else 
        {
            Debug.Log("Lose");
            ToastPushBad();
            _t = _reset;
        }
    }
    private string SetNeedTimeHold()
    {
        _doneTime.text = Convert.ToString(UnityEngine.Random.Range(_defaultHoldTime, _maximumHoldTime));
        _needSetTime = false;
        return _doneTime.text;
    }
    
    private void ToastPushDone()
    {
        _force = UnityEngine.Random.Range(1.5f, 3f);
        _rb1.AddForce(Vector3.up * _force, ForceMode.Impulse);
        _rb1.AddTorque(Vector3.right * _force);
        _rb1.AddTorque(Vector3.back * _force);
        _rb2.AddForce(Vector3.up * _force, ForceMode.Impulse);
        _rb2.AddTorque(Vector3.right * _force);
        _rb2.AddTorque(Vector3.forward * _force);
    }
    private void ToastPushBad()
    {
        _forceBad = UnityEngine.Random.Range(2f, 5f);
        _rb1.AddForce(Vector3.up * _force, ForceMode.Impulse);
        _rb1.AddTorque(Vector3.right * _force);
        _rb1.AddTorque(Vector3.back * _force);
        _rb2.AddForce(Vector3.up * _force, ForceMode.Impulse);
        _rb2.AddTorque(Vector3.right * _force);
        _rb2.AddTorque(Vector3.forward * _force);
    }
}
