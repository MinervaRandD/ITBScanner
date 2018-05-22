'' Manages the multi-panel UI
'' Positions our panels, shows/hides them and calls PanelHelpers to do the higher logic for each panel.
Public Class UIMan

    '' All our supported panels
    '' Add more here to extend UI
    Enum PanelTypes
        Welcome
        Testing
        Submit
        Upload
        Finish

        Last
    End Enum

    '' The Panels and PanelHelpers
    Private MyPanels(PanelTypes.Last - 1) As Panel
    Private MyPanelHelpers(PanelTypes.Last - 1) As PanelHelpers.General

    '' The UI Form containing the panels
    Private MyForm As Form

    Sub New(ByVal TheForm As Form)
        MyForm = TheForm

        '' Make all the helpers
        MyPanelHelpers(PanelTypes.Welcome) = New PanelHelpers.Welcome(CType(TheForm, FormMain))
        MyPanelHelpers(PanelTypes.Testing) = New PanelHelpers.Testing(CType(TheForm, FormMain))
        MyPanelHelpers(PanelTypes.Submit) = New PanelHelpers.Submit(CType(TheForm, FormMain))
        MyPanelHelpers(PanelTypes.Upload) = New PanelHelpers.Upload(CType(TheForm, FormMain))
        MyPanelHelpers(PanelTypes.Finish) = New PanelHelpers.Finish(CType(TheForm, FormMain))
        '' ... Add more helpers here as needed ...

    End Sub

    '' Associates a Panel with a PanelType
    '' In effect initializes the Panel for use and stores it in the MyPanels array
    Public Sub SetPanel(ByVal ThePanelType As PanelTypes, ByVal ThePanelControl As Panel)
        '' Save it
        MyPanels(ThePanelType) = ThePanelControl

        '' Position it
        With ThePanelControl
            .Location = New Point(0, 0)
            .Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
        End With

    End Sub

    '' Switches visibility to Panel and calles the appropriate PanelHelper
    Public Sub SwitchToPanel(ByVal ThePanelType As PanelTypes)
        For I As Integer = 0 To PanelTypes.Last - 1
            If I <> ThePanelType Then
                MyPanels(I).Visible = False
            Else
                MyPanels(I).Visible = True
                '' Load the panel logic using out panel helpers
                MyPanelHelpers(I).Load()
            End If
        Next
    End Sub

End Class
