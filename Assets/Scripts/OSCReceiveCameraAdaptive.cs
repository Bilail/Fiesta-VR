// script for setting an adaptive frustum to a camera in Unity
// this script needs Osc.cs and UDPPacketIO.cs to work

using UnityEngine;
using System.Collections;

 
public class OSCReceiveCameraAdaptive : MonoBehaviour {
	public string RemoteIP = "0.0.0.0"; //127.0.0.1 signifies a local host (if testing locally
	public int SendToPort = 0; //the port you will be sending from
	public int ListenerPort = 0; //the port you will be listening on

	private Osc handler;
	private Vector3 head_pos;

	void SetHeadPosition(float posX,  float posY,  float posZ) 
	{
		head_pos.Set(posX, posY, posZ);			
	}

	public Vector3 GetHeadPosition ()
	{
		return head_pos;
	}

	//These functions are called when messages are received
	//Access values via: oscMessage.Values[0], oscMessage.Values[1], etc
	void AllMessageHandler(OscMessage oscMessage){
        // You can use the two following lines to test what you are receiving 
		string msgString = Osc.OscMessageToString(oscMessage); //the message and value combined
        Debug.Log(msgString); //log the message and values coming from OSC

        // Get the message
        string msgAddress = oscMessage.Address;
        Debug.Log("message tag: "+msgAddress);

        switch (msgAddress){
		case "...":
			// Get the values of the message
            // ...

            // Do something with the values
            // ...

			break;
		default:
			break;
		}
	}

	// Use this for initialization
	void Start () {
        // init OSC packet receiver
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(RemoteIP, SendToPort, ListenerPort);
		handler = GetComponent<Osc>();
		handler.init(udp); 
		handler.SetAllMessageHandler(AllMessageHandler);
	}
	
}

