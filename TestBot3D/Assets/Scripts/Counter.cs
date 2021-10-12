using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class Counter : MonoBehaviour
{
	public BehaviorTree behaviorTree;
	public TextMesh counterText;

	public int numberAgentA;
	public GameObject prefabAgentA;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		counterText.text = behaviorTree.GetVariable("Count").GetValue().ToString();
	}
}