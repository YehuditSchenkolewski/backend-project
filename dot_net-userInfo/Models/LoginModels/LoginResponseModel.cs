using dot_net_userInfo.Models;

namespace dot_net_userInfo.Models.LoginModels
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public User PersonalDetails { get; set; }

        public LoginResponseModel(string token, User user)
        {
            this.Token = token;
            this.PersonalDetails = user;
        }
    }

}

