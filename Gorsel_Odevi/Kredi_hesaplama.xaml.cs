namespace Gorsel_Odevi
{
    public partial class Kredi_hesaplama : ContentPage
    {
        public Kredi_hesaplama()
        {
            InitializeComponent();
        }

        public double kkdf = 0.0;
        public double bsmv = 0.0;

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            valueLabel.Text = args.NewValue.ToString("0");

            HandleCalculation();
        }

        void myPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sls = myPicker.SelectedItem.ToString();
            if (sls == "İhtiyaç kerdisi")
            {
                kkdf = 0.15;
                bsmv = 0.10;
            }
            else if (sls == "konut kredisi")
            {
                kkdf = 0;
                bsmv = 0;
            }
            else if (sls == "Taşıt kredisi")
            {
                kkdf = 0.15;
                bsmv = 0.5;
            }
            else if (sls == "Ticari kredisi")
            {
                kkdf = 0;
                bsmv = 0.5;
            }

            HandleCalculation();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            if (myPicker.SelectedIndex == -1)
            {
                DisplayAlert("Seç kredi'nin tipi", "Lütfen hesaplamadan önce kredi tipi seç", "OK");
                return;
            }

            HandleCalculation();
        }

        private void HandleCalculation()
        {
            string tut = kredi_tutari.Text;
            string or = faiz_orani.Text;
            string ay = valueLabel.Text;

            double Tutar;
            double Oran;
            int Vade;

            bool tutarParsed = double.TryParse(tut, out Tutar);
            bool oranParsed = double.TryParse(or, out Oran);
            bool vadeParsed = int.TryParse(ay, out Vade);

            double brutFaiz = ((Oran + (Oran * bsmv) + (Oran * kkdf)) / 100);
            double taksit = Math.Round(((Math.Pow(1 + brutFaiz, Vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, Vade) - 1)) * Tutar ,2);
            double tolam = Math.Round(taksit * Vade,2);
            double TopalF = Math.Round((tolam - Tutar),2);

            AlikTak.Text = $"Aylik Taksit: {taksit.ToString()}";
            ToplamOde.Text = $"Toplam ödeme: {tolam.ToString()}";
            ToplamFa.Text = $"Toplam faiz: {TopalF.ToString()}";
        }
    }
}
