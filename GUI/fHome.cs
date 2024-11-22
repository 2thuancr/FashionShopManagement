﻿using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fHome : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static Account LoginAccount { get; set; }

        public fHome()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Chỉ hiện thị những menu mà Account có quyền thực hiện.

            _baseForm = new BaseForm();
        }

        private void MOVE_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Account này có quyền mở Menu hay không
            int accountTypeId = fHome.LoginAccount.TypeID;
            bool isHasPermission = AccountTypePermissionBUS.Instance.CheckPermissionByAccountTypeId(accountTypeId, "MenuSanPham");
            if (isHasPermission == false)
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            

            fSanPham fSanPham = new fSanPham(); 
            fSanPham.Show();
        }

        private void btn_DonHang_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Account này có quyền mở Menu hay không
            int accountTypeId = fHome.LoginAccount.TypeID;
            bool isHasPermission = AccountTypePermissionBUS.Instance.CheckPermissionByAccountTypeId(accountTypeId, "MenuDonHang");
            if (isHasPermission == false)
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            fDonHang fDonHang = new fDonHang();
            fDonHang.Show();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Account này có quyền mở Menu hay không
            int accountTypeId = fHome.LoginAccount.TypeID;
            bool isHasPermission = AccountTypePermissionBUS.Instance.CheckPermissionByAccountTypeId(accountTypeId, "MenuKhachHang");
            if (isHasPermission == false)
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            fKhachHang fKhachHang = new fKhachHang();
            fKhachHang.Show();
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Account này có quyền mở Menu hay không
            int accountTypeId = fHome.LoginAccount.TypeID;
            bool isHasPermission = AccountTypePermissionBUS.Instance.CheckPermissionByAccountTypeId(accountTypeId, "MenuNhanVien");
            if (isHasPermission == false)
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            fNhanVien fNhanVien = new fNhanVien();
            fNhanVien.Show();
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Account này có quyền mở Menu hay không
            int accountTypeId = fHome.LoginAccount.TypeID;
            bool isHasPermission = AccountTypePermissionBUS.Instance.CheckPermissionByAccountTypeId(accountTypeId, "MenuBaoCao");
            if (isHasPermission == false)
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                return;
            }

            fBaoCao fBaoCao = new fBaoCao();
            fBaoCao.ShowDialog();
        }

        private void btn_CaiDat_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Account này có quyền mở Menu hay không
            int accountTypeId = fHome.LoginAccount.TypeID;
            bool isHasPermission = AccountTypePermissionBUS.Instance.CheckPermissionByAccountTypeId(accountTypeId, "MenuCaiDat");
            if (isHasPermission == false)
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            FPhanCa fPhanCa = new FPhanCa();
            fPhanCa.Show();
        }

        private void fHome_Load(object sender, EventArgs e)
        {
            try
            {
                if (LoginAccount != null)
                {
                    var accountType = AccountTypeBUS.Instance.GetAccountTypeById(LoginAccount.TypeID);
                    if (accountType != null)
                    {
                        this.label_UserName.Text = $"{LoginAccount.UserName} ({accountType.TypeName})";
                    }
                    else
                    {
                        this.label_UserName.Text = $"{LoginAccount.UserName} ({LoginAccount.TypeID})";
                    }

                    this.label_Role.Text = Account.ConnectionName;
                }
            }
           catch(Exception) {
                MessageBox.Show("Có lỗi phát sinh");
            }
        }

        private void btn_ChienDich_Click(object sender, EventArgs e)
        {
            fCampaign fCampaign = new fCampaign();
            fCampaign.Show();
        }


        private BaseForm _baseForm;
        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Language.SelectedItem != null)  // Kiểm tra trước khi sử dụng
            {
                if (comboBox_Language.SelectedItem.ToString() == "EN")
                {
                    _baseForm.ChangeLanguage("en");
                    _baseForm.UpdateControlsLanguage(this);
                }
                else if (comboBox_Language.SelectedItem.ToString() == "VI")
                {
                    _baseForm.ChangeLanguage("vi");
                    _baseForm.UpdateControlsLanguage(this);
                }
            }
            else
            {
                MessageBox.Show("Không có ngôn ngữ được chọn.");
            }
        }
    }
}
