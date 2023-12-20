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

    public GameObject pathPointSphere;

    // Start is called before the first frame update
    void Start()
    {
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
        print(groundLevel + verticalHeight * _FFT.GetBandValue(2, _FreqBands));
        if(LastTimeUpdate + (60f/(54f * 3f / 4f * 3f)) <= (AudioSettings.dspTime)){
            LastTimeUpdate = (float)AudioSettings.dspTime;
            Vector3 pathPointPosition = new Vector3 (0f, groundLevel + verticalHeight * intensity, points.Count * horizontalSpacing);
            points.Add(pathPointPosition);
            Instantiate(pathPointSphere, pathPointPosition, Quaternion.identity);
            // _FFTGameObjects[i].transform.localScale = _BaseScale + (_ScaleStrength * _FFT.GetBandValue(2, _FreqBands));
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FFTObjectArray_v1 : MonoBehaviour
// {
//     public FrequencyBandAnalyser _FFT;
//     public FrequencyBandAnalyser.Bands _FreqBands = FrequencyBandAnalyser.Bands.Eight;

//     GameObject[] _FFTGameObjects;
//     public GameObject _ObjectToSpawn;

//     public float _Spacing = 1;
//     public Vector3 _ScaleStrength = Vector3.up;
//     Vector3 _BaseScale;

//     // Start is called before the first frame update
//     void Start()
//     {
//         _FFTGameObjects = new GameObject[(int)_FreqBands];
//         _BaseScale = _ObjectToSpawn.transform.localScale;
       
//         //---   LINEAR
//         for (int i = 0; i < _FFTGameObjects.Length; i++)
//         {
//             GameObject newFFTObject = Instantiate(_ObjectToSpawn);
//             newFFTObject.transform.SetParent(transform);
//             newFFTObject.transform.localPosition = new Vector3(_Spacing * i, 0, 0);
//             _FFTGameObjects[i] = newFFTObject;
//         }        
//     }

//     private void Update()
//     {
//         for (int i = 0; i < _FFTGameObjects.Length; i++)
//         {
//             _FFTGameObjects[i].transform.localScale = _BaseScale + (_ScaleStrength * _FFT.GetBandValue(i, _FreqBands));
//         }
//     }
// }
