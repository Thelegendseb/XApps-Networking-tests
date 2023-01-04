Imports System.Net.Sockets
Imports XApps.Networking
Public Class Form1
    Dim S As XNetServer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        S = New XNetServer
        S.BindSocket(InputBox("IP to bind to: "), 8888)
        AddHandler S.ClientReceived, AddressOf OnClientReceived
        S.Start()
    End Sub
    Private Sub OnClientReceived(SocketFound As Socket)
        ' // Create XNetTransmitter instance from Socket

        MsgBox("Client received - Local Endpoint: " & SocketFound.LocalEndPoint.ToString)
        MsgBox("Client received - Remote Endpoint: " & SocketFound.RemoteEndPoint.ToString)
        Dim Transmitter As New XNetTransmitter(SocketFound)
        Transmitter.Start()
        AddHandler Transmitter.DataReceived, AddressOf OnConnectedSocketDataReceived

    End Sub
    Private Sub OnConnectedSocketDataReceived(data() As Byte)
        Dim str As String = System.Text.Encoding.UTF8.GetString(data).Trim()
        str = str.Replace(vbNullChar, "")
        Me.RichTextBox1.Invoke(Sub() Me.RichTextBox1.Text &= str & vbCrLf)
    End Sub
End Class

' // =====================================