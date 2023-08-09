using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace WebApplication1.pagecode
{
    public partial class pagecode_user_profile1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                loadPersonalData(Session["nrp1"].ToString());
                loadEmpAddress(Session["nrp1"].ToString());
                loadEmpFamily(Session["nrp1"].ToString());
                loadEmpEducation(Session["nrp1"].ToString());
                loadEmpTraining(Session["nrp1"].ToString());
                loadEmpPersonalID(Session["nrp1"].ToString());
                loadEmpTaxData(Session["nrp1"].ToString());
                loadEmpClaimKM(Session["nrp1"].ToString());
                loadEmpWarning(Session["nrp1"].ToString());
            }
        }

        void loadPersonalData(string nrp1)
        {
            dlPersonalData.DataSource = getPersonalData(nrp1);
            dlPersonalData.DataBind();
            dlOrg.DataSource = getPersonalData(nrp1);
            dlOrg.DataBind();
        }

        void loadEmpAddress(string nrp1)
        {
            dlEmpAddress.DataSource = getEmpAddress(nrp1);
            dlEmpAddress.DataBind();
        }

        void loadEmpFamily(string nrp1)
        {
            gvfamily1.DataSource = getEmpFamilyMember(nrp1);
            gvfamily1.DataBind();
        }

        void loadEmpEducation(string nrp1)
        {
            gveducation1.DataSource = getEmpEducation(nrp1);
            gveducation1.DataBind();
        }

        void loadEmpTraining(string nrp1)
        {
            gvtraining1.DataSource = getEmpTraining(nrp1);
            gvtraining1.DataBind();
        }

        void loadEmpPersonalID(string nrp1)
        {
            gvpersonalid.DataSource = getEmpPersonalID(nrp1);
            gvpersonalid.DataBind();
        }

        void loadEmpTaxData(string nrp1)
        {
            gvtaxid.DataSource = getEmpTaxData(nrp1);
            gvtaxid.DataBind();
        }

        void loadEmpClaimKM(string nrp1)
        {
            gvkm1.DataSource = getEmpKlaimKM(nrp1);
            gvkm1.DataBind();
        }

        void loadEmpWarning(string nrp1)
        {
            gvwarning.DataSource = getEmpWarning(nrp1);
            gvwarning.DataBind();
        }

        static DataTable getPersonalData(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_empprofile/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empProfileResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("nrp1");
                dtable1.Columns.Add("contracttype1");
                dtable1.Columns.Add("costcenter1");
                dtable1.Columns.Add("position1");
                dtable1.Columns.Add("job1");
                dtable1.Columns.Add("fullname1");
                dtable1.Columns.Add("birthplace1");
                dtable1.Columns.Add("birthdate1");
                dtable1.Columns.Add("gender1");
                dtable1.Columns.Add("nationality1");
                dtable1.Columns.Add("maritalstatus1");
                dtable1.Columns.Add("religion1");
                dtable1.Columns.Add("useriddpa1");
                dtable1.Columns.Add("bankkey1");
                dtable1.Columns.Add("bankacct1");
                dtable1.Columns.Add("nobpjs1");
                dtable1.Columns.Add("fullnamespv1");
                dtable1.Columns.Add("personalareaname1");
                dtable1.Columns.Add("jamsostek1");
                dtable1.Columns.Add("location1");

                if (String.IsNullOrEmpty(result1.dbrd_empprofile1Result.nrp1) == false)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.nrp1),
                            class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.contracttype1),
                            class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.costcenter1),
                            class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.position1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.job1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.fullname1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.birthplace1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.birthdate1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.gender1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.nationality1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.maritalstatus1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.religion1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.useriddpa1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.bankkey1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.bankacct1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.nobpjs1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.fullnamespv1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.personalareaname1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.jamsostek1),
                             class1.function1.Base64Decode1(result1.dbrd_empprofile1Result.location1));
                }
            }

            return dtable1;
        }

        static DataTable getEmpAddress(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_empaddress/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empAddressResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("id1");
                dtable1.Columns.Add("nrp1");
                dtable1.Columns.Add("addresstype1");
                dtable1.Columns.Add("streetandhouseno1");
                dtable1.Columns.Add("secondaddressline1");
                dtable1.Columns.Add("city1");
                dtable1.Columns.Add("postalcode1");
                dtable1.Columns.Add("region1");
                dtable1.Columns.Add("country1");
                dtable1.Columns.Add("tlpno1");
                dtable1.Columns.Add("hpno1");


                for (int i = 0; i <= result1.dbrd_empaddress1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].id1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].nrp1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].addresstype1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].streetandhouseno1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].secondaddressline1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].city1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].postalcode1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].region1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].country1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].tlpno1),
                            class1.function1.Base64Decode1(result1.dbrd_empaddress1Result[i].hpno1)
                   );
                }
            }

            return dtable1;
        }

        static DataTable getEmpFamilyMember(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_empfamily/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empFamilyMemberResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("id1");
                dtable1.Columns.Add("nrp1");
                dtable1.Columns.Add("nik1");
                dtable1.Columns.Add("familytype1");
                dtable1.Columns.Add("begda1");
                dtable1.Columns.Add("number1");
                dtable1.Columns.Add("name1");
                dtable1.Columns.Add("dateofbirth1");
                dtable1.Columns.Add("birthplace1");
                dtable1.Columns.Add("cityofbirth1");
                dtable1.Columns.Add("gender1");


                for (int i = 0; i <= result1.dbrd_empfamily1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].id1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].nrp1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].nik1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].familytype1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].begda1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].number1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].name1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].dateofbirth1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].birthplace1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].cityofbirth1),
                            class1.function1.Base64Decode1(result1.dbrd_empfamily1Result[i].gender1)
                   );
                }
            }

            return dtable1;
        }

        static DataTable getEmpEducation(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_empeducation/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empEducationResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("tglmasuk1");
                dtable1.Columns.Add("tgllulus1");
                dtable1.Columns.Add("jenjangpendidikan1");
                dtable1.Columns.Add("namainstitusi1");
                dtable1.Columns.Add("jurusan1");


                for (int i = 0; i <= result1.dbrd_empeducation1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_empeducation1Result[i].tglmasuk1),
                            class1.function1.Base64Decode1(result1.dbrd_empeducation1Result[i].tgllulus1),
                            class1.function1.Base64Decode1(result1.dbrd_empeducation1Result[i].jenjangpendidikan1),
                            class1.function1.Base64Decode1(result1.dbrd_empeducation1Result[i].namainstitusi1),
                            class1.function1.Base64Decode1(result1.dbrd_empeducation1Result[i].jurusan1)
                   );
                }
            }

            return dtable1;
        }

        static DataTable getEmpTraining(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_emptraining/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empTrainingResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("tglmulai1");
                dtable1.Columns.Add("tglselesai1");
                dtable1.Columns.Add("metodetraining1");
                dtable1.Columns.Add("namainstitusi1");
                dtable1.Columns.Add("namatraining1");


                for (int i = 0; i <= result1.dbrd_emptraining1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_emptraining1Result[i].begda1),
                            class1.function1.Base64Decode1(result1.dbrd_emptraining1Result[i].endda1),
                            class1.function1.Base64Decode1(result1.dbrd_emptraining1Result[i].educationest1),
                            class1.function1.Base64Decode1(result1.dbrd_emptraining1Result[i].courseapp1),
                            class1.function1.Base64Decode1(result1.dbrd_emptraining1Result[i].coursename1)
                   );
                }
            }

            return dtable1;
        }

        static DataTable getEmpPersonalID(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_emppersonalid/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject < class1.dataclass1.empPersonalIDResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("tipe1");
                dtable1.Columns.Add("nomor1");
               


                for (int i = 0; i <= result1.dbrd_emppersonalid1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_emppersonalid1Result[i].tipe1),
                            class1.function1.Base64Decode1(result1.dbrd_emppersonalid1Result[i].nomor1)
                   );
                }
            }

            return dtable1;
        }

        static DataTable getEmpTaxData(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_emptaxdata/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empTaxDataResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("nonpwp1");
                dtable1.Columns.Add("status1");
                dtable1.Columns.Add("jmlh1");


                for (int i = 0; i <= result1.dbrd_taxdata1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_taxdata1Result[i].nonpwp1),
                            class1.function1.Base64Decode1(result1.dbrd_taxdata1Result[i].status1),
                            class1.function1.Base64Decode1(result1.dbrd_taxdata1Result[i].jmlh1)
                   );
                }
            }

            return dtable1;
        }

        static DataTable getEmpKlaimKM(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_empclaimkm/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empKlaimKMResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("tgl1");
                dtable1.Columns.Add("claimer1");
                dtable1.Columns.Add("ket1");
                dtable1.Columns.Add("jmlh1");


                for (int i = 0; i <= result1.dbrd_claimkm1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_claimkm1Result[i].dateoforigin1),
                            class1.function1.Base64Decode1(result1.dbrd_claimkm1Result[i].claimant1),
                            class1.function1.Base64Decode1(result1.dbrd_claimkm1Result[i].wagetype1),
                            class1.function1.Base64Decode1(result1.dbrd_claimkm1Result[i].amount1)
                   );
                }
            }

            return dtable1;
        }

        static DataTable getEmpWarning(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dbrd_empwarning/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empWarningResult>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("begda1");
                dtable1.Columns.Add("endda1");
                dtable1.Columns.Add("reason1");
              

                for (int i = 0; i <= result1.dbrd_empwarning1Result.Count - 1; i++)
                {

                    dtable1.Rows.Add(class1.function1.Base64Decode1(result1.dbrd_empwarning1Result[i].begda1),
                            class1.function1.Base64Decode1(result1.dbrd_empwarning1Result[i].endda1),
                            class1.function1.Base64Decode1(result1.dbrd_empwarning1Result[i].reason1)
                   );
                }
            }

            return dtable1;
        }
    }

   

    
}