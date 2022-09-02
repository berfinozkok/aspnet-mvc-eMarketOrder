using System.Drawing.Imaging;

namespace QRForm
{
    public partial class BarcodeQRGenerator : Form
    {
        bool isGenerated = false; //know generated 
        public BarcodeQRGenerator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isGenerated = true;
            resultPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            resultPictureBox.Image = barcode.Draw(BarcodeTextBox.Text, 200);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            isGenerated = true;
            resultPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Zen.Barcode.CodeQrBarcodeDraw QRbarcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            resultPictureBox.Image = QRbarcode.Draw(BarcodeTextBox.Text, 200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isGenerated)
            {
                string pathh = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                resultPictureBox.Image.Save(pathh + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg",
                    ImageFormat.Jpeg);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}