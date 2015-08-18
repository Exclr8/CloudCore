Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Visio

Public Class GraphUtil

    Public Sub DropContainer_Example()

        Dim vsoDocument As Document
        vsoDocument = Application.Documents.OpenEx(Application.GetBuiltInStencilFile(visBuiltInStencilContainers, visMSUS), visOpenHidden)
        Application.ActivePage.DropContainer(vsoDocument.Masters.ItemU("Container 1"), Application.ActiveWindow.Selection)
        vsoDocument.Close()

    End Sub

    Private Function visBuiltInStencilContainers() As Object
        Throw New NotImplementedException
    End Function

    Private Function visMSUS() As Object
        Throw New NotImplementedException
    End Function

    Private Function visOpenHidden() As Object
        Throw New NotImplementedException
    End Function

End Class
