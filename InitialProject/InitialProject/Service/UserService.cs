using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class UserService
    {
        public UserService() { }    


        UserRepository userRepository = new UserRepository();
        public void UpdateStatus(bool titleFlag)
        {
            userRepository.UpdateStatus(titleFlag);
        }
    }
}
