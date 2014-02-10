Imports System.Drawing
Imports System.Threading
Imports System.Threading.Tasks

Public Class Form1

    Protected WithEvents m As Map

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    m = New Map(pb.Width - 1, pb.Height - 1, 10, 15, 10)



    '    'Draw()
    'End Sub


    'Private Sub Draw()
    '    Dim elapsed As Long = (gametime.ElapsedMilliseconds - lastaction) / simulationtime

    '    Dim pbg As Graphics = pb.CreateGraphics

    '    Dim buffer As New Bitmap(pb.Width, pb.Height)
    '    Dim g As Graphics = Graphics.FromImage(buffer)

    '    g.Clear(Color.White)
    '    Dim p As New Pen(Brushes.Black)
    '    For Each b As Building In m.Buildings
    '        g.DrawRectangle(p, b.PositionRect)
    '    Next

    '    g.DrawRectangle(New Pen(Brushes.Cyan), m.AreaRect)

    '    p = New Pen(Brushes.Blue)
    '    Dim z As New Pen(Brushes.Red)
    '    For Each c As Citizen In m.Citizens
    '        Try
    '            If gametime.IsRunning Then c.SetPositionFromTime(c.CurrentActionTime - elapsed)
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        If c.Alive Then
    '            If c.isZombie Then
    '                g.DrawEllipse(z, CInt(c.Location.X - 1), CInt(c.Location.Y - 1), 2, 2)
    '            Else
    '                g.DrawEllipse(p, CInt(c.Location.X - 1), CInt(c.Location.Y - 1), 2, 2)
    '            End If
    '        Else
    '            g.DrawEllipse(New Pen(Brushes.Black), CInt(c.Location.X - 1), CInt(c.Location.Y - 1), 2, 2)
    '        End If

    '        If HighlightedCitizen IsNot Nothing AndAlso HighlightedCitizen.Equals(c) Then
    '            'g.DrawRectangle(New Pen(Brushes.ForestGreen), CInt(c.Location.X - (m.VisualRange / 2)), CInt(c.Location.Y - (m.VisualRange / 2)), m.VisualRange, m.VisualRange)
    '            Dim pts(2) As PointF
    '            pts(0) = New PointF(c.Location.X, c.Location.Y)
    '            Dim m As New GeomLib.Matrix2D
    '            m.SetToRotation(45)
    '            Dim v As New GeomLib.Vector2D(c.FacingVector)
    '            v.TransformBy(m)
    '            Dim uv As New GeomLib.Vector2D(1, 0)
    '            Dim a As Integer = uv.AngleTo(v)
    '            If v.Y < 0 Then a = 360 - a
    '            g.DrawPie(New Pen(Brushes.Brown), CInt(c.Location.X - Map.VisualRange), CInt(c.Location.Y - Map.VisualRange), Map.VisualRange * 2, Map.VisualRange * 2, a, 90)
    '            'g.DrawLine(New Pen(Brushes.ForestGreen), CInt(c.Location.X), CInt(c.Location.Y), CInt(c.FacingVector.X + c.Location.X), CInt(c.FacingVector.Y + c.Location.Y))

    '        End If

    '        If righthighlightedcitizen IsNot Nothing AndAlso righthighlightedcitizen.Equals(c) Then
    '            'g.DrawRectangle(New Pen(Brushes.ForestGreen), CInt(c.Location.X - (m.VisualRange / 2)), CInt(c.Location.Y - (m.VisualRange / 2)), m.VisualRange, m.VisualRange)
    '            Dim pts(2) As PointF
    '            pts(0) = New PointF(c.Location.X, c.Location.Y)
    '            Dim m As New GeomLib.Matrix2D
    '            m.SetToRotation(45)
    '            Dim v As New GeomLib.Vector2D(c.FacingVector)
    '            v.TransformBy(m)
    '            Dim uv As New GeomLib.Vector2D(1, 0)
    '            Dim a As Integer = uv.AngleTo(v)
    '            If v.Y < 0 Then a = 360 - a
    '            g.DrawPie(New Pen(Brushes.DarkOliveGreen), CInt(c.Location.X - Map.VisualRange), CInt(c.Location.Y - Map.VisualRange), Map.VisualRange * 2, Map.VisualRange * 2, a, 90)
    '            'g.DrawLine(New Pen(Brushes.ForestGreen), CInt(c.Location.X), CInt(c.Location.Y), CInt(c.FacingVector.X + c.Location.X), CInt(c.FacingVector.Y + c.Location.Y))

    '        End If
    '    Next

    '    If path IsNot Nothing Then
    '        For Each pfn As Algorithms.PathFinderNode In path
    '            g.DrawEllipse(New Pen(Brushes.DarkSlateBlue), pfn.X, pfn.Y, 1, 1)
    '        Next
    '    End If

    '    pbg.DrawImage(buffer, 0, 0)



    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    quit = False
    '    Dim t As Task = Task.Factory.StartNew(New Action(AddressOf process))
    'End Sub

    Private quit As Boolean = False
    Private WaitTime As Integer = 50
    Public SimulationSpeed As Integer = 25
    Dim gametime As New Stopwatch
    Dim lastaction As Long

    Private Sub process()
        gametime.Start()
        Do
            If gametime.ElapsedMilliseconds - lastaction >= (1 / SimulationSpeed) * 5000 Then
                m.ProcessActions()
                lastaction = gametime.ElapsedMilliseconds
            End If

            cam.DrawMap(m, pb.CreateGraphics)

            Thread.Sleep(WaitTime)
        Loop Until quit
        gametime.Stop()
        gametime.Reset()
    End Sub

    'Private Sub pb_Click(ByVal sender As System.Object, ByVal e As MouseEventArgs)
    '    Dim p As Point = pb.PointToClient(Control.MousePosition)

    '    If ZoomBtn.Checked Then
    '        If cam IsNot Nothing Then
    '            If e.Button = System.Windows.Forms.MouseButtons.Right Then
    '                If cam.Zoom < 100 Then
    '                    If cam.Zoom > 20 Then
    '                        cam.Zoom += 10
    '                    ElseIf cam.Zoom > 5 Then
    '                        cam.Zoom += 5
    '                    ElseIf cam.Zoom > 1 Then
    '                        cam.Zoom += 1
    '                    ElseIf cam.Zoom > 0.1 Then
    '                        cam.Zoom += 0.1
    '                    End If
    '                End If
    '            Else
    '                If cam.Zoom > 0 Then
    '                    If cam.Zoom > 20 Then
    '                        cam.Zoom -= 10
    '                    ElseIf cam.Zoom > 5 Then
    '                        cam.Zoom -= 5
    '                    ElseIf cam.Zoom > 1 Then
    '                        cam.Zoom -= 1
    '                    ElseIf cam.Zoom > 0.1 Then
    '                        cam.Zoom -= 0.1
    '                    End If
    '                End If

    '            End If
    '            cam.DrawMap(m, pb.CreateGraphics)
    '        End If
    '    Else


    '        Dim clickarea As New Rectangle(p.X - 5, p.Y - 5, 10, 10)

    '        Dim clickedon As New List(Of Citizen)

    '        For Each c As Citizen In m.Citizens
    '            c.Highlighted = False
    '            If clickarea.Contains(c.Location.ToPoint) Then
    '                clickedon.Add(c)
    '            End If
    '        Next

    '        If clickedon.Count = 1 Then
    '            pg.SelectedObject = clickedon(0)
    '            pg.Show()
    '            If e.Button = System.Windows.Forms.MouseButtons.Right Then
    '                righthighlightedcitizen = clickedon(0)
    '            Else
    '                HighlightedCitizen = clickedon(0)
    '                clickedon(0).Highlighted = True
    '            End If
    '            Draw()
    '        ElseIf clickedon.Count > 1 Then
    '            ms.Items.Clear()
    '            For Each c As Citizen In clickedon
    '                Dim tsb As New ToolStripButton("Citizen" & c.CitizenID)
    '                AddHandler tsb.Click, AddressOf popuphandler
    '                tsb.Tag = c
    '                ms.Items.Add(tsb)
    '            Next
    '            ms.Show(pb, p)
    '        End If
    '    End If
    'End Sub

    Dim HighlightedCitizen As Citizen = Nothing
    Dim righthighlightedcitizen As Citizen = Nothing

    Private Sub popuphandler(ByVal Sender As Object, ByVal E As EventArgs)
        Dim tsb As ToolStripButton = Sender
        pg.SelectedObject = tsb.Tag
        CType(tsb.Tag, Citizen).Highlighted = True
        pg.Show()
        m.HighlightedCitizen = tsb.Tag
    End Sub


    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    quit = True
    'End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    m.ProcessActions()
    '    pg.SelectedObject = HighlightedCitizen
    '    pg.Show()
    '    Draw()
    'End Sub


    Public Delegate Sub EventOccuredDelegate(ByRef sender As Citizen, ByVal Text As String)

    Dim EventHistory As New List(Of Citizen)

    Public Sub EventOccurred(ByRef sender As Citizen, ByVal text As String)
        EventHistory.Insert(0, sender)
        If EventHistory.Count > 100 Then
            EventHistory.RemoveAt(EventHistory.Count - 1)
            output.Items.RemoveAt(output.Items.Count - 1)
        End If
        output.Items.Insert(0, text)
    End Sub

    Private Sub m_EventOccurred_handler(ByRef Sender As Citizen, ByVal Text As String) Handles m.EventOccurred
        Me.Invoke(New EventOccuredDelegate(AddressOf EventOccurred), Sender, Text)
    End Sub

    Dim path As List(Of Algorithms.PathFinderNode)

    Dim cam As Camera

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cam = New Camera(pb.Width, pb.Height)
        cam.Zoom = 50
        cam.CameraLocation = New Point(pb.Width / 2, pb.Height / 2)
        cam.DrawMap(m, pb.CreateGraphics)

    End Sub

    Private Sub output_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If output.SelectedIndex > -1 Then
            HighlightedCitizen = EventHistory(output.SelectedIndex)
            pg.SelectedObject = HighlightedCitizen
            pg.Show()
            m.HighlightedCitizen = EventHistory(output.SelectedIndex)
            cam.DrawMap(m, pb.CreateGraphics)
        End If
    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If HighlightedCitizen.path IsNot Nothing Then

            Dim g As Graphics = pb.CreateGraphics
            For t As Integer = 0 To HighlightedCitizen.path.Count - 1
                Dim pfn As Algorithms.PathFinderNode = HighlightedCitizen.path(t)
                g.DrawEllipse(New Pen(Brushes.Red), pfn.X, pfn.Y, 1, 1)
            Next
        End If
    End Sub

    'Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cam IsNot Nothing Then
    '        cam.Zoom = NumericUpDown2.Value
    '        cam.DrawMap(m, pb.CreateGraphics)
    '    End If
    'End Sub

    'Private Sub VScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
    '    If cam IsNot Nothing Then
    '        If VScrollBar1.Value = 0 Then
    '            cam.Zoom = 0.5
    '            cam.DrawMap(m, pb.CreateGraphics)
    '        Else
    '            cam.Zoom = VScrollBar1.Value
    '            cam.DrawMap(m, pb.CreateGraphics)
    '        End If
    '    End If
    'End Sub



    Private Sub ZoomBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomBtn.Click
        MoveCamBtn.Checked = False
        If ZoomBtn.Checked Then
            ZoomBtn.Checked = False
        Else
            ZoomBtn.Checked = True
        End If
    End Sub

    Private Sub NewSimBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSimBtn.Click
        m = New Map(pb.Width - 1, pb.Height - 1)
        output.Items.Clear()
        Dim mp As New MapProperties(m)
        If mp.ShowDialog() = DialogResult.OK Then
            m.Init()
            cam = New Camera(pb.Width, pb.Height)
            cam.CameraLocation = New Point(pb.Width / 2, pb.Height / 2)
            cam.DrawMap(m, pb.CreateGraphics)
        End If
    End Sub


    Private Sub pb_Click1(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pb.Click
        Dim p As Point = pb.PointToClient(Control.MousePosition)

        If ZoomBtn.Checked Then
            If cam IsNot Nothing Then
                'MsgBox(cam.CameraLocation.ToString)
                cam.CameraLocation = cam.RevertPoint(p)
                If e.Button = System.Windows.Forms.MouseButtons.Right Then
                    cam.Zoom *= 2
                Else
                    cam.Zoom /= 2

                End If

                cam.DrawMap(m, pb.CreateGraphics)
            End If
        ElseIf MoveCamBtn.Checked Then
            cam.CameraLocation = cam.RevertPoint(p)
            'MsgBox(p.ToString & " " & cam.CameraLocation.ToString)
            cam.DrawMap(m, pb.CreateGraphics)

        Else

            Dim rp As Point = cam.RevertPoint(p)
            Dim clickarea As New Rectangle(rp.X - 5, rp.Y - 5, 10, 10)

            Dim clickedon As New List(Of Citizen)

            For Each c As Citizen In m.Citizens
                c.Highlighted = False
                If clickarea.Contains(c.Location.ToPoint) Then
                    clickedon.Add(c)
                End If
            Next

            If clickedon.Count = 1 Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    pg.SelectedObject = clickedon(0)
                    pg.Show()
                    m.HighlightedCitizen = clickedon(0)
                    HighlightedCitizen = clickedon(0)
                    clickedon(0).Highlighted = True
                    cam.DrawMap(m, pb.CreateGraphics)
                Else
                    HistoryMenu.Items(0).Tag = clickedon(0)
                    HistoryMenu.Show(pb, p)
                End If

            ElseIf clickedon.Count > 1 Then
                ms.Items.Clear()
                For Each c As Citizen In clickedon
                    Dim tsb As New ToolStripButton("Citizen" & c.CitizenID)
                    AddHandler tsb.Click, AddressOf popuphandler
                    tsb.Tag = c
                    ms.Items.Add(tsb)
                Next
                ms.Show(pb, p)
            Else
                For Each bldg As Building In m.Buildings
                    If bldg.PositionRect.Contains(rp) Then
                        pg.SelectedObject = bldg
                        pg.Show()
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub MoveCamBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveCamBtn.Click
        ZoomBtn.Checked = False
        MoveCamBtn.Checked = Not MoveCamBtn.Checked
    End Sub

    Private Sub ResetCamBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetCamBtn.Click
        cam.Zoom = 100
        cam.CameraLocation = New Point(pb.Width / 2, pb.Height / 2)
        cam.DrawMap(m, pb.CreateGraphics)
    End Sub

    Private Sub StepSimBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepSimBtn.Click
        m.ProcessActions()
        pg.SelectedObject = HighlightedCitizen
        pg.Show()
        cam.DrawMap(m, pb.CreateGraphics)
    End Sub

    Private Sub PlaySimBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaySimBtn.Click
        quit = False
        Dim t As Task = Task.Factory.StartNew(New Action(AddressOf process))
    End Sub

    Private Sub SimulationSpeedUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimulationSpeedUp.Click
        SimulationSpeed += 1
        SimLbl.Text = "Simulation Speed: " & SimulationSpeed
    End Sub

    Private Sub SimulationSpeedDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimulationSpeedDown.Click
        If SimulationSpeed > 1 Then
            SimulationSpeed -= 1
        End If
        SimLbl.Text = "Simulation Speed: " & SimulationSpeed
    End Sub

    Private Sub StopSimBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopSimBtn.Click
        quit = True
    End Sub

    Private Sub output_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles output.DoubleClick
        If output.SelectedIndex > -1 Then
            HighlightedCitizen = EventHistory(output.SelectedIndex)
            pg.SelectedObject = HighlightedCitizen
            pg.Show()
            m.HighlightedCitizen = EventHistory(output.SelectedIndex)
            cam.DrawMap(m, pb.CreateGraphics)
        End If
    End Sub

    Private Sub ViewHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewHistoryToolStripMenuItem.Click
        Dim ch As New CitizenHistory(CType(sender, ToolStripItem).Tag)
        ch.Show()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mp As New MapProperties(m)
        mp.ShowDialog()

    End Sub


    Private Sub pb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb.Resize
        If cam IsNot Nothing And m IsNot Nothing Then
            cam.ViewportWidth = pb.Width
            cam.ViewportHeight = pb.Height
            cam.DrawMap(m, pb.CreateGraphics)
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        quit = True
    End Sub
End Class


