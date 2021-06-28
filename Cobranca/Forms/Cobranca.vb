Imports FirebirdSql.Data.FirebirdClient
Public Class Cobranca
    Dim conexaoFB As FbConnection
    Dim da As FbDataAdapter
    Dim ds As New DataSet
    Private Sub Cobranca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexaoFB = New FbConnection("Server=localhost;User=SYSDBA;Password=masterkey;Database=C:\SIGE.FDB")
        ' DABASE NÃO INCLUSO (BAIXAR NO MEGA)
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles cod_cliente.TextChanged
        pesquisar()
    End Sub
    Public Sub pesquisar()
        conexaoFB.Open()
        da = New FbDataAdapter("Select ID_PESSOA as CODIGO,RAZAO as NOME,FANTASIA as RAZAO from GE_PESSOA where ID_PESSOA LIKE '%" + cod_cliente.Text + "%' AND RAZAO LIKE '%" + nometxb.Text + "%'", conexaoFB)
        Try
            da.Fill(ds, "Cadastro")
            DTGcliente.DataSource = ds.Tables(0)
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            DTGcliente.DataSource = dt
        Catch ex As Exception
        End Try
        conexaoFB.Close()
    End Sub
    Private Sub Nometxb_TextChanged(sender As Object, e As EventArgs) Handles nometxb.TextChanged
        pesquisar()
    End Sub
End Class
