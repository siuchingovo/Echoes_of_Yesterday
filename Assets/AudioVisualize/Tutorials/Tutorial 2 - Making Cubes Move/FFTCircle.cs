using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFTCircle : MonoBehaviour
{
    [Header("Reference")]
    public FrequencyBandAnalyser _FFT;
    public FrequencyBandAnalyser.Bands _FreqBands = FrequencyBandAnalyser.Bands.Eight;
    GameObject[] _FFTGameObjects;
    public GameObject pathPointSphere;
    [Header("Parameters")]
    public int resolution = 60;
    public float groundLevel = 0f;
    public float radius = 6f;
    public float deltaTheta;
    public float deltaHeight;
    public float scale;

    [Header("Debug(dont modify through inspector)")]
    public List<Vector3> points ;
    public float LastTimeUpdate = 0f;
    public float dspTimeOffset;
    public float currentTheta;
    public float currentHeight;
    public float currentDistance = 0;
    public float numPointDrawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        dspTimeOffset = (float)AudioSettings.dspTime;
        _FFTGameObjects = new GameObject[(int)_FreqBands];
        // _BaseScale = _ObjectToSpawn.transform.localScale;     
    }

    
    private void Update()
    {
        float intensity = 0f;
        for(int i=0; i<8; i++) {
            intensity += _FFT.GetBandValue(i, _FreqBands);
        }
 
        float currentMusicTime = (float)AudioSettings.dspTime - dspTimeOffset;
        print(currentMusicTime);

        // if(LastTimeUpdate + (60f/(54f * 3f / 4f * 3f)) <= currentMusicTime )
        if(LastTimeUpdate + (60f/(54f * 3f / 4f * 3f)) <= currentMusicTime && currentMusicTime >= 0f && currentMusicTime <= 28f )
        {
            // LastTimeUpdate = (float)AudioSettings.dspTime;
            numPointDrawn += 1;
            LastTimeUpdate += (60f/(54f * 3f / 4f * 3f));

            float x = radius * Mathf.Cos(numPointDrawn * deltaTheta);
            float y = groundLevel + numPointDrawn * deltaHeight * intensity *scale;
            float z = radius * Mathf.Sin(numPointDrawn * deltaTheta);

            Vector3 pathPointPosition = new Vector3 (x, y, z);

            points.Add(pathPointPosition);
            Instantiate(pathPointSphere, pathPointPosition, Quaternion.identity);
            // _FFTGameObjects[i].transform.localScale = _BaseScale + (_ScaleStrength * _FFT.GetBandValue(2, _FreqBands));
        }
    }
}

