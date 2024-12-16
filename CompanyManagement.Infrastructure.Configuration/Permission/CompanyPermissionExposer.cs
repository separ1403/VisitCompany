using Framework.Infrastructure;

namespace CompanyManagement.Infrastructure.Configuration.Permission
{
    public class CompanyPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "شرکت", new List<PermissionDto>
                    {
                        new PermissionDto(CompanyPermission.ListCompanies, "لیست شرکت ها"),
                        new PermissionDto(CompanyPermission.SearchCompanies, "جستجوی شرکت ها"),
                        new PermissionDto(CompanyPermission.CreateCompanies, "ایجاد شرکت"),
                        new PermissionDto(CompanyPermission.EditCompanies, "ویرایش شرکت"),
                        new PermissionDto(CompanyPermission.ReferCompanies, "ارجاع شرکت"),


                    }
                },
                {
                    "دسته بندی", new List<PermissionDto>
                    {
                        new PermissionDto(CompanyPermission.SearchCompanyCategories, "جستجوی دسته بندی"),
                        new PermissionDto(CompanyPermission.ListCompanyCategories, "لیست دسته بندی"),
                        new PermissionDto(CompanyPermission.CreateCompanyCategory, "ایجاد دسته بندی"),
                        new PermissionDto(CompanyPermission.EditCompanyCategory, "ویرایش دسته بندی"),
                    }

                },
                {
                    "حساب های کاربری", new List<PermissionDto>
                    {
                        new PermissionDto(CompanyPermission.ListAccounts, "لیست حساب های کاربری"),
                        new PermissionDto(CompanyPermission.SearchAccounts, "جستجوی حساب های کاربری"),
                        new PermissionDto(CompanyPermission.CreateAccounts, "ایجاد حساب  کاربری"),
                        new PermissionDto(CompanyPermission.EditAccounts, "ویرایش حساب  کاربری"),

                    }
                },
                {
                "نفش ها", new List<PermissionDto>
                {
                    new PermissionDto(CompanyPermission.ListRoles, "لیست نقش ها"),
                    new PermissionDto(CompanyPermission.SearchRoles, "جستجوی نقش ها"),
                    new PermissionDto(CompanyPermission.CreateRoles, "ایجاد نقش "),
                    new PermissionDto(CompanyPermission.EditRoles, "ویرایش نقش ها"),

                }
            },

                {
                "مجوزها", new List<PermissionDto>
                {
                    new PermissionDto(CompanyPermission.SearchLicenceCategories, "جستجوی مجوزها "),
                    new PermissionDto(CompanyPermission.ListLicenceCategories, "لیست مجوزها "),
                    new PermissionDto(CompanyPermission.CreateLicenceCategories, "ایجاد مجوز "),
                    new PermissionDto(CompanyPermission.EditLicenceCategories, "ویرایش مجوزها"),
                }

            },



                {
                "استان محل خدمت", new List<PermissionDto>
                {
                    new PermissionDto(CompanyPermission.SearchStateCategories, "جستجوی دسته بندی استانی "),
                    new PermissionDto(CompanyPermission.ListStateCategories, "لیست دسته بندی استانی "),
                    new PermissionDto(CompanyPermission.CreateStateCategory, "ایجاد دسته بندی استانی "),
                    new PermissionDto(CompanyPermission.EditStateCategory, "ویرایش دسته بندی استانی"),
                }

            }


            };
        }
    }
}






