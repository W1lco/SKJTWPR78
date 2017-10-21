using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public class ClickFront : MonoBehaviour {
    public static short Message = 12355;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        StringMessage sm = new StringMessage();
        sm.value = "Achterkant";
        NetworkServer.SendToAll(Message, sm);
        Debug.Log("OnScoreMessage " + sm.value);
        SceneManager.LoadScene("Menu");
    }
}
