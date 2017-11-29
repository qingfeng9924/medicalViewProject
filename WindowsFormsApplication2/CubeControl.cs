using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
public class CubeConrol : UserControl
{
    private Image image;
    private Graphics graphics;

    //
    private System.Windows.Forms.Label label1;
    public int Base = 100;
    public bool isMove = false;
    const int Band = 10;
    const int MinWidth = 100;
    const int MinHeight = 100;
    private EnumMousePointPosition m_MousePointPosition;
    private Point p, p1;
    public CubeConrol(int width, int height)
    {
        this.MinimumSize = new System.Drawing.Size(99, 99);
        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myMouseDown);
        this.MouseLeave += new System.EventHandler(this.myMouseLeave);
        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
        this.MouseUp += new MouseEventHandler(myMouseUp);
        this.Width = width;
        this.Height = height;
        image = new Bitmap(width, height);
        graphics = Graphics.FromImage(image);
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        var bitMap = new Bitmap(image);
        bitMap.MakeTransparent(Color.White);
        image = bitMap;
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.CompositingQuality = CompositingQuality.GammaCorrected;
        float[][] mtxItens = {
            new float[] {1,0,0,0,0},
            new float[] {0,1,0,0,0},
            new float[] {0,0,1,0,0},
            new float[] {0,0,0,1,0},
            new float[] {0,0,0,0,1}};
        ColorMatrix colorMatrix = new ColorMatrix(mtxItens);
        ImageAttributes imgAtb = new ImageAttributes();
        imgAtb.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        g.DrawImage(image, ClientRectangle, 0.0f, 0.0f, image.Width, image.Height, GraphicsUnit.Pixel, imgAtb);
    }
    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        Graphics g = e.Graphics;
        if (Parent != null)
        {
            BackColor = Color.Transparent;
            int index = Parent.Controls.GetChildIndex(this);
            for (int i = Parent.Controls.Count - 1; i > index; i--)
            {
                Control c = Parent.Controls[i];
                if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                {
                    Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                    c.DrawToBitmap(bmp, c.ClientRectangle);
                    g.TranslateTransform(c.Left - Left, c.Top - Top);
                    g.DrawImageUnscaled(bmp, Point.Empty);
                    g.TranslateTransform(Left - c.Left, Top - c.Top);
                    bmp.Dispose();
                }
            }
        }
        else
        {
            g.Clear(Parent.BackColor);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, Color.Transparent)), this.ClientRectangle);
        }
    }
    public void DrawCircles()
    {
        using (Brush b = new SolidBrush(Color.Red))
        {
            using (Pen p = new Pen(Color.Green, 3))
            {
                this.graphics.DrawEllipse(p, 50, 40, 30, 30);
            }
        }
    }
    //示例代码，请自行修改。
    public void DrawRectangle()
    {
        using (Brush b = new SolidBrush(Color.Red))
        {
            using (Pen p = new Pen(Color.Red, 3))
            {
                this.graphics.DrawRectangle(p, 50, 50, 40, 40);
            }
        }
    }
    //Image属性，每当赋值会引发Invalidate
    public Image Image
    {
        get
        {
            return image;
        }
        set
        {
            image = value;

            this.Invalidate();
        }
    }

    private enum EnumMousePointPosition
    {
        MouseSizeNone = 0,
        MouseSizeRight = 1,
        MouseSizeLeft = 2,
        MouseSizeBottom = 3,
        MouseSizeTop = 4,
        MouseSizeTopLeft = 5,
        MouseSizeTopRight = 6,
        MouseSizeBottomLeft = 7,
        MouseSizeBottomRight = 8,
        MouseDrag = 9
    }

    private void myMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        p.X = e.X;
        p.Y = e.Y;
        p1.X = e.X;
        p1.Y = e.Y;
        this.Refresh();
    }
    private void myMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        this.Parent.Refresh();
    }
    private void myMouseLeave(object sender, System.EventArgs e)
    {
        m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
        this.Cursor = Cursors.Arrow;
        CubeConrol lCtrl = (sender as CubeConrol);
        lCtrl.isMove = false;
    }

    private EnumMousePointPosition MousePointPosition(Size size, System.Windows.Forms.MouseEventArgs e)
    {
        if ((e.X >= -1 * Band) | (e.X <= size.Width * 0.75) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
        {

            if (e.X < Band)
            {

                if (e.Y < Band)
                {
                    return EnumMousePointPosition.MouseSizeTopLeft;
                }

                else
                {

                    if (e.Y > -1 * Band + size.Height)
                    {
                        return EnumMousePointPosition.MouseSizeBottomLeft;
                    }

                    else
                    {
                        return EnumMousePointPosition.MouseSizeLeft;
                    }

                }

            }

            else
            {

                if (e.X > (-1 * Band + size.Width) * 0.75)
                {

                    if (e.Y < Band)
                    {
                        return EnumMousePointPosition.MouseSizeTopRight;
                    }

                    else
                    {

                        if (e.Y > -1 * Band + size.Height)
                        {
                            return EnumMousePointPosition.MouseSizeBottomRight;
                        }

                        else
                        {
                            return EnumMousePointPosition.MouseSizeRight;
                        }

                    }

                }

                else
                {

                    if (e.Y < Band)
                    {
                        return EnumMousePointPosition.MouseSizeTop;
                    }

                    else
                    {

                        if (e.Y > -1 * Band + size.Height)
                        {
                            return EnumMousePointPosition.MouseSizeBottom;
                        }

                        else
                        {
                            return EnumMousePointPosition.MouseDrag;
                        }
                    }
                }
            }
        }
        else
        {
            return EnumMousePointPosition.MouseSizeNone;
        }
    }
    private void MyMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {

        CubeConrol lCtrl = (sender as CubeConrol);
       foreach(Control c in this.Parent.Controls)
       {
           c.Refresh();
       }
        if (e.Button == MouseButtons.Left)
        {

            switch (m_MousePointPosition)
            {
                case EnumMousePointPosition.MouseSizeRight:

                    lCtrl.isMove = true;
                    lCtrl.Width = lCtrl.Width + (e.X - p1.X) / 2;
                    p1.X = e.X;
                    p1.Y = e.Y;
                    break;
                case EnumMousePointPosition.MouseSizeTop:

                    if (e.Y >= p.Y && lCtrl.Height <= MinHeight)
                        break;
                    else
                    {
                        lCtrl.isMove = true;
                        lCtrl.Top = lCtrl.Top + e.Y - p.Y;
                        lCtrl.Height = lCtrl.Height - (e.Y - p1.Y);
                        break;
                    }
                default:
                    break;
            }
            this.Refresh();
            if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
            if (lCtrl.Height < MinHeight)
            {
                lCtrl.Height = MinHeight;
                lCtrl.Top = this.getBase() - lCtrl.Height;
            }
        }
        else
        {
            lCtrl.isMove = false;
            m_MousePointPosition = MousePointPosition(lCtrl.Size, e); //'判断光标的位置状态
            switch (m_MousePointPosition) //'改变光标
            {
                case EnumMousePointPosition.MouseSizeNone:
                    this.Cursor = Cursors.Arrow;       //'箭头
                    break;
                case EnumMousePointPosition.MouseDrag:
                    this.Cursor = Cursors.Default;
                    break;
                case EnumMousePointPosition.MouseSizeTop:
                    this.Cursor = Cursors.SizeNS;      //'南北
                    break;
                case EnumMousePointPosition.MouseSizeRight:
                    this.Cursor = Cursors.SizeWE;      //'东西
                    break;
                default:
                    break;
            }
        }
    }
    public int getBase()
    {
        return this.Base;
    }



   // public void getWidth(int)
}