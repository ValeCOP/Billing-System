namespace Billing_System.Utilities.ValidationConstants
{
    public static class ValidationConstants
    {
        public const string AppExpiredDateFormat = "yyyy-MM-dd";
        public const string AppActivationDateFormat = "dd-MM-yyyy HH:mm";
        public static class Payments
        {
            public const int NameMaxLength = 200;
            public const int NameMinLength = 3;
            public const int ValueMinLength = 0;
            public const int ValueMaxLength = 150;
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
            public const string InstallationFeeMin = "0";
            public const string InstallationFeeMax = "150";
            public const string  FeeMin = "22";
            public const string FeeMax = "50";
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
    }
}
