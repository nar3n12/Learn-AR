using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class ClickHandler : MonoBehaviour
{
    public UnityEvent downEvent;
    public UnityEvent upEvent;
    private Animator _anim;
   // private int _flag = 0;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        Debug.Log("clicked");
            _anim.Play("onclick");
            downEvent?.Invoke();
      
       /** else if (_flag == 1)
        {
            _flag = 0;
            _anim.Play("blink");
            UpEvent?.Invoke();
        } **/
    }

    private void OnMouseUp()
    {
        upEvent?.Invoke();
        Debug.Log("up event invoked");
    }
}
