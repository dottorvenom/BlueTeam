<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(771, 59)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Credentials File (with IPs)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(686, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(671, 22)
        Me.TextBox1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.RichTextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 341)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(767, 448)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logs"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 412)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Label5"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(641, 409)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(99, 33)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "Clear"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(15, 21)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(738, 377)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 199)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(771, 117)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Salt Windows"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(14, 74)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(222, 20)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Change Remote User Password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Client SALT"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(685, 21)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 37)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Select"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(105, 28)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(574, 22)
        Me.TextBox2.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Button4)
        Me.GroupBox4.Controls.Add(Me.TextBox3)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 73)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(771, 120)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Salt Linux"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(685, 59)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(72, 33)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Select"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(105, 64)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(574, 22)
        Me.TextBox4.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Script"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Client SALT"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(686, 14)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(71, 36)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Select"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(105, 21)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(575, 22)
        Me.TextBox3.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(796, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(471, 675)
        Me.DataGridView1.TabIndex = 6
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(796, 704)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(226, 79)
        Me.Button11.TabIndex = 7
        Me.Button11.Text = "Go!!!"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1028, 706)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(227, 77)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Controlla SALT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1273, 803)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "MyInjectorAgent v.0.1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button11 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBox1 As CheckBox
End Class
