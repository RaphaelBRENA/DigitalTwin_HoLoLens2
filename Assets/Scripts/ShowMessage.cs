using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShowMessage : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    public Image image;
    public Sprite spriteOn;
    public Sprite spriteOff;

    public string serverIP = "192.168.210.25";
    public int serverPort = 5005;

    public void SendMessageUdp(string message)
    {
        UdpClient udpClient = new UdpClient();
        try
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            udpClient.Send(bytes, bytes.Length, serverIP, serverPort);
            Debug.Log("Message sent!");
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.ToString());
        }
        finally
        {
            udpClient.Close();
        }
    }

    public void Show(string message)
    {
        TextMeshPro.text = "Status: " + message;
        image.sprite = spriteOn;
        SendMessageUdp("Reactor ON");
    }
    public void Show2(string message)
    {
        TextMeshPro.text = "Status: " + message;
        image.sprite = spriteOff;
        SendMessageUdp("Reactor OFF");
    }
}
