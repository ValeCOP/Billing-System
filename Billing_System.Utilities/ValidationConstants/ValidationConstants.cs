namespace Billing_System.Utilities.ValidationConstants
{
    using System.Runtime.CompilerServices;

    public static class ValidationConstants
    {

        public const string TechnicalTeemsEmails = "359888719126@sms.mtel.net,adminraiovo@gmail.com,359883339303@sms.mtel.net";

        public const string AppExpiredDateFormat = "yyyy-MM-dd";
        public const string AppActivationDateFormat = "dd-MM-yyyy HH:mm";
        public const string AppActivationDateFormatForDb = "yyyy-MM-dd HH:mm:ss";   
        public const int ActivatedClientsCount = 5;

        public const string ApiUrl = "https://localhost:7231/Clients";
        public const string LoginApiUrl = "https://localhost:7231/Login/Login";

        public static class Payments
        {
            public const int NameMaxLength = 200;
            public const int NameMinLength = 3;
            public const int ValueMinLength = 0;
            public const int ValueMaxLength = 264;
            public const int InstallationFeeMinLength = 0;
            public const int InstallationFeeMaxLength = 150;
        }

        public static class Clients
        {
            public const int FullNameMaxLength = 255;
            public const int AddressMaxLength = 1000;
            
        }

        public static class TechnicalProblems
        {
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;
            public const string DescriptionErrorMessage = "Description must be between {2} and {1} characters";
        }
        //ResolveTechProblem
        public static class ResolveTechProblemConstants
        {
            public const int SolutionMinLength = 20;
            public const int SolutionMaxLength = 200;
            public const string SolutionErrorMessage = "Please describe the problem in detail! Solution must be at least {2} characters";
        }

        public static class ApplicationUsers
        {
            public const int UserNameMaxLength = 50;
            public const int UserNameMinLength = 3;
            public const string AdminEmail = "admin@infocastsystems.eu";
            public static string AdminRoleName = "Administrator";

        }
        public static class ActiveISPClientsForm
        {

            public const int FullNameMaxLength = 100;
            public const int FullNameMinLength = 3;
            public const int CommentsMaxLength = 1000;
            public const int MonthsMin = 1;
            public const int MonthsMax = 12;
            public const string InstallationFeeMin = "0";
            public const string InstallationFeeMax = "150";
            public const string  FeeMin = "22";
            public const string FeeMax = "264";
            public const string FeeErrorMessage = "Invalid Fee; Maximum Two Decimal Points.";
            public const string InstallationFeeErrorMessage = "Invalid Installation Fee; Maximum Two Decimal Points.";
            public const string DateComparisonErrorMessage = "Expired Date must be after Activation Date";
            public const string ActivationInputDataErrorMessage = "Invalid input data";

        }

        public static class Expense
        {
            public const int NameMaxLength = 200;
            public const int NameMinLength = 3;
            public const string ValueMinLength = "0.10";
            public const string ValueMaxLength = "10000.00";
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 3;
            public const string NameErrorMessage = "Name must be between {2} and {1} characters";
            public const string DescriptionErrorMessage = "Description must be between {2} and {1} characters";
            public const string ReceiptUrlErrorMessage = "Invalid URL";
        }

        public static class Promotions
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 3;
            public const string NameErrorMessage = "Name must be between {2} and {1} characters";
        }

        public static class Invoices
        {
            public const int MOLMaxLength = 200;
            public const int MOLMinLength = 3;
            public const int UINLength = 9;
            public const int VATINLength = 11;
            public const int RecipientMaxLength = 255;
            public const int RecipientMinLength = 3;
            public const int CompilerMaxLength = 255;
            public const int CompilerMinLength = 3;
            public const string CompilerErrorMessage = "Compiler must be between {2} and {1} characters";
            public const string RecipientErrorMessage = "Recipient must be between {2} and {1} characters";
            public const string MOLErrorMessage = "MOL must be between {2} and {1} characters";
            public const string UINErrorMessage = "UIN must be {1} characters";
            public const string VATINErrorMessage = "VATIN must be {1} characters";
        }

        //chat
        public static class Chat
        {
            public const int UserMaxLength = 50;
            public const int UserMinLength = 3;
            public const int MessageMaxLength = 1000;
            public const int MessageMinLength = 1;
            public const string UserErrorMessage = "User must be between {2} and {1} characters";
            public const string MessageErrorMessage = "Message must be between {2} and {1} characters";
        }

        public static class RolesConstants
        {
            public const string AreaName = "Admin";
            public const string AdministratorRoleName = "Administrator";
            public const string CashierRoleName = "Cashier";
            public const string TechnicianRoleName = "Technician";
            public const string AdminEmail = "admin@infocastsystems.eu";
        }
    }
}
