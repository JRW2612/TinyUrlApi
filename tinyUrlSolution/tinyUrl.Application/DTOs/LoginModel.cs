namespace tinyUrl.Application.DTOs
{
    public class LoginModel
    {
        public int userId { get; set; }
        public required string userName { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }

        //api access role for the user, can be used for role-based access control (RBAC)
        public string role { get; set; }

        //token can be used for authentication and authorization, can be used for session management
        public string token { get; set; }
        //refresh token can be used to generate new access token when the current access token expires, can be used for session management
        public string refreshToken { get; set; }

        //used for passwordless login
        public required long mobileNumber { get; set; }
        //if password not known then use code for login
        //code can be used for passwordless login or for two-factor authentication (2FA)
        //code can be used for password reset or account verification
        public required string code { get; set; }

    }
}
