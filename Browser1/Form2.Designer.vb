<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Assistent = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'Assistent
        '
        Me.Assistent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Assistent.Location = New System.Drawing.Point(0, 0)
        Me.Assistent.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Assistent.Name = "Assistent"
        Me.Assistent.ScriptErrorsSuppressed = True
        Me.Assistent.Size = New System.Drawing.Size(426, 298)
        Me.Assistent.TabIndex = 9
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.Assistent)
        Me.Name = "Form2"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Assistent As WebBrowser
End Class
