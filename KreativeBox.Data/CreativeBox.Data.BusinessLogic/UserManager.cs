using CreativeBox.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativeBox.Domain.Entity;
using System.Data.Entity.Core.Objects;

namespace CreativeBox.Data.BusinessLogic
{
    public class UserManager : BaseBusinessManager, IUser
    {
        public UserEntity FetchUserDetail(int userid)
        {
            return SelectUser(userid)[0];
        }

        public List<UserEntity> SelectUserList()
        {
            return SelectUser(0);
        }

        private List<UserEntity> SelectUser(int userid)
        {
            List<UserEntity> lstUserEntity = new List<UserEntity>();
            UserEntity objUserEntity = new UserEntity();

            var contractorData = DataAccessHelper.KreativeBoxEntities.KB_SelectUser(userid).ToList();
            if (contractorData.Any())
            {
                foreach (var item in contractorData)
                {
                    objUserEntity = new UserEntity
                    {
                        UserId = item.UserId,
                        UserName = item.UserName,
                        Password = item.Password,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DOB = item.DOB,
                        Email = item.Email,
                        Address = item.Address,
                        Phone = item.Phone,
                        LoginTime = item.LoginTime,
                        UserType = item.UserType,
                        RoleTypeId = item.RoleTypeId,
                        UserImage = item.UserImage,
                        IsDeleted = item.IsDeleted,
                        IsActive = item.IsActive
                    };
                    lstUserEntity.Add(objUserEntity);
                }
            }

            return lstUserEntity;
        }

        public int OperationUser(UserEntity objUser)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.UserOperation(objUser.UserId, objUser.UserName,
                objUser.Password, objUser.FirstName, objUser.LastName, objUser.DOB, objUser.Email,
                objUser.Address, objUser.Phone, objUser.UserType, objUser.RoleTypeId, objUser.UserImage,
                objUser.CreatedBy, objUser.UpdatedBy, objUser.IsDeleted,
                objUser.IsActive, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public int OperationUserDelete(UserEntity objUser)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.UserDelete(objUser.UserId,
                objUser.UpdatedBy, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }

        public UserEntity UserLogin(string username, string password)
        {
            UserEntity objUserEntity = new UserEntity();
            var userEntity = DataAccessHelper.KreativeBoxEntities.KB_User_Login(username, password).ToList();
            if (!userEntity.Any()) return objUserEntity;
            foreach (var item in userEntity)
            {
                objUserEntity.UserId = item.UserId;
                objUserEntity.UserName = item.UserName;
                objUserEntity.Password = item.Password;
                objUserEntity.FirstName = item.FirstName;
                objUserEntity.LastName = item.LastName;
                objUserEntity.DOB = item.DOB;
                objUserEntity.Email = item.Email;
                objUserEntity.Address = item.Address;
                objUserEntity.Phone = item.Phone;
                objUserEntity.LoginTime = item.LoginTime;
                objUserEntity.UserType = item.UserType;
                objUserEntity.RoleTypeId = item.RoleTypeId;
                objUserEntity.CreatedBy = item.CreatedBy;
                objUserEntity.UserImage = item.UserImage;
                objUserEntity.CreatedDate = item.CreatedDate;
                objUserEntity.IsDeleted = item.IsDeleted;
                objUserEntity.IsActive = item.IsActive;                
            }
            return objUserEntity;
        }

        public int UserChangePassword(UserEntity objUser)
        {
            var returnParam = new ObjectParameter("ReturnCode", typeof(int));
            DataAccessHelper.KreativeBoxEntities.KB_User_Change_Password(objUser.UserId, objUser.Password,
                objUser.NewPassword, returnParam);

            int resultId = Convert.IsDBNull(returnParam.Value) ? 0 : (int)returnParam.Value;
            return resultId;
        }
    }
}
