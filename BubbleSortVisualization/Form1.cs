using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BubbleSortVisualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] dizi;
        SolidBrush[] renkler;
        Random r = new Random();
        Bitmap image;
        private void button1_Click(object sender, EventArgs e)
        {

            islem = "rastgele";
            panel1.Invalidate();
        }
        public SolidBrush rastgelerenk()
        {
            SolidBrush b = new SolidBrush(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            return b;
        }
        int sayac = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            sirala = true;
            islem = "sirala";
            panel1.Invalidate();
            if (dizi!=null)
            {
                int[] zamanhesabi = new int[dizi.Length];
                for (int i = 0; i < zamanhesabi.Length; i++)
                {
                    zamanhesabi[i] = dizi[i];
                }
                label2.Text = "Sıralandı, kaydediliyor.";
                listBox1.Items.Add(sayac + ". Çalıştırma: " + millisecs(zamanhesabi).ToString() + " nanosaniye.");
                sayac++;
            }
           
            /*if (dizi!=null)
            {
                grafik = panel1.CreateGraphics();
                int[] zamanhesabi = dizi;
                int maxdeger = panel1.Height;
                listBox2.Items.Clear();
                float kalinlik = ((float)panel1.Width / (float)dizi.Length);
                label2.Text = "Sıralanıyor..";
                int temp;
                listBox2.Items.Clear();
                for (int j = 0; j <= dizi.Length - 2; j++)
                {
                    for (int i = 0; i <= dizi.Length - 2; i++)
                    {
                        for (int k = 0; k < dizi.Length; k++)
                        {
                            Ciz(k, maxdeger, kalinlik, renkler[k]);
                        }
                        Ciz(i, maxdeger, kalinlik, Brushes.White);
                        Thread.Sleep(trackBar1.Value);
                        Ciz(i, maxdeger, kalinlik, Brushes.Black);
                        if (dizi[i] > dizi[i + 1])
                        {
                            temp = dizi[i + 1];
                            dizi[i + 1] = dizi[i];
                            dizi[i] = temp;
                            SolidBrush tmpbrush = renkler[i + 1];
                            renkler[i + 1] = renkler[i];
                            renkler[i] = tmpbrush;
                        }
                        else
                        {
                            Ciz(i, maxdeger, kalinlik,renkler[i]);
                            Thread.Sleep(trackBar1.Value);
                        }
                    }
                    listBox2.Items.Add((j + 1) + ". Adım:" + ArrtoListbox(dizi));
                }
                label2.Text = "Sıralandı, kaydediliyor.";
                listBox1.Items.Add(sayac+". Çalıştırma: " + millisecs(zamanhesabi).ToString() + " nanosaniye.");
                sayac++;
            }
            else
            {
                label2.Text = "Bir dizi oluşturmadınız.";
                label2.ForeColor = Color.Red;
            }*/
            
        }
      
        string ArrtoListbox(int[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " > ";
            }
            return str;
        }
        double millisecs(int[] arr)
        {
            int temp;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            sw.Stop();
            return (sw.Elapsed.TotalMilliseconds * 1000000);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString() + "ms";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = 1000;
            trackBar1.Minimum = 1;
            image =new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            this.DoubleBuffered = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            islem = "ters";
            panel1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            islem = "sirali";
            panel1.Invalidate();
        }
        public bool checkMaxVal(int deger)
        {
            if (deger>panel1.Height)
            {
                return false;
            }
            return true;
        }

        bool manuel = false;
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (dizi == null ||!manuel) dizi = new int[0];
            manuel = true;
            if (textBox2.Text != "")
            {
                int val = Convert.ToInt32(textBox2.Text);
                if (checkMaxVal(val))
                {
                    Array.Resize(ref dizi, dizi.Length + 1);
                    dizi[dizi.GetUpperBound(0)] = val;
                    label2.Text = "Sayı Eklendi.";
                    label2.ForeColor = Color.Green;
                    textBox2.Text = "";
                }
                else
                {
                    label2.Text = "Sayı büyüklüğü, panel yüksekliğinden fazla olamaz! " + panel1.Height + " değerinden düşük bir sayı giriniz.";
                    label2.ForeColor = Color.Red;
                }
            }
            else
            {
                label2.Text = "Bir değer giriniz";
                label2.ForeColor = Color.Red;
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            islem = "manuel";
            panel1.Invalidate();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            dizi = new int[0];
        }
        public void Ciz(int i, float maxdeger, float kalinlik, Brush b,PaintEventArgs e)
        {
            RectangleF rec = new RectangleF(i*kalinlik, dizi[i], 20, 20);
            if (manuel)
            {
                if ((dizi[i] + 50) < panel1.Height)
                    rec = new RectangleF(i * kalinlik, (maxdeger - (dizi[i] + 50)), kalinlik, (dizi[i] + 50));
            }
            e.Graphics.FillEllipse(b, rec);
            e.Graphics.DrawString(dizi[i].ToString(), new Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, rec);
        }
        bool sirala = false;
        string islem;
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            switch (islem)
            {
                case "sirala":
                    
                    if (dizi != null)
                    {
                        if (sirala)
                        {
                            e.Graphics.FillRectangle(Brushes.Black, 0, 0, panel1.Width, panel1.Height);
                            int maxdeger = panel1.Height;
                            listBox2.Items.Clear();
                            float kalinlik = ((float)panel1.Width / (float)dizi.Length);
                            label2.Text = "Sıralanıyor..";
                            int temp;
                            listBox2.Items.Clear();
                            for (int j = 0; j <= dizi.Length - 2; j++)
                            {
                                for (int i = 0; i <= dizi.Length - 2; i++)
                                {
                                    for (int k = 0; k < dizi.Length; k++)
                                    {
                                        Ciz(k, maxdeger, kalinlik, renkler[k], e);
                                    }
                                    Ciz(i, maxdeger, kalinlik, Brushes.White, e);
                                    Thread.Sleep(trackBar1.Value);
                                    Ciz(i, maxdeger, kalinlik, Brushes.Black, e);
                                    if (dizi[i] > dizi[i + 1])
                                    {
                                        temp = dizi[i + 1];
                                        dizi[i + 1] = dizi[i];
                                        dizi[i] = temp;
                                        SolidBrush tmpbrush = renkler[i + 1];
                                        renkler[i + 1] = renkler[i];
                                        renkler[i] = tmpbrush;
                                    }
                                    else
                                    {
                                        Ciz(i, maxdeger, kalinlik, renkler[i], e);
                                        Thread.Sleep(trackBar1.Value);

                                    }
                                }
                                listBox2.Items.Add((j + 1) + ". Adım:" + ArrtoListbox(dizi));
                            }
                        }
                        else
                        {
                            //Sayfa değişikliği vb yapıldığında, görüntüler tekrar oluşturuluyor.
                            label2.Text = "Yenilendi..";
                            e.Graphics.FillRectangle(Brushes.Black, 0, 0, panel1.Width, panel1.Height);
                            int maxdeger = panel1.Height;
                            float kalinlik = ((float)panel1.Width / (float)dizi.Length);
                            for (int j = 0; j <= dizi.Length - 2; j++)
                            {
                                for (int i = 0; i <= dizi.Length - 2; i++)
                                {
                                    for (int k = 0; k < dizi.Length; k++)
                                    {
                                        Ciz(k, maxdeger, kalinlik, renkler[k], e);
                                    }
                                }
                            }
                        }
                       
                    }
                    else
                    {
                        label2.Text = "Bir dizi oluşturmadınız.";
                        label2.ForeColor = Color.Red;
                    }
                    sirala = false;
                    break;
                case "ters":
                    manuel = false;
                    if (textBox1.Text != "")
                    {
                        if (checkMaxVal(Convert.ToInt32(textBox1.Text)))
                        {
                            int Adet = Convert.ToInt32(textBox1.Text);
                            dizi = new int[Adet];
                            renkler = new SolidBrush[Adet];
                            float maxdeger = panel1.Height;
                            float kalinlik = ((float)panel1.Width / (float)dizi.Length);
                            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, panel1.Width, maxdeger);
                            for (int i = 0; i < dizi.Length; i++)
                            {
                                dizi[i] = i * (panel1.Height / dizi.Length);
                            }
                            Array.Reverse(dizi);
                            for (int i = 0; i < dizi.Length; i++)
                            {
                                SolidBrush b = rastgelerenk();
                                RectangleF rec = new RectangleF(i * kalinlik, maxdeger - dizi[i], kalinlik, dizi[i]);
                                e.Graphics.FillRectangle(b, rec);
                                e.Graphics.DrawString(dizi[i].ToString(), new Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, rec);
                                renkler[i] = b;
                            }
                            label2.Text = "Sıralamayı başlatabilirsiniz.";
                            label2.ForeColor = Color.Green;
                        }
                        else
                        {
                            label2.Text = "Sayı büyüklüğü, panel yüksekliğinden fazla olamaz! " + panel1.Height + " değerinden düşük bir sayı giriniz.";
                            label2.ForeColor = Color.Red;
                        }

                    }
                    else
                    {
                        label2.Text = "Bir değer giriniz!";
                        label2.ForeColor = Color.Red;
                    }
                    break;
                case "rastgele":
                    manuel = false;
                    if (textBox1.Text != "")
                    {
                        if (checkMaxVal(Convert.ToInt32(textBox1.Text)))
                        {
                            Random rnd = new Random();
                            int Adet = Convert.ToInt32(textBox1.Text);
                            dizi = new int[Adet];
                            renkler = new SolidBrush[Adet];
                            float maxdeger = panel1.Height; float uzunluk;
                            float kalinlik = ((float)panel1.Width / (float)dizi.Length); ;
                            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, panel1.Width, maxdeger);

                            for (int i = 0; i < dizi.Length; i++)
                            {
                                dizi[i] = rnd.Next(0, (int)maxdeger);
                            }

                            for (int i = 0; i < dizi.Length; i++)
                            {
                                uzunluk = maxdeger - dizi[i];
                                /*
                                Brush b = rastgelerenk();
                                e.Graphics.FillRectangle(b, i * kalinlik, maxdeger - dizi[i], kalinlik, maxdeger);
                                renkler[i] = b;
                                */
                                SolidBrush b = rastgelerenk();
                                RectangleF rec = new RectangleF(i * kalinlik, uzunluk, kalinlik, maxdeger);
                                e.Graphics.FillRectangle(b, rec);
                                e.Graphics.DrawString(dizi[i].ToString(), new Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, rec);
                                renkler[i] = b;
                            }
                            label2.Text = "Sıralamayı başlatabilirsiniz.";
                            label2.ForeColor = Color.Green;
                        }
                        else
                        {
                            label2.Text = "Sayı büyüklüğü, panel yüksekliğinden fazla olamaz! " + panel1.Height + " değerinden düşük bir sayı giriniz.";
                            label2.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        label2.Text = "Bir değer giriniz!";
                        label2.ForeColor = Color.Red;
                    }
                    break;
                case "sirali":
                    manuel = false;
                    if (textBox1.Text != "")
                    {
                        if (checkMaxVal(Convert.ToInt32(textBox1.Text)))
                        {
                            int Adet = Convert.ToInt32(textBox1.Text);
                            dizi = new int[Adet];
                            renkler = new SolidBrush[Adet];
                            float maxdeger = panel1.Height;
                            float kalinlik = ((float)panel1.Width / (float)dizi.Length);
                            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, panel1.Width, maxdeger);
                            for (int i = 0; i < dizi.Length; i++)
                            {
                                dizi[i] = i * (panel1.Height / dizi.Length);
                            }
                            for (int i = 0; i < dizi.Length; i++)
                            {
                                SolidBrush b = rastgelerenk();
                                RectangleF rec = new RectangleF(i * kalinlik, maxdeger - dizi[i], kalinlik, maxdeger);
                                e.Graphics.FillRectangle(b, rec);
                                e.Graphics.DrawString(dizi[i].ToString(), new Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, rec);
                                renkler[i] = b;
                            }
                        }
                        else
                        {
                            label2.Text = "Sayı büyüklüğü, panel yüksekliğinden fazla olamaz! " + panel1.Height + " değerinden düşük bir sayı giriniz.";
                            label2.ForeColor = Color.Red;
                        }
                        label2.Text = "Sıralamayı başlatabilirsiniz.";
                        label2.ForeColor = Color.Green;

                    }
                    else
                    {
                        label2.Text = "Bir değer giriniz!";
                        label2.ForeColor = Color.Red;
                    }
                    break;
                case "manuel":
                    if (dizi != null)
                    {
                        if (dizi.Length > 1)
                        {
                            int Adet = dizi.Length;
                            renkler = new SolidBrush[Adet];
                            float maxdeger = panel1.Height;
                            float kalinlik = ((float)panel1.Width / (float)dizi.Length);
                            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, panel1.Width, maxdeger);
                            for (int i = 0; i < dizi.Length; i++)
                            {
                                RectangleF rec;
                                SolidBrush b = rastgelerenk();
                                if ((dizi[i] + 50) < panel1.Height)
                                    rec = new RectangleF(i * kalinlik, (maxdeger - (dizi[i]+50)), kalinlik, (dizi[i]+50));
                                else
                                    rec = new RectangleF(i * kalinlik, (maxdeger - dizi[i]), kalinlik, dizi[i]);
                                e.Graphics.FillRectangle(b, rec);
                                e.Graphics.DrawString(dizi[i].ToString(), new Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, rec);
                                renkler[i] = b;
                            }
                            label2.Text = "Sıralamayı başlatabilirsiniz.";
                            label2.ForeColor = Color.Green;
                        }

                    }
                    else
                    {
                        label2.Text = "Henüz hiç bir eleman eklemediniz.";
                        label2.ForeColor = Color.Red;
                    }
                    break;
            }
        }
    }
}
