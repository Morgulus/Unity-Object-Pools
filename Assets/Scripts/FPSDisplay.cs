using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour { 

    public Text highestFPSLabel,
                averageFPSLabel,
                lowestFPSLabel;
    FPSCounter counter;

    [System.Serializable] private struct FPSColor
    {
        public Color color;
        public int minimumFps;
    }

    [SerializeField] FPSColor[] coloring;

    private void Awake()
    {
        counter = GetComponent<FPSCounter>();
    }
    private void Update()
    {
        DisplayLabel(averageFPSLabel, counter.AverageFPS, "A");
        DisplayLabel(highestFPSLabel, counter.HighestFPS, "H");
        DisplayLabel(lowestFPSLabel, counter.LowestFPS, "L");        
    }
    void DisplayLabel(Text label, int fps, string name)
    {
        label.text = name + ": " + Mathf.Clamp(fps, 0, 999);
        for (int i = 0; i < coloring.Length; i++)
        {
            if (fps >= coloring[i].minimumFps)
            {
                label.color = coloring[i].color;
                break;
            }
        }
    }
}
