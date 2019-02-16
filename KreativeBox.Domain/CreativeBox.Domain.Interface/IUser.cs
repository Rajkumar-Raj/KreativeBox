using CreativeBox.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Interface
{
    public interface IUser
    {
        List<UserEntity> SelectUserList();

        UserEntity FetchUserDetail(int userid);

        int OperationUser(UserEntity objUserEntity);

        int OperationUserDelete(UserEntity objUserEntity);

        UserEntity UserLogin(string username, string password);

        int UserChangePassword(UserEntity objUser);
    }
}
