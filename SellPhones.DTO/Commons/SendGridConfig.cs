namespace OLET4VUniverse.DTO.Commons
{
    public class SendGridConfig
    {
        public bool IsTesting { get; set; }
        public string ApiKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public SendGridTemplate Templates { get; set; }
    }

    public class SendGridTemplate
    {
        public string TestSendEmail { get; set; }
        public string ActivePackageSuccess { get; set; }
        public string PackageBeforeExpired { get; set; }
        public string FreeContent { get; set; }

        public string ChangedPasswordSuccess { get; set; }
        public string RegisterSuccess { get; set; }

        public string UpgradeAccount { get; set; }
        public string UpgradeAccountLaos { get; set; }
        public string UpgradeAccountCampuchia { get; set; }
        public string UpgradeAccountChina { get; set; }

        public string ForgotPassword { get; set; }
        public string ForgotPasswordLaos { get; set; }
        public string ForgotPasswordCampuchia { get; set; }
        public string ForgotPasswordChina { get; set; }

        public string ExpiredAccount { get; set; }
        public string ExpiredAccountLaos { get; set; }
        public string ExpiredAccountCampuchia { get; set; }
        public string ExpiredAccountChina { get; set; }

        public string ResetPasswordOTP { get; set; }
        public string ResetPasswordOTPLaos { get; set; }
        public string ResetPasswordOTPCampuchia { get; set; }
        public string ResetPasswordOTPChina { get; set; }

        public string PotentialCustomer { get; set; }
        public string PotentialCustomerLaos { get; set; }
        public string PotentialCustomerCampuchia { get; set; }
        public string PotentialCustomerChina { get; set; }
    }
}