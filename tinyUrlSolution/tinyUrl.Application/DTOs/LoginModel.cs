namespace tinyUrl.Application.DTOs
{
    public class LoginModel
    {
        int userId { get; set; }
        string userName { get; set; }
        string email { get; set; }
        string password { get; set; }

        //api access role for the user, can be used for role-based access control (RBAC)
        string role { get; set; }

        //token can be used for authentication and authorization, can be used for session management
        string token { get; set; }
        //refresh token can be used to generate new access token when the current access token expires, can be used for session management
        string refreshToken { get; set; }

        //used for passwordless login
        long mobileNumber { get; set; }
        //if password not known then use code for login
        //code can be used for passwordless login or for two-factor authentication (2FA)
        //code can be used for password reset or account verification
        string code { get; set; }

    }
}
