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
        AsyncIO.ForceDotNet.Force();
        Debug.Log("Connecting to test server");
        publisher = new PublisherSocket();
        publisher.Bind("tcp://*:6666");
        data = new byte[SIZE];

        InvokeRepeating(nameof(Send), 0.0f, 1.0f / 20.0f);
    }

    void Send()
    {
        counter++;
        Debug.Log(counter);
        publisher.SendFrame(data);
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        publisher.Dispose();
        NetMQConfig.Cleanup();
    }
}
