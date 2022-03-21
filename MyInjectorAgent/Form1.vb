Imports System
Imports System.IO

Imports Renci.SshNet


Public Class Form1

    Public df As New datafile
    Public timeout As Integer = 30 'sec
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FileSystemWatcher info
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False


        inizializza_dg()

        TextBox2.Text = "C:\Users\Dino\Desktop\ScambioVM\Salt-Minion-3004-Py3-AMD64-Setup.exe"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.ShowDialog()
        TextBox2.Text = OpenFileDialog1.FileName.ToString
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RichTextBox1.Clear()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog1.ShowDialog()
        TextBox3.Text = OpenFileDialog1.FileName.ToString
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        OpenFileDialog1.ShowDialog()
        TextBox4.Text = OpenFileDialog1.FileName.ToString
    End Sub



    Sub inizializza_dg()
        DataGridView1.Columns.Add("ip", "Client IP")
        DataGridView1.Columns.Add("salt", "Salt Master")
        DataGridView1.Columns.Add("stato", "State")
    End Sub

    Sub add_item_dg(i, sm, st)

        Dim ctr As Integer
        ctr = DataGridView1.Rows.Count - 1
        DataGridView1.Rows.Add()
        DataGridView1.Rows(ctr).Cells(0).Value = i
        DataGridView1.Rows(ctr).Cells(1).Value = sm
        DataGridView1.Rows(ctr).Cells(2).Value = st
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        MsgBox("Negli host dove SALT è già presente la prima installazione lo rimuove, quindi ripeterla")
        esecuzione()
    End Sub


    Public Sub esecuzione()

        RichTextBox1.Clear()
        DataGridView1.Rows.Clear()


        Dim stringa As String = ""
        If File.Exists(TextBox1.Text) Then
            Dim w_filei As New StreamReader(TextBox1.Text)

            'Dim ip As String = ""
            'Dim port As Int16 = 0
            'Dim username As String = ""
            'Dim password As String = ""

            df.ip = ""
            df.port = 0
            df.username = ""
            df.password_new = ""
            df.password_old = ""
            df.salt_master = ""

            Dim stringa_array() As String

            Dim ssh As SshClient
            Dim sshcommand As SshCommand
            Dim conninfo As ConnectionInfo
            Dim authmethod As AuthenticationMethod

            stringa = w_filei.ReadLine 'salta la prima linea header
            While Not w_filei.EndOfStream
                stringa = w_filei.ReadLine
                Try
                    stringa_array = stringa.Split(";")

                    df.ip = stringa_array(0)
                    df.port = Int(stringa_array(1))
                    df.username = stringa_array(2)
                    df.password_old = stringa_array(3)
                    df.password_new = stringa_array(4)
                    df.salt_master = stringa_array(5)

                    RichTextBox1.AppendText("Connection to " & df.ip & "...." & vbCrLf)

                    authmethod = New PasswordAuthenticationMethod(df.username, df.password_old)
                    conninfo = New ConnectionInfo(df.ip, df.port, df.username, authmethod)
                    ssh = New SshClient(conninfo)
                    ssh.ConnectionInfo.Timeout = TimeSpan.FromSeconds(timeout)  ' timeout client ssh
                    ssh.Connect()

                    If ssh.IsConnected Then
                        RichTextBox1.AppendText("Connected" & vbCrLf)

                        sshcommand = ssh.RunCommand("uname -a")
                        If sshcommand.ExitStatus = 0 Then
                            RichTextBox1.AppendText("Linux machine:" & sshcommand.Result & vbCrLf)
                            'linux machine
                            If File.Exists(TextBox3.Text) Then
                                caricamento(TextBox3.Text, "/tmp/salt.deb", conninfo, "L")
                            Else
                                RichTextBox1.AppendText("File SALT not found :(" & vbCrLf)
                            End If
                            '
                            ' esecuzione installazione remota e avvio script se impostato
                        Else

                            sshcommand = ssh.RunCommand("ver")
                            If sshcommand.ExitStatus = 0 Then
                                RichTextBox1.AppendText("Windows machine:" & sshcommand.Result & vbCrLf)
                                'windows machine
                                If File.Exists(TextBox2.Text) Then
                                    caricamento(TextBox2.Text, "c:\salt.exe", conninfo, "W")
                                Else
                                    RichTextBox1.AppendText("File SALT not found :(" & vbCrLf)
                                End If


                            Else
                                RichTextBox1.AppendText("Not supported OS" & sshcommand.Result & vbCrLf)
                            End If
                        End If
                        ssh.Disconnect()
                        RichTextBox1.AppendText("Disconnected" & vbCrLf)
                    Else
                        RichTextBox1.AppendText("Not connected" & vbCrLf)
                    End If

                Catch ex As Exception
                    RichTextBox1.AppendText("Error :(" & vbCrLf)
                End Try
            End While
            w_filei.Close()
            w_filei = Nothing

        Else
            RichTextBox1.AppendText("File credentials not found :(" & vbCrLf)

        End If
    End Sub

    Public Sub caricamento(ByVal filei As String, ByVal rpath As String, ByVal conn As ConnectionInfo, ByVal so As String)
        'Dim sftp As SftpClient
        'Sftp = New SftpClient(conn)
        'Sftp.Connect()
        Dim scp As ScpClient
        scp = New ScpClient(conn)
        scp.ConnectionInfo.Timeout = TimeSpan.FromSeconds(timeout)  ' timeout client scp
        scp.Connect()
        If scp.IsConnected Then
            RichTextBox1.AppendText("Start file transfer..." & vbCrLf)
            'If File.Exists(filei) Then
            'Dim filestream = New FileStream(filei, FileMode.Open)
            'Sftp.BeginUploadFile(filestream, rpath)
            Try
                Dim finfo As New FileInfo(filei)
                scp.Upload(finfo, rpath)

                RichTextBox1.AppendText("File transfered!!! :)" & vbCrLf)

                Select Case so
                    Case "L"   'da integrare? **********************************

                        'esecuzione installazione

                        'esecuzione eventuale script post


                        'add_item_dg(conn.Host, conn.Username, "OK")
                    Case "W"

                        'esecuzione installazione
                        If installa("W", rpath, conn) Then
                            add_item_dg(df.ip, df.salt_master, "OK")
                            If CheckBox1.Checked Then  'controlla se è stato specificato uno script post inst

                                If esegui_Script_windows(conn) Then
                                    RichTextBox1.AppendText("Script executed!!!" & vbCrLf)
                                Else
                                    RichTextBox1.AppendText("Error on script execution!!! :(" & vbCrLf)
                                End If

                            End If

                        Else
                            add_item_dg(df.ip, df.salt_master, "Failed")
                        End If

                        'esecuzione eventuale script post  cambio password genera in locale e cambia  (file output csv)


                End Select

                'Else
                'RichTextBox1.AppendText("File exe not found :(, error on file transfer" & vbCrLf)
                'End If
                'Sftp.Disconnect()
            Catch
                RichTextBox1.AppendText("Error on scp connection!!! :(" & vbCrLf)
            End Try
            scp.Disconnect()

        Else
            RichTextBox1.AppendText("Error on file transfer" & vbCrLf)
        End If
    End Sub


    Private Function installa(ByVal so As String, ByVal rp As String, ByVal conn As ConnectionInfo) As Boolean
        installa = False

        Dim s As SshClient
        Dim sc As SshCommand
        s = New SshClient(conn)
        s.ConnectionInfo.Timeout = TimeSpan.FromSeconds(timeout)  ' timeout client ssh
        s.Connect()
        If s.IsConnected Then
            RichTextBox1.AppendText("Start Salt installation..." & vbCrLf)





            'verificare se già presente ripetere la procedura 2 volte, 1 per la rimozione e 1 per l'installazione *****************
            '
            ' controlla pid / presenza file exe
            '
            '**********************************************************************************************************************





            sc = s.RunCommand(rp & " /S /start-service=1 /master=" & df.salt_master)
            If sc.ExitStatus = 0 Then
                RichTextBox1.AppendText("Salt installed! :)" & vbCrLf)
                installa = True
            Else
                RichTextBox1.AppendText("Error on salt installed! Fuck!" & vbCrLf)
            End If
            s.Disconnect()
        End If

    End Function

    Public Function esegui_Script_windows(ByVal conn As ConnectionInfo) As Boolean
        esegui_Script_windows = False

        Dim s As SshClient
        Dim ssc As SshCommand
        s = New SshClient(conn)
        s.ConnectionInfo.Timeout = TimeSpan.FromSeconds(timeout)  ' timeout client ssh

        Try
            s.Connect()
            If s.IsConnected Then

                Dim cmd As String = "Set-ADAccountPassword -Identity " & df.username & " -Reset -NewPassword (ConvertTo-SecureString -AsPlainText " & df.password_new & " -Force)"

                ssc = s.RunCommand("%SystemRoot%\system32\WindowsPowerShell\v1.0\powershell.exe -ExecutionPolicy Bypass """ & cmd & """")
                If ssc.ExitStatus = 0 Then
                    esegui_Script_windows = True
                Else
                    esegui_Script_windows = False
                End If

                esegui_Script_windows = True
                s.Disconnect()
            Else
                esegui_Script_windows = False
            End If

        Catch
            esegui_Script_windows = False
        End Try


    End Function

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        'in ssh ps -aux o tasklist con pid salt
    End Sub
End Class


'INSERIRE PROCEDURE SCHEDULATE PER LA NOTTE IN MODO DA RIATTIVARE SEMPRE SALT?????????? <--------------------------------------
