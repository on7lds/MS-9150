'Niet vergeten : Add Project Reference to System.Management
Imports System.Management
Imports System.IO.Ports
Imports Microsoft.Win32
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Reflection.Emit
Imports System.Runtime.Serialization
Imports System.Reflection

Public Class Metex
    Dim regSleutel As String = "Software\LDS Software\MS-9150"

    Dim WithEvents serialPort As New SerialPort()
    Dim sendTimer As New Timer()
    Dim SerBaud, SerBits, SerStopbits, Ontv As String
    Dim gestart As Boolean = False

    Private insertWatcher As ManagementEventWatcher
    Private removeWatcher As ManagementEventWatcher

    Private Sub Metex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim v As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
        ToolStripStatusLabel3.Text = $"v{v.Major}.{v.Minor}"  '.{v.Build}.{v.Revision}"

        ComboBoxPorts.Items.AddRange(SerialPort.GetPortNames())

        sendTimer.Interval = 500
        AddHandler sendTimer.Tick, AddressOf SendSpace

        LoadSerialSettingsFromRegistry()

        ButtonConnect.Text = "Connect"

        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        Dim path As New Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, Puls.Width, Puls.Height)
        Puls.Region = New Region(path)

        StartUSBWatchers()
    End Sub

    Private Sub Metex_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If insertWatcher IsNot Nothing Then insertWatcher.Stop()
        If removeWatcher IsNot Nothing Then removeWatcher.Stop()
    End Sub

    Private Sub StartUSBWatchers()
        ' USB toegevoegd
        Dim insertQuery As New WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2")
        insertWatcher = New ManagementEventWatcher(insertQuery)
        AddHandler insertWatcher.EventArrived, AddressOf USBChanged
        insertWatcher.Start()

        ' USB verwijderd
        Dim removeQuery As New WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3")
        removeWatcher = New ManagementEventWatcher(removeQuery)
        AddHandler removeWatcher.EventArrived, AddressOf USBChanged
        removeWatcher.Start()
    End Sub

    Private Sub USBChanged(sender As Object, e As EventArrivedEventArgs)
        ' Verplaats naar UI thread om ComboBox bij te werken
        Me.Invoke(New MethodInvoker(AddressOf UpdateCOM))
    End Sub

    Private Sub UpdateCOM()
        ComboBoxPorts.Items.Clear()
        ComboBoxPorts.Items.AddRange(SerialPort.GetPortNames())

    End Sub



    Private Sub USBActie()
        ComboBoxPorts.Items.Clear()
        ComboBoxPorts.Items.AddRange(SerialPort.GetPortNames())
    End Sub


    Private Sub LoadSerialSettingsFromRegistry()
        Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(regSleutel, True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.CreateSubKey("Software\VBSerialApp")
            regKey.SetValue("PortName", "COM3")
            regKey.SetValue("BaudRate", 1200)  ' Standaard baudrate 1200
            regKey.SetValue("DataBits", 7)     ' Standaard data bits 7
            regKey.SetValue("StopBits", 2)     ' Standaard stop bits 2
            regKey.SetValue("Interval", 300)
        End If

        ComboBoxPorts.Text = regKey.GetValue("PortName", "COM3")
        SerBaud = regKey.GetValue("BaudRate", 1200)  ' 1200 baud
        SerBits = regKey.GetValue("DataBits", 7)  ' 7 bits
        SerStopbits = regKey.GetValue("StopBits", 2) ' 2 stopbits
        SpinEditInterval.Value = regKey.GetValue("Interval", 300)

    End Sub

    Private Sub SaveSerialSettingsToRegistry()
        Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(regSleutel)
        regKey.SetValue("PortName", ComboBoxPorts.Text)
        regKey.SetValue("BaudRate", SerBaud)
        regKey.SetValue("DataBits", SerBits)
        regKey.SetValue("StopBits", SerStopbits)
        regKey.SetValue("Interval", SpinEditInterval.Value)
    End Sub

    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        If ButtonConnect.Text = "Connect" Then
            Try
                With serialPort
                    .PortName = ComboBoxPorts.Text
                    .BaudRate = Integer.Parse(SerBaud)
                    .DataBits = Integer.Parse(SerBits)
                    .StopBits = CType(SerStopbits, IO.Ports.StopBits)
                    .Handshake = Handshake.None
                    .ReadTimeout = 1000
                    .WriteTimeout = 1000
                    .Open()

                    ' Essential to communicate with MS-9150
                    .DtrEnable = True
                    .RtsEnable = False
                End With

                SaveSerialSettingsToRegistry()

                sendTimer.Start()
                ButtonConnect.Text = "Disconnect"
                ButtonConnect.BackColor = Color.Green
                ToolStripStatusLabel1.Text = ComboBoxPorts.Text & ", " & SerBaud & " " & SerBits & "N" & SerStopbits
            Catch ex As Exception
                MessageBox.Show("Fout bij verbinden: " & ex.Message)
                If serialPort.IsOpen Then
                    serialPort.Close()
                    ToolStripStatusLabel1.Text = "Serial Port closed"
                End If
            End Try
        Else
            Try
                sendTimer.Stop()
                If serialPort.IsOpen Then
                    serialPort.Close()
                    ToolStripStatusLabel1.Text = "Serial Port closed"
                End If
                ButtonConnect.Text = "Connect"
                ButtonConnect.BackColor = SystemColors.Control
                Puls.BackColor = SystemColors.Control
                Ontvangen.Text = "Metex MS-9150"
                Ontvangen.ForeColor = Color.Black
            Catch ex As Exception
                MessageBox.Show("Fout bij afsluiten: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Metex_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        gestart = True
    End Sub

    Private Sub SendSpace(sender As Object, e As EventArgs)
        Try
            If serialPort.IsOpen Then
                serialPort.Write(" ")
                If (Puls.BackColor = Color.Green) Then
                    Puls.BackColor = Color.White
                Else
                    Puls.BackColor = Color.Green
                End If

                Invoke(Sub()
                           If (String.IsNullOrEmpty(Ontv)) Then
                               Ontvangen.Text = "No Data"
                               Ontvangen.ForeColor = Color.Red
                           Else
                               Ontvangen.Text = Ontv
                               Ontvangen.ForeColor = Color.Black
                           End If
                           Ontv = ""
                       End Sub)
            End If
        Catch ex As Exception
            sendTimer.Stop()
            Invoke(Sub()
                       MessageBox.Show("Fout bij verzenden: " & ex.Message)
                       ButtonConnect.Text = "Connect"
                       If serialPort.IsOpen Then
                           serialPort.Close()
                           ToolStripStatusLabel1.Text = "Serial Port closed"
                       End If
                       ButtonConnect.Text = "Connect"
                       ButtonConnect.BackColor = SystemColors.Control
                       Puls.BackColor = SystemColors.Control
                       Ontvangen.Text = "Metex MS-9150"
                       Ontvangen.ForeColor = Color.Black
                   End Sub)
        End Try
    End Sub

    Private Sub serialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Try
            Dim incoming As String = serialPort.ReadExisting()

            Invoke(Sub()
                       Ontv &= incoming
                   End Sub)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SpinEditInterval_ValueChanged(sender As Object, e As EventArgs) Handles SpinEditInterval.ValueChanged
        sendTimer.Interval = Convert.ToInt32(SpinEditInterval.Value)
        Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(regSleutel)
        If gestart Then regKey.SetValue("Interval", SpinEditInterval.Value)
    End Sub
End Class
