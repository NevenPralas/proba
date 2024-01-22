using UnityEngine;

public class ActivateScriptOnArrowKeyPress : MonoBehaviour
{
    public GameObject squadLeaderObject;
    public string scriptName = "MortarSquadLeader";
    public float delay = 30f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Invoke("ActivateScript", delay);
        }
    }

    void ActivateScript()
    {
        if (squadLeaderObject != null)
        {
            MonoBehaviour script = squadLeaderObject.GetComponent(scriptName) as MonoBehaviour;

            if (script != null)
            {
                script.enabled = true;
                Debug.Log(scriptName + " script activated on " + squadLeaderObject.name);
            }
            else
            {
                Debug.LogError("Script '" + scriptName + "' not found on " + squadLeaderObject.name);
            }
        }
        else
        {
            Debug.LogError("SquadLeaderObject is not assigned!");
        }
    }
}