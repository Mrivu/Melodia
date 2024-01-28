using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public static class IDsorter
{
    public static string GetStatusID(int id)
    {
        if (id == 0)
        {
            return "none";
        }
        else if (id == 1)
        {
            return "Daze";
        }
        else if (id == 2)
        {
            return "Voltage";
        }
        else
        {
            return null;
        }
    }
}
