using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_family_list_add : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadKodeKabKerja();
            ddlVaccineProvider.Enabled = false;
            txtVac1.Enabled = false;
            txtVac2.Enabled = false;

            ddlVaccineProvider.BackColor = Color.DarkGray;
            txtVac1.BackColor = Color.DarkGray;
            txtVac2.BackColor = Color.DarkGray;
        }

        protected void cmdSave1_Click(object sender, EventArgs e)
        {
            int i;
            string parvacprovider1, parvacshot1, parvacshot2;
            if (String.IsNullOrEmpty(txtNama1.Text.Trim()) == true || String.IsNullOrEmpty(txtNIK1.Text.Trim()) == true
               || String.IsNullOrEmpty(txtTempatLahir1.Text.Trim()) || String.IsNullOrEmpty(txtTglLahir1.Text.Trim()) == true
               || String.IsNullOrEmpty(ddlGender1.SelectedValue) == true || String.IsNullOrEmpty(ddlGender1.SelectedValue) == true
               || String.IsNullOrEmpty(txtAlamat1.Text.Trim()) == true || String.IsNullOrEmpty(txtKelurahan1.Text.Trim()) == true
               || String.IsNullOrEmpty(txtKecamatan1.Text.Trim()) == true || String.IsNullOrEmpty(txtKabupatenKota1.Text.Trim()) == true
               || String.IsNullOrEmpty(txtPropinsi1.Text.Trim()) == true || String.IsNullOrEmpty(txtHP1.Text) == true
               || String.IsNullOrEmpty(txtEmailPriv.Text.Trim()) == true)
            {
                popUpMsgBox("Semua data harus diisi");
            }
            else
            {
                if (txtNIK1.Text.Trim().Length < 16)
                {
                    popUpMsgBox("NIK harus 16 karakter");
                }
                else
                {
                    if (chkVac.Checked == true)
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                    }

                    if(ddlVaccineBefore.SelectedValue=="0")
                    {
                        parvacprovider1 = "";
                        parvacshot1 = "";
                        parvacshot2 = "";
                    }
                    else
                    {
                        parvacprovider1 = ddlVaccineProvider.SelectedValue;
                        parvacshot1 = txtVac1.Text.Trim();
                        parvacshot2 = txtVac2.Text.Trim();
                    }

                    AddData(ddlType1.SelectedValue, txtTglLahir1.Text.Trim(), txtTempatLahir1.Text.Trim(), "ID", ddlGender1.SelectedValue,
                        txtJob1.Text.Trim(), txtNIK1.Text.Trim(), txtNama1.Text.Trim(), txtHP1.Text.Trim(), "", Session["nrp1"].ToString(),
                        txtAlamat1.Text.Trim(), txtKelurahan1.Text.Trim(), txtKecamatan1.Text.Trim(),
                        txtKabupatenKota1.Text.Trim(), txtPropinsi1.Text.Trim(), txtAlamatKTP.Text.Trim(), txtKelurahanKTP.Text.Trim(),
                        txtKecamatanKTP.Text.Trim(), txtKabKTP.Text.Trim(), txtPropinsiKTP.Text.Trim(), i, txtEmailPriv.Text.Trim(), ddlVaccineBefore.SelectedValue,
                        ddlStatusNikah.SelectedValue, ddlCustJourney.SelectedValue, ddlKabKotaKerja.SelectedValue, parvacprovider1,
                        parvacshot1, parvacshot2);

                    popUpMsgBox_Redirect("Data Saved");
                }
            }
        }

        void UpdateFamilyAddress(String parid1, String paridfamily1, string paralamat1, string parkelurahan1, string parkecamatan1,
          string parkabkota1, string parpropinsi1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/famaddressupdate";
            object input = new
            {
                id1 = parid1,
                idfamily1 = paridfamily1,
                alamat1 = paralamat1,
                kelurahan1 = parkelurahan1,
                kecamatan1 = parkecamatan1,
                kabkota1 = parkabkota1,
                propinsi1 = parpropinsi1
            };
            string inputJson = JsonConvert.SerializeObject(input);

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            byte[] bytes = Encoding.UTF8.GetBytes(inputJson);

            using (Stream stream = httpRequest.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }

            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (Stream stream = httpResponse.GetResponseStream())
                {
                    //hidID1.Value = (new StreamReader(stream)).ReadToEnd();
                }
            }
        }

        void AddData(string type1,string dateofbirth1, string birthplace1 , string cityofbirth1 , string gender1 , string jobtype1,
            string nik1 , string nama1 , string nohp1 , string dateofmarried1 , string nrpemployee1,string paralamat1,string parkelurahan1,
            string parkecamatan1,string parkabkota1,string parpropinsi1, string paralamatktp1, string parkelurahanktp1,
            string parkecamatanktp1, string parkabkotaktp1, string parpropinsiktp1,int parvac1,string paremailpriv1, string parvacbefore1,
            string parstatusnikah1,string parcustjourney1,string parkabkodekerja1,string parvacprovider1,string parvacshot1,string parvacshot2)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/familymemberadd";
            if(parvacbefore1 == "0")
            {
                parvacprovider1 = "";
                parvacshot1 = "";
                parvacshot2 = "";
            }

            object input = new
            {
                type1 = type1,
                dateofbirth1 = dateofbirth1,
                birthplace1 = birthplace1,
                cityofbirth1 = cityofbirth1,
                gender1 = gender1,
                jobtype1 = jobtype1,
                nik1 = nik1,
                nama1 = nama1,
                nohp1 = nohp1,
                dateofmarried1 = dateofmarried1,
                nrp1 = nrpemployee1,
                alamat1 = paralamat1,
                kelurahan1 = parkelurahan1,
                kecamatan1 = parkecamatan1,
                kabkota1 = parkabkota1,
                propinsi1 = parpropinsi1,
                alamatktp1 = paralamatktp1,
                kelurahanktp1 = parkelurahanktp1,
                kecamatanktp1 = parkecamatanktp1,
                kabkotaktp1 = parkabkotaktp1,
                propinsiktp1 = parpropinsiktp1,
                vac1 = parvac1,
                emailpriv1 = paremailpriv1,
                vacbefore1 = parvacbefore1,
                statusnikah1 = parstatusnikah1,
                custjourney1 = parcustjourney1,
                kodekabkerja1 = parkabkodekerja1,
                vacprovider1 = parvacprovider1,
                vacshot1 = parvacshot1,
                vacshot2 = parvacshot2

            };
            string inputJson = JsonConvert.SerializeObject(input);

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            byte[] bytes = Encoding.UTF8.GetBytes(inputJson);

            using (Stream stream = httpRequest.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }

            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (Stream stream = httpResponse.GetResponseStream())
                {
                    //hidID1.Value = (new StreamReader(stream)).ReadToEnd();
                }
            }
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("')};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        void popUpMsgBox_Redirect(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='family_list.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        protected void cmdGetDataFromEmployee_Click(object sender, EventArgs e)
        {
            fillDataAddressFromEmployee1(Session["nrp1"].ToString());
        }

        void fillDataAddressFromEmployee1(String nrp1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/employeeaddress/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.Timeout = 10000;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listEmployeeAddress1>(jsonstr);
                for (int i = 0; i <= result1.GetEmployeeAddressDataResult.Count - 1; i++)
                {

                    //ddlGender1.SelectedValue  = Base64Decode1(result1.GetFamilyMemberDataResult[i].jeniskelamin1);
                    txtAlamat1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].alamat1);
                    txtKelurahan1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kelurahan1);
                    txtKecamatan1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kecamatan1);
                    txtKabupatenKota1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kab_kota1);
                    txtPropinsi1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].propinsi1);
                    txtAlamatKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].alamatktp1);
                    txtKelurahanKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kelurahanktp1);
                    txtKecamatanKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kecamatanktp1);
                    txtKabKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kabkotaktp1);
                    txtPropinsiKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].propinsiktp1);
                }
            }
        }

        void loadKodeKabKerja()
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listkabkotakerja";
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);

                var result1 = JsonConvert.DeserializeObject<listKotaKabKerja1>(jsonstr);
                ddlKabKotaKerja.Items.Add(new ListItem("Pilih Kab/Kota Kerja", ""));

                if (result1.GetListKabKotaKerjaResult[0].kodekabkotakerja1.ToString() != "")
                {
                    for (int i = 0; i <= result1.GetListKabKotaKerjaResult.Count - 1; i++)
                    {
                        ddlKabKotaKerja.Items.Add(new ListItem(result1.GetListKabKotaKerjaResult[i].namakabkotakerja1,
                            result1.GetListKabKotaKerjaResult[i].kodekabkotakerja1));
                    }
                }
            }

        }

        public class listEmployeeAddress1
        {
            public List<employeeAddress1> GetEmployeeAddressDataResult { get; set; }
        }

        public class employeeAddress1
        {
            public string alamat1 { get; set; }
            public string id1 { get; set; }
            public string kab_kota1 { get; set; }
            public string kecamatan1 { get; set; }
            public string kelurahan1 { get; set; }
            public string nohp1 { get; set; }
            public string nrpemployee1 { get; set; }
            public string propinsi1 { get; set; }
            public string nik1 { get; set; }
            public string alamatktp1 { get; set; }
            public string kelurahanktp1 { get; set; }
            public string kecamatanktp1 { get; set; }
            public string kabkotaktp1 { get; set; }
            public string propinsiktp1 { get; set; }

        }

        public class listKotaKabKerja1
        {
            public List<GetlistKotaKerja1> GetListKabKotaKerjaResult { get; set; }
        }

        public class GetlistKotaKerja1
        {
            public string kodekabkotakerja1 { get; set; }
            public string namakabkotakerja1 { get; set; }
        }

        public static string Base64Decode1(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected void ddlVaccineBefore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVaccineBefore.SelectedValue == "0")
            {

                ddlVaccineProvider.Enabled = false;
                txtVac1.Enabled = false;
                txtVac2.Enabled = false;

                ddlVaccineProvider.BackColor = Color.DarkGray;
                txtVac1.BackColor = Color.DarkGray;
                txtVac2.BackColor = Color.DarkGray;

            }
            else
            {
                ddlVaccineProvider.Enabled = true;
                txtVac1.Enabled = true;
                txtVac2.Enabled = true;

                ddlVaccineProvider.BackColor = Color.White;
                txtVac1.BackColor = Color.White;
                txtVac2.BackColor = Color.White;
            }
            updVaccineData.Update();
        }

        //protected void ddlType1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if(ddlType1.SelectedValue=="1")
        //    //{
        //    //    ddlNumber1.Enabled = false;
        //    //    ddlNumber1.BackColor = Color.DarkGray;
        //    //}
        //    //else if (ddlType1.SelectedValue == "2")
        //    //{
        //    //    ddlNumber1.Enabled = true;
        //    //    ddlNumber1.BackColor = Color.White;
        //    //}
        //    //updDdlNumber1.Update();
        //}
    }
}