<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbname = New System.Windows.Forms.TextBox
        Me.grades = New System.Windows.Forms.GroupBox
        Me.tbfinal = New System.Windows.Forms.TextBox
        Me.tbsemis = New System.Windows.Forms.TextBox
        Me.tbmidterm = New System.Windows.Forms.TextBox
        Me.tbprelim = New System.Windows.Forms.TextBox
        Me.lbfinal = New System.Windows.Forms.Label
        Me.lbsemis = New System.Windows.Forms.Label
        Me.lbmidterm = New System.Windows.Forms.Label
        Me.lbprelim = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbremarks = New System.Windows.Forms.Label
        Me.lbgenave = New System.Windows.Forms.Label
        Me.tbremarks = New System.Windows.Forms.TextBox
        Me.tbgenave = New System.Windows.Forms.TextBox
        Me.tbsemgrade = New System.Windows.Forms.TextBox
        Me.lbgrade = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.computeBtn = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.tblevel = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.reloadTable = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.grades.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbname)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(403, 60)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Student Name"
        '
        'tbname
        '
        Me.tbname.Location = New System.Drawing.Point(32, 21)
        Me.tbname.Name = "tbname"
        Me.tbname.Size = New System.Drawing.Size(349, 20)
        Me.tbname.TabIndex = 0
        Me.tbname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grades
        '
        Me.grades.Controls.Add(Me.tbfinal)
        Me.grades.Controls.Add(Me.tbsemis)
        Me.grades.Controls.Add(Me.tbmidterm)
        Me.grades.Controls.Add(Me.tbprelim)
        Me.grades.Controls.Add(Me.lbfinal)
        Me.grades.Controls.Add(Me.lbsemis)
        Me.grades.Controls.Add(Me.lbmidterm)
        Me.grades.Controls.Add(Me.lbprelim)
        Me.grades.ForeColor = System.Drawing.Color.White
        Me.grades.Location = New System.Drawing.Point(12, 154)
        Me.grades.Name = "grades"
        Me.grades.Size = New System.Drawing.Size(191, 165)
        Me.grades.TabIndex = 3
        Me.grades.TabStop = False
        Me.grades.Text = "Enter Grade Here"
        '
        'tbfinal
        '
        Me.tbfinal.Location = New System.Drawing.Point(68, 123)
        Me.tbfinal.Name = "tbfinal"
        Me.tbfinal.Size = New System.Drawing.Size(100, 20)
        Me.tbfinal.TabIndex = 7
        '
        'tbsemis
        '
        Me.tbsemis.Location = New System.Drawing.Point(68, 90)
        Me.tbsemis.Name = "tbsemis"
        Me.tbsemis.Size = New System.Drawing.Size(100, 20)
        Me.tbsemis.TabIndex = 6
        '
        'tbmidterm
        '
        Me.tbmidterm.Location = New System.Drawing.Point(68, 56)
        Me.tbmidterm.Name = "tbmidterm"
        Me.tbmidterm.Size = New System.Drawing.Size(100, 20)
        Me.tbmidterm.TabIndex = 5
        '
        'tbprelim
        '
        Me.tbprelim.Location = New System.Drawing.Point(68, 23)
        Me.tbprelim.Name = "tbprelim"
        Me.tbprelim.Size = New System.Drawing.Size(100, 20)
        Me.tbprelim.TabIndex = 4
        '
        'lbfinal
        '
        Me.lbfinal.AutoSize = True
        Me.lbfinal.Location = New System.Drawing.Point(23, 127)
        Me.lbfinal.Name = "lbfinal"
        Me.lbfinal.Size = New System.Drawing.Size(29, 13)
        Me.lbfinal.TabIndex = 3
        Me.lbfinal.Text = "Final"
        '
        'lbsemis
        '
        Me.lbsemis.AutoSize = True
        Me.lbsemis.Location = New System.Drawing.Point(22, 93)
        Me.lbsemis.Name = "lbsemis"
        Me.lbsemis.Size = New System.Drawing.Size(35, 13)
        Me.lbsemis.TabIndex = 2
        Me.lbsemis.Text = "Semis"
        '
        'lbmidterm
        '
        Me.lbmidterm.AutoSize = True
        Me.lbmidterm.Location = New System.Drawing.Point(23, 59)
        Me.lbmidterm.Name = "lbmidterm"
        Me.lbmidterm.Size = New System.Drawing.Size(44, 13)
        Me.lbmidterm.TabIndex = 1
        Me.lbmidterm.Text = "Midterm"
        '
        'lbprelim
        '
        Me.lbprelim.AutoSize = True
        Me.lbprelim.Location = New System.Drawing.Point(23, 26)
        Me.lbprelim.Name = "lbprelim"
        Me.lbprelim.Size = New System.Drawing.Size(35, 13)
        Me.lbprelim.TabIndex = 0
        Me.lbprelim.Text = "Prelim"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbremarks)
        Me.GroupBox3.Controls.Add(Me.lbgenave)
        Me.GroupBox3.Controls.Add(Me.tbremarks)
        Me.GroupBox3.Controls.Add(Me.tbgenave)
        Me.GroupBox3.Controls.Add(Me.tbsemgrade)
        Me.GroupBox3.Controls.Add(Me.lbgrade)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(215, 154)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 165)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Result"
        '
        'lbremarks
        '
        Me.lbremarks.AutoSize = True
        Me.lbremarks.Location = New System.Drawing.Point(14, 107)
        Me.lbremarks.Name = "lbremarks"
        Me.lbremarks.Size = New System.Drawing.Size(49, 13)
        Me.lbremarks.TabIndex = 9
        Me.lbremarks.Text = "Remarks"
        '
        'lbgenave
        '
        Me.lbgenave.AutoSize = True
        Me.lbgenave.Location = New System.Drawing.Point(14, 69)
        Me.lbgenave.Name = "lbgenave"
        Me.lbgenave.Size = New System.Drawing.Size(49, 13)
        Me.lbgenave.TabIndex = 8
        Me.lbgenave.Text = "Gen Ave"
        '
        'tbremarks
        '
        Me.tbremarks.Enabled = False
        Me.tbremarks.Location = New System.Drawing.Point(78, 105)
        Me.tbremarks.Name = "tbremarks"
        Me.tbremarks.Size = New System.Drawing.Size(100, 20)
        Me.tbremarks.TabIndex = 7
        '
        'tbgenave
        '
        Me.tbgenave.Enabled = False
        Me.tbgenave.Location = New System.Drawing.Point(78, 66)
        Me.tbgenave.Name = "tbgenave"
        Me.tbgenave.Size = New System.Drawing.Size(100, 20)
        Me.tbgenave.TabIndex = 6
        '
        'tbsemgrade
        '
        Me.tbsemgrade.Enabled = False
        Me.tbsemgrade.Location = New System.Drawing.Point(78, 26)
        Me.tbsemgrade.Name = "tbsemgrade"
        Me.tbsemgrade.Size = New System.Drawing.Size(100, 20)
        Me.tbsemgrade.TabIndex = 5
        '
        'lbgrade
        '
        Me.lbgrade.AutoSize = True
        Me.lbgrade.Location = New System.Drawing.Point(12, 30)
        Me.lbgrade.Name = "lbgrade"
        Me.lbgrade.Size = New System.Drawing.Size(60, 13)
        Me.lbgrade.TabIndex = 0
        Me.lbgrade.Text = "Sem Grade"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 335)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(190, 41)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'computeBtn
        '
        Me.computeBtn.Location = New System.Drawing.Point(215, 335)
        Me.computeBtn.Name = "computeBtn"
        Me.computeBtn.Size = New System.Drawing.Size(200, 41)
        Me.computeBtn.TabIndex = 6
        Me.computeBtn.Text = "Compute"
        Me.computeBtn.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(215, 382)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(200, 41)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Log Out"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(12, 382)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(191, 41)
        Me.SaveBtn.TabIndex = 9
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(421, 8)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(734, 368)
        Me.DataGridView1.TabIndex = 10
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.tblevel)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(13, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(402, 70)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Student Information"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(57, 26)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(130, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'tblevel
        '
        Me.tblevel.Location = New System.Drawing.Point(249, 26)
        Me.tblevel.Name = "tblevel"
        Me.tblevel.Size = New System.Drawing.Size(131, 20)
        Me.tblevel.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Year Level"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Subject"
        '
        'reloadTable
        '
        Me.reloadTable.Location = New System.Drawing.Point(699, 382)
        Me.reloadTable.Name = "reloadTable"
        Me.reloadTable.Size = New System.Drawing.Size(201, 40)
        Me.reloadTable.TabIndex = 12
        Me.reloadTable.Text = "Reload Table"
        Me.reloadTable.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SaddleBrown
        Me.ClientSize = New System.Drawing.Size(1166, 435)
        Me.Controls.Add(Me.reloadTable)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.computeBtn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grades)
        Me.Controls.Add(Me.GroupBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grades.ResumeLayout(False)
        Me.grades.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbname As System.Windows.Forms.TextBox
    Friend WithEvents grades As System.Windows.Forms.GroupBox
    Friend WithEvents lbfinal As System.Windows.Forms.Label
    Friend WithEvents lbsemis As System.Windows.Forms.Label
    Friend WithEvents lbmidterm As System.Windows.Forms.Label
    Friend WithEvents lbprelim As System.Windows.Forms.Label
    Friend WithEvents tbfinal As System.Windows.Forms.TextBox
    Friend WithEvents tbsemis As System.Windows.Forms.TextBox
    Friend WithEvents tbmidterm As System.Windows.Forms.TextBox
    Friend WithEvents tbprelim As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbremarks As System.Windows.Forms.Label
    Friend WithEvents lbgenave As System.Windows.Forms.Label
    Friend WithEvents tbremarks As System.Windows.Forms.TextBox
    Friend WithEvents tbgenave As System.Windows.Forms.TextBox
    Friend WithEvents tbsemgrade As System.Windows.Forms.TextBox
    Friend WithEvents lbgrade As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents computeBtn As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tblevel As System.Windows.Forms.TextBox
    Friend WithEvents reloadTable As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
