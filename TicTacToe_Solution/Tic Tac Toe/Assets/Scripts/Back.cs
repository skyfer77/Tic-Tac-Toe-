using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Back":
                Application.LoadLevel("Main");
                Array_field.Clear();
                break;
        }
    }
}
