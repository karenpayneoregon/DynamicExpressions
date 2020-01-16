﻿Imports NorthWindLibrary

Public Class Form1
    Public Sub SortTest()

        Using context = New NorthWindAzureContext()
            Dim sortCompanyNameAscending = context.Customers.ToList().Sort("CompanyName", SortDirection.Descending)
            Dim sortContactNameDescending = (From cust In context.Customers).ToList().Sort("ContactName", SortDirection.Descending)
            Console.WriteLine()
        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SortTest()

    End Sub
End Class
