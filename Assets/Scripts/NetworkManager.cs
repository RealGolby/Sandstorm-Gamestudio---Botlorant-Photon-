using UnityEngine;
using TMPro;
using Photon.Bolt;
using UdpKit;
using System;
using Photon.Bolt.Matchmaking;

public class NetworkManager : Photon.Bolt.GlobalEventListener
{
    [SerializeField] TMP_Text feedback;

    public void FeedbackUser(string text)
    {
        feedback.gameObject.SetActive(true);
        feedback.text = text;
    }

    public void Connect()
    {
        FeedbackUser("Connecting...");
        BoltLauncher.StartClient();
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        FeedbackUser("Searching...");
        BoltMatchmaking.JoinSession(HeadlessServerManager.RoomID());
    }

    public override void Connected(BoltConnection connection)
    {
        FeedbackUser("Connected!");
    }
}
