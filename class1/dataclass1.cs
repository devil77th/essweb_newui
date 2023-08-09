using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Policy;
using System.Web;


namespace WebApplication1.class1
{
    public class dataclass1
    {
        public class empProfileResult
        {
            public empProfile dbrd_empprofile1Result { get; set; }
        }

        public class empProfileResult2
        {
            public empProfile getempprofile3Result { get; set; }
        }

        public class empProfile
        {
            public string nrp1 { get; set; }
            public string contracttype1 { get; set; }
            public string costcenter1 { get; set; }
            public string position1 { get; set; }
            public string job1 { get; set; }
            public string fullname1 { get; set; }
            public string birthplace1 { get; set; }
            public string birthdate1 { get; set; }
            public string cityofbirth1 { get; set; }
            public string gender1 { get; set; }
            public string nationality1 { get; set; }
            public string maritalstatus1 { get; set; }
            public string religion1 { get; set; }
            public string useriddpa1 { get; set; }
            public string bankkey1 { get; set; }
            public string bankacct1 { get; set; }
            public string nobpjs1 { get; set; }
            public string fullnamespv1 { get; set; }
            public string personalareaname1 { get; set; }
            public string jamsostek1 { get; set; }
            public string location1 { get; set; }
            public string joinDate1 { get; set; }
            public string posName1 { get; set; }
            public string status1 { get; set; }

        }

        public class empAddressResult
        {
            public List<empAddress> dbrd_empaddress1Result { get; set; }
        }

        public class empAddress
        {
            public string id1 { get; set; }
            public string nrp1 { get; set; }
            public string addresstype1 { get; set; }
            public string streetandhouseno1 { get; set; }
            public string secondaddressline1 { get; set; }
            public string city1 { get; set; }
            public string postalcode1 { get; set; }
            public string region1 { get; set; }
            public string country1 { get; set; }
            public string tlpno1 { get; set; }
            public string hpno1 { get; set; }

        }

        public class empFamilyMemberResult
        {
            public List<empFamilyMember> dbrd_empfamily1Result { get; set; }
        }

        public class empFamilyMember
        {
            public string begda1 { get; set; }
            public string birthplace1 { get; set; }
            public string cityofbirth1 { get; set; }
            public string dateofbirth1 { get; set; }
            public string familytype1 { get; set; }
            public string id1 { get; set; }
            public string name1 { get; set; }
            public string nik1 { get; set; }
            public string nrp1 { get; set; }
            public string number1 { get; set; }
            public string gender1 { get; set; }

        }

        public class empEducationResult
        {
            public List<empEducation> dbrd_empeducation1Result { get; set; }
        }

        public class empEducation
        {
            public string jenjangpendidikan1 { get; set; }
            public string jurusan1 { get; set; }
            public string namainstitusi1 { get; set; }
            public string tgllulus1 { get; set; }
            public string tglmasuk1 { get; set; }

        }

        public class empTrainingResult
        {
            public List<empTraining> dbrd_emptraining1Result { get; set; }
        }

        public class empTraining
        {
            public string begda1 { get; set; }
            public string courseapp1 { get; set; }
            public string coursename1 { get; set; }
            public string educationest1 { get; set; }
            public string endda1 { get; set; }

        }

        public class empPersonalIDResult
        {
            public List<empPersonalID> dbrd_emppersonalid1Result { get; set; }
        }

        public class empPersonalID
        {
            public string tipe1 { get; set; }
            public string nomor1 { get; set; }

        }

        public class empTaxDataResult
        {
            public List<empTaxData> dbrd_taxdata1Result { get; set; }
        }

        public class empTaxData
        {
            public string jmlh1 { get; set; }
            public string nonpwp1 { get; set; }
            public string status1 { get; set; }


        }

        public class empKlaimKMResult
        {
            public List<empKlaimKM> dbrd_claimkm1Result { get; set; }
        }

        public class empKlaimKM
        {
            public string amount1 { get; set; }
            public string claimant1 { get; set; }
            public string dateoforigin1 { get; set; }
            public string nrp1 { get; set; }
            public string wagetype1 { get; set; }


        }

        public class empWarningResult
        {
            public List<empWarning> dbrd_empwarning1Result { get; set; }
        }

        public class empWarning
        {
            public string begda1 { get; set; }
            public string endda1 { get; set; }
            public string reason1 { get; set; }
            
        }

        public class lstOvtHRResult
        {
            public List<lstOvtHR> listapproval_ovt_hrResult { get; set; }
        }

