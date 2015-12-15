using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Dreams.Dht.Bootstrap;
using Dreams.Kademlia;

namespace TestNode
{
    public partial class Form1 : Form
    {
        private Client client = new Client();
        public Form1()
        {
            InitializeComponent();

            client.Lookup += new Client.LookupHandler(client_Lookup);
        }

        delegate void LookupResultDelegate(string key, string val);
        void OnLookupResult(string key, string val)
        {
            textBoxFindVal.Text = val;
        }
        void client_Lookup(string key, string val)
        {
            this.Invoke(new LookupResultDelegate(OnLookupResult), new object[]{key,val});
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            client.Me.Name = textBoxId.Text;
            client.Me.EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Int32.Parse(textBoxPort.Text));

            PeerInfo peer1 = new PeerInfo();
            peer1.Id = PeerId.CalculateId("bootnode");
            peer1.EndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.34"), 4401);
            client.BootstrapPeers.Add(peer1);
            peer1.Id = PeerId.CalculateId("bootnode2");
            peer1.EndPoint = new IPEndPoint(IPAddress.Parse("10.95.73.36"), 4401);
            client.BootstrapPeers.Add(peer1);
            peer1.Id = PeerId.CalculateId("bootnode3");
            peer1.EndPoint = new IPEndPoint(IPAddress.Parse("10.95.24.224"), 4401);
            client.BootstrapPeers.Add(peer1);

            client.Start();

            MulticastBootstrap multicast = new MulticastBootstrap();
            //multicast.Start();
            //multicast.Send(Dreams.Kademlia.Message.CreatePingRequest(client.Me));

            textBoxNodeHexId.Text = client.Me.Id.ToString();
            textBoxPort.Text = client.Me.EndPoint.Port.ToString();
        }

        private void buttonDump_Click(object sender, EventArgs e)
        {
            textBoxDump.Text = client.Dump();
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            client.BeginStore(textBoxStoreKey.Text, textBoxStoreVal.Text);
            textBoxStoreKeyHex.Text = PeerId.CalculateId(textBoxStoreKey.Text).ToString();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            client.BeginLookup(textBoxFindKey.Text);
            textBoxFindKeyHex.Text = PeerId.CalculateId(textBoxFindKey.Text).ToString();
        }

    }
}