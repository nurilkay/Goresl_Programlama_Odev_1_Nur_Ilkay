namespace Gorsel_Odevi { 

public partial class VucutKitleIndeksiHesaplama : ContentPage
{
    public VucutKitleIndeksiHesaplama()
    {
        InitializeComponent();
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {   
        if (double.TryParse(KiloGirisi.Text, out double kilo) &&
            double.TryParse(BoyGirisi.Text, out double boy) &&
            boy > 0 )
        {
            double vki = VucutKitleIndeksiniHesapla(kilo, boy);
            string rapor = SonucRaporunuOlustur(vki);
            VkiSonucuLabel.Text = $"VKI: {vki:F2} - {rapor}";
        }
        else
        {
            VkiSonucuLabel.Text = "Geçersiz giriş. Lütfen geçerli bir değer giriniz.";
        }
    }

    private double VucutKitleIndeksiniHesapla(double kilo, double boy)
    {
        return kilo / (boy * boy);
    }

    private void KiloSliderDegeriDegistirildi(object sender, ValueChangedEventArgs e)
    {
        KiloGirisi.Text = e.NewValue.ToString("0");
    }

    private void BoySliderDegeriDegistirildi(object sender, ValueChangedEventArgs e)
    {
        BoyGirisi.Text = e.NewValue.ToString("");
    }

    private string SonucRaporunuOlustur(double vki)
    {
        string rapor;

        if (vki < 16)
        {
            rapor = "İleri düzeyde zayıf";
        }
        else if (16 <= vki && vki <= 16.99)
        {
            rapor = "Orta düzeyde Zayıf";
        }
        else if (17 <= vki && vki <= 18.49)
        {
            rapor = "Hafif Düzeyde Zayıf";
        }
        else if (18.50 <= vki && vki <= 24.9)
        {
            rapor = "Normal kilo";
        }
        else if (25 <= vki && vki <= 29.99)
        {
            rapor = "Hafif şişman / fazla kilolu";
        }
        else if (30 <= vki && vki <= 34.99)
        {
            rapor = "1. derece obez";
        }
        else if (35 <= vki && vki <= 39.99)
        {
            rapor = "2. derece obez";
        }
        else if (vki >= 40)
        {
            rapor = "3. derece obez / Morbid obez";
        }
        else
        {
            rapor = "Hata oluştu";
        }

        return rapor;
    }
}
}
