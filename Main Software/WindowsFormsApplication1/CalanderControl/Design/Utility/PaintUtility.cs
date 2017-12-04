using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CalanderControl.Design.Enums;
using CalanderControl.Design.Layout;

namespace CalanderControl.Design.Utility
{
    public static class PaintUtility
    {
        public static bool themed;
        public static string ThemeName = string.Empty;
        public static string xpThemeName = string.Empty;

        public static Color ChangeColor(Color startColor, Color endColor, int level, bool swapColors)
        {
            if (swapColors)
            {
                Color color = startColor;
                startColor = endColor;
                endColor = color;
            }
            if (level == -1)
            {
                return endColor;
            }
            int r = startColor.R;
            int g = startColor.G;
            int b = startColor.B;
            if (r < endColor.R)
            {
                if ((r + level) < endColor.R)
                {
                    r += level;
                }
                else
                {
                    r = endColor.R;
                }
            }
            else if ((r - level) > endColor.R)
            {
                r -= level;
            }
            else
            {
                r = endColor.R;
            }
            if (r < endColor.G)
            {
                if ((g + level) < endColor.G)
                {
                    g += level;
                }
                else
                {
                    g = endColor.G;
                }
            }
            else if ((g - level) > endColor.G)
            {
                g -= level;
            }
            else
            {
                g = endColor.G;
            }
            if (b < endColor.B)
            {
                if ((b + level) < endColor.B)
                {
                    b += level;
                }
                else
                {
                    b = endColor.B;
                }
            }
            else if ((b - level) > endColor.B)
            {
                b -= level;
            }
            else
            {
                b = endColor.B;
            }
            return Color.FromArgb(0xff, r, g, b);
        }

        public static void DrawBackground(Graphics g, RectangleF rect, Brush fillBrush, CornerShape bShape,
                                          int cornerRadius, Region excRegion)
        {
            if (excRegion != null)
            {
                g.ExcludeClip(excRegion);
            }
            GraphicsPath path = GetDrawingPath(rect, bShape, cornerRadius);
            g.FillPath(fillBrush, path);
            fillBrush.Dispose();
            path.Dispose();
        }

        public static void DrawBorder(Graphics g, RectangleF rect, CornerShape bShape,
                                      ToolStripStatusLabelBorderSides bVisibility, DashStyle bLineStyle,
                                      int cornerRadius, Brush borderBrush, Region excRegion)
        {
            DrawBorder(g, rect, bShape, bVisibility, bLineStyle, cornerRadius, Color.Empty, borderBrush, excRegion);
        }

