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
    public partial class pagecode_employee_address_edit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                loadKodeKabKerja();
                fillData1(Session["nrp1"].ToString());
              
            }
        }

        public static string Base64Decode1(string base64EncodedData)
        {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        void fillData1(String nrp1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/employeeaddress/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.Timeout = 10000;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string vac1="", vac2="";
                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listEmployeeAddress1>(jsonstr);
                for (int i = 0; i <= result1.GetEmployeeAddressDataResult.Count - 1; i++)
                {
                    if(String.IsNullOrEmpty(result1.GetEmployeeAddressDataResult[i].vacshot1)==false)
                    {
                        vac1 = Convert.ToDateTime(Base64Decode1(result1.GetEmployeeAddressDataResult[i].vacshot1)).ToString("dd-MMM-yyyy");
                    }

                    if (String.IsNullOrEmpty(result1.GetEmployeeAddressDataResult[i].vacshot2) == false)
                    {
                        vac2 = Convert.ToDateTime(Base64Decode1(result1.GetEmployeeAddressDataResult[i].vacshot2)).ToString("dd-MMM-yyyy");
                    }

                    hidID1.Value = result1.GetEmployeeAddressDataResult[i].id1;
                    //ddlGender1.SelectedValue  = Base64Decode1(result1.GetFamilyMemberDataResult[i].jeniskelamin1);
                    txtAlamat1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].alamat1);
                    txtKelurahan1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kelurahan1);
                    txtKecamatan1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kecamatan1);
                    txtKabupatenKota1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kab_kota1);
                    txtPropinsi1.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].propinsi1);
                    txtNIK.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].nik1);
                    txtNoHP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].nohp1);
                    txtAlamatKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].alamatktp1);
                    txtKabKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kabkotaktp1);
                    txtKecamatanKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kecamatanktp1);
                    txtKelurahanKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kelurahanktp1);
                    txtPropinsiKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].propinsiktp1);
                    txtEmailPriv.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].emailpriv1);
                    ddlCustJourney.SelectedValue = Base64Decode1(result1.GetEmployeeAddressDataResult[i].custjourney1);
                    ddlStatusNikah.SelectedValue = Base64Decode1(result1.GetEmployeeAddressDataResult[i].statuskawin1);
                    txtNamaKTP.Text = Base64Decode1(result1.GetEmployeeAddressDataResult[i].namaktp1);
                    ddlKabKotaKerja.SelectedValue = Base64Decode1(result1.GetEmployeeAddressDataResult[i].kodekabkerja1);
                    ddlVaccineProvider.SelectedValue = Base64Decode1(result1.GetEmployeeAddressDataResult[i].vacprovider1);
                    //String vac1 = Convert.ToDateTime(Base64Decode1(result1.GetEmployeeAddressDataResult[i].vacshot1)).ToString("dd-MMM-yyyy");
                    //String vac2 = Convert.ToDateTime(Base64Decode1(result1.GetEmployeeAddressDataResult[i].vacshot2)).ToString("dd-MMM-yyyy");
                    
                    if(vac1 == "01-Jan-1900" || String.IsNullOrEmpty(vac1) == true)
                    {
                        txtVac1.Text = "";
                    }
                    else
                    {
                        txtVac1.Text = vac1;
                    }

                    if(vac2 == "01-Jan-1900" || String.IsNullOrEmpty(vac2) == true)
                    {
                        txtVac2.Text = "";
                    }
                    else
                    {
                        txtVac2.Text = vac2;
                    }
                    

                    if (Base64Decode1(result1.GetEmployeeAddressDataResult[i].vac1) == "1")
                    {
                        chkVac.Checked = true;
                    }
                    else
                    {
                        chkVac.Checked = false;
                    }

                    if (Base64Decode1(result1.GetEmployeeAddressDataResult[i].vacbefore1) == "1")
                    {
                        ddlVaccineBefore.SelectedValue = "1";
                        ddlVaccineProvider.Enabled = true;
                        txtVac1.Enabled = true;
                        txtVac2.Enabled = true;

                        ddlVaccineProvider.BackColor = Color.White;
                        txtVac1.BackColor = Color.White;
                        txtVac2.BackColor = Color.White;
                    }
                    else
                    {
                        ddlVaccineBefore.SelectedValue = "0";
                        ddlVaccineProvider.Enabled = false;
                        txtVac1.Enabled = false;
                        txtVac2.Enabled = false;

                        ddlVaccineProvider.BackColor = Color.DarkGray;
                        txtVac1.BackColor = Color.DarkGray;
                        txtVac2.BackColor = Color.DarkGray;
                    }

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

        public class listKotaKabKerja1
        {
            public List<GetlistKotaKerja1> GetListKabKotaKerjaResult { get; set; }
        }

        public class GetlistKotaKerja1
        {
            public string kodekabkotakerja1 { get; set; }
            public string namakabkotakerja1 { get; set; }
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
            public string vac1 { get; set; }
            public string alamatktp1 { get; set; }
            public string kabkotaktp1 { get; set; }
            public string kecamatanktp1 { get; set; }
            public string kelurahanktp1 { get; set; }
            public string propinsiktp1 { get; set; }
            public string emailpriv1 { get; set; }
            public string vacbefore1 { get; set; }
            public string statuskawin1 { get; set; }
            public string custjourney1 { get; set; }
            public string namaktp1 { get; set; }
            public string vacprovider1 { get; set; }
            public string kodekabkerja1 { get; set; }
            public string vacshot1 { get; set; }
            public string vacshot2 { get; set; }
        }

        protected void cmdSave1_Click(object sender, EventArgs e)
        {
            int i;
            string parvacprov1,parshot1,parshot2;
            if (String.IsNullOrEmpty(txtAlamat1.Text.Trim()) == false && string.IsNullOrEmpty(txtKelurahan1.Text.Trim()) == false
               && String.IsNullOrEmpty(txtKecamatan1.Text.Trim()) == false && String.IsNullOrEmpty(txtKabupatenKota1.Text.Trim()) == false
               && String.IsNullOrEmpty(txtPropinsi1.Text.Trim()) == false && String.IsNullOrEmpty(txtNIK.Text.Trim()) == false
               && String.IsNullOrEmpty(txtNoHP.Text.Trim()) == false && String.IsNullOrEmpty(txtAlamatKTP.Text) == false
               && String.IsNullOrEmpty(txtKabKTP.Text.Trim()) == false && String.IsNullOrEmpty(txtKecamatanKTP.Text.Trim()) == false 
               && String.IsNullOrEmpty(txtKelurahanKTP.Text.Trim()) == false && String.IsNullOrEmpty(txtPropinsiKTP.Text.Trim()) == false
               && String.IsNullOrEmpty(txtEmailPriv.Text.Trim()) == false && ddlKabKotaKerja.SelectedValue != ""
               && txtNIK.Text.Length == 16 && String.IsNullOrEmpty(txtNamaKTP.Text.Trim()) == false )
            {
                if(chkVac.Checked==true)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }

                if(ddlVaccineBefore.SelectedValue == "1")
                {
                    parvacprov1 = ddlVaccineProvider.SelectedValue;
                    parshot1 = txtVac1.Text.Trim();
                    parshot2 = txtVac2.Text.Trim();
                }
                else
                {
                    parvacprov1 = "";
                    parshot1 = "";
                    parshot2 = "";
                }

                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/empaddressupdate";
                object input = new
                {
                    id1 = hidID1.Value,
                    nrpemployee1 = Session["nrp1"].ToString(),
                    alamat1 = txtAlamat1.Text.Trim(),
                    kelurahan1 = txtKelurahan1.Text.Trim(),
                    kecamatan1 = txtKecamatan1.Text.Trim(),
                    kabkota1 = txtKabupatenKota1.Text.Trim(),
                    propinsi1 = txtPropinsi1.Text.Trim(),
                    nohp1 = txtNoHP.Text.Trim(),
                    nik1 = txtNIK.Text.Trim(),
                    vac1 = i,
                    alamatktp1 = txtAlamatKTP.Text.Trim(),
                    kelurahanktp1 = txtKelurahanKTP.Text.Trim(),
                    kecamatanktp1 = txtKecamatanKTP.Text.Trim(),
                    kabkotaktp1 = txtKabKTP.Text.Trim(),
                    propinsiktp1 = txtPropinsiKTP.Text.Trim(),
                    emailpriv1 = txtEmailPriv.Text.Trim(),
                    vacbefore1 = ddlVaccineBefore.SelectedValue,
                    statusnikah1 = ddlStatusNikah.SelectedValue,
                    custjourney1 = ddlCustJourney.SelectedValue,
                    vaccine_provider1 = parvacprov1,
                    namektp1 = txtNamaKTP.Text.Trim(),
                    kodekabkerja1 = ddlKabKotaKerja.SelectedValue,
                    shot1 = parshot1,
                    shot2 = parshot2
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
                popUpMsgBox_Redirect("Data Updated");
            }
            else
            {
                popUpMsgBox("Semua field harus diisi");
            }
        }
        void popUpMsgBox_Redirect(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='profile_employee.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
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

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected void ddlVaccineBefore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlVaccineBefore.SelectedValue=="0")
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
    }
}