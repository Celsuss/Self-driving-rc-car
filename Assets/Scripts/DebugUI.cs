using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct Action{
	public Action(float[] vectorAction, int size){
		actions = new float[size];
		for(int i = 0; i < size; ++i)
			actions[i] = vectorAction[i];
	}
	float[] actions;
}

public class DebugUI : MonoBehaviour {
	public static DebugUI m_Instance;
	[SerializeField] int m_MaxActions;
	Text m_VelocityText;
	Text m_InputText;

	Queue<Action> m_Actions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateActionsText();
	}

	void UpdateActionsText(){
		Action[] actions = m_Actions.ToArray();

		string actionsStr = "Actions: [";
		for(int i = 0; i < m_Actions.Count; ++i){
			actionsStr += string.Format("[{0}] {1}]", i, actions[i]);
		}
		actionsStr += "]";

		m_InputText.text = actionsStr;
	}

	// Adds actions and remove the oldest action if needed
	public void AddActions(float[] vectorAction, int size) {
		m_Actions.Enqueue(new Action(vectorAction, size));
		if(m_Actions.Count > m_MaxActions)
			m_Actions.Dequeue();
	}
}