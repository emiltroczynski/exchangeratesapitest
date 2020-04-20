using System.Reflection;

namespace TaskFromGain.Model
{
    class Rates
    {
        #region active curriencies
        public double AED { set; get; }
        public double AFN { set; get; }
        public double ALL { set; get; }
        public double AMD { set; get; }
        public double ANG { set; get; }
        public double AOA { set; get; }
        public double ARS { set; get; }
        public double AUD { set; get; }
        public double AWG { set; get; }
        public double AZN { set; get; }
        public double BAM { set; get; }
        public double BBD { set; get; }
        public double BDT { set; get; }
        public double BGN { set; get; }
        public double BHD { set; get; }
        public double BIF { set; get; }
        public double BMD { set; get; }
        public double BND { set; get; }
        public double BOB { set; get; }
        public double BOV { set; get; }
        public double BRL { set; get; }
        public double BSD { set; get; }
        public double BTN { set; get; }
        public double BWP { set; get; }
        public double BYN { set; get; }
        public double BZD { set; get; }
        public double CAD { set; get; }
        public double CDF { set; get; }
        public double CHE { set; get; }
        public double CHF { set; get; }
        public double CHW { set; get; }
        public double CLF { set; get; }
        public double CLP { set; get; }
        public double CNY { set; get; }
        public double COP { set; get; }
        public double COU { set; get; }
        public double CRC { set; get; }
        public double CUC { set; get; }
        public double CUP { set; get; }
        public double CVE { set; get; }
        public double CZK { set; get; }
        public double DJF { set; get; }
        public double DKK { set; get; }
        public double DOP { set; get; }
        public double DZD { set; get; }
        public double EGP { set; get; }
        public double ERN { set; get; }
        public double ETB { set; get; }
        public double EUR { set; get; }
        public double FJD { set; get; }
        public double FKP { set; get; }
        public double GBP { set; get; }
        public double GEL { set; get; }
        public double GHS { set; get; }
        public double GIP { set; get; }
        public double GMD { set; get; }
        public double GNF { set; get; }
        public double GTQ { set; get; }
        public double GYD { set; get; }
        public double HKD { set; get; }
        public double HNL { set; get; }
        public double HRK { set; get; }
        public double HTG { set; get; }
        public double HUF { set; get; }
        public double IDR { set; get; }
        public double ILS { set; get; }
        public double INR { set; get; }
        public double IQD { set; get; }
        public double IRR { set; get; }
        public double ISK { set; get; }
        public double JMD { set; get; }
        public double JOD { set; get; }
        public double JPY { set; get; }
        public double KES { set; get; }
        public double KGS { set; get; }
        public double KHR { set; get; }
        public double KMF { set; get; }
        public double KPW { set; get; }
        public double KRW { set; get; }
        public double KWD { set; get; }
        public double KYD { set; get; }
        public double KZT { set; get; }
        public double LAK { set; get; }
        public double LBP { set; get; }
        public double LKR { set; get; }
        public double LRD { set; get; }
        public double LSL { set; get; }
        public double LYD { set; get; }
        public double MAD { set; get; }
        public double MDL { set; get; }
        public double MGA { set; get; }
        public double MKD { set; get; }
        public double MMK { set; get; }
        public double MNT { set; get; }
        public double MOP { set; get; }
        public double MRU { set; get; }
        public double MUR { set; get; }
        public double MVR { set; get; }
        public double MWK { set; get; }
        public double MXN { set; get; }
        public double MXV { set; get; }
        public double MYR { set; get; }
        public double MZN { set; get; }
        public double NAD { set; get; }
        public double NGN { set; get; }
        public double NIO { set; get; }
        public double NOK { set; get; }
        public double NPR { set; get; }
        public double NZD { set; get; }
        public double OMR { set; get; }
        public double PAB { set; get; }
        public double PEN { set; get; }
        public double PGK { set; get; }
        public double PHP { set; get; }
        public double PKR { set; get; }
        public double PLN { set; get; }
        public double PYG { set; get; }
        public double QAR { set; get; }
        public double RON { set; get; }
        public double RSD { set; get; }
        public double RUB { set; get; }
        public double RWF { set; get; }
        public double SAR { set; get; }
        public double SBD { set; get; }
        public double SCR { set; get; }
        public double SDG { set; get; }
        public double SEK { set; get; }
        public double SGD { set; get; }
        public double SHP { set; get; }
        public double SLL { set; get; }
        public double SOS { set; get; }
        public double SRD { set; get; }
        public double SSP { set; get; }
        public double STN { set; get; }
        public double SVC { set; get; }
        public double SYP { set; get; }
        public double SZL { set; get; }
        public double THB { set; get; }
        public double TJS { set; get; }
        public double TMT { set; get; }
        public double TND { set; get; }
        public double TOP { set; get; }
        public double TRY { set; get; }
        public double TTD { set; get; }
        public double TWD { set; get; }
        public double TZS { set; get; }
        public double UAH { set; get; }
        public double UGX { set; get; }
        public double USD { set; get; }
        public double USN { set; get; }
        public double UYI { set; get; }
        public double UYU { set; get; }
        public double UYW { set; get; }
        public double UZS { set; get; }
        public double VES { set; get; }
        public double VND { set; get; }
        public double VUV { set; get; }
        public double WST { set; get; }
        public double XAF { set; get; }
        public double XAG { set; get; }
        public double XAU { set; get; }
        public double XBA { set; get; }
        public double XBB { set; get; }
        public double XBC { set; get; }
        public double XBD { set; get; }
        public double XCD { set; get; }
        public double XDR { set; get; }
        public double XOF { set; get; }
        public double XPD { set; get; }
        public double XPF { set; get; }
        public double XPT { set; get; }
        public double XSU { set; get; }
        public double XTS { set; get; }
        public double XUA { set; get; }
        public double XXX { set; get; }
        public double YER { set; get; }
        public double ZAR { set; get; }
        public double ZMW { set; get; }
        public double ZWL { set; get; }

        #endregion

        #region historical curriencies
        public double BGL { set; get; }
        public double AOR { set; get; }
        public double BYB { set; get; }
        public double ECS { set; get; }
        public double ECV { set; get; }
        public double TJR { set; get; }
        public double GRD { set; get; }
        public double AFA { set; get; }
        public double XFO { set; get; }
        public double YUM { set; get; }
        public double SRG { set; get; }
        public double MGF { set; get; }
        public double ROL { set; get; }
        public double SIT { set; get; }
        public double TRL { set; get; }
        public double AZM { set; get; }
        public double CYP { set; get; }
        public double MTL { set; get; }
        public double CSD { set; get; }
        public double MZM { set; get; }
        public double ZWD { set; get; }
        public double SKK { set; get; }
        public double SDD { set; get; }
        public double GHC { set; get; }
        public double VEB { set; get; }
        public double ZWN { set; get; }
        public double TMM { set; get; }
        public double ZWR { set; get; }
        public double EEK { set; get; }
        public double LVL { set; get; }
        public double ZMK { set; get; }
        public double XFU { set; get; }
        public double USS { set; get; }
        public double LTL { set; get; }
        public double BYR { set; get; }
        public double MRO { set; get; }
        public double STD { set; get; }
        public double VEF { set; get; }
        #endregion

        internal int GetRatesCount()
        {
            int ratesCount = 0;
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (var p in properties)
            {
                if ((double)p.GetValue(this) != 0)
                {
                    ratesCount++;
                }
            }

            return ratesCount;
        }
    }
}
