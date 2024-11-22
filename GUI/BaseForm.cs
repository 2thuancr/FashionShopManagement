using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI
{
    // BaseForm.cs
    public class BaseForm
    {
        private ResourceManager _resourceManager;

        public BaseForm()
        {
            // Khởi tạo ResourceManager nếu cần thiết
            _resourceManager = new ResourceManager("GUI.Resource", typeof(BaseForm).Assembly);
        }

        // Phương thức thay đổi ngôn ngữ
        public void ChangeLanguage(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        }

        // Cập nhật ngôn ngữ cho các control trên form
        public void UpdateControlsLanguage(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control.Tag != null)
                {
                    string resourceKey = control.Tag.ToString();
                    string localizedText = _resourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentUICulture);
                    if (localizedText != null)
                    {
                        control.Text = localizedText;
                    }
                }

                if (control.Controls.Count > 0)
                {
                    UpdateControlsLanguage(control);
                }
            }
        }
    }

}
