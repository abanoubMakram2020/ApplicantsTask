namespace ApplicantsTask.Presentation.MVC.Helper
{
    public sealed class ProjectConfiguration
    {
        public struct APIURLs
        {
            public const string GET_APPLICANTS = "Applicant/GetAll";
            public const string GET_APPLICANT_BY_ID = "Applicant/GetById";
            public const string GET_CREATE_UPDATE_APPLICANT = "Applicant/CreateOrUpdate";
            public const string DELETE_APPLICANT = "Applicant/Delete";

            public const string USER_LOGIN = "User/Login";
            public const string USER_REGISTRATION = "User/Register";
        }
    }
}
