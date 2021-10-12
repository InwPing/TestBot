using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public int numberAgentA;
    public int numberAgentB;
    public int numberAgentG;

    public GameObject prefabAgentA;
    public GameObject prefabAgentB;
    public GameObject prefabAgentG;


    // Use this for initialization
    void Start()
    {
        Vector3 size = transform.localScale;

        for (int i = 0; i < numberAgentA; i++)
        {
            GameObject instanceAgentA = (GameObject)Instantiate(prefabAgentA);
            instanceAgentA.transform.position = new Vector3(Random.Range(-size.x * 10f, size.x * 10f), 0, Random.Range(-size.z * 10f, size.z * 10f));

        }

        for (int i = 0; i < numberAgentB; i++)
        {
            GameObject instanceAgentB = (GameObject)Instantiate(prefabAgentB);
            instanceAgentB.transform.position = new Vector3(Random.Range(-size.x * 10f, size.x * 10f), 0, Random.Range(-size.z * 10f, size.z * 10f));

        }

        for (int i = 0; i < numberAgentG; i++)
        {
            GameObject instanceAgentG = (GameObject)Instantiate(prefabAgentG);
            instanceAgentG.transform.position = new Vector3(Random.Range(-size.x * 3f, size.x * 3f), 0.5f, Random.Range(-size.z * 3f, size.z * 3f));

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}