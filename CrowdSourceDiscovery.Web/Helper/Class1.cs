using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CrowdSourceDiscovery.Web.Helper
{
    public class PermissionHelper
    {
        private readonly IPrincipal _principalIndentity;

        public PermissionHelper(IPrincipal principal)
        {
            _principalIndentity = principal;
        }

        public bool CheckCurrentViewerIsUser(Guid userId)
        {
            if (!_principalIndentity.Identity.IsAuthenticated)
            {
                return false;
            }

            return new Guid(_principalIndentity.Identity.GetUserId()) == userId;
        }
    }
}