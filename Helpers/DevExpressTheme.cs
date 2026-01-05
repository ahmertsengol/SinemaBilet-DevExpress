using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System.Drawing;

namespace Sinemaci.BiletSistemi.Helper
{
    /// <summary>
    /// DevExpress tema yönetimi ve renk paleti
    /// AppColors.cs'teki renkler DevExpress skin sistemiyle eşleştirildi
    /// </summary>
    public static class DevExpressTheme
    {
        // Ana Renkler (DevExpress skins ile uyumlu)
        public static Color Primary = Color.FromArgb(41, 128, 185);      // Mavi
        public static Color Secondary = Color.FromArgb(52, 73, 94);      // Koyu Gri
        public static Color Accent = Color.FromArgb(230, 126, 34);       // Turuncu

        // Arka Plan
        public static Color Background = Color.FromArgb(236, 240, 241);  // Açık Gri
        public static Color CardBackground = Color.White;
        public static Color DarkBackground = Color.FromArgb(44, 62, 80); // Koyu

        // Durum Renkleri
        public static Color Success = Color.FromArgb(46, 204, 113);      // Yeşil
        public static Color SuccessHover = Color.FromArgb(39, 174, 96);  // Koyu Yeşil
        public static Color Danger = Color.FromArgb(231, 76, 60);        // Kırmızı
        public static Color Warning = Color.FromArgb(241, 196, 15);      // Sarı
        public static Color Info = Color.FromArgb(52, 152, 219);         // Açık Mavi
        public static Color SecondaryHover = Color.FromArgb(44, 62, 80); // Koyu Gri

        // Text
        public static Color TextPrimary = Color.FromArgb(44, 62, 80);    // Koyu
        public static Color TextSecondary = Color.FromArgb(127, 140, 141); // Gri
        public static Color TextLight = Color.White;

        // Koltuk Renkleri
        public static Color KoltukBos = Color.FromArgb(46, 204, 113);      // Yeşil
        public static Color KoltukDolu = Color.FromArgb(149, 165, 166);    // Gri
        public static Color KoltukSecili = Color.FromArgb(52, 152, 219);   // Mavi
        public static Color KoltukHover = Color.FromArgb(88, 214, 141);    // Açık Yeşil

        /// <summary>
        /// DevExpress default tema/skin ayarla
        /// </summary>
        public static void ApplyDefaultSkin()
        {
            // Office 2019 Colorful teması - modern ve profesyonel
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
        }

        /// <summary>
        /// Belirli bir DevExpress skin uygular
        /// Kullanılabilir skinler: "Office 2019 Colorful", "WXI", "Office 2019 Black", "The Bezier", vb.
        /// </summary>
        public static void ApplySkin(string skinName)
        {
            UserLookAndFeel.Default.SetSkinStyle(skinName);
        }

        /// <summary>
        /// Kullanılabilir tüm DevExpress skin isimlerini döndürür
        /// </summary>
        public static string[] GetAvailableSkins()
        {
            var skinNames = new List<string>();
            foreach (SkinContainer skin in SkinManager.Default.Skins)
            {
                skinNames.Add(skin.SkinName);
            }
            return skinNames.ToArray();
        }

        /// <summary>
        /// Mevcut aktif skin adını döndürür
        /// </summary>
        public static string GetCurrentSkinName()
        {
            return UserLookAndFeel.Default.ActiveSkinName;
        }
    }
}
