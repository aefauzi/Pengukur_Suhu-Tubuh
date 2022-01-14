Public Class Form1
    Dim data_masuk As String

    Private Sub btn_con_Click(sender As Object, e As EventArgs) Handles btn_con.Click
        SerialPort1.BaudRate = Val(tb_baudrate.Text)
        SerialPort1.PortName = tb_com.Text

        Try
            SerialPort1.Open()

            If SerialPort1.IsOpen() Then
                pb_connection.BackColor = Color.Green
                tim_serial.Enabled = True


            End If
        Catch ex As Exception
            MessageBox.Show("GAGAL, TELITI LAGI...!!!", "Note")

        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        data_masuk = SerialPort1.ReadLine()
    End Sub

    Private Sub tim_serial_Tick(sender As Object, e As EventArgs) Handles tim_serial.Tick
        lbl_area.Text = data_masuk
        Try
            Dim data As String() = data_masuk.Split(";") '123;456;234;233;123
            lbl_area.Text = data(0)
            lbl_object.Text = data(1)

            sg_area.Value = Val(data(0))
            sg_object.Value = Val(data(1))

            tem_area.Value = Val(data(0))
            tem_object.Value = Val(data(1))

            graf_suhu.Series("Temp_Area").Points.AddY(data(0))
            graf_suhu.Series("Temp_Object").Points.AddY(data(1))
            If graf_suhu.Series(0).Points.Count = 30 Then
                graf_suhu.Series(0).Points.RemoveAt(0)

            End If
            graf_suhu.ChartAreas(0).AxisY.Maximum = 50

            If Val(data(1)) < 37 Then
                lbl_aman.BackColor = Color.Lime
                lbl_over.BackColor = Color.LightSteelBlue
            End If
            If Val(data(1)) > 37 Then
                lbl_over.BackColor = Color.Red
                lbl_aman.BackColor = Color.LightSteelBlue
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles graf_suhu.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tim_serial.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tim_serial.Start()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.load()
    End Sub
End Class
