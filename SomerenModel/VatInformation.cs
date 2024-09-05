using System;

namespace SomerenModel
{
    public class VatInformation
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Vat9 { get; private set; }
        public string Vat21 { get; private set; }
        public string TotalVat { get; private set; }

        public VatInformation(DateTime startDate, DateTime endDate, string vat9Percent, string vat21Percent, string totalVat)
        {
            StartDate = startDate;
            EndDate = endDate;
            Vat9 = vat9Percent;
            Vat21 = vat21Percent;
            TotalVat = totalVat;
        }
    }
}
