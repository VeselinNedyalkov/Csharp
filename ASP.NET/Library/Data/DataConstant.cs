namespace Library.Data
{
    public class DataConstant
    {
        public class ApplicationUserConstant
        {
            public const int UserNameMinlength = 5;
            public const int UserNameMaxlength = 20;
            public const int EmailMinlength = 10;
            public const int EmailMaxlength = 60;
            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;

        }

        public class BookConstant
        {
            public const int TitleMinLenght = 10;
            public const int TitleMaxLenght = 50;
            public const int AuthorMinLenght = 5;
            public const int AuthorMaxLenght = 50;
            public const int DescriptionMinLenght = 5;
            public const int DescriptionMaxLenght = 5000;

        }

        public class CategoryConstant
        {
            public const int NameMinlength = 5;
            public const int NameMaxlength = 50;
        }

        public class RegisterError
        {
            public const string UserNameError = "The leng is between 5 and 20 simbols";
            public const string EmailNameError = "The leng is between 10 and 60 simbols";
        }
    }
}
