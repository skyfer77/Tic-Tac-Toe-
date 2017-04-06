using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array_field : MonoBehaviour {

    public static int[] field = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static List<int> free_f;
    public static bool turn = false, check_time = false;
    public static int num_d = 0, draw_n=0, num = 0;
    public static bool human = true;
	public static int num_player = 0;
    public static void found_free()
    {
        free_f = new List<int>();
        for (int j = 0; j < field.Length; j++)
        {
            if (field[j] == 0)
                free_f.Add(j);
        }
    }

    public static void Clear()
    {
        for (int i = 0; i <= 8; i++)
            field[i] = 0;
    }
}
