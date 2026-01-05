using DevExpress.XtraEditors;
using DevExpress.XtraBars.Alerter;
using DevExpress.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Helper
{
    /// <summary>
    /// DevExpress kontrolleri için UI yardımcı metodlar
    /// UIHelper.cs'in DevExpress versiyonu
    /// </summary>
    public static class DevExpressUIHelper
    {
        /// <summary>
        /// DevExpress SimpleButton oluşturur (modern stil)
        /// </summary>
        public static SimpleButton CreateModernButton(string text, Color backColor, Color foreColor, int width = 150, int height = 45)
        {
            var btn = new SimpleButton
            {
                Text = text,
                Size = new Size(width, height),
                Appearance = {
                    BackColor = backColor,
                    ForeColor = foreColor,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Options = {
                        UseBackColor = true,
                        UseForeColor = true,
                        UseFont = true
                    }
                },
                Cursor = Cursors.Hand,
                AllowFocus = false
            };

            return btn;
        }

        /// <summary>
        /// DevExpress TextEdit oluşturur (modern stil)
        /// </summary>
        public static TextEdit CreateModernTextEdit(string placeholder, bool isPassword = false)
        {
            var txt = new TextEdit
            {
                Properties = {
                    NullValuePrompt = placeholder,
                    NullValuePromptShowForEmptyValue = true,
                    Appearance = {
                        Font = new Font("Segoe UI", 11F),
                        BackColor = Color.FromArgb(236, 240, 241),
                        ForeColor = DevExpressTheme.TextPrimary,
                        Options = {
                            UseFont = true,
                            UseBackColor = true,
                            UseForeColor = true
                        }
                    }
                },
                Height = 40
            };

            if (isPassword)
            {
                txt.Properties.PasswordChar = '●';
                txt.Properties.UseSystemPasswordChar = false;
            }

            return txt;
        }

        /// <summary>
        /// DevExpress LabelControl oluşturur
        /// </summary>
        public static LabelControl CreateLabel(string text, Font? font = null, Color? foreColor = null)
        {
            var lbl = new LabelControl
            {
                Text = text,
                Appearance = {
                    Font = font ?? new Font("Segoe UI", 11F),
                    ForeColor = foreColor ?? DevExpressTheme.TextPrimary,
                    Options = {
                        UseFont = true,
                        UseForeColor = true
                    }
                },
                AutoSizeMode = LabelAutoSizeMode.None,
                AllowHtmlString = true
            };

            return lbl;
        }

        /// <summary>
        /// DevExpress PanelControl oluşturur (gradient arka plan ile)
        /// </summary>
        public static PanelControl CreateGradientPanel(Color color1, Color color2, bool isHorizontal = false)
        {
            var panel = new PanelControl
            {
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };

            // DevExpress gradient support
            panel.Appearance.BackColor = color1;
            panel.Appearance.BackColor2 = color2;
            panel.Appearance.GradientMode = isHorizontal
                ? System.Drawing.Drawing2D.LinearGradientMode.Horizontal
                : System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            panel.Appearance.Options.UseBackColor = true;

            return panel;
        }

        /// <summary>
        /// SimpleButton'a hover efekti ekler
        /// </summary>
        public static void AddHoverEffect(SimpleButton? button, Color normalColor, Color hoverColor)
        {
            if (button == null) return;

            button.Appearance.BackColor = normalColor;
            button.Appearance.Options.UseBackColor = true;

            button.MouseEnter += (s, e) =>
            {
                if (button.IsDisposed) return;
                button.Appearance.BackColor = hoverColor;
            };

            button.MouseLeave += (s, e) =>
            {
                if (button.IsDisposed) return;
                button.Appearance.BackColor = normalColor;
            };
        }

        /// <summary>
        /// DevExpress AlertControl ile toast notification gösterir
        /// UIHelper.ShowToast()'un DevExpress versiyonu
        /// </summary>
        public static void ShowToast(Form? parentForm, string message, AlertType type = AlertType.Success, int duration = 3000)
        {
            if (parentForm == null || parentForm.IsDisposed) return;
            if (string.IsNullOrWhiteSpace(message)) return;

            try
            {
                AlertControl alertControl = new AlertControl();

                // Alert properties
                alertControl.AutoFormDelay = duration;
                alertControl.AllowHotTrack = false;
                alertControl.ShowPinButton = false;
                alertControl.ShowCloseButton = true;

                // Renk ve ikon ayarları
                Color bgColor = type switch
                {
                    AlertType.Success => DevExpressTheme.Success,
                    AlertType.Error => DevExpressTheme.Danger,
                    AlertType.Warning => DevExpressTheme.Warning,
                    AlertType.Info => DevExpressTheme.Info,
                    _ => DevExpressTheme.Primary
                };

                // Alert göster
                AlertInfo info = new AlertInfo("SİNEMACİ", message);
                // DevExpress AlertControl otomatik olarak tema renklerini kullanır

                alertControl.Show(parentForm, info);
            }
            catch
            {
                // AlertControl başarısız olursa sessizce devam et
            }
        }

        /// <summary>
        /// XtraForm'a fade-in animasyonu ekler
        /// </summary>
        public static void FadeIn(XtraForm form, int duration = 500)
        {
            form.Opacity = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 10 };
            int steps = duration / 10;
            int currentStep = 0;

            timer.Tick += (s, e) =>
            {
                currentStep++;
                form.Opacity = (double)currentStep / steps;
                if (currentStep >= steps)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };
            timer.Start();
        }
    }

    /// <summary>
    /// Toast notification türleri
    /// </summary>
    public enum AlertType
    {
        Success,
        Error,
        Warning,
        Info
    }
}
