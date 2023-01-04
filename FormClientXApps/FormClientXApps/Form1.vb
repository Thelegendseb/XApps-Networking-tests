Imports XApps.Networking
Public Class Form1
    Dim C As XNetTransmitter
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        C = New XNetTransmitter
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' // Connect
        C.ConnectSocket(InputBox("IP to connect to: "), 8888)
        Button1.Text = "Connected"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' // Start
        C.Start()
        Button2.Text = "Started"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' // Send
        C.Send(System.Text.Encoding.UTF8.GetBytes(InputBox("Type your message to send:")))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' // Stop
        C.Stop()
    End Sub
End Class
