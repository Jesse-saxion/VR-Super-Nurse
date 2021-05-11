using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    // Percentage of the button press that is required for the button to be seen as 'pressed'.
    [SerializeField] private float threshold = .1f;

    // Prevent button activations on controllers when bounciness happens after the push of the button.
    [SerializeField] private float deadZone = 0.025f;

    // Keep track if the button is already pressed, to prevent rapid button presses every frame.
    private bool _isPressed;

    // To compare against the current position to see how far the button has been pressed moved.
    private Vector3 _startPos;

    // Acquire linear limit from this joint.
    private ConfigurableJoint _joint;


    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (_isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
