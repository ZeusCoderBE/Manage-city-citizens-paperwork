using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyCDTP
{
    public class SoHoKhau
    {
        private string mshokhau;
        private int masoto;
        private string cccd;
        private int douutien;
        private int ngay;
        private int thang;
        private int nam;
        private int cccdnguoidangky;
        private string sodangky;
        private string dato;
        private string noidangky;
        public SoHoKhau(string mshokhau, int masoto, string cccd, int douutien,int ngay,int thang,int nam,int cccdnguoidangky,string sodangky,string dato,string noidangky)
        {
            this.mshokhau = mshokhau.Trim();
            this.masoto = masoto;
            this.cccd = cccd.Trim();
            this.douutien = douutien;
            this.ngay = ngay;
            this.thang = thang;
            this.nam = nam;
            this.cccdnguoidangky = cccdnguoidangky;
            this.sodangky = sodangky.Trim();
            this.dato = dato.Trim();
            this.noidangky = noidangky.Trim();
        }
 
        public string Cccd
        {
            get => cccd;
            
        }
        public string DatO
        {
            get => dato;

        }
        public int DoUuTien
        {
            get => douutien;
            
        }

        public int MaSoTo
        {
            get => masoto;
            
        }

        public string MsHoKhau
        {
            get => mshokhau;
        }

        public int Ngay
        {
            get => ngay;
        }

        public int Thang
        {
            get => thang;
        }

        public int Nam
        {
            get => nam;
           
        }

        public int CccdNguoiDangKy
        {
            get => cccdnguoidangky;
            
        }

        public string SoDangKy
        {
            get => sodangky;
            
        }
        public string NoiDangKy
        {
            get => noidangky;

        }
    }
}