using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Roles;
using TCO.SNT.Entities;
using TCO.SNT.Entities.Exceptions;

namespace TCO.SNT.UseCases.ApplicationServices
{
    internal class UserAccessService
    {
        private readonly ISharedModuleContract _sharedModuleContract;
        private readonly TaxpayerStoreUserValidator _storeAccessValidator;

        public UserAccessService(ISharedModuleContract sharedModuleContract, TaxpayerStoreUserValidator storeAccessValidator)
        {
            _sharedModuleContract = sharedModuleContract;
            _storeAccessValidator = storeAccessValidator;
        }

        public void ThrowIfUserNotAllowedToCorrectUformDraft(UFormType uFormType, UFormStatusType uFormStatus)
        {
            // Uform from ESF can be corrected by:
            // -- SntOperator role
            // -- SntReadOnly role            
            // -- TcoWareHouse role when Uform type is WriteOff type

            var isDraft = uFormStatus == UFormStatusType.DRAFT;
            var isSntOperator = _sharedModuleContract.IsCurrentUserInRole(RoleType.SntOperator);
            var isTcoWarehouse = _sharedModuleContract.IsCurrentUserInRole(RoleType.TCOWarehouse);
            var isSntReadOnly = _sharedModuleContract.IsCurrentUserInRole(RoleType.SntReadOnly);
            var isFormWriteOff = uFormType == UFormType.WRITE_OFF;

            if (isDraft && (isSntOperator || isSntReadOnly || (isTcoWarehouse && isFormWriteOff)))
            {
                return;
            }

            throw new ForbiddenException("UForm draft is forbidden for correction");
        }

        public void ThrowIfUserNotAllowedToSendUform(UFormType uFormType)
        {
            // 1. SntOperator role can send all UForms types to ESF
            // 2. TCOWarehouse role can send only write off UForms
            // 3. Other roles are forbidden to send Uforms to ESF

            var isSntOperator = _sharedModuleContract.IsCurrentUserInRole(RoleType.SntOperator);
            var isTcoWarehouse = _sharedModuleContract.IsCurrentUserInRole(RoleType.TCOWarehouse);

            if (isSntOperator || (isTcoWarehouse && uFormType == UFormType.WRITE_OFF))
            {
                return;
            }

            throw new ForbiddenException("Uform is forbidden for sending");
        }

        public void ThrowIfUserNotAllowedToEditSntDraft()
        {
            // Draft edit allowed only for SntReadOnly and SntOperator roles

            if (!_sharedModuleContract.IsCurrentUserInRole(RoleType.SntOperator) &&
                !_sharedModuleContract.IsCurrentUserInRole(RoleType.SntReadOnly))
            {
                throw new ForbiddenException("Edit snt draft is not allowed");
            }
        }

        public void ThrowIfUserNotAllowedToCorrectSnt()
        {
            if (!_sharedModuleContract.IsCurrentUserInRole(RoleType.SntOperator))
            {
                throw new ForbiddenException("Correction snt is not allowed");
            }
        }

        public async Task ThrowIfTaxpayerStoreForbidden(Entities.Snt snt, CancellationToken cancellationToken)
        {
            if (snt.Customer.TaxpayerStoreId.HasValue)
            {
                await _storeAccessValidator.ThrowExceptionIfTaxpayerStoreForbiddenForUserAsync(snt.Customer.TaxpayerStoreId.Value, cancellationToken);
            }

            if (snt.Seller.TaxpayerStoreId.HasValue)
            {
                await _storeAccessValidator.ThrowExceptionIfTaxpayerStoreForbiddenForUserAsync(snt.Seller.TaxpayerStoreId.Value, cancellationToken);
            }
        }

        public async Task ThrowIfTaxpayerStoreForbidden(UForm form, CancellationToken cancellationToken)
        {
            var userTaxpareStores = await _storeAccessValidator.GetUserAllowedTaxpayerStoreIdsAsync(cancellationToken);

            var sourceProducts = form.SourceProducts.Where(q => q.BalanceId != null);
            var products = form.Products.Where(q => q.BalanceId != null);

            if (sourceProducts.Any(q => !userTaxpareStores.Contains(q.Balance.TaxpayerStoreId)) ||
                products.Any(q => !userTaxpareStores.Contains(q.Balance.TaxpayerStoreId)))
            {
                throw new ForbiddenException($"One or several TaxpayerStore(s) are forbidden for user");
            }
        }
    }
}
