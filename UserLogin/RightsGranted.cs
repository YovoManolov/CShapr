using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    class RightsGranted
    {
        public static Dictionary<UserRoles, List<RoleRights>> role_RolRightsDict =
            new Dictionary<UserRoles, List<RoleRights>>();

        public RightsGranted()
        {
            List<RoleRights> anonRR = new List<RoleRights>();
            List<RoleRights> admRR = new List<RoleRights>() { RoleRights.CanEditStudents, RoleRights.CanEditUsers, RoleRights.CanSeeLogs };
            List<RoleRights> inspRR = new List<RoleRights>() { RoleRights.CanEditStudents, RoleRights.CanEditUsers};
            List<RoleRights> profRR = new List<RoleRights>() { RoleRights.CanEditStudents};
            List<RoleRights> studRR = new List<RoleRights>();
            //ANONYMOS, ADMIN, INSPECTOR, PROFESSOR, STUDENT

            role_RolRightsDict.Add(UserRoles.ANONYMOS, anonRR);
            role_RolRightsDict.Add(UserRoles.ADMIN, admRR);
            role_RolRightsDict.Add(UserRoles.INSPECTOR, inspRR);
            role_RolRightsDict.Add(UserRoles.PROFESSOR, profRR);
            role_RolRightsDict.Add(UserRoles.STUDENT, studRR);
        }

        public static List<RoleRights> getRightsByRole(UserRoles role)
        {
            return role_RolRightsDict[role];
        }

    }
}
