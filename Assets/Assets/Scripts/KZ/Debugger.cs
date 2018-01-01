using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private CharacterController _controller;

    public GUIStyle style;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void OnGUI()
    {
        var ups = _controller.velocity;
        ups.y = 0;
        GUI.Label(new Rect(0, 100, 400, 100), "Speed: " + Mathf.Round(ups.magnitude * 100) / 100 + "ups", style);
        GUI.Label(new Rect(0, 120, 400, 100), "OnGround: " + _controller.isGrounded, style);
    }
}