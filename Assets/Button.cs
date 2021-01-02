using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private ChangeColor parentChangeColor;
    private void Start()
    {
        parentChangeColor = GetComponentInParent<ChangeColor>();
    }

    public void OnClick()
    {
        parentChangeColor.SetRandomColor();
    }
}
