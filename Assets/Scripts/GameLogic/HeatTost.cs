using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeatTost : MonoBehaviour
{
    #region Serialize variables
    [SerializeField] private GameObject _toast1;
    [SerializeField] private GameObject _toast2;
    [SerializeField] private GameObject _armFryst;
    [SerializeField] private Vector3 _activeArm;
    [SerializeField] private Vector3 _deactiveArm;
    [SerializeField] private Renderer _toastHeatColor1;
    [SerializeField] private Renderer _toastHeatColor2;
    [SerializeField] private Text _needHoldToDone;
    [SerializeField] private Text _doneTime;
    [SerializeField] private Animator _toasterVibrant;
    [SerializeField] private AudioManager _audio;
    #endregion
    #region Variables
    public static bool _done = false;
    private Rigidbody _rb1;
    private Rigidbody _rb2;
    private Transform _arm;
    private float _force = 1.6f;
    private float _forceRight = 1.7f;
    private float _t = 0f;
    private int _defaultHoldTime = 1;
    private int _maximumHoldTime = 3;
    private bool _needSetTime = true;
    private float _reset = 0;
    private bool _pushOn = false;
    private bool _once = true;
    #endregion
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
        if (_once)
        {
            _once = false;
            _audio.ClickStartToaster();
        }
        _needHoldToDone.text = Convert.ToString(_t);
        _t += Time.deltaTime;
        _arm.localPosition = _activeArm;
        _toastHeatColor1.material.color = Color.Lerp(Color.white, Color.red, _t / Convert.ToInt32(_doneTime.text));
        _toastHeatColor2.material.color = Color.Lerp(Color.white, Color.red, _t / Convert.ToInt32(_doneTime.text));
    }
    private void OnMouseUp()
    {
        _once = true;
        _arm.localPosition = _deactiveArm;
        _needSetTime = true;
        _toasterVibrant.SetTrigger("Vibrant");
        _audio.StopToaster();
        CheckDoneTime();
        if (_needSetTime)
        {
            _doneTime.text = SetNeedTimeHold();
        }
    }
    private void FixedUpdate()
    {
        if (_pushOn)
        {
            ToastPush();
        }
    }
    private void CheckDoneTime()
    {
        float roundTime = Mathf.Round(_t);
        if (roundTime == Convert.ToInt32(_doneTime.text))
        {
            _t = _reset;
            _done = true;
            StartCoroutine(DelayPush());
        }
        else
        {
            _t = _reset;
            _done = false;
            StartCoroutine(DelayPush());
        }
    }
    private string SetNeedTimeHold()
    {
        _doneTime.text = Convert.ToString(UnityEngine.Random.Range(_defaultHoldTime, _maximumHoldTime));
        _needSetTime = false;
        return _doneTime.text;
    }
    private IEnumerator CheckOnce()
    {
        yield return new WaitForSeconds(0.5f);
        _once = true;
    }
    private IEnumerator DelayPush()
    {
        _pushOn = true;
        yield return new WaitForSeconds(0.05f);
        _pushOn = false;
    }

    private void ToastPush()
    {
        _rb1.AddForce(Vector3.up * _force, ForceMode.Impulse);
        _rb2.AddForce(Vector3.up * _force, ForceMode.Impulse);
        Invoke("AddTorque", 0.2f);
    }
    private void AddTorque()
    {
        _rb1.AddTorque(Vector3.right * _forceRight, ForceMode.Impulse);
        _rb2.AddTorque(Vector3.right * _forceRight, ForceMode.Impulse);
    }
}
