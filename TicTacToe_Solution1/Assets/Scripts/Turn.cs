using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour {
    public GameObject x, o;
    string first, winner;
    public GameObject win1, win2, draw, play_again;
    private GameObject f;
    private int lose =0, win=0, draw_int=0;
    private List<GameObject> fields = new List<GameObject>();

    public bool Winner(int winer)//check winner
    {
        if (Array_field.field[0] == winer && Array_field.field[1] == winer && Array_field.field[2] == winer)
            return true;
        else if (Array_field.field[3] == winer && Array_field.field[4] == winer && Array_field.field[5] == winer)
            return true;
        else if (Array_field.field[6] == winer && Array_field.field[7] == winer && Array_field.field[8] == winer)
            return true;
        else if (Array_field.field[0] == winer && Array_field.field[3] == winer && Array_field.field[6] == winer)
            return true;
        else if (Array_field.field[1] == winer && Array_field.field[4] == winer && Array_field.field[7] == winer)
            return true;
        else if (Array_field.field[2] == winer && Array_field.field[5] == winer && Array_field.field[8] == winer)
            return true;
        else if (Array_field.field[0] == winer && Array_field.field[4] == winer && Array_field.field[8] == winer)
            return true;
        else if (Array_field.field[2] == winer && Array_field.field[4] == winer && Array_field.field[6] == winer)
            return true;
        else
            return false;
    }

    void Artificial_Intelligence_turn() //bot
    {
        int num = 0;
        Array_field.found_free();
        if (Array_field.free_f.Count == 0 )//check draw after human turn
        {
            draw.SetActive(true);
            draw_int = 1;
            int draw_int_d = PlayerPrefs.GetInt("Draws");
            PlayerPrefs.SetInt("Draws", draw_int_d + draw_int);
            GameObject.Find("Draws").GetComponent<Text>().text = PlayerPrefs.GetInt("Draws").ToString();
            Array_field.draw_n = 5;
            PlayerPrefs.SetString("Winner", "Computer");
            for (int k = 0; k <= 8; k++)
            {
                fields[k].SetActive(false);
            }
        }
        else if (PlayerPrefs.GetString("Difficult") == "Easy") //if bot easy
        {
            num = Random.Range(0, Array_field.free_f.Count);
            Array_field.num_d = Array_field.free_f[num];
        }
        else if (PlayerPrefs.GetString("Difficult") == "Norm")//if bot norm
        {
            if (Array_field.free_f.Count > 1)
            {
                if (Array_field.field[0] == 1 && Array_field.field[1] == 1 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[0] == 1 && Array_field.field[3] == 1 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[0] == 1 && Array_field.field[4] == 1 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[1] == 1 && Array_field.field[4] == 1 && Array_field.field[7] == 0)
                    Array_field.num_d = 7;
                else if (Array_field.field[2] == 1 && Array_field.field[1] == 1 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[2] == 1 && Array_field.field[5] == 1 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[2] == 1 && Array_field.field[4] == 1 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[3] == 1 && Array_field.field[4] == 1 && Array_field.field[5] == 0)
                    Array_field.num_d = 5;
                else if (Array_field.field[3] == 1 && Array_field.field[6] == 1 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[4] == 1 && Array_field.field[5] == 1 && Array_field.field[3] == 0)
                    Array_field.num_d = 3;
                else if (Array_field.field[4] == 1 && Array_field.field[6] == 1 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[4] == 1 && Array_field.field[7] == 1 && Array_field.field[1] == 0)
                    Array_field.num_d = 1;
                else if (Array_field.field[4] == 1 && Array_field.field[8] == 1 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[5] == 1 && Array_field.field[8] == 1 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[6] == 1 && Array_field.field[7] == 1 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[6] == 1 && Array_field.field[8] == 1 && Array_field.field[7] == 0)
                    Array_field.num_d = 7;
                else if (Array_field.field[7] == 1 && Array_field.field[8] == 1 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else
                {
                    num = Random.Range(0, Array_field.free_f.Count);
                    Array_field.num_d = Array_field.free_f[num];
                }
            }
            else
            {
                num = Random.Range(0, Array_field.free_f.Count);
                Array_field.num_d = Array_field.free_f[num];
            }
        }
        else if ((PlayerPrefs.GetString("Difficult") == "Hard"))//if bot hard
        {
            if (Array_field.field[4] == 0)
                Array_field.num_d = 4;
            else if (Array_field.free_f.Count > 1)
            {
                if (Array_field.field[0] == 2 && Array_field.field[1] == 2 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[0] == 2 && Array_field.field[3] == 2 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[0] == 2 && Array_field.field[4] == 2 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[0] == 2 && Array_field.field[6] == 2 && Array_field.field[3] == 0)
                    Array_field.num_d = 3;
                else if (Array_field.field[1] == 2 && Array_field.field[4] == 2 && Array_field.field[7] == 0)
                    Array_field.num_d = 7;
                else if (Array_field.field[2] == 2 && Array_field.field[1] == 2 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[2] == 2 && Array_field.field[5] == 2 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[2] == 2 && Array_field.field[4] == 2 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[2] == 2 && Array_field.field[8] == 2 && Array_field.field[5] == 0)
                    Array_field.num_d = 5;
                else if (Array_field.field[3] == 2 && Array_field.field[4] == 2 && Array_field.field[5] == 0)
                    Array_field.num_d = 5;
                else if (Array_field.field[3] == 2 && Array_field.field[6] == 2 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[4] == 2 && Array_field.field[5] == 2 && Array_field.field[3] == 0)
                    Array_field.num_d = 3;
                else if (Array_field.field[4] == 2 && Array_field.field[6] == 2 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[4] == 2 && Array_field.field[7] == 2 && Array_field.field[1] == 0)
                    Array_field.num_d = 1;
                else if (Array_field.field[4] == 2 && Array_field.field[8] == 2 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[5] == 2 && Array_field.field[8] == 2 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[6] == 2 && Array_field.field[7] == 2 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[6] == 2 && Array_field.field[8] == 2 && Array_field.field[7] == 0)
                    Array_field.num_d = 7;
                else if (Array_field.field[7] == 2 && Array_field.field[8] == 2 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[0] == 1 && Array_field.field[1] == 1 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[0] == 1 && Array_field.field[3] == 1 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[0] == 1 && Array_field.field[4] == 1 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[0] == 1 && Array_field.field[6] == 1 && Array_field.field[3] == 0)
                    Array_field.num_d = 3;
                else if (Array_field.field[1] == 1 && Array_field.field[4] == 1 && Array_field.field[7] == 0)
                    Array_field.num_d = 7;
                else if (Array_field.field[2] == 1 && Array_field.field[1] == 1 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[2] == 1 && Array_field.field[5] == 1 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[2] == 1 && Array_field.field[4] == 1 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[2] == 1 && Array_field.field[8] == 1 && Array_field.field[5] == 0)
                    Array_field.num_d = 5;
                else if (Array_field.field[3] == 1 && Array_field.field[4] == 1 && Array_field.field[5] == 0)
                    Array_field.num_d = 5;
                else if (Array_field.field[3] == 1 && Array_field.field[6] == 1 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[4] == 1 && Array_field.field[5] == 1 && Array_field.field[3] == 0)
                    Array_field.num_d = 3;
                else if (Array_field.field[4] == 1 && Array_field.field[6] == 1 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[4] == 1 && Array_field.field[7] == 1 && Array_field.field[1] == 0)
                    Array_field.num_d = 1;
                else if (Array_field.field[4] == 1 && Array_field.field[8] == 1 && Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[5] == 1 && Array_field.field[8] == 1 && Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[6] == 1 && Array_field.field[7] == 1 && Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                else if (Array_field.field[6] == 1 && Array_field.field[8] == 1 && Array_field.field[7] == 0)
                    Array_field.num_d = 7;
                else if (Array_field.field[7] == 1 && Array_field.field[8] == 1 && Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[0] == 0)
                    Array_field.num_d = 0;
                else if (Array_field.field[2] == 0)
                    Array_field.num_d = 2;
                else if (Array_field.field[6] == 0)
                    Array_field.num_d = 6;
                else if (Array_field.field[8] == 0)
                    Array_field.num_d = 8;
                
                else
                {
                    num = Random.Range(0, Array_field.free_f.Count);
                    Array_field.num_d = Array_field.free_f[num];
                }
            }
            else
            {
                num = Random.Range(0, Array_field.free_f.Count);
                Array_field.num_d = Array_field.free_f[num];
            }

        }
        Array_field.field[Array_field.num_d] = 2;
        f = fields[Array_field.num_d];
        if (PlayerPrefs.GetString("Winner") == "Computer")
        {
            f.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            f.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (Winner(2))//if winner computer
        {
                win2.SetActive(true);
                lose = 1;
                int lose_d = PlayerPrefs.GetInt("Loses");
                PlayerPrefs.SetInt("Loses", lose_d + lose);
                PlayerPrefs.SetString("Winner", "Computer");
                GameObject.Find("Loses").GetComponent<Text>().text = PlayerPrefs.GetInt("Loses").ToString();
                for (int k = 0; k <= 8; k++)
                {
                    fields[k].SetActive(false);
                }

        }

        Array_field.found_free();
        
        if (Array_field.free_f.Count == 0 && lose == 0 && Array_field.draw_n != 5)//check draw after computer turn
        {
            draw.SetActive(true);
            draw_int = 1;
            int draw_int_d = PlayerPrefs.GetInt("Draws");
            PlayerPrefs.SetInt("Draws", draw_int_d + draw_int);
            GameObject.Find("Draws").GetComponent<Text>().text = PlayerPrefs.GetInt("Draws").ToString();
            Array_field.draw_n = 0;
            if (PlayerPrefs.GetString("Winner") == "Computer" && Array_field.draw_n != 5)
                PlayerPrefs.SetString("Winner", "Human");
            for (int k = 0; k <= 8; k++)
            {
                fields[k].SetActive(false);
            }
        }
    }
    
    private void Start()
    {
        for (int k = 0; k <= 8; k++)
        {
            fields.Add(GameObject.Find("Field (" + k + ")"));
        }
        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
        GameObject.Find("Draws").GetComponent<Text>().text = PlayerPrefs.GetInt("Draws").ToString();
        GameObject.Find("Loses").GetComponent<Text>().text = PlayerPrefs.GetInt("Loses").ToString();
        
        if ((PlayerPrefs.GetString("Winner") == "Computer" && Array_field.turn == false))//check who first turn
        {
            Array_field.found_free();
            Artificial_Intelligence_turn();
            Array_field.turn = true;
            Array_field.draw_n = 0;
        }
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Field (0)":
                if (Array_field.field[0] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[0] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (1)":
                if (Array_field.field[1] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[1] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (2)":
                if (Array_field.field[2] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[2] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (3)":
                if (Array_field.field[3] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[3] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (4)":
                if (Array_field.field[4] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[4] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (5)":
                if (Array_field.field[5] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[5] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (6)":
                if (Array_field.field[6] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[6] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (7)":
                if (Array_field.field[7] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[7] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "Field (8)":
                if (Array_field.field[8] == 0)
                {
                    if (PlayerPrefs.GetString("Winner") == "Computer")
                        o.SetActive(true);
                    else
                        x.SetActive(true);
                    Array_field.field[8] = 1;
                    Array_field.found_free();
                    if (Winner(1))
                    {
                        win1.SetActive(true);
                        win = 1;
                        int win_d = PlayerPrefs.GetInt("Wins");
                        PlayerPrefs.SetInt("Wins", win_d + win);
                        GameObject.Find("Wins").GetComponent<Text>().text = PlayerPrefs.GetInt("Wins").ToString();
                        PlayerPrefs.SetString("Winner", "Human");
                        for (int k = 0; k <= 8; k++)
                        {
                            fields[k].SetActive(false);
                        }
                    }
                    else
                    {
                        Artificial_Intelligence_turn();
                    }
                }
                break;
            case "PLAY AGAIN":
                
                for (int i = 0; i <= 8; i++)
                {
                    fields[i].SetActive(true);
                    fields[i].transform.GetChild(0).gameObject.SetActive(false);
                    fields[i].transform.GetChild(1).gameObject.SetActive(false);
                }
                win1.SetActive(false);
                win2.SetActive(false);
                draw.SetActive(false);
                Array_field.Clear();
                if ((PlayerPrefs.GetString("Winner") == "Computer"))
                {
                    Array_field.draw_n = 0;
                    Array_field.found_free();
                    Artificial_Intelligence_turn();

                }
                break;
        }
    }

    
}
