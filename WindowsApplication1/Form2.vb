Imports MySql.Data.MySqlClient

Public Class Form2

    'Dim Table_Name As String = "botol" 'your table name
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=data_siswa")

    Private Sub btn_in_Click(sender As Object, e As EventArgs) Handles btn_in.Click

        Dim command As New MySqlCommand("INSERT INTO `tb_siswa`(`no`, `siswa`, `nis`, `kelas`, `suhu`, `keterangan`) VALUES (@id,@name,@nis,@kelas,@suhu,@ket)", connection)

        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@nama", MySqlDbType.VarChar).Value = TextBox2.Text
        command.Parameters.Add("@nis", MySqlDbType.VarChar).Value = TextBox3.Text
        command.Parameters.Add("@kelas", MySqlDbType.VarChar).Value = TextBox4.Text
        command.Parameters.Add("@suhu", MySqlDbType.VarChar).Value = TextBox5.Text
        command.Parameters.Add("@ket", MySqlDbType.VarChar).Value = TextBox6.Text

        connection.Open()

        If command.ExecuteNonQuerry() = 1 Then

            MessageBox.Show("Data Inserted")

        Else

            MessageBox.Show("ERROR")

        Else If

            connection.Close()

    End Sub
End Class