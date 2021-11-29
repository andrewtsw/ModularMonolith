using System;
using System.Linq;
using System.Reflection;
using TCO.Finportal.EInvoicing.Controllers;
using TCO.Finportal.Framework.Controllers;
using TCO.Finportal.Shared.Controllers;
using TCO.Finportal.Shared.Controllers.Admin;
using TCO.SNT.Common.Roles;
using TCO.SNT.Controllers;
using TCO.SNT.Controllers.Admin;
using Xunit;
using SntControllers = TCO.SNT.Controllers;
using EInvoicingControllers = TCO.Finportal.EInvoicing.Controllers;
using SharedControllers = TCO.Finportal.Shared.Controllers;


namespace TCO.SNT.Tests
{
    public class ControllersRoleTests
    {
        #region AdminController

        [Fact]
        public void AdminController_Should_Have_Only_Admin_Role()
        {
            AssertControllerHasRoles(typeof(AdminController), new RoleType[] { RoleType.Admin });
        }
        #endregion

        #region GroupRoleController

        [Fact]
        public void GroupRoleController_Should_Have_Only_Admin_Role()
        {
            AssertControllerHasRoles(typeof(GroupRoleController), new RoleType[] { RoleType.Admin });
        }

        #endregion

        #region GroupTaxpayerStoreController

        [Fact]
        public void GroupTaxpayerStoreController_Should_Have_Only_Admin_Role()
        {
            AssertControllerHasRoles(typeof(GroupTaxpayerStoreController), new RoleType[] { RoleType.Admin });
        }

        #endregion

        #region BalanceController

