Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports System
Imports System.Data
Imports System.IO
Imports System.Data.OleDb

Public Class Reports
    Dim db As New DBHelper(My.Settings.DBconn)
    Dim dr As SqlClient.SqlDataReader
    Dim parameters As New Dictionary(Of String, Object)
    Dim stringBuilder As String

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        parameters.Add("ProductCode", txtProductCode.Text)
        parameters.Add("ProductName", txtProductName.Text)
        parameters.Add("Stock", txtQuantity.Text)
        parameters.Add("Price", txtPrice.Text)
        stringBuilder = "if exists(select 1 from products where PRODUCTCODE = @ProductCode)" + vbCrLf
        stringBuilder = stringBuilder + "update Products set PRODUCTNAME=UPPER(@ProductName), STOCK=@Stock, PRICE=@Price where PRODUCTCODE=@ProductCode" + vbCrLf
        stringBuilder = stringBuilder + "else insert into Products (PRODUCTCODE, PRODUCTNAME, STOCK, PRICE) values (UPPER(@ProductCode), @ProductName, @Stock, @Price)" + vbCrLf
        db.ExecuteNonQuery(stringBuilder, parameters)
        parameters.Clear()
        MsgBox("Transaction successful!", vbExclamation + vbOKOnly, "")
    End Sub
End Class