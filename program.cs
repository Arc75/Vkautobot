using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace Testapp
{
    static class Program
    {
                
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    //public class vkontach
    //{
    //    public bool authorize = false;
    //    ulong appId = 5433602;
    //    bool uspeh;
    //    Settings settings = Settings.Messages;
    //    ApiAuthParams auth = new ApiAuthParams();
    //    public void Reply()
    //    {
    //        VkApi vk = new VkApi();
    //        auth.Login = emailOrPhone;
    //        auth.Password = pass;
    //        auth.ApplicationId = appId;
    //        auth.Settings = settings;
    //        vk.Authorize(auth);

    //        if (vk.IsAuthorized == true)
    //            uspeh = true;
    //        else
    //            uspeh = false;

    //        if (uspeh == true)
    //        {
    //            Console.WriteLine("Успех авторизации");
    //            var messages = vk.Messages.GetDialogs(new MessagesDialogsGetParams { Unread = true, Count = 5 });
    //            if (messages.TotalCount != 0)
    //            {
    //                Console.WriteLine("Есть непрочитанные");
    //                var messageid = messages.Messages.FirstOrDefault();
    //                var name = vk.Users.Get(Convert.ToInt64(messageid.UserId));
    //                if (name != null)
    //                    Console.WriteLine("Последнее сообщение пришло от  {0} {1}", name.FirstName, name.LastName);
    //            }
    //            Console.ReadLine();
    //        }
    //    }
    //}


    public class Logic
    {
        ulong appId = 5433602;
        public bool uspeh;
        public string name;
        Settings settings = Settings.Messages;
        ApiAuthParams auth = new ApiAuthParams();
        VkApi vk = new VkApi();
        public void Auth()
        {
            auth.Login = Model.Init.user.FirstOrDefault().Login;
            auth.Password = Model.Init.user.FirstOrDefault().Pass;
            auth.ApplicationId = appId;
            auth.Settings = settings;
            try
            {
                vk.Authorize(auth);
            }
            catch (VkNet.Exception.VkApiAuthorizationException)
            {
                uspeh = false;
            }
            
            if (vk.IsAuthorized == true)
                uspeh = true;
            else
                uspeh = false;

            if (uspeh == true)
            {
                var profileInfo = vk.Account.GetProfileInfo();
                name = profileInfo.FirstName +" "+ profileInfo.LastName;                
            }
        }
    }
}