        [Fact]
        public void BalanceController_GetAll_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(BalanceController), "GetAll", expectedRoles);
        }

        [Fact]
        public void BalanceController_GetBalanceListReport_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(BalanceController), "GetBalanceListReport", expectedRoles);
        }

        [Fact]
        public void BalanceController_ImportBalances_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(BalanceController), "ImportBalances", expectedRoles);
        }

        [Fact]
        public void BalanceController_ImportBalancesInitial_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(BalanceController), "ImportBalancesInitial", expectedRoles);
        }

        [Fact]
        public void BalanceController_FixBalancesImportKey_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(BalanceController), "FixBalancesImportKey", expectedRoles);
        }

        [Fact]
        public void BalanceController_ValidateBalances_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(BalanceController), "ValidateBalances", expectedRoles);
        }

        [Fact]
        public void BalanceController_All_Actions_Are_Tested()
        {
            AssertControllerActionsTested(typeof(BalanceController));
        }

        #endregion

        #region Shared DictionariesController

        [Fact]
        public void DictionariesController_GetMeasureUnits_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.AllBusinesRoles;

            AssertControllerActionHasRoles(typeof(SharedControllers.DictionariesController), "GetMeasureUnits", expectedRoles);
        }

        [Fact]
        public void DictionariesController_GetFavouriteMeasureUnits_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.AllBusinesRoles;

            AssertControllerActionHasRoles(typeof(SharedControllers.DictionariesController), "GetFavouriteMeasureUnits", expectedRoles);
        }

        [Fact]
        public void DictionariesController_ImportMeasureUnits_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.AdminRoles;

            AssertControllerActionHasRoles(typeof(SharedControllers.DictionariesController), "ImportMeasureUnits", expectedRoles);
        }

        [Fact]
        public void SharedDictionariesController_All_Actions_Are_Tested()
        {
            AssertControllerActionsTested(typeof(SharedControllers.DictionariesController));
        }

        #endregion

        #region Snt DictionariesController

        [Fact]
        public void DictionariesController_GetFavoriteProducts_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.SntModuleRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "GetFavoriteProducts", expectedRoles);
        }

        [Fact]
        public void DictionariesController_AddFavoriteProduct_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.AdminRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "AddFavoriteProduct", expectedRoles);
        }

        [Fact]
        public void DictionariesController_GetCurrencies_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.SntModuleRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "GetCurrencies", expectedRoles);
        }

        [Fact]
        public void DictionariesController_ImportExchangeRates_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.AdminRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "ImportExchangeRates", expectedRoles);
        }

        [Fact]
        public void DictionariesController_GetCountries_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.SntModuleRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "GetCountries", expectedRoles);
        }

        [Fact]
        public void DictionariesController_GetFavouriteCountries_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.SntModuleRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "GetFavouriteCountries", expectedRoles);
        }

        [Fact]
        public void DictionariesController_GetFavouriteCurrencies_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.SntModuleRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "GetFavouriteCurrencies", expectedRoles);
        }

        [Fact]
        public void DictionariesController_ImportGsvs_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.AdminRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "ImportGsvs", expectedRoles);
        }

        [Fact]
        public void DictionariesController_ImportErrorCodes_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.AdminRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "ImportErrorCodes", expectedRoles);
        }

        [Fact]
        public void DictionariesController_GetChildrenProducts_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.SntModuleRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "GetChildrenProducts", expectedRoles);
        }

        [Fact]
        public void DictionariesController_SearchProducts_Should_Have_Roles()
        {
            var expectedRoles = RoleTypeExtensions.SntModuleRoles;

            AssertControllerActionHasRoles(typeof(SntControllers.DictionariesController), "SearchProducts", expectedRoles);
        }

        [Fact]
        public void SntDictionariesController_All_Actions_Are_Tested()
        {
            AssertControllerActionsTested(typeof(SntControllers.DictionariesController));
        }

        #endregion

        #region EsfProfileController

        [Fact]
        public void EsfProfileController_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.TCOWarehouse,
                RoleType.Admin,
                RoleType.ApReadWrite,
                RoleType.ArReadWrite
            };

            AssertControllerHasRoles(typeof(EsfProfileController), expectedRoles);
        }

        #endregion

        #region SntController

        [Fact]
        public void SntController_GetAll_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "GetAll", expectedRoles);
        }

        [Fact]
        public void SntController_Get_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "Get", expectedRoles);
        }

        [Fact]
        public void SntController_GetSntListReport_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "GetSntListReport", expectedRoles);
        }

        [Fact]
        public void SntController_Revoke_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "Revoke", expectedRoles);
        }

        [Fact]
        public void SntController_Confirm_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "Confirm", expectedRoles);
        }

        [Fact]
        public void SntController_Decline_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "Decline", expectedRoles);
        }

        [Fact]
        public void SntController_Import_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "Import", expectedRoles);
        }

        [Fact]
        public void SntController_SaveDraft_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "SaveDraft", expectedRoles);
        }

        [Fact]
        public void SntController_Send_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "Send", expectedRoles);
        }

        [Fact]
        public void SntController_GetSellerByTin_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "GetSellerByTin", expectedRoles);
        }

        [Fact]
        public void SntController_SearchSntParticipantsByName_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(SntControllers.SntController), "SearchSntParticipantsByName", expectedRoles);
        }

        [Fact]
        public void SntController_All_Actions_Are_Tested()
        {
            AssertControllerActionsTested(typeof(SntControllers.SntController));

        }
        #endregion

        #region TaxpayerStoreController

        [Fact]
        public void TaxpayerStoreController_GetUserTaxpayerStores_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(TaxpayerStoreController), "GetUserTaxpayerStores", expectedRoles);
        }

        [Fact]
        public void TaxpayerStoreController_GetAllTaxpayerStores_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse,
                RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(TaxpayerStoreController), "GetAllTaxpayerStores", expectedRoles);
        }

        [Fact]
        public void TaxpayerStoreController_Import_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(TaxpayerStoreController), "Import", expectedRoles);
        }

        [Fact]
        public void TaxpayerStoreController_All_Actions_Are_Tested()
        {
            AssertControllerActionsTested(typeof(TaxpayerStoreController));
        }

        #endregion

        #region UFormController

        [Fact]
        public void UFormController_GetAllForms_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator,
               RoleType.SntReadOnly,
               RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(UFormController), "GetAllForms", expectedRoles);
        }

        [Fact]
        public void UFormController_Get_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator,
               RoleType.SntReadOnly,
               RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(UFormController), "Get", expectedRoles);
        }

        [Fact]
        public void UFormController_SaveManufactureDraft_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator,
               RoleType.SntReadOnly
            };

            AssertControllerActionHasRoles(typeof(UFormController), "SaveManufactureDraft", expectedRoles);
        }

        [Fact]
        public void UFormController_SaveMovementDraft_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator,
               RoleType.SntReadOnly
            };

            AssertControllerActionHasRoles(typeof(UFormController), "SaveMovementDraft", expectedRoles);
        }

        [Fact]
        public void UFormController_SaveWriteOffDraft_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator,
               RoleType.SntReadOnly,
               RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(UFormController), "SaveWriteOffDraft", expectedRoles);
        }

        [Fact]
        public void UFormController_SaveBalanceDraft_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator,
               RoleType.SntReadOnly
            };

            AssertControllerActionHasRoles(typeof(UFormController), "SaveBalanceDraft", expectedRoles);
        }

        [Fact]
        public void UFormController_Cancel_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator
            };

            AssertControllerActionHasRoles(typeof(UFormController), "Cancel", expectedRoles);
        }

        [Fact]
        public void UFormController_Send_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(UFormController), "Send", expectedRoles);
        }

        [Fact]
        public void UFormController_Import_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.SntOperator,
               RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(UFormController), "Import", expectedRoles);
        }

        [Fact]
        public void UFormController_GetUFormListReport_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse
            };

            AssertControllerActionHasRoles(typeof(UFormController), "GetUFormListReport", expectedRoles);
        }

        [Fact]
        public void UFormController_All_Actions_Are_Tested()
        {
            AssertControllerActionsTested(typeof(UFormController));
        }

        #endregion

        #region UserController

        [Fact]
        public void UserController_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.SntOperator,
                RoleType.SntReadOnly,
                RoleType.TCOWarehouse,
                RoleType.Admin,
                RoleType.ApReadOnly,
                RoleType.ApReadWrite,
                RoleType.ArReadOnly,
                RoleType.ArReadWrite
            };

            AssertControllerHasRoles(typeof(UserController), expectedRoles);
        }

        #endregion

        #region InvoicesController

        [Fact]
        public void InvoicesController_ImportInvoicesInitial_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "ImportInvoicesInitial", expectedRoles);
        }

        [Fact]
        public void InvoicesController_ImportInvoicesRegular_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "ImportInvoicesRegular", expectedRoles);
        }

        [Fact]
        public void InvoicesController_SearchInboundInvoices_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ApReadOnly,
               RoleType.ApReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "SearchInboundInvoices", expectedRoles);
        }

        [Fact]
        public void InvoicesController_GetInboundInvoice_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ApReadOnly,
               RoleType.ApReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "GetInboundInvoice", expectedRoles);
        }

        [Fact]
        public void InvoicesController_Confirm_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ApReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "Confirm", expectedRoles);
        }

        [Fact]
        public void InvoicesController_Decline_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ApReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "Decline", expectedRoles);
        }

        [Fact]
        public void InvoicesController_SearchOutboundInvoices_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ArReadOnly,
               RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "SearchOutboundInvoices", expectedRoles);
        }

        [Fact]
        public void InvoicesController_GetOutboundInvoice_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ArReadOnly,
               RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "GetOutboundInvoice", expectedRoles);
        }

        [Fact]
        public void InvoicesController_SaveDraft_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "SaveDraft", expectedRoles);
        }

        [Fact]
        public void InvoicesController_Send_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "Send", expectedRoles);
        }

        [Fact]
        public void InvoicesController_Revoke_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "Revoke", expectedRoles);
        }

        [Fact]
        public void InvoicesController_BuildReport_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.ApReadOnly,
               RoleType.ApReadWrite,
               RoleType.ArReadOnly,
               RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(InvoicesController), "BuildReport", expectedRoles);
        }

        [Fact]
        public void InvoicesController_All_Actions_Are_Tested()
        {
            AssertControllerActionsTested(typeof(InvoicesController));
        }

        #endregion

        #region AwpController
        
        [Fact]
        public void AwpController_ImportAwpsRegular_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(AwpController), "ImportAwpsRegular", expectedRoles);
        }

        [Fact]
        public void AwpController_ImportAwpsInitial_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(AwpController), "ImportAwpsInitial", expectedRoles);
        }

        [Fact]
        public void AwpController_GetAll_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {               
               RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(AwpController), "GetAll", expectedRoles);
        }

        #endregion

        #region EInvoicingSntController
        
        [Fact]
        public void EInvoicingSntController_GetSntList_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
                RoleType.ArReadWrite
            };

            AssertControllerActionHasRoles(typeof(EInvoicingControllers.SntController), "GetSntList", expectedRoles);
        }

        #endregion

        #region JdeController

        [Fact]
        public void JdeController_ImportJdeArInvoices_Should_Have_Roles()
        {
            var expectedRoles = new RoleType[] {
               RoleType.Admin
            };

            AssertControllerActionHasRoles(typeof(JdeController), "ImportJdeArInvoices", expectedRoles);
        }

        #endregion

        private void AssertControllerHasRoles(Type controllerType, RoleType[] expectedRoles)
        {
            var attributes = controllerType.GetCustomAttributes(typeof(RoleAuthorizeAttribute), true);

            Assert.True(attributes.Any(), $"Authorize Attribute for {controllerType.Name} should be specified");

            var attribute = (RoleAuthorizeAttribute)attributes.First();
            var roleTypes = attribute.RoleTypes;

            var difference = roleTypes.Length >= expectedRoles.Length ? roleTypes.Except(expectedRoles) : expectedRoles.Except(roleTypes);

            var errMsg = $"{controllerType.Name} should have only {string.Join(", ", expectedRoles.Select(q => q.ToString())) } role(s)";

            Assert.True(!difference.Any(), errMsg);
        }

        private void AssertControllerActionHasRoles(Type controllerType, string methodName, RoleType[] expectedRoles)
        {
            var methodInfo = controllerType.GetMethod(methodName);
            var attributes = methodInfo.GetCustomAttributes(typeof(RoleAuthorizeAttribute), true);

            Assert.True(attributes.Any(), $"Authorize Attribute for Action {methodName} should be specified");

            var authorizeAttr = (RoleAuthorizeAttribute)attributes.First();
            var roleTypes = authorizeAttr.RoleTypes;
            var difference = roleTypes.Length >= expectedRoles.Length ? roleTypes.Except(expectedRoles) : expectedRoles.Except(roleTypes);

            var errMsg = $"Action {methodName} should have only {string.Join(", ", expectedRoles.Select(q => q.ToString())) } role(s)";
            Assert.True(!difference.Any(), errMsg);
        }

        private void AssertControllerActionsTested(Type controllerType)
        {
            // All tests for controller actions should be named as: {ControllerName}_{ActionName}_{AnyOtherDescription}

            var controllerTests = typeof(ControllersRoleTests)
                                    .GetMethods()
                                    .Where(q => q.Name.Contains(controllerType.Name))
                                    .Select(q => q.Name.Split("_")[1]);

            var actionNames = controllerType
                                    .GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                                    .Select(q => q.Name);

            var difference = actionNames.Except(controllerTests);

            var errMsg = $"Controller actions : {string.Join(", ", difference)}, do not have access role tests";

            Assert.True(!difference.Any(), errMsg);
        }
    }
}
