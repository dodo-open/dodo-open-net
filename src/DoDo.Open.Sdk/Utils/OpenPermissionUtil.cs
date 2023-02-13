
using System;
using System.Linq;
using DoDo.Open.Sdk.Models.Permissions;

namespace DoDo.Open.Sdk.Utils
{
    /// <summary>
    /// 开放权限工具
    /// </summary>
    public class OpenPermissionUtil
    {
        /// <summary>
        /// 计算权限值
        /// </summary>
        /// <param name="permissions">加入计算的权限码</param>
        /// <returns></returns>
        public static string CalculationPermission(params Permission[] permissions)
        {
            try
            {
                var calculationPermission = permissions.Aggregate(0, (current, permission) => current | (int)permission);

                return Convert.ToString(calculationPermission, 16).ToLower();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        /// <summary>
        /// 校验权限值
        /// </summary>
        /// <param name="targetPermission">欲校验的权限值</param>
        /// <param name="permissions">用于校验的权限码</param>
        /// <returns></returns>
        public static bool CheckPermission(string targetPermission, params Permission[] permissions)
        {
            try
            {
                var calculationPermission = Convert.ToInt32(targetPermission, 16);

                return (calculationPermission & (int)Permission.Administrator) == (int)Permission.Administrator || permissions.All(permission => (calculationPermission & (int)permission) == (int)permission);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
