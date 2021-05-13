Imports System.Speech.Recognition
Imports System.Threading
Imports System.Globalization
Public Class Form2
    'control form1 from form2
    Public frm1 As Form1
    ' recogniser & grammar
    Public recog As New SpeechRecognizer
    Dim gram As Grammar
    'events
    Public Event SpeechRecognized As _
     EventHandler(Of SpeechRecognizedEventArgs)
    Public Event SpeechRecognitionRejected As _
     EventHandler(Of SpeechRecognitionRejectedEventArgs)

    'word list'
    ReadOnly wordlist As String() = New String() {"go forward", "go back", "how do you know", "where am I", "new file", "close", "what are you", "who created you", "who is president of america", "who created windows", "show"}

    Public Sub Recevent(ByVal sender As System.Object, ByVal e As RecognitionEventArgs)
        'Also you can use sapi as voice with command: sapi.speak("hello")
        Dim sapi
        sapi = CreateObject("sapi.spvoice")
        Select Case e.Result.Text
            Case "new file"
                frm1.plusTab.PerformClick()
                My.Computer.Audio.Play(My.Resources.newtab, AudioPlayMode.WaitToComplete)
            Case "go forward"
                frm1.cWeb.GoForward()
            Case "go back"
                frm1.cWeb.GoBack()
            Case "how do you know"
                Me.Visible = True
                Me.BringToFront()
                My.Computer.Audio.Play(My.Resources.conn, AudioPlayMode.WaitToComplete)
            Case "where am I"
                Assistent.Navigate("https://whatismyipaddress.com/")
                My.Computer.Audio.Play(My.Resources.whereami, AudioPlayMode.WaitToComplete)
            Case "what are you"
                My.Computer.Audio.Play(My.Resources.iam, AudioPlayMode.WaitToComplete)
            Case "who created you"
                My.Computer.Audio.Play(My.Resources.designer, AudioPlayMode.WaitToComplete)
            Case "can you change your voice"
                sapi.speak("Yes, I can")
            Case "close"
                Me.Visible = False
            Case "who is president of america"
                Assistent.Navigate("https://www.google.com/search?q=who+is+president+of+america")
                My.Computer.Audio.Play(My.Resources.JB, AudioPlayMode.WaitToComplete)
            Case "who created windows"
                Assistent.Navigate("https://www.google.com/search?q=who+created+windows")
                My.Computer.Audio.Play(My.Resources.BG, AudioPlayMode.WaitToComplete)
            Case "show"
                Me.Visible = True
                Me.BringToFront()
        End Select
    End Sub
    ' word reognised fail
    Public Sub Recfailevent(ByVal sender As System.Object, ByVal e As RecognitionEventArgs)
    End Sub

    Public Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' need these to get British English rather than default US
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-GB")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-GB")
        ' convert the word list into a grammar
        Dim words As New Choices(wordlist)
        gram = New Grammar(New GrammarBuilder(words))
        recog.LoadGrammar(gram)
        ' add handlers for the recognition events
        AddHandler recog.SpeechRecognized, AddressOf Me.Recevent
        AddHandler recog.SpeechRecognitionRejected, AddressOf Me.Recfailevent
        ' enable the recogniser
        recog.Enabled = True
        'recog.Dispose()
    End Sub
End Class