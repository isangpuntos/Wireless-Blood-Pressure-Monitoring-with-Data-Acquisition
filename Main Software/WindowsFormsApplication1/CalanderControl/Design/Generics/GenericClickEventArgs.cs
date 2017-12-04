using System.Drawing;
using System.Windows.Forms;

namespace CalanderControl.Design.Generics
{
    public delegate void GenericClickEventHandler<T>(object sender, GenericClickEventArgs<T> e);

    public class GenericClickEventArgs<T> : GenericEventArgs<T>
    {
        private readonly MouseButtons button;
        private readonly Point position;

        public GenericClickEventArgs()
        {
            button = MouseButtons.None;
            position = Point.Empty;
        }

        public GenericClickEventArgs(T value, MouseButtons button, Point position) : base(value)
        {
            this.button = MouseButtons.None;
            this.position = Point.Empty;
            this.button = button;
            this.position = position;
        }

        public MouseButtons Button
        {
            get { return button; }
        }

        public Point Position
        {
            get { return position; }
        }
    }
}