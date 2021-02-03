'------------------------------------------------------------
'-                File Name : Form1.frm                     - 
'-                Part of Project: Assign11                  -
'------------------------------------------------------------
'-                Written By: Alex Buckstiegel              -
'-                Written On: 4-20-20         -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the server side of the application 
'- I also realized about half way through the program that it 
'- would have been easier to put them in the same program
'- because the code is at least 90% copy and pasted from the
'- server side with slight modifications.
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program plays a game of mancala, but through the internet!    -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- Client - TcpClient for the client
'- aConn - a connection
'- NetStream - Stream of network info
'- NetWriter - Writes the NetStream
'- NetReader - Reads the NetStream
'- GetDataThread - Thread that gets the data
'- currentPlayer - Boolean variables determining the player
'- btnLast - Contains a copy of the lsat button clicked
'- changedPlayer - Boolean if the player hanged
'------------------------------------------------------------
Imports System.Threading
Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel
Imports System.Text

Public Class Form1
    Dim Client As TcpClient
    Dim NetStream As NetworkStream
    Dim NetWriter As BinaryWriter
    Dim NetReader As BinaryReader
    Dim GetDataThread As Thread
    Dim btnLast As Button
    Dim ChangedPlayer = True
    Dim currentPlayer As Boolean
    Const P1 = True
    Const P2 = False
    '------------------------------------------------------------
    '-                Subprogram Name: Form1_Load            -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Form load, sets the current Player to Player 1, and then
    '- sets CheckForIllegalCrossThreadCalls to false
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentPlayer = P1
        CheckForIllegalCrossThreadCalls = False
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: btnStartClient_Click     -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '- Runs the startup process of the listening process and 
    '- calls boardsetup
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnStartClient_Click(sender As Object, e As EventArgs) Handles btnStartClient.Click


        Try
            Client = New TcpClient
            Client.Connect(txtServerAddress.Text, CInt(txtServerPort.Text))

            NetStream = Client.GetStream()

            NetWriter = New BinaryWriter(NetStream)
            NetReader = New BinaryReader(NetStream)

            txtLog.Text &= "Network stream and reader/writer objects created" & vbCrLf
            btnStartClient.Enabled = False
            btnStopClient.Enabled = True

            txtLog.Text &= "Preparing thread to watch for data" & vbCrLf
            GetDataThread = New Thread(AddressOf GetDataFromServer)
            GetDataThread.Start()

        Catch IOEx As IOException
            txtLog.Text &= "Error Setting up Client -- Closing" & vbCrLf

        Catch SoecketEx As SocketException
            txtLog.Text &= "Cannot find server -- try again later" & vbCrLf

        Catch ex As Exception

        End Try
        BoardSetup()
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: GetDataFromServer        -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '- Gets the data from the server, runs a constant loop checking
    '- for new data, and parsing for new data
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- TheData - String of the Data
    '------------------------------------------------------------
    Sub GetDataFromServer()
        Dim TheData As String = ""
        txtLog.Text &= "Data watching thread active" & vbCrLf


        Try
            Do
                CheckForWin()
                Dim temp = TheData
                TheData = NetReader.ReadString
                If TheData <> temp Then
                    txtLog.Text &= TheData
                    ParseTheData(TheData)





                End If
            Loop While TheData <> "~~END~~"
            DisconnectClient()
        Catch IOEx As IOException
            txtLog.Text &= "Closing client connection..."
            DisconnectClient()
        Catch ex As Exception

        End Try
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: ParseTheData             -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Parses the data sent, and updates the board appropriately
    '- also swaps the player if necessary
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- TheData - String of the the data
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- inputtedData()  - Array of the split of TheData
    '------------------------------------------------------------
    Sub ParseTheData(TheData As String)
        Dim inputtedData() = TheData.Split("-")
        For int As Integer = 0 To 11
            For Each button In pnlGameBoard.Controls
                If button.tag = int Then
                    button.text = inputtedData(int + 1)
                End If
            Next
        Next
        If inputtedData(13) = "T" Then
            ChangePlayer()
            ChangeEnabled()
        End If
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: btnStopServer_Click            -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- callss the DisconnectClient(), which disconnects the client
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------


    Private Sub btnStopClient_Click(sender As Object, e As EventArgs) Handles btnStopClient.Click
        DisconnectClient()
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: DisconnectClient            -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Shamelessly stolen from class example, but why reinvent 
    '- the wheel?
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub DisconnectClient()
        txtLog.Text &= "Attempting to disconnect from server" & vbCrLf
        btnStartClient.Enabled = True
        btnStopClient.Enabled = False

        Try
            NetWriter.Write("~~END~~")
        Catch ex As Exception

        End Try

        Try
            NetWriter.Close()
            NetReader.Close()
            NetStream.Close()
            Client.Close()
            NetWriter = Nothing
            NetReader = Nothing
            Client = Nothing
            Try
                GetDataThread.Abort()
            Catch ex As Exception

            End Try

        Catch ex As Exception

        Finally
            txtLog.Text &= "Disconnected... Client closed" & vbCrLf
        End Try
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: BoardSetup()            -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Sets the board to the default values
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub BoardSetup()
        btnBottom1.Text = "5"
        btnBottom2.Text = "5"
        btnBottom3.Text = "5"
        btnBottom4.Text = "5"
        btnBottom5.Text = "5"

        btnTop1.Text = "5"
        btnTop2.Text = "5"
        btnTop3.Text = "5"
        btnTop4.Text = "5"
        btnTop5.Text = "5"

        btnLeftBig.Text = "0"
        btnRightBig.Text = "0"

        If btnTop1.Enabled = False Then
            btnBottom1.Enabled = True
            btnBottom2.Enabled = True
            btnBottom3.Enabled = True
            btnBottom4.Enabled = True
            btnBottom5.Enabled = True
        End If
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: btnBottomClick            -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Runs when any of the bottom board buttons are pushed. Distributes
    '- the points to the other buttons, determines if the player
    '- can go again, and checks for a win. 
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- butttonValue - senders value
    '- buttonPosition - senders position
    '- total - buttonPosition + buttonValue used for determing 
    '- extra points
    '- extra - total-11 for extra points that need to be looped around
    '------------------------------------------------------------
    Private Sub btnBottomClick(sender As Object, e As EventArgs) Handles btnBottom1.Click, btnBottom2.Click, btnBottom3.Click, btnBottom4.Click, btnBottom5.Click
        Dim buttonValue As Integer = CInt(sender.text)
        Dim buttonPostition As Integer = CInt(sender.tag)
        If buttonPostition + buttonValue < 12 Then
            For position As Integer = buttonPostition To buttonValue + buttonPostition
                For Each button In pnlGameBoard.Controls
                    If button.tag = position Then
                        button.text = CStr(CInt(button.text) + 1)
                        btnLast = button
                    End If
                Next
            Next
        Else
            Dim total = buttonPostition + buttonValue
            Dim extra = total - 11
            For position As Integer = buttonPostition To 11
                For Each button In pnlGameBoard.Controls
                    If button.tag = position Then
                        button.text = CStr(CInt(button.text) + 1)
                        btnLast = button
                    End If
                Next
            Next
            For position As Integer = 0 To extra - 1
                For Each button In pnlGameBoard.Controls
                    If button.tag = position Then
                        button.text = CStr(CInt(button.text) + 1)
                        btnLast = button
                    End If
                Next
            Next
        End If
        If btnLast.Name = btnLeftBig.Name Or btnLast.Name = btnRightBig.Name Then
            lblWinner.Text = "Go again!"
            ChangedPlayer = False
        Else
            ChangePlayer()
            ChangeEnabled()
            ChangedPlayer = True
        End If
        CheckForWin()
        sender.text = "0"
        GeneratePacket()
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: GeneratePacket
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '- Generates the string packet to send to the other player
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- StringToSend - StringBuuilder of eventual final string   -
    '- strFinal - actual final string that is send to NetWriter
    '------------------------------------------------------------
    Sub GeneratePacket()
        Dim StringToSend As New StringBuilder
        'String Formatting:
        'P - The first letter will be P when there is a message sent
        StringToSend.Append("P")
        '1 or 2 - The next letter will be which player made the change. Since this is the client's code, and the Server is player 1, it will be hardcoded to be 2
        StringToSend.Append("2")
        'Next will go through all of the controls in the game board in order
        Dim counter = 0
        For position As Integer = 0 To 11
            For Each button In pnlGameBoard.Controls
                If button.tag = position Then
                    StringToSend.Append("-")
                    StringToSend.Append(button.text)
                    counter += 1

                End If
            Next
        Next
        StringToSend.Append("-")
        If changedPlayer Then
            StringToSend.Append("T")
        Else
            StringToSend.Append("F")
        End If
        StringToSend.Append("-")
        StringToSend.AppendLine("")
        Dim strFinal = StringToSend.ToString
        txtLog.Text &= strFinal
        NetWriter.Write(strFinal)
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: ChangePlayer            -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Changes the current player
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub ChangePlayer()
        If currentPlayer = P1 Then
            currentPlayer = P2
        Else
            currentPlayer = P1
        End If
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: ChangeEnabled
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Toggles whether or not the buttons can be pressed
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub ChangeEnabled()
        If currentPlayer = P2 Then
            btnBottom1.Enabled = True
            btnBottom2.Enabled = True
            btnBottom3.Enabled = True
            btnBottom4.Enabled = True
            btnBottom5.Enabled = True
        Else
            btnBottom1.Enabled = False
            btnBottom2.Enabled = False
            btnBottom3.Enabled = False
            btnBottom4.Enabled = False
            btnBottom5.Enabled = False
        End If
    End Sub
    '------------------------------------------------------------
    '-                Subprogram Name: CheckForWin              -
    '------------------------------------------------------------
    '-                Written By: Alex Buckstiegel              -
    '-                Written On: 4-20-20
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '- Checks for the win conditions, but for some reason it doesn't
    '- work all that well and I cannot for the life of me figure out
    '- why
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub CheckForWin()
        If btnBottom1.Text = "0" And btnBottom2.Text = "0" And btnBottom3.Text = "0" And btnBottom4.Text = "0" And btnBottom5.Text = "0" Then
            For Each button In pnlGameBoard.Controls
                button.enabled = False
                lblWinner.Text = "Player 2 Wins!"
            Next
        End If
        If btnTop1.Text = "0" And btnTop2.Text = "0" And btnTop3.Text = "0" And btnTop4.Text = "0" And btnTop5.Text = "0" Then
            For Each button In pnlGameBoard.Controls
                button.enabled = False
                lblWinner.Text = "Player 1 Wins!"
            Next
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        DisconnectClient()
    End Sub
End Class
