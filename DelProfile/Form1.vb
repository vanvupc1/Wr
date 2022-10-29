Imports System.IO
Imports System.Net
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Net.NetworkInformation
Public Class DelProfiles
    'Dim Filepath As String = Application.StartupPath & "\DelProf2.exe"
    'Dim Filepath As String = Application.StartupPath & "\delprof.exe"
    Dim Filepath As String = Application.UserAppDataPath & "\delprof.exe"
    Dim desktopPath = My.Computer.FileSystem.SpecialDirectories.Desktop
    Private cmd As New MySqlCommand
    Public namecomputer As String
    Public counttime As Integer = 0
    'Dim deleteapp As String = desktopPath & "\delprof.exe"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not My.Computer.FileSystem.FileExists(Filepath) Then
            Using MsiFile As New FileStream(Filepath, FileMode.Create)
                MsiFile.Write(My.Resources.delprof, 0, My.Resources.delprof.Length)

            End Using
        End If
        CbSetTime.Text = "0"
        'UpdateWeekly()
        'Mac_PcCode()
        ' open the resources files

    End Sub
    Public Sub RunfileEXE(ByVal Path As String)
        Try
            Dim exe As New ProcessStartInfo
            exe.FileName = Path
            exe.Arguments = " /Q /I"
            'exe.Arguments = Path
            exe.UseShellExecute = False
            exe.Verb = "runas"
            exe.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(exe).WaitForExit()
        Catch ex As Exception
            Console.WriteLine(ex.Message)

        End Try

    End Sub
    Public Sub KillProcess()
        Dim procsToKill() As String = {"CAA"} ' Add more tho this list
        For Each p As Process In Process.GetProcesses
            If procsToKill.Contains(p.ProcessName) Then
                p.Kill()
            End If
        Next
    End Sub
    'Show time countdown
    <Obsolete>
    Private Sub TimerCountdown_Tick(sender As Object, e As EventArgs) Handles TimerCountdown.Tick
        Threading.Thread.Sleep(1000)
        counttime -= 1
        LbTimeCount.Text = counttime.ToString
        If counttime = 0 Then

            TimerCountdown.Stop()
            FunctionShutdownandReset()
            'FunctionDelete()
        End If
    End Sub


    Private Sub StartTime(ByVal int As Integer)
        TimerCountdown.Enabled = True
        TimerCountdown.Interval = int
        TimerCountdown.Start()

        counttime = TimerCountdown.Interval


    End Sub

    'Fuction deleteprofile and update data

    'Pause count down
    Private Sub BtPause_Click(sender As Object, e As EventArgs) Handles BtPause.Click
        TimerCountdown.Stop()
        'System.Diagnostics.Process.Start("Shutdown", "-a")
    End Sub

    'Function shutdown or reset
    Private Sub FunctionShutdownandReset()
        If CbShutdown.CheckState = CheckState.Checked And CbRestart.CheckState = CheckState.Unchecked Then

            System.Diagnostics.Process.Start("Shutdown", "-s -t 00")
        Else
            System.Diagnostics.Process.Start("Shutdown", "-r -t 00")

        End If
    End Sub
    <Obsolete>
    Private Sub FunctionDelete()

        If CbShutdown.CheckState = CheckState.Checked And CbRestart.CheckState = CheckState.Unchecked Then
            KillProcess()
            RunfileEXE(Filepath)
            UpdateWeekly()
            Mac_PcCode()
        ElseIf CbShutdown.CheckState = CheckState.Unchecked And CbRestart.CheckState = CheckState.Checked Then
            KillProcess()
            RunfileEXE(Filepath)
            UpdateWeekly()
            Mac_PcCode()
        End If
    End Sub

    'Add label
    Private Sub Addlabel()
        Dim lbl As New Label
        lbl.SetBounds(243, 111, 22, 16)
        lbl.Text = "/ s"
        lbl.Enabled = False
        lbl.Font = New Drawing.Font("Microsoft Sans Serif", 9.75, FontStyle.Italic)
        Me.Controls.Add(lbl)
    End Sub
    'Show time countdown
    Private Sub ShowInfor()
        If CbShutdown.CheckState = CheckState.Checked Then
            LbShow.Text = "This computer will shutdown after "
            Addlabel()
        Else
            LbShow.Text = "This computer will restart after "
            Addlabel()
        End If
    End Sub

    <Obsolete>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtDelete.Click

        If CbSetTime.SelectedItem.ToString <> "0" Then
            ShowInfor()
            StartTime(Integer.Parse(CbSetTime.SelectedItem.ToString))
            BtPause.Enabled = True
            FunctionDelete()

        End If

    End Sub
    'Get data IP and Computer
    <Obsolete>
    Private Function GetIPAddress()
        Dim arr(4) As String

        Dim ComputerName As String
        ComputerName = My.Computer.Name
        Dim strIPAddress As String = "No Find"
        Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())

        For Each address In ipHostInfo.AddressList()
            'arr = address.ToString.Split(".")

            'If arr(0) <> "169" Then
            If HaveInternetConnection() = True Then
                strIPAddress = address.ToString
            End If
            'End If
        Next

        Return strIPAddress
    End Function
    'Check 
    Private Function CheckExits(ByVal computer As String, ByVal ip As String)
        Dim result As Boolean = False
        Dim connStr As String = "server=10.18.100.33;user=vupham;database=vupham;port=3306;password=HmBh7kh1YOe3I3a9;"
        Dim conn = New MySqlConnection(connStr)
        conn.Open()
        Dim emtry As String = ""
        Dim sql = "SELECT workstation_ipcsdl.Workstation,IPAddress,isnull(setpccsdl.NameComputer) FROM vupham.workstation_ipcsdl cross join 
        vupham.setpccsdl on workstation_ipcsdl.Workstation = setpccsdl.Workstation where workstation_ipcsdl.IPAddress = '" & ip & "' ;"
        cmd = New MySqlCommand(sql, conn)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            namecomputer = reader.GetString(2).ToString
            If reader.GetString(2).ToString = computer Then
                result = True
            End If

        End While
        conn.Close()

        Return result
    End Function
    'Check exits log weekly
    Private Function CheckExitsLog(ByVal computer As String, ByVal ip As String)
        Dim result As Boolean = False
        Dim connStr As String = "server=10.18.100.33;user=vupham;database=vupham;port=3306;password=HmBh7kh1YOe3I3a9;"
        Dim conn = New MySqlConnection(connStr)
        conn.Open()
        Dim sql = "SELECT count(*) FROM vupham.LogIP_PC_Weekly where IP_Address = '" & ip & "' and NameComputer ='" & computer & "';"
        cmd = New MySqlCommand(sql, conn)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            If reader.GetString(0).ToString = 1 Then
                result = True
            End If

        End While
        conn.Close()

        Return result
    End Function

    <Obsolete>
    Private Sub GetInfor()
        Dim Command As MySqlCommand
        Dim Reader As MySqlDataReader
        Dim Ipaddress As String = GetIPAddress()
        Dim PCName As String = My.Computer.Name
        'Dim dateupdate As String = DateTime.Now.ToString("dd/MM/yyyy")
        'Dim time As String = DateTime.Now.ToString("h:mm:ss tt")
        Dim datetimeupdate As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim connStr As String = "server=10.18.100.33;user=vupham;database=vupham;port=3306;password=HmBh7kh1YOe3I3a9;"
        Dim conn = New MySqlConnection(connStr)

        conn.Open()
        If conn.State = ConnectionState.Open Then
            Dim Query As String
            Query = "insert into vupham.LogIP_PC_Weekly (IP_Address, NameComputer, DateTimeUpdate) VALUES ('" & GetIPAddress() & "','" & PCName & "','" & datetimeupdate & "')"
            Command = New MySqlCommand(Query, conn)
            Reader = Command.ExecuteReader
            'MsgBox("Change IP and Data Saved!")
            conn.Close()
        Else
            MsgBox("Can't connect to DATABASE")
        End If
        conn.Close()

    End Sub

    <Obsolete>
    Private Sub UpdateWeekly()
        Dim PC As String = My.Computer.Name
        Dim ipadd As String = GetIPAddress()
        If CheckExits(PC, ipadd) = False Then
            If CheckExitsLog(PC, ipadd) = False Then
                GetInfor()

            End If
        End If
    End Sub
    'Update Namecomputer and MAC Address
    Private Function CheckExitsMAC(ByVal mac As String, ByVal nampc As String)
        Dim result As Boolean = False
        Dim connStr As String = "server=10.18.100.33;user=vupham;database=vupham;port=3306;password=HmBh7kh1YOe3I3a9;"
        Dim conn = New MySqlConnection(connStr)
        conn.Open()
        Dim sql = "SELECT * FROM vupham.pccode_mac_address where Physical_Address = '" & mac & "';"
        cmd = New MySqlCommand(sql, conn)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            If reader.GetString(1) = nampc Then
                result = True
            End If


        End While
        conn.Close()

        Return result
    End Function
    Private Function getMacAddress()

        Dim nic As NetworkInterface = Nothing

        Dim mac_Address As String = "NoFind"

        For Each nic In NetworkInterface.GetAllNetworkInterfaces
            If nic.OperationalStatus = OperationalStatus.Up Then
                mac_Address = nic.GetPhysicalAddress().ToString
                Return mac_Address
                Exit For
            End If

        Next

        nic = Nothing

        Return mac_Address
    End Function
    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("8.8.8.8")
        Catch
            Return False
        End Try

    End Function

    Private Function FindidMAc(ByVal mac As String)
        Dim result As Integer = 0
        Dim connStr As String = "server=10.18.100.33;user=vupham;database=vupham;port=3306;password=HmBh7kh1YOe3I3a9;"
        Dim conn = New MySqlConnection(connStr)
        conn.Open()
        Dim sql = "SELECT * FROM vupham.pccode_mac_address where Physical_Address = '" & mac & "';"
        cmd = New MySqlCommand(sql, conn)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            result = reader.GetString(0)
        End While
        conn.Close()

        Return result
    End Function
    Private Sub UpdateMAC_NamePC(ByVal namepc As String, ByVal mac As String)
        Dim Command As MySqlCommand
        Dim Reader As MySqlDataReader
        Dim connStr As String = "server=10.18.100.33;user=vupham;database=vupham;port=3306;password=HmBh7kh1YOe3I3a9;"
        Dim conn = New MySqlConnection(connStr)

        conn.Open()
        If conn.State = ConnectionState.Open Then
            Dim Query As String
            Query = "UPDATE vupham.pccode_mac_address SET NameComputer = '" & namepc & "' WHERE (idpccode_macaddress = '" & FindidMAc(mac) & "');"
            Command = New MySqlCommand(Query, conn)
            Reader = Command.ExecuteReader
            conn.Close()
        Else
            MsgBox("Can't connect to DATABASE")
        End If
        conn.Close()
    End Sub
    Private Sub Mac_PcCode()
        If CheckExitsMAC(getMacAddress(), My.Computer.Name) = False And FindidMAc(getMacAddress()) = 0 Then
            InsertMAC_Pccode(getMacAddress(), My.Computer.Name)
        ElseIf CheckExitsMAC(getMacAddress(), My.Computer.Name) = False And FindidMAc(getMacAddress()) <> 0 Then
            UpdateMAC_NamePC(My.Computer.Name, getMacAddress())
            'MsgBox(FindidMAc(getMacAddress()))
        End If
    End Sub
    Private Sub InsertMAC_Pccode(ByVal mac As String, ByVal namecomputer As String)
        Dim Command As MySqlCommand
        Dim Reader As MySqlDataReader
        Dim datetimeupdate As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim connStr As String = "server=10.18.100.33;user=vupham;database=vupham;port=3306;password=HmBh7kh1YOe3I3a9;"
        Dim conn = New MySqlConnection(connStr)

        conn.Open()
        If conn.State = ConnectionState.Open Then
            Dim Query As String
            Query = "INSERT INTO vupham.pccode_mac_address (NameComputer, Physical_Address) VALUES ('" & namecomputer & "', '" & mac & "');"
            Command = New MySqlCommand(Query, conn)
            Reader = Command.ExecuteReader
            'MsgBox("Change IP and Data Saved!")
            conn.Close()
        Else
            MsgBox("Can't connect to DATABASE")
        End If
        conn.Close()

    End Sub

    Private Sub CbShutdown_CheckedChanged(sender As Object, e As EventArgs) Handles CbShutdown.CheckedChanged
        If CbShutdown.CheckState = CheckState.Checked Then
            CbRestart.CheckState = CheckState.Unchecked
        ElseIf CbShutdown.CheckState = CheckState.Unchecked Then
            CbRestart.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub CbRestart_CheckedChanged(sender As Object, e As EventArgs) Handles CbRestart.CheckedChanged
        If CbRestart.CheckState = CheckState.Checked Then
            CbShutdown.CheckState = CheckState.Unchecked
        ElseIf CbRestart.CheckState = CheckState.Unchecked Then
            CbShutdown.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub CbSetTime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSetTime.SelectedIndexChanged

    End Sub


End Class
