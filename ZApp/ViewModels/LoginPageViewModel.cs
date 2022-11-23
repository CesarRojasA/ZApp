using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ZApp.Interfaces;
using ZApp.Models;

namespace ZApp.ViewModels
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        #region [Private attributes]
        public event PropertyChangedEventHandler PropertyChanged;
        private LoginRequestModel loginRequestModel;
        private readonly ILoginService _loginService;
        private bool isEnableScreen;
        #endregion

        #region [Public attributes]
        public LoginRequestModel LoginRequestModel
        {
            get => loginRequestModel;
            set
            {
                if (loginRequestModel != value)
                {
                    loginRequestModel = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsEnableScreen
        {
            get => isEnableScreen;
            set
            {
                if (isEnableScreen != value)
                {
                    isEnableScreen = value;
                    OnPropertyChanged(); 
                }
            }
        }
        public ICommand LoginCommand { set; get; }
        #endregion

        #region [Constructor]
        public LoginPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
           
            Initialize();
        }
        #endregion

        #region [Methods]
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private void Initialize()
        {
            try
            {
                LoginCommand = new Command(async () => await Login());
                LoginRequestModel = new LoginRequestModel();
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private async Task Login()
        {
            try
            {
                if (LoginRequestModel.Email == string.Empty || LoginRequestModel.Password == string.Empty )
                {
                    //await UserDialogs.Instance.AlertAsync("Por favor ingrese una email y un válido", "Email y contraseña errónea");
                }
                else
                {
                    LoginResponseModel LoginResponse = await _loginService.postLogin(LoginRequestModel);
                    if (LoginResponse == null)
                    { }
                    //await UserDialogs.Instance.AlertAsync("Intete nuevamente", "Error");
                    else
                    {
                        FillPreferences(LoginResponse);
                        //_ = await NavigationService.NavigateAsync("GamificationPage");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void FillPreferences(LoginResponseModel loginResponse)
        {
            try
            {
                Preferences.Set("TokenLogin", loginResponse.AuthorizationToken);
                Preferences.Set("EmailLogin", loginResponse.Email);
                Preferences.Set("FirstnameLogin", loginResponse.Firstname);
                Preferences.Set("SurnameLogin", loginResponse.Surname);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}