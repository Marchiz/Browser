Imports System.Runtime.InteropServices
#Disable Warning

Public Class Form1
    Public WithEvents cWeb As New WebBrowser
    Public WithEvents cTitle, cLink As New Label
    Public WithEvents cTab As New Panel
    Public WithEvents cext As New Button


    Public frm2 As Form2
    Public tb0, tb1, tb2 As String
    Public t = {tb0, tb1, tb2}

    Sub NewTab()
        'Constructor
        Dim tab As New Panel
        Dim ext As New Button
        Dim web As New WebBrowser
        Dim title As New Label
        web = CType(CheckWeb(Check), WebBrowser)

        'Current tab
        cWeb = CType(web, WebBrowser)
        cTab = CType(tab, Panel)
        cext = CType(ext, Button)
        cTitle = CType(title, Label)

        'Build tab form
        PanelTitlebar.Controls.Add(tab)
        MainPanel.Controls.Add(web)
        tab.Controls.Add(ext)
        tab.Controls.Add(title)

        'Location, size, dock
        tab.Size = New Size(100, 60)
        ext.Size = New Size(15, 15)
        ext.FlatStyle = FlatStyle.Flat
        title.Font = New Font("Comic Sans MS", 8, FontStyle.Regular)
        title.Size = New Size(80, 15)
        tab.Dock = DockStyle.Left
        web.Dock = DockStyle.Fill
        ext.Location = New Point(tab.Location.X + 80, tab.Location.Y + 10)
        title.Location = New Point(tab.Location.X + 5, tab.Location.Y + 10)

        'Assign images
        tab.BackgroundImage = My.Resources.tab
        tab.BackgroundImageLayout = BackgroundImageLayout.Stretch
        ext.BackgroundImage = My.Resources.x
        ext.BackgroundImageLayout = BackgroundImageLayout.Stretch

        web.BringToFront()
        tab.BringToFront()
        plusTab.BringToFront()
        hide()



        'Destructor
        AddHandler ext.Click, Sub()
                                  ext.Dispose()
                                  tab.Dispose()
                                  t(Check) = ""
                                  web.Navigate("")
                                  web.SendToBack()
                                  web.Navigate("")
                                  web.Visible = False
                                  NoTabs()

                              End Sub
        'Tab click
        AddHandler tab.Click, Sub()
                                  cext = ext
                                  cTab = tab
                                  cWeb = web
                                  cTitle = title
                                  Try
                                      link.Text = cWeb.Url.ToString
                                  Catch
                                      link.Text = ""
                                  End Try
                                  web.BringToFront()
                                  If web.Url IsNot Nothing Then
                                      hide()
                                      web.Visible = True
                                  Else
                                      hide()
                                  End If
                              End Sub
        'title(tab) click
        AddHandler title.Click, Sub()
                                    cExt = ext
                                    cTab = tab
                                    cWeb = web
                                    cTitle = title
                                    Try
                                        link.Text = cWeb.Url.ToString
                                    Catch
                                        link.Text = ""
                                    End Try
                                    web.BringToFront()
                                    If web.Url IsNot Nothing Then
                                        web.Visible = True
                                    Else
                                        hide()
                                    End If
                                End Sub


    End Sub
    'CurrentWeb navigate to address
    Sub Nav(a As String)
        t(Check) = a
        cWeb.Navigate(a)
        cWeb.Visible = True
    End Sub
    'Checks which tab is ready to use
    Function Check()
        For i = 0 To 2
            If t(i) = "" Then
                Return i
                Exit Function
            End If
        Next
    End Function
    'return address of web to use
    Function CheckWeb(i As Integer)
        Select Case i
            Case 0
                Return w0
            Case 1
                Return w1
            Case 2
                Return w2
        End Select
    End Function
    'Hide all webs
    Sub hide()
        w0.Visible = False
        w1.Visible = False
        w2.Visible = False
    End Sub
    'No tabs? Open a new one
    Sub NoTabs()
        For i = 0 To 2
            If t(i) IsNot "" Then
                Exit Sub
            End If
        Next
        plusTab.PerformClick()
    End Sub
    'url to title
    Function UrlToTitle(a As String)
        Dim domain As String() = {"www.", "https:", "m.", ".com", ".ro", ".net", "/", "http:"}
        For i = 0 To domain.GetLength(0) - 1
            a = Replace(a, domain(i), "")
        Next
        Return a
    End Function

    'Initialize
    Public Sub New()
        InitializeComponent()
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
        Me.Anchor = AnchorStyles.None
    End Sub

    'Open child form
    Public currentChildForm As Form
    Sub OpenChildForm(childForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        currentChildForm = childForm

        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        MainPanel.Controls.Add(childForm)
        MainPanel.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    '   Public currentChildWeb As WebBrowser
    '   Sub OpenChildWeb(childForm As WebBrowser)
    '      currentChildWeb = childForm
    '      childForm.Dock = DockStyle.Fill
    '     MainPanel.Controls.Add(childForm)
    '     MainPanel.Tag = childForm
    '     childForm.BringToFront()
    '     childForm.Show()
    '  End Sub

    'Drag form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTitlebar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    '-'

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Maximized Then
            FormBorderStyle = FormBorderStyle.None
        Else
            FormBorderStyle = FormBorderStyle.Sizable
        End If
    End Sub

    Private Sub bntMinimized_Click(sender As Object, e As EventArgs) Handles bntMinimized.Click


    End Sub
    Private Sub btnMaximized_Click(sender As Object, e As EventArgs) Handles btnMaximized.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        Else
            WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewTab()
        t(0) = ""
        t(1) = ""
        t(2) = ""

    End Sub

    'New tab
    Private Sub plustab_Click(sender As Object, e As EventArgs) Handles plusTab.Click
        hide()
        NewTab()
        MainPanel.BringToFront()
        link.Text = ""
    End Sub


    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        cWeb.Refresh()
    End Sub

    Private Sub BtnForward_Click(sender As Object, e As EventArgs) Handles BtnForward.Click
        cWeb.GoForward()
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        cWeb.GoBack()
    End Sub


    Private Sub BtnSideBar_Click(sender As Object, e As EventArgs) Handles BtnSideBar.Click
        If PanelSideBar.Visible = True Then
            PanelSideBar.Hide()
        Else
            PanelSideBar.Show()
        End If
    End Sub

    Private Sub cWeb_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles cWeb.DocumentCompleted
        cTitle.Text = UrlToTitle(cWeb.Url.ToString)
        link.Text = cWeb.Url.ToString
    End Sub

    'Button performs click
    Private Sub BntLinkedin_Click(sender As Object, e As EventArgs) Handles BntLinkedin.Click
        Nav("www.linkedin.com")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Dispose()
        OpenChildForm(Form2)
        Form2.Visible = False
        Form2.frm1 = Me
    End Sub

    Private Sub BtnFacebook_Click(sender As Object, e As EventArgs) Handles BtnFacebook.Click
        Nav("www.facebook.com")
    End Sub
    Private Sub BtnInstagram_Click(sender As Object, e As EventArgs) Handles BtnInstagram.Click
        Nav("www.instagram.com")
    End Sub

    Private Sub link_KeyDown(sender As Object, e As KeyEventArgs) Handles link.KeyDown
        If e.KeyCode = Keys.Enter Then
            Nav(link.Text)
        End If
    End Sub
End Class