        public class lstOvtHR
        {
            public string idtrx { get; set; }
            public string fullname { get; set; }
            public string timefrom { get; set; }
            public string timeto { get; set; }
            public string timefromapp { get; set; }
            public string timetoapp { get; set; }
            public string reason { get; set; }
            public string nrp1 { get; set; }    
            public string nrpapprover1 { get; set; }
            public string status1 { get; set; }
            public string nameapprover1 { get; set; }
        }

        public class GetDataTrxOVTResult1
        {
            public List<empOVT> getDataOvt1Result { get; set; }
        }

        public class empOVT
        {
            public string fullname { get; set; }
            public string reason { get; set; }
            public string idtrx { get; set; }
            public string timefrom { get; set; }
            public string timeto { get; set; }
            public string actci { get; set; }
            public string actco { get; set; }
            public string nrp { get; set; }

        }

        public class GetCekAppOvt1
        {
            public string CekApproverResult { get; set; }
        }

        public class lstCICOWFHperNRPResult1
        {
            public List<lstCICOWFHperNRP> listCICOWFHperNRP1Result { get; set; }
        }

        public class lstCICOWFHDetailResult1
        {
            public lstCICOWFHperNRP listCICOWFHDetail1Result { get; set;}
        }

        public class lstCICOWFOperNRPResult1
        {
            public List<lstCICOWFHperNRP> listCICOWFOperNRP1Result { get; set; }
        }

        public class lstCICOWFODetailResult1
        {
            public lstCICOWFHperNRP listCICOWFODetail1Result { get; set; }
        }

        public class lstCICOWFHperNRP
        {
            public string approvalstatus1 { get; set; }
            public string nrp1 { get; set; }
            public string submittype1 { get; set; }
            public string time1 { get; set; }
            public string type1 { get; set; }
            public string idtrx1 { get; set; }
        }

        public class listReqAbsperNRP1Result1
        {
            public List<lstAbsperNRP> listReqAbsperNRP1Result { get; set; }
        }

        public class listReqAbsDetailResult1
        {
            public lstAbsperNRP listAbsDetail1Result { get; set; }
        }


        public class lstAbsperNRP
        { 
        
            public string nrp1 { get; set; }    
            public string id1 { get; set; }
            public string abscode1 { get; set; }
            public string absname1 { get; set; }
            public string begda1 { get; set;}
            public string endda1 { get; set;}
            public string number1 { get; set; }
            public string status1 { get; set; }
            public string creda1 { get; set; }

        }

        public class listSaldoCutiResult1
        {
            public List<lstSaldoCuti> listSaldoCutiperNRP1Result { get; set; }
        }

        public class lstSaldoCuti
        {

            public string absencecode1 { get; set; }
            public string begda1 { get; set; }
            public string endda1 { get; set; }
            public string jumlah1 { get; set; }
            public string nrp1 { get; set; }
            public string remain1 { get; set; }

        }

        public class lstReqAttResultPerNRP
        {
            public List<lstAtt> listReqAttperNRP1Result { get; set; }
        }

        public class lstReqAttDetail
        {
            public lstAtt listAttDetail1Result { get; set; }
        }

        public class lstAtt
        {
            public string attcode1 { get; set;}
            public string attname1 { get; set;}
            public string begda1 { get; set;}
            public string endda1 { get; set;}
            public string creda1 { get; set;}
            public string id1 { get; set;}
            public string nrp1 { get; set;}
            public string status1 { get; set;}

        }

        public class filetemplateresign
        {
            public essbin getfile_essResult { get; set; }
        }

        public class fileuploadresign
        {
            public essbin GetUploadFile_TrxResign1Result { get; set; }
        }

        public class essbin
        {
            public string filename1 { get; set; }
            public string filebin64 { get; set; }
        }

        public class trxResign1
        {
            public trxResign2 cektrxResign1Result { get; set; }
        }

        public class trxResign2
        {
            public string id1 { get; set; }
            public string nrp1 { get; set; }
            public string nama1 { get; set; }
            public string iskaryconfirm1 { get; set;}
            public string karyconfirmdt1 { get; set; }
            public string ishrdconfirm1 { get; set; }
            public string hrdconfirmdt1 { get; set; }
            public string tgljoin1 { get; set; }
            public string pos1 { get; set; }
            public string contracttype1 { get; set; }
            public string resigndt1 { get; set; }
            public string createdt1 { get; set; }
            public string createby1 { get; set; }
            public string modby1 { get; set; }
            public string moddt1 { get; set; }
        }

        

    }
}