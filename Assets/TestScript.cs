using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetMQ;
using NetMQ.Sockets;

public class TestScript : MonoBehaviour
{
    PublisherSocket publisher;
    ulong counter = 0;
    const ulong SIZE = 1280 * 720 * 3 * sizeof(float);
    byte[] data;

    void Start()
    {
        Debug.Log("Connecting to test server");
        publisher = new PublisherSocket();
        publisher.Bind("tcp://*:6666");
        data = new byte[SIZE];
    }

    void Update()
    {
        Debug.Log($"Sending");
        publisher.SendFrame(data);
        counter++;
    }
}
