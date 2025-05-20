using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Share.Models.Mock
{
    public class HealthInsurancePolicy
    {
        public int PolicyId { get; set; }
        public int InsuredPersonId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string InsuranceCompany { get; set; } = string.Empty;
        public string PolicyType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PremiumAmount { get; set; }
        public double CoverageAmount { get; set; }
        public double Deductible { get; set; }
        public bool IsActive { get; set; }
        public string PolicyStatus { get; set; } = string.Empty;
        public string Beneficiary { get; set; } = string.Empty;
        public string HospitalNetwork { get; set; } = string.Empty;
        public string AdditionalBenefits { get; set; } = string.Empty;
        public string PolicyTerms { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public int AgentId { get; set; }
    }
}
