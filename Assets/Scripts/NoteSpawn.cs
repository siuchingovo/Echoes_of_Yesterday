using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] Note = new GameObject[7];
    [SerializeField] Material[] Mat = new Material[4];
    private float[] trails = new float[4];
    private float[] beatPos = new float[2];
    // Start is called before the first frame update
    void Start()
    {
        trails[0] = 0.2f;
        trails[1] = 0.0f;
        trails[2] = -0.2f;
        // trails[3] = -0.3f;
        // beatPos[0] = -0.2f;
        // beatPos[1] = 0.3f;
        // for(int i = 0; i < 2; i++){
            GameObject clone = Instantiate(Note[Random.Range(0, 7)], new Vector3(0, 0, 0), Quaternion.identity); //new Quaternion(0.0f,-0.70710682f,0f,0.707106829f));
            clone.transform.parent = this.transform;
            clone.transform.localPosition = new Vector3(trails[Random.Range(0, 3)], 0.0f, 0.0f);
            clone.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Mat[Random.Range(0, 4)];
            // clone.transform.localRotation = new Quaternion(0.0f,-0.70710682f,0f,0.707106829f);
            // clone.transform.localScale = new Vector3(0.3f, 6f, 0.3f);

        // }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
