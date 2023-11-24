using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    [SerializeField] GameObject Note;
    private float[] trails = new float[4];
    private float[] beatPos = new float[2];
    // Start is called before the first frame update
    void Start()
    {
        trails[0] = 0.3f;
        trails[1] = 0.1f;
        trails[2] = -0.1f;
        trails[3] = -0.3f;
        beatPos[0] = -0.2f;
        beatPos[1] = 0.3f;
        for(int i = 0; i < 2; i++){
            GameObject clone = Instantiate(Note, new Vector3(0, 0, 0), Quaternion.identity); //new Quaternion(0.0f,-0.70710682f,0f,0.707106829f));
            clone.transform.parent = this.transform;
            clone.transform.localPosition = new Vector3(beatPos[i], 0.5f, trails[Random.Range(0, 4)]);
            clone.transform.localRotation = new Quaternion(0.0f,-0.70710682f,0f,0.707106829f);
            clone.transform.localScale = new Vector3(0.3f, 6f, 0.3f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
