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
    public partial class pagecode_family_list_edit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String reqID1 = Request["id1"];
            if (Page.IsPostBack == false)
            {
                loadKodeKabKerja();
                fillData1(reqID1);
                fillData2(reqID1);
            }
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



        void fillData1(String id1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/familymember/" + id1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.Timeout = 10000;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listfamily1>(jsonstr);
                String status2 = "", jeniskelamin1 = "" , vacshot1,vacshot2;
                for (int i = 0; i <= result1.GetFamilyMemberDataResult.Count - 1; i++)
                {
                    if (Base64Decode1(result1.GetFamilyMemberDataResult[i].status1) == "1")
                    {
                        status2 = "Suami/Istri";
                    }
                    else if (Base64Decode1(result1.GetFamilyMemberDataResult[i].status1) == "2")
                    {
                        status2 = "Anak";
                    }
                    else if (Base64Decode1(result1.GetFamilyMemberDataResult[i].status1) == "3")
                    {
                        status2 = "Istri";
                    }

                    if (Base64Decode1(result1.GetFamilyMemberDataResult[i].jeniskelamin1) == "Lelaki")
                    {
                        jeniskelamin1 = "1";
                    }
                    else
                    {
                        jeniskelamin1 = "2";
                    }

                    hidID1.Value = result1.GetFamilyMemberDataResult[i].idfamily1;
                    //ddlGender1.SelectedValue  = Base64Decode1(result1.GetFamilyMemberDataResult[i].jeniskelamin1);
                    ddlGender1.SelectedValue = jeniskelamin1;
                    txtNama1.Text = Base64Decode1(result1.GetFamilyMemberDataResult[i].nama1);
                    ddlType1.SelectedValue = Base64Decode1(result1.GetFamilyMemberDataResult[i].status1);
                    //ddlType1.SelectedItem.Text = status2;
                    txtTempatLahir1.Text = Base64Decode1(result1.GetFamilyMemberDataResult[i].tempatlahir1);
                    txtTglLahir1.Text = Convert.ToDateTime(Base64Decode1(result1.GetFamilyMemberDataResult[i].tgllahir1)).ToString("dd-MMM-yyyy");
                    txtHP1.Text = Base64Decode1(result1.GetFamilyMemberDataResult[i].nohp1);
                    txtJob1.Text = Base64Decode1(result1.GetFamilyMemberDataResult[i].job1);
                    txtNIK1.Text = Base64Decode1(result1.GetFamilyMemberDataResult[i].nik1);
                    ddlNumber1.SelectedValue = Base64Decode1(result1.GetFamilyMemberDataResult[i].num1);
                    txtEmailPriv.Text = Base64Decode1(result1.GetFamilyMemberDataResult[i].emailpriv1);
                    ddlStatusNikah.SelectedValue = Base64Decode1(result1.GetFamilyMemberDataResult[i].statusnikah1);
                    ddlCustJourney.SelectedValue = Base64Decode1(result1.GetFamilyMemberDataResult[i].custjourney1);
                    ddlKabKotaKerja.SelectedValue = Base64Decode1(result1.GetFamilyMemberDataResult[i].kodekabkerja1);
                    ddlVaccineProvider.SelectedValue = Base64Decode1(result1.GetFamilyMemberDataResult[i].vacprovider1);
                    vacshot1 = Base64Decode1(result1.GetFamilyMemberDataResult[i].vacshot1);
                    vacshot2 = Base64Decode1(result1.GetFamilyMemberDataResult[i].vacshot2);

                    if (vacshot1 == "01-Jan-1900")
                    {
                        txtVac1.Text = "";
                    }
                    else
                    {
                        txtVac1.Text = vacshot1;
                    }

                    if (vacshot2 == "01-Jan-1900")
                    {
                        txtVac2.Text = "";
                    }
                    else
                    {
                        txtVac2.Text = vacshot2;
                    }


                    if (ddlType1.SelectedValue == "1")
                    {
                        ddlNumber1.Enabled = false;
                        ddlNumber1.BackColor = Color.DarkGray;
                    }

                    if(result1.GetFamilyMemberDataResult[i].vac1 == "1")
                    {
                        chkVac.Checked = true;
                    }
                    else
                    {
                        chkVac.Checked = false;
                    }

                    if (result1.GetFamilyMemberDataResult[i].vacbefore1 == "1")
                    {
                        ddlVaccineBefore.SelectedValue = "1";
                    }
                    else
                    {
                        ddlVaccineBefore.SelectedValue = "0";
                    }

                    if (result1.GetFamilyMemberDataResult[i].vacbefore1 == "1")
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

        public class listfamily1
        {
            public List<family1> GetFamilyMemberDataResult { get; set; }
        }

        public class family1
        {
            public string idfamily1 { get; set; }
            public string jeniskelamin1 { get; set; }
            public string nama1 { get; set; }
            public string negarakelahiran1 { get; set; }
            public string status1 { get; set; }
            public string tempatlahir1 { get; set; }
            public string tgllahir1 { get; set; }
            public string job1 { get; set; }
            public string nik1 { get; set; }
            public string nohp1 { get; set; }
            public string num1 { get; set; }
            public string vac1 { get; set; }
            public string emailpriv1 { get; set; }
            public string vacbefore1 { get; set; }
            public string statusnikah1 { get; set; }
            public string custjourney1 { get; set; }
            public string kodekabkerja1 { get; set; }
            public string vacprovider1 { get; set; }
            public string vacshot1 { get; set; }
            public string vacshot2 { get; set; }

        }

        protected void cmdSave1_Click(object sender, EventArgs e)
        {
            string number2 = "";
            int i,i1;

            if(chkVac.Checked==true)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }

            if (ddlType1.SelectedValue == "1")
            {
                number2 = "";
            }
            else
            {
                number2 = ddlNumber1.SelectedValue;
            }

            if (ddlVaccineBefore.SelectedValue == "1")
            {
                i1 = 1;
            }
            else
            {
                i1= 0;
            }

            if (String.IsNullOrEmpty(txtNama1.Text.Trim()) == true || String.IsNullOrEmpty(txtNIK1.Text.Trim()) == true
               || String.IsNullOrEmpty(txtTempatLahir1.Text.Trim()) || String.IsNullOrEmpty(txtTglLahir1.Text.Trim()) == true
               || String.IsNullOrEmpty(ddlGender1.SelectedValue) == true || String.IsNullOrEmpty(ddlGender1.SelectedValue) == true
               || String.IsNullOrEmpty(txtAlamat1.Text.Trim()) == true || String.IsNullOrEmpty(txtKelurahan1.Text.Trim()) == true
               || String.IsNullOrEmpty(txtKecamatan1.Text.Trim()) == true || String.IsNullOrEmpty(txtKabupatenKota1.Text.Trim()) == true
               || String.IsNullOrEmpty(txtPropinsi1.Text.Trim()) == true || String.IsNullOrEmpty(txtAlamatKTP.Text.Trim()) == true
               || String.IsNullOrEmpty(txtKelurahanKTP.Text.Trim()) == true || String.IsNullOrEmpty(txtKecamatanKTP.Text.Trim()) == true
               || String.IsNullOrEmpty(txtKabKTP.Text.Trim()) == true || String.IsNullOrEmpty(txtPropinsiKTP.Text.Trim()) == true
               || String.IsNullOrEmpty(txtHP1.Text.Trim())==true || String.IsNullOrEmpty(txtEmailPriv.Text.Trim()) == true)

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
                    string parvacshot1, parvacshot2,parvacprovider;
                    if(ddlVaccineBefore.SelectedValue == "0")
                    {
                        parvacshot1 = "";
                        parvacshot2 = "";
                        parvacprovider = "";
                    }
                    else
                    {
                        parvacshot1 = txtVac1.Text.Trim();
                        parvacshot2 = txtVac2.Text.Trim();
                        parvacprovider = ddlVaccineProvider.SelectedValue;
                    }

                    var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/familymemberupdate";
                    object input = new
                    {
                        id1 = hidID1.Value,
                        type1 = ddlType1.SelectedValue,
                        number1 = number2,
                        dateofbirth1 = txtTglLahir1.Text,
                        birthplace1 = txtTempatLahir1.Text.Trim(),
                        cityofbirth1 = "ID",
                        gender1 = ddlGender1.SelectedValue,
                        jobtype1 = txtJob1.Text.Trim(),
                        nik1 = txtNIK1.Text.Trim(),
                        nama1 = txtNama1.Text.Trim(),
                        nohp1 = txtHP1.Text.Trim(),
                        dateofmarried1 = "",
                        vac1 = i,
                        emailpriv1 = txtEmailPriv.Text.Trim(),
                        vacbefore1 = i1,
                        statusnikah1 = ddlStatusNikah.SelectedValue,
                        custjourney1 = ddlCustJourney.SelectedValue,
                        kodekabkerja1 = ddlKabKotaKerja.SelectedValue,
                        vacprovider1 = parvacprovider,
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
                    UpdateFamilyAddress(hidID2.Value, hidIDFamily1.Value, txtAlamat1.Text.Trim(), txtKelurahan1.Text.Trim(),
                        txtKecamatan1.Text.Trim(), txtKabupatenKota1.Text.Trim(), txtPropinsi1.Text.Trim(),
                        txtAlamatKTP.Text.Trim(), txtKelurahanKTP.Text.Trim(), txtKecamatanKTP.Text.Trim(),
                        txtKabKTP.Text.Trim(), txtPropinsiKTP.Text.Trim());
                    popUpMsgBox_Redirect("Data Updated");
                }
            }
        }

        void UpdateFamilyAddress(String parid1, String paridfamily1, string paralamat1, string parkelurahan1, string parkecamatan1,
            string parkabkota1, string parpropinsi1, string paralamatktp1, string parkelurahanktp1, string parkecamatanktp1,
            string parkabkotaktp1, string parpropinsiktp1)
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
                propinsi1 = parpropinsi1,
                alamatktp1 = paralamatktp1,
                kelurahanktp1 = parkelurahanktp1,
                kecamatanktp1 = parkecamatanktp1,
                kabkotaktp1 = parkabkotaktp1,
                propinsiktp1 = parpropinsiktp1
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

        public class listFamilyAddress1
        {
            public List<famAddress1> GetFamilyAddressDataResult { get; set; }
        }

        public class famAddress1
        {
            public string alamat1 { get; set; }
            public string id1 { get; set; }
            public string kab_kota1 { get; set; }
            public string kecamatan1 { get; set; }
            public string kelurahan1 { get; set; }
            public string idfamily1 { get; set; }
            public string propinsi1 { get; set; }
            public string alamatktp1 { get; set; }
            public string kabkotaktp1 { get; set; }
            public string kecamatanktp1 { get; set; }
            public string kelurahanktp1 { get; set; }
            public string propinsiktp1 { get; set; }

        }

        void fillData2(String id1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/familyaddress/" + id1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.Timeout = 10000;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listFamilyAddress1>(jsonstr);

                if(result1.GetFamilyAddressDataResult.Count==0)
                {
                    hidIDFamily1.Value = id1;
                }

                for (int i = 0; i <= result1.GetFamilyAddressDataResult.Count - 1; i++)
                {
                    hidIDFamily1.Value = result1.GetFamilyAddressDataResult[i].idfamily1;
                    hidID2.Value = result1.GetFamilyAddressDataResult[i].id1;
                    txtAlamat1.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].alamat1);
                    txtKelurahan1.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].kelurahan1);
                    txtKecamatan1.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].kecamatan1);
                    txtKabupatenKota1.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].kab_kota1);
                    txtPropinsi1.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].propinsi1);
                    txtAlamatKTP.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].alamatktp1);
                    txtKelurahanKTP.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].kelurahanktp1);
                    txtKecamatanKTP.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].kecamatanktp1);
                    txtKabKTP.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].kabkotaktp1);
                    txtPropinsiKTP.Text = Base64Decode1(result1.GetFamilyAddressDataResult[i].propinsiktp1);
                    //ddlGender1.SelectedValue  = Base64Decode1(result1.GetFamilyMemberDataResult[i].jeniskelamin1);

                }
            }
        }

        protected void cmdDelete1_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/famdeletedata";
            object input = new
            {
                idfamily1 = hidIDFamily1.Value
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
            popUpMsgBox_Redirect("Data Deleted");
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
            public string alamatktp1 { get; set; }
            public string kelurahanktp1 { get; set; }
            public string kecamatanktp1 { get; set; }
            public string kabkotaktp1 { get; set; }
            public string propinsiktp1 { get; set; }

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
    }
}