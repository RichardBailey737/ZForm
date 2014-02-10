using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GeomLib
{
    public class Camera
    {
        public Camera(int ViewportWidth, int ViewportHeight) {
            _viewportwidth = ViewportWidth;
            _viewportheight = ViewportHeight;
            CameraLocation = new System.Drawing.PointF(0, 0);
            Zoom = 100;
            UpdateViewport();
        }
        
        System.Drawing.PointF _CameraLocation;
        public PointF CameraLocation {
            get {
                return _CameraLocation;
                }
            set {
                _CameraLocation = value;
                UpdateViewport();
            }
        }

        int _viewportwidth;
        public int ViewportWidth {
            get {
                return _viewportwidth;
            }
            set {
                _viewportwidth = value;
                UpdateViewport();
            }
        }

        int _viewportheight;
        public int  ViewportHeight {
         get {
            return _viewportheight;
         }
        set {
            _viewportheight = value;
            }
        }


    Rectangle ViewportRect;

    public double Zoom { get; set; }

    private void UpdateViewport() {
        ViewportRect = new Rectangle(Convert.ToInt32(CameraLocation.X)- ViewportWidth / 2, Convert.ToInt32(CameraLocation.Y ) - ViewportHeight / 2, ViewportWidth, ViewportHeight);
    }

    public PointF TranslatePoint(PointF OriginalPoint)  {
        //MsgBox("Viewport:" & ViewportRect.ToString)
        //MsgBox("Cam:" & CameraLocation.ToString)
        //MsgBox("O:" & OriginalPoint.ToString)
        PointF p = ToRelativeCoordinates(OriginalPoint);

        //MsgBox("Relative:" & p.ToString)
        p.X = (int)((p.X * Zoom + p.X) / Zoom);
        p.Y = (int)((p.Y * Zoom + p.Y) / Zoom);
        //MsgBox("Scaled:" & p.ToString)
        //p.X += CameraLocation.X
        //p.Y += CameraLocation.Y
        //MsgBox("Final:" & p.ToString)
        return ToWorldCoordinates(p);
    }

    public PointF ToRelativeCoordinates(PointF OPoint) {
        PointF p = new PointF(OPoint.X - CameraLocation.X, OPoint.Y - CameraLocation.Y);
        return p;
    }

    public PointF ToWorldCoordinates(PointF Opoint) {
        PointF p = new PointF(Opoint.X + CameraLocation.X, Opoint.Y + CameraLocation.Y);
        return p;
    }

    public PointF RevertPoint(PointF TranslatedPoint) {
        //MsgBox(TranslatedPoint.ToString)
        PointF p = new PointF(TranslatedPoint.X - ((ViewportWidth / 2) - CameraLocation.X), TranslatedPoint.Y - ((ViewportHeight / 2) - CameraLocation.Y));
        p = ToRelativeCoordinates(p);

        //MsgBox(p.ToString)
        p.X = (float)((p.X * Zoom) / (Zoom + 1));
        p.Y = (float)((p.Y * Zoom) / (Zoom + 1));
        // MsgBox(p.ToString)
        return ToWorldCoordinates(p);
    }

    public PointF CenterPoint(PointF Opoint )  {
        PointF p = new PointF(Opoint.X + ((ViewportRect.Width / 2) - CameraLocation.X), Opoint.Y + ((ViewportHeight / 2) - CameraLocation.Y));
        return p;
    }


        //public void DrawMap(ByRef Area As Map, ByRef g As Graphics)


        //    Dim BufferImage As new Bitmap(ViewportWidth, ViewportHeight)
        //    Dim Buffer As Graphics = Graphics.FromImage(BufferImage)

        //    Buffer.Clear(Color.White)

        //    Dim p1, p2 As PointF
        //    For Each bld As Building In Area.Buildings
        //        p1 = CenterPoint(TranslatePoint(new PointF(bld.PositionRect.X, bld.PositionRect.Y)))
        //        p2 = CenterPoint(TranslatePoint(new PointF(bld.PositionRect.Right, bld.PositionRect.Bottom)))
        //        Buffer.DrawRectangle(new Pen(Brushes.Black), p1.X, p1.Y, (p2.X - p1.X), (p2.Y - p1.Y))
        //    Next

        //    //Buffer.DrawRectangle(new Pen(Brushes.Black), 0, 0, ViewportRect.Width - 1, ViewportRect.Height - 1)
        //    p1 = CenterPoint(TranslatePoint(new PointF(0, 0)))
        //    p2 = CenterPoint(TranslatePoint(new PointF(Area.Width, Area.Height)))

        //    Buffer.DrawRectangle(new Pen(Brushes.Black), p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y)
        //    Dim scale As Double = (4 * Zoom + 4) / Zoom
        //    //MsgBox(scale)


        //    For Each c As Citizen In Area.Citizens
        //        p1 = CenterPoint(TranslatePoint(c.Location.ToPoint))
        //        If c.Alive Then
        //            If c.isZombie Then
        //                Buffer.FillEllipse(Brushes.Red, CInt(p1.X - (scale / 2)), CInt(p1.Y - (scale / 2)), CInt(scale), CInt(scale))
        //            Else
        //                Buffer.FillEllipse(Brushes.Blue, CInt(p1.X - (scale / 2)), CInt(p1.Y - (scale / 2)), CInt(scale), CInt(scale))
        //            End If
        //        Else
        //            Buffer.FillEllipse(Brushes.Black, CInt(p1.X - (scale / 2)), CInt(p1.Y - (scale / 2)), CInt(scale), CInt(scale))
        //        End If
        //    Next

        //    If Area.HighlightedCitizen IsNot Nothing Then
        //        Dim vis As Double = (Area.VisualRange * Zoom + Area.VisualRange) / Zoom
        //        Dim m As new GeomLib.Matrix2D
        //        m.SetToRotation(45)
        //        Dim v As new GeomLib.Vector2D(Area.HighlightedCitizen.FacingVector)
        //        v.TransformBy(m)
        //        Dim uv As new GeomLib.Vector2D(1, 0)
        //        Dim a As int = uv.AngleTo(v)
        //        If v.Y < 0 Then a = 360 - a
        //        p1 = CenterPoint(TranslatePoint(Area.HighlightedCitizen.Location.ToPoint))
        //        Buffer.DrawPie(new Pen(Brushes.Brown), CInt(p1.X - vis), CInt(p1.Y - vis), CInt(vis * 2), CInt(vis * 2), a, 90)
        //    End If

        //    g.DrawImage(BufferImage, 0, 0)

        //}
    }

    public static class GeomLibExtensions 
    {
        public static Point ToPoint(this PointF pt)
        {
            return new Point((int)Math.Round(pt.X), (int)Math.Round(pt.Y));
        }
    }
}