        internal static void DrawBorder(Graphics g, RectangleF rect, CornerShape bShape,
                                        ToolStripStatusLabelBorderSides bVisibility, DashStyle bLineStyle,
                                        int cornerRadius, Color borderColor, Brush borderBrush, Region excRegion)
        {
            if (bVisibility == ToolStripStatusLabelBorderSides.None)
            {
                return;
            }
            if (excRegion != null)
            {
                g.ExcludeClip(excRegion);
            }
            Pen pen;
            if (borderBrush != null)
            {
                pen = new Pen(borderBrush, 1f);
            }
            else
            {
                pen = new Pen(borderColor, 1f);
            }
            SmoothingMode smoothingMode = g.SmoothingMode;
            pen.DashStyle = bLineStyle;
            int num = 2*cornerRadius;
            if (bVisibility == ToolStripStatusLabelBorderSides.All)
            {
                GraphicsPath path = GetDrawingPath(rect, bShape, cornerRadius);
                g.DrawPath(pen, path);
                path.Dispose();
                g.SmoothingMode = smoothingMode;
                pen.Dispose();
                return;
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Left) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X, (rect.Y + rect.Height) - cornerRadius);
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X + cornerRadius, rect.Y, (rect.X + rect.Width) - cornerRadius, rect.Y);
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Right) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X + rect.Width, rect.Y + cornerRadius, rect.X + rect.Width,
                           (rect.Y + rect.Height) - cornerRadius);
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, (rect.X + rect.Width) - cornerRadius,
                           rect.Y + rect.Height);
            }
            if (((bVisibility & ToolStripStatusLabelBorderSides.Left) > ToolStripStatusLabelBorderSides.None) ||
                ((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None))
            {
                switch (bShape.TopLeft)
                {
                    case CornerType.Sliced:
                        g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X + cornerRadius, rect.Y);
                        break;

                    case CornerType.Square:
                        if (((bVisibility & ToolStripStatusLabelBorderSides.Left) <=
                             ToolStripStatusLabelBorderSides.None) ||
                            ((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None))
                        {
                            if (((bVisibility & ToolStripStatusLabelBorderSides.Left) <=
                                 ToolStripStatusLabelBorderSides.None) &&
                                ((bVisibility & ToolStripStatusLabelBorderSides.Top) >
                                 ToolStripStatusLabelBorderSides.None))
                            {
                                g.DrawLine(pen, rect.X, rect.Y, rect.X + cornerRadius, rect.Y);
                            }
                            else
                            {
                                g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X, rect.Y);
                                g.DrawLine(pen, rect.X, rect.Y, rect.X + cornerRadius, rect.Y);
                            }
                        }
                        else
                        {
                            g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X, rect.Y);
                        }
                        break;
                }
                if (((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None) ||
                    ((bVisibility & ToolStripStatusLabelBorderSides.Right) > ToolStripStatusLabelBorderSides.None))
                {
                    switch (bShape.TopRight)
                    {
                        case CornerType.Sliced:
                            g.DrawLine(pen, (rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                       rect.Y + cornerRadius);
                            break;
                        case CornerType.Square:
                            if (((bVisibility & ToolStripStatusLabelBorderSides.Right) >
                                 ToolStripStatusLabelBorderSides.None) ||
                                ((bVisibility & ToolStripStatusLabelBorderSides.Top) <=
                                 ToolStripStatusLabelBorderSides.None))
                            {
                                if (((bVisibility & ToolStripStatusLabelBorderSides.Right) >
                                     ToolStripStatusLabelBorderSides.None) &&
                                    ((bVisibility & ToolStripStatusLabelBorderSides.Top) <=
                                     ToolStripStatusLabelBorderSides.None))
                                {
                                    g.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X + rect.Width,
                                               rect.Y + cornerRadius);
                                }
                                else
                                {
                                    g.DrawLine(pen, (rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                               rect.Y);
                                    g.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X + rect.Width,
                                               rect.Y + cornerRadius);
                                }
                            }
                            else
                            {
                                g.DrawLine(pen, (rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                           rect.Y);
                            }
                            break;
                    }
                    if (((bVisibility & ToolStripStatusLabelBorderSides.Right) > ToolStripStatusLabelBorderSides.None) ||
                        ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) > ToolStripStatusLabelBorderSides.None))
                    {
                        switch (bShape.BottomRight)
                        {
                            case CornerType.Sliced:
                                g.DrawLine(pen, rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                           (rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height);
                                break;

                            case CornerType.Square:
                                if (((bVisibility & ToolStripStatusLabelBorderSides.Right) <=
                                     ToolStripStatusLabelBorderSides.None) ||
                                    ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) >
                                     ToolStripStatusLabelBorderSides.None))
                                {
                                    if (((bVisibility & ToolStripStatusLabelBorderSides.Right) <=
                                         ToolStripStatusLabelBorderSides.None) &&
                                        ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) >
                                         ToolStripStatusLabelBorderSides.None))
                                    {
                                        g.DrawLine(pen, (rect.X + rect.Width), (rect.Y + rect.Height),
                                                   (rect.X + rect.Width) - cornerRadius, (rect.Y + rect.Height));
                                    }
                                    else
                                    {
                                        g.DrawLine(pen, (rect.X + rect.Width), ((rect.Y + rect.Height) - cornerRadius),
                                                   rect.X + rect.Width, (rect.Y + rect.Height));
                                        g.DrawLine(pen, (rect.X + rect.Width), (rect.Y + rect.Height),
                                                   (rect.X + rect.Width) - cornerRadius, (rect.Y + rect.Height));
                                    }
                                }
                                else
                                {
                                    g.DrawLine(pen, rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                               rect.X + rect.Width, rect.Y + rect.Height);
                                }
                                break;
                        }
                        if (((bVisibility & ToolStripStatusLabelBorderSides.Bottom) >
                             ToolStripStatusLabelBorderSides.None) ||
                            ((bVisibility & ToolStripStatusLabelBorderSides.Left) > ToolStripStatusLabelBorderSides.None))
                        {
                            switch (bShape.BottomLeft)
                            {
                                case CornerType.Sliced:
                                    g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                               (rect.Y + rect.Height) - cornerRadius);
                                    g.SmoothingMode = smoothingMode;
                                    pen.Dispose();
                                    return;

                                case CornerType.Square:
                                    if (((bVisibility & ToolStripStatusLabelBorderSides.Left) >
                                         ToolStripStatusLabelBorderSides.None) ||
                                        ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) <=
                                         ToolStripStatusLabelBorderSides.None))
                                    {
                                        if (((bVisibility & ToolStripStatusLabelBorderSides.Left) >
                                             ToolStripStatusLabelBorderSides.None) &&
                                            ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) <=
                                             ToolStripStatusLabelBorderSides.None))
                                        {
                                            g.DrawLine(pen, rect.X, rect.Y + rect.Height, rect.X,
                                                       (rect.Y + rect.Height) - cornerRadius);
                                        }
                                        else
                                        {
                                            g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                                       rect.Y + rect.Height);
                                            g.DrawLine(pen, rect.X, rect.Y + rect.Height, rect.X,
                                                       (rect.Y + rect.Height) - cornerRadius);
                                        }
                                    }
                                    else
                                    {
                                        g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                                   rect.Y + rect.Height);
                                    }
                                    g.SmoothingMode = smoothingMode;
                                    pen.Dispose();
                                    return;
                            }
                            g.DrawArc(pen, rect.X, (rect.Y + rect.Height) - num, num, num, 90f, 90f);
                        }
                        g.DrawArc(pen, (rect.X + rect.Width) - num, (rect.Y + rect.Height) - num, num, num, 0f, 90f);
                    }
                    g.DrawArc(pen, (rect.X + rect.Width) - num, rect.Y, num, num, 270f, 90f);
                }
                g.DrawArc(pen, rect.X, rect.Y, num, num, 180f, 90f);
            }
        }

        public static void DrawImage(Graphics g, Rectangle rect, Image img, int alpha)
        {
            if (img != null)
            {
                if (alpha == 0xff)
                {
                    g.DrawImage(img, rect);
                }
                else
                {
                    var imageAttr = new ImageAttributes();
                    imageAttr.SetColorMatrix(MakeTransparentImage(alpha));
                    g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttr);
                    imageAttr.Dispose();
                }
            }
        }

        public static GraphicsPath GetDrawingPath(RectangleF rect, CornerShape bShape, int cornerRadius)
        {
            var path = new GraphicsPath();
            int num = 2*cornerRadius;
            if (bShape.TopLeft == CornerType.Square)
            {
                if (bShape.TopRight == CornerType.Square)
                {
                    path.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                }
                else
                {
                    path.AddLine(rect.X, rect.Y, (rect.X + rect.Width) - cornerRadius, rect.Y);
                    if (bShape.TopRight == CornerType.Round)
                    {
                        path.AddArc((rect.X + rect.Width) - num, rect.Y, num, num, 270f, 90f);
                    }
                    else
                    {
                        path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                     rect.Y + cornerRadius);
                    }
                }
            }
            else if (bShape.TopRight == CornerType.Square)
            {
                path.AddLine(rect.X + cornerRadius, rect.Y, rect.X + rect.Width, rect.Y);
            }
            else
            {
                path.AddLine(rect.X + cornerRadius, rect.Y, (rect.X + rect.Width) - cornerRadius, rect.Y);
                if (bShape.TopRight == CornerType.Round)
                {
                    path.AddArc((rect.X + rect.Width) - num, rect.Y, num, num, 270f, 90f);
                }
                else
                {
                    path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                 rect.Y + cornerRadius);
                }
            }
            if (bShape.TopRight == CornerType.Square)
            {
                if (bShape.BottomRight == CornerType.Square)
                {
                    path.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                }
                else
                {
                    path.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius);
                    if (bShape.BottomRight == CornerType.Round)
                    {
                        path.AddArc((rect.X + rect.Width) - num, (rect.Y + rect.Height) - num, num, num, 0f, 90f);
                    }
                    else
                    {
                        path.AddLine(rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                     (rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height);
                    }
                }
            }
            else if (bShape.BottomRight == CornerType.Square)
            {
                path.AddLine(rect.X + rect.Width, rect.Y + cornerRadius, (rect.X + rect.Width), (rect.Y + rect.Height));
            }
            else
            {
                path.AddLine(rect.X + rect.Width, rect.Y + cornerRadius, (rect.X + rect.Width),
                             ((rect.Y + rect.Height) - cornerRadius));
                if (bShape.BottomRight == CornerType.Round)
                {
                    path.AddArc((rect.X + rect.Width) - num, (rect.Y + rect.Height) - num, num, num, 0f, 90f);
                }
                else
                {
                    path.AddLine(rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                 (rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height);
                }
            }
            if (bShape.BottomRight == CornerType.Square)
            {
                if (bShape.BottomLeft == CornerType.Square)
                {
                    path.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);
                }
                else
                {
                    path.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X + cornerRadius, rect.Y + rect.Height);
                    if (bShape.BottomLeft == CornerType.Round)
                    {
                        path.AddArc(rect.X, (rect.Y + rect.Height) - num, num, num, 90f, 90f);
                    }
                    else
                    {
                        path.AddLine(rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                     (rect.Y + rect.Height) - cornerRadius);
                    }
                }
            }
            else if (bShape.BottomLeft == CornerType.Square)
            {
                path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);
            }
            else
            {
                path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height, rect.X + cornerRadius,
                             rect.Y + rect.Height);
                if (bShape.BottomLeft == CornerType.Round)
                {
                    path.AddArc(rect.X, (rect.Y + rect.Height) - num, num, num, 90f, 90f);
                }
                else
                {
                    path.AddLine(rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                 (rect.Y + rect.Height) - cornerRadius);
                }
            }
            if (bShape.BottomLeft == CornerType.Square)
            {
                if (bShape.TopLeft == CornerType.Square)
                {
                    path.AddLine(rect.X, rect.Y + rect.Height, rect.X, rect.Y);
                    return path;
                }
                path.AddLine(rect.X, rect.Y + rect.Height, rect.X, rect.Y + cornerRadius);
                if (bShape.TopLeft == CornerType.Round)
                {
                    path.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
                    return path;
                }
                path.AddLine(rect.X, rect.Y + cornerRadius, rect.X + cornerRadius, rect.Y);
                return path;
            }
            if (bShape.TopLeft == CornerType.Square)
            {
                path.AddLine(rect.X, (rect.Y + rect.Height) - cornerRadius, rect.X, rect.Y);
                return path;
            }
            path.AddLine(rect.X, (rect.Y + rect.Height) - cornerRadius, rect.X, rect.Y + cornerRadius);
            if (bShape.TopLeft == CornerType.Round)
            {
                path.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
                return path;
            }
            path.AddLine(rect.X, rect.Y + cornerRadius, rect.X + cornerRadius, rect.Y);
            return path;
        }

        public static ColorMatrix MakeTransparentImage(int alpha)
        {
            var matrix = new ColorMatrix();
            matrix.Matrix00 = 1f;
            matrix.Matrix11 = 1f;
            matrix.Matrix22 = 1f;
            matrix.Matrix33 = alpha/255f;
            matrix.Matrix44 = 1f;
            return matrix;
        }
    }
}