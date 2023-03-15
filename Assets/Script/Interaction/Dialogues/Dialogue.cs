using UnityEngine;

/*
 * This script came from Brackeys tutorial on YouTube:
 * https://www.youtube.com/watch?v=_nRzoTzeyxU
 */
[System.Serializable]
public class Dialogue
{
    public string name;
    
    [TextArea(3, 10)]
    public string[] sentences;
}