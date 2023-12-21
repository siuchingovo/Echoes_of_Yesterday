using UnityEngine;

public class AudioAnalyzer_yun : MonoBehaviour
{
    public AudioSource audioSource;

    public int frameInterval = 60;

    public Vector3 audioPosition = new Vector3(0f, 0f, 0f);

    public PathPointDrawer pathPointDreawer;

    private int counter = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        counter += 1;
        float[] spectrumData = new float[256]; 

        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Blackman);
        
        
        float maxFrequency = FindMaxFrequency(spectrumData);
        float objectHeight = MapFrequencyToHeight(maxFrequency) * 0.1f;

        if (counter % frameInterval == 0)
        {
            audioPosition = new Vector3(audioPosition.x + 1, objectHeight, audioPosition.z);
            pathPointDreawer.DrawPoint(audioPosition);

            transform.position = audioPosition;
        }
    }

    float FindMaxFrequency(float[] spectrumData)
    {
        float maxFrequency = 0f;
        float maxIntensity = 0f;

        for (int i = 0; i < spectrumData.Length; i++)
        {
            if (spectrumData[i] > maxIntensity)
            {
                maxIntensity = spectrumData[i];
                maxFrequency = i * AudioSettings.outputSampleRate / 2 / spectrumData.Length;
            }
        }

        return maxFrequency;
    }

    float MapFrequencyToHeight(float frequency)
    {
        return Mathf.Lerp(0f, 10f, frequency / 1000f);
    }

}
