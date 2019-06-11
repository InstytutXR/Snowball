﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowball
{
    public class Server : MonoBehaviour
    {
        [SerializeField]
        int DefaultSendPort = 59902;

        [SerializeField]
        int DefaultListenPort = 59901;

        [SerializeField]
        int DefaultBufferSize = 4096;

        public bool IsOpened { get { return com.IsOpened; } }

        public int SendPort { get { return com.SendPortNumber; } set { com.SendPortNumber = value; } }
        public int ListenPort { get { return com.ListenPortNumber; } set { com.ListenPortNumber = value; } }
        [SerializeField]
        public int BufferSize { get { return com.BufferSize; } set { com.BufferSize = value; } }

        public ComServer.ConnectedHandler OnConnected { get { return com.OnConnected; } set { com.OnConnected = value; } }
        public ComServer.DisconnectedHandler OnDisconnected { get { return com.OnDisconnected; } set { com.OnDisconnected = value; } }

        public void SetBeaconDataCreateFunction(ComServer.BeaconDataGenerateFunc func) { com.SetBeaconDataCreateFunction(func); }

        public int BeaconIntervalMs { get { return com.BeaconIntervalMs; } set { com.BeaconIntervalMs = value; } }
        public int MaxHealthLostCount { get { return com.MaxHealthLostCount; } set { com.MaxHealthLostCount = value; } }

        ComServer com = new ComServer();
        public ComServer ComServer { get { return com; } }

        private Server()
        {
            com.SendPortNumber = DefaultSendPort;
            com.ListenPortNumber = DefaultListenPort;
            com.BufferSize = DefaultBufferSize;
        }

        private void OnDestroy()
        {
            Util.Log("server:OnDestroy");
            com.Close();
        }

        public void AddBeaconList(string ip)
        {
            com.AddBeaconList(ip);
        }

        public void RemoveBeaconList(string ip)
        {
            com.RemoveBeaconList(ip);
        }


        public void Open()
        {
            com.Open();
        }

        public void Close()
        {
            com.Close();
        }

        public void AddChannel(IDataChannel channel)
        {
            com.AddChannel(channel);
        }

        public void RemoveChannel(IDataChannel channel)
        {
            com.RemoveChannel(channel);
        }

        public void BeaconStart()
        {
            com.BeaconStart();
        }

        public void BeaconStop()
        {
            com.BeaconStop();
        }

        public bool Disconnect(ComNode node)
        {
            return com.Disconnect(node);
        }

        public bool Broadcast<T>(ComGroup group, short channelId, T data)
        {
            return com.Broadcast(group, channelId, data);
        }

        public bool SendData<T>(ComNode node, short channelId, T data)
        {
            return com.SendData(node, channelId, data);
        }

    }

}
