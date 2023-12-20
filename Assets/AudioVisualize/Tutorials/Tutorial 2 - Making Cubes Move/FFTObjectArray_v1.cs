using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFTObjectArray_v1 : MonoBehaviour
{
    public FrequencyBandAnalyser _FFT;
    public FrequencyBandAnalyser.Bands _FreqBands = FrequencyBandAnalyser.Bands.Eight;

    GameObject[] _FFTGameObjects;
    public GameObject _ObjectToSpawn;

    public float horizontalSpacing = 1f;
    public float verticalHeight = 1f;
    public List<Vector3> points ;
    public int resolution = 60;
    public float groundLevel = 0f;
    public float LastTimeUpdate = 0f;
    public float dspTimeOffset;

    public GameObject pathPointSphere;

    // Start is called before the first frame update
    void Start()
    {
        dspTimeOffset = (float)AudioSettings.dspTime;
        _FFTGameObjects = new GameObject[(int)_FreqBands];
        // _BaseScale = _ObjectToSpawn.transform.localScale;
       
        // //---   LINEAR
        // for (int i = 0; i < _FFTGameObjects.Length; i++)
        // {
        //     GameObject newFFTObject = Instantiate(_ObjectToSpawn);
        //     newFFTObject.transform.SetParent(transform);
        //     newFFTObject.transform.localPosition = new Vector3(_Spacing * i, 0, 0);
        //     _FFTGameObjects[i] = newFFTObject;
        // }        
    }

    
    private void Update()
    {
        float intensity = 0f;
        for(int i=0; i<8; i++) {
            intensity += _FFT.GetBandValue(i, _FreqBands);
        }
        // print(groundLevel + verticalHeight * _FFT.GetBandValue(2, _FreqBands));
        // if(LastTimeUpdate + (60f/(54f * 3f / 4f * 3f)) <= (AudioSettings.dspTime)){
        //     // LastTimeUpdate = (float)AudioSettings.dspTime;
        //     LastTimeUpdate += (60f/(54f * 3f / 4f * 3f));
        //     Vector3 pathPointPosition = new Vector3 (0f, groundLevel + verticalHeight * intensity, points.Count * horizontalSpacing);
        //     points.Add(pathPointPosition);
        //     Instantiate(pathPointSphere, pathPointPosition, Quaternion.identity);
        //     // _FFTGameObjects[i].transform.localScale = _BaseScale + (_ScaleStrength * _FFT.GetBandValue(2, _FreqBands));
        // }
        float currentMusicTime = (float)AudioSettings.dspTime - dspTimeOffset;
        print(currentMusicTime);
        // if(LastTimeUpdate + (60f/(54f * 3f / 4f * 3f)) <= currentMusicTime && currentMusicTime >= 0f && currentMusicTime <= 28f )
        // if(LastTimeUpdate + (60f/(54f * 3f / 4f * 3f)) <= currentMusicTime && currentMusicTime >= 58f && currentMusicTime <= 88f )
         if(LastTimeUpdate + (60f/(54f * 3f / 4f * 3f)) <= currentMusicTime && currentMusicTime >= 108f && currentMusicTime <= 138f )
        {
            // LastTimeUpdate = (float)AudioSettings.dspTime;
            LastTimeUpdate += (60f/(54f * 3f / 4f * 3f));
            Vector3 pathPointPosition = new Vector3 (0f, groundLevel + verticalHeight * intensity, points.Count * horizontalSpacing);
            points.Add(pathPointPosition);
            Instantiate(pathPointSphere, pathPointPosition, Quaternion.identity);
            // _FFTGameObjects[i].transform.localScale = _BaseScale + (_ScaleStrength * _FFT.GetBandValue(2, _FreqBands));
        }
    }
}

