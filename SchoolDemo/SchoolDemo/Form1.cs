namespace SchoolDemo
{
    public partial class Form1 : Form
    {
        int sayii = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            fillClassDepartments();
            fillClassbolum();
            fillClassBrans();
            
        }

        private void fillClassDepartments()
        {
            var names = Enum.GetNames<Departments>();
            names.ToList().ForEach(n => comboBoxBolum.Items.Add(n));
        }
        private void fillClassbolum()
        {
            var names = Enum.GetNames<bolum>();
            names.ToList().ForEach(n => comboBoxSube.Items.Add(n));
        }
        private void fillClassBrans()
        {
            var names = Enum.GetNames<Brans>();
            names.ToList().ForEach(n => comboBoxEgitmenBransi.Items.Add(n));
        }

        public void buttonSinifOlustur_Click(object sender, EventArgs e)
        {
            string sayi = sayii.ToString();
            string ogretmen = "Bilinmiyor";
            string[] row = { textBoxSinifNo.Text +" "+ comboBoxSube.Text,sayi , ogretmen };
            var satir = new ListViewItem(row);
            listViewSiniflar.Items.Add(satir);
            groupBox2.Enabled = true;
            textBoxOgrenciAdi.Enabled = true;
            textBoxOgrenciSoyadi.Enabled = true;
            textBoxOgrenciAdresi.Enabled = true;
            buttonOgrenciEkle.Enabled = true;
        }

        public void buttonOgrenciEkle_Click(object sender, EventArgs e)

        {
            
            if(textBoxOgrenciAdi.Text != "" || textBoxOgrenciSoyadi.Text != "" || textBoxOgrenciAdresi.Text != "")
            {
                if (listViewSiniflar.SelectedItems.Count == 0)
                {
                    MessageBox.Show("��renci ekliyorsun da nereye ? , �nce S�n�f Ekle; Ekliyse de se�ti�inden emin ol!");
                }
                else
                {

                    listBoxOgrenciler.Items.Add(textBoxOgrenciAdi.Text + " " + textBoxOgrenciSoyadi.Text + " " + textBoxOgrenciAdresi.Text);
                    int x = Convert.ToInt32(listViewSiniflar.SelectedItems[0].SubItems[1].Text);
                    x = x + 1;
                    string ogrsayisi = x.ToString();
                    listViewSiniflar.SelectedItems[0].SubItems[1].Text = ogrsayisi;
                    textBoxOgrenciAdi.Text = "";
                    textBoxOgrenciSoyadi.Text = "";
                    textBoxOgrenciAdresi.Text = "";
                }
            }
            else
            {
                MessageBox.Show("��renci Bilgileri Bo� B�rak�lamaz !!!");
            }
        }

        private void buttonEgitmenAta_Click(object sender, EventArgs e)
        {

            if (textBoxEgitmenAdi.Text != "" || textBoxEgitmenSoyadi.Text != "" || comboBoxEgitmenBransi.Text != "")
            {

                if (listViewSiniflar.SelectedItems.Count == 0)
                {
                    MessageBox.Show("E�itmeni atayaca��n�z s�n�f mevcut de�il ya da se�ilmemi�. L�tfen kontrol ediniz.");
                }
                else
                {

                    listViewSiniflar.SelectedItems[0].SubItems[2].Text = textBoxEgitmenAdi.Text + " " + textBoxEgitmenSoyadi.Text;
                }
            }
            else
            {
                MessageBox.Show("E�itmen Bilgileri Bo� B�rak�lamaz!");
            }
        }
        
    }
}