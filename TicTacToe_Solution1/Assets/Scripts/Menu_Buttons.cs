using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Buttons : MonoBehaviour
{
    public GameObject e, e_h, n, n_h, h, h_h;
    private void Start()
    {
        if (PlayerPrefs.GetString("Difficult") == "Easy")
        {
            e_h.SetActive(true);
            e.SetActive(false);
            n.SetActive(true);
            n_h.SetActive(false);
            h.SetActive(true);
            h_h.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Difficult") == "Norm")
        {
            n_h.SetActive(true);
            e.SetActive(true);
            n.SetActive(false);
            e_h.SetActive(false);
            h.SetActive(true);
            h_h.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Difficult") == "Hard")
        {
            h_h.SetActive(true);
            e.SetActive(true);
            n.SetActive(true);
            n_h.SetActive(false);
            h.SetActive(false);
            e_h.SetActive(false);
        }
    }
    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Start":
                Application.LoadLevel("Start");
                PlayerPrefs.SetInt("Wins", 0);
                PlayerPrefs.SetInt("Draws", 0);
                PlayerPrefs.SetInt("Loses", 0);
                break;
            case "Exit":
                Application.Quit();
                break;
            
            case "E":
                PlayerPrefs.SetString("Difficult", "Easy");
                e_h.SetActive(true);
                e.SetActive(false);
                n.SetActive(true);
                n_h.SetActive(false);
                h.SetActive(true);
                h_h.SetActive(false);
                break;
            case "N":
                PlayerPrefs.SetString("Difficult", "Norm");
                n_h.SetActive(true);
                e.SetActive(true);
                n.SetActive(false);
                e_h.SetActive(false);
                h.SetActive(true);
                h_h.SetActive(false);
                break;
            case "H":
                PlayerPrefs.SetString("Difficult", "Hard");
                h_h.SetActive(true);
                e.SetActive(true);
                n.SetActive(true);
                n_h.SetActive(false);
                h.SetActive(false);
                e_h.SetActive(false);
                break;
        }
    }
}
