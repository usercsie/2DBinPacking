using _2DBinPacking.UI;
using System;
using System.Windows.Forms;

namespace _2DBinPacking
{
    public partial class Form1 : Form, IForm
    {
        private BindingSource _DataSource = new BindingSource();        
        private FormPresenter _Presenter;
        private IDocument _Drawer;
        private RectDataCollection _RectCollection;

        public IDocument Drawer
        {
            get
            {
                return _Drawer;
            }
        }
        public int RectMargin
        {
            get
            {
                return Convert.ToInt32(MarginTextBox.Text);
            }
        }
        public int BinPadding
        {
            get
            {
                return Convert.ToInt32(PaddingTextBox.Text);
            }
        }
        public int RectCount
        {
            get
            {
                return Convert.ToInt32(BoxCountTextBox.Text);
            }
        }

        public Form1()
        {
            InitializeComponent();            

            _Presenter = new FormPresenter(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDrawer();

            _RectCollection = new RectDataCollection();            
        }

        private void InitializeDrawer()
        {
            DrawingPanel panel = new DrawingPanel();
            panel.Dock = DockStyle.Fill;
            panel.Parent = splitContainer1.Panel1;
            _Drawer = panel;
        }
        private void PlacingRectsButton_Click(object sender, EventArgs e)
        {
            float coverage;
            RectController controller = new RectController();
            controller.Adjust(ref _RectCollection);

            _Presenter.Place(Drawer.Width, Drawer.Height, _RectCollection, out coverage);

            SpaceCoverageLabel.Text = string.Format(string.Format("{0} %", (coverage * 100).ToString("0.00")));

            DisplayRectangles(_RectCollection);
        }
        private void GeneratingRectsButton_Click(object sender, EventArgs e)
        {            
            _RectCollection = _Presenter.GenerateRandomRectDatas(RectCount);
            BindToDataGridView(_RectCollection);
        }
        private void BindToDataGridView(RectDataCollection collection)
        {
            _DataSource.Clear();
            foreach (var item in _RectCollection)
            {
                _DataSource.Add(item);
            }

            this.dataGridView1.DataSource = _DataSource;
        }
        private void DisplayRectangles(RectDataCollection collection)
        {
            _Drawer.Shapes.Clear();

            foreach(var rect in collection)
            {
                if (rect.Placed == false)
                    continue;

                _Drawer.Shapes.Add(new Drawing2D.Shape.Rectangle(rect.Key, (int)rect.Rect.Left, (int)rect.Rect.Top, 
                    (int)rect.Rect.Width, (int)rect.Rect.Height));
            }

            this.Refresh();
        }
    }
}
