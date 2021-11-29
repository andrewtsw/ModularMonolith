using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using TCO.SNT.Entities;
using TCO.Finportal.Framework.Domain.Exceptions;

namespace TCO.SNT.Tests
{
    public class SntTests
    {
        private readonly IReadOnlyList<SntStatus> _allowedToConfirmSntStatusList = new List<SntStatus>
                        {
                            SntStatus.NOT_VIEWED,
                            SntStatus.CREATED,
                            SntStatus.DELIVERED
                        };

        private readonly IReadOnlyList<SntStatus> _allowedToDeclineSntStatusList = new List<SntStatus>
                        {
                            SntStatus.NOT_VIEWED,
                            SntStatus.CREATED,
                            SntStatus.DELIVERED
                        };

        private readonly IReadOnlyList<SntStatus> _allowedToRevokeSntStatusList = new List<SntStatus>
                        {
                            SntStatus.NOT_VIEWED,
                            SntStatus.CREATED,
                            SntStatus.DELIVERED
                        };

        private readonly IReadOnlyList<SntStatus> _finishedStatusSntList = new List<SntStatus>
        {
                            SntStatus.CANCELED,
                            SntStatus.CONFIRMED,
                            SntStatus.CONFIRMED_BY_OGD,
                            SntStatus.DECLINED,
                            SntStatus.DECLINED_BY_OGD,
                            SntStatus.REVOKED
                         };

        private readonly IReadOnlyList<SntStatus> _correctableStatusSntList = new List<SntStatus>
        {
                            SntStatus.NOT_VIEWED,
                            SntStatus.DELIVERED
                         };

        private readonly IReadOnlyList<SntStatus> _editableStatusSntList = new List<SntStatus>
        {
                            SntStatus.DRAFT
                         };

        private IReadOnlyList<SntStatus> GetEnumSntStatusesExcept(IEnumerable<SntStatus> statusList)
        {
            return Enum.GetNames(typeof(SntStatus))
                .Select(q => (SntStatus)Enum.Parse(typeof(SntStatus), q))
                .Where(q => !statusList.Contains(q))
                .ToList();
        }

        [Fact]
        public void Snt_Should_Be_Allowed_To_Confirm_In_Status()
        {
            Assert.All(_allowedToConfirmSntStatusList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.True(snt.IsAllowedToConfirm(), $"Snt in status {status} should be allowed to confirm");
            });
        }

        [Fact]
        public void Snt_Should_Not_Be_Allowed_To_Confirm_In_Status()
        {
            var _notAllowedToConfirmSntStatusList = GetEnumSntStatusesExcept(_allowedToConfirmSntStatusList);

            Assert.All(_notAllowedToConfirmSntStatusList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.False(snt.IsAllowedToConfirm(), $"Snt in status {status} should not be allowed to confirm");
            });
        }

        [Fact]
        public void Snt_Should_Be_Allowed_To_Decline_In_Status()
        {
            Assert.All(_allowedToDeclineSntStatusList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.True(snt.IsAllowedToDecline(), $"Snt in status {status} should be allowed to decline");
            });
        }

        [Fact]
        public void Snt_Should_Not_Be_Allowed_To_Decline_In_Status()
        {
            var _notAllowedToDeclineSntStatusList = GetEnumSntStatusesExcept(_allowedToDeclineSntStatusList);

            Assert.All(_notAllowedToDeclineSntStatusList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.False(snt.IsAllowedToDecline(), $"Snt in status {status} should not be allowed to decline");
            });
        }

        [Fact]
        public void Snt_Should_Be_Allowed_To_Revoke_In_Status()
        {
            Assert.All(_allowedToRevokeSntStatusList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.True(snt.IsAllowedToRevoke(), $"Snt in status {status} should be allowed to revoke");
            });
        }

        [Fact]
        public void Snt_Should_Not_Be_Allowed_To_Revoke_In_Status()
        {
            var _notAllowedToRevokeSntStatusList = GetEnumSntStatusesExcept(_allowedToRevokeSntStatusList);

            Assert.All(_notAllowedToRevokeSntStatusList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.False(snt.IsAllowedToRevoke(), $"Snt in status {status} should not be allowed to revoke");
            });
        }

        [Fact]
        public void Snt_Means_Finished_In_Status()
        {
            Assert.All(_finishedStatusSntList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.True(snt.IsFinished(), $"Snt in status {status} should mean as finished");
            });
        }

        [Fact]
        public void Snt_Means_Not_Finished_In_Status()
        {
            var _notFinishedSntStatusList = GetEnumSntStatusesExcept(_finishedStatusSntList);

            Assert.All(_notFinishedSntStatusList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };
                Assert.False(snt.IsFinished(), $"Snt in status {status} should mean as not finished");
            });
        }

        [Fact]
        public void Snt_Should_Be_Correctable_In_Status()
        {
            Assert.All(_correctableStatusSntList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };

                var exception = Record.Exception(() => snt.ValidateForCorrection());

                Assert.Null(exception);
            });
        }

        [Fact]
        public void Snt_Should_Not_Be_Correctable_In_Status()
        {
            var _notCorrectableStatusSntList = GetEnumSntStatusesExcept(_correctableStatusSntList);

            Assert.All(_notCorrectableStatusSntList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };

                Assert.Throws<ValidationException>(() => snt.ValidateForCorrection());
            });
        }

        [Fact]
        public void Snt_Should_Be_Editable_In_Status()
        {
            Assert.All(_editableStatusSntList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };

                var exception = Record.Exception(() => snt.ValidateForEdit());

                Assert.Null(exception);
            });
        }

        [Fact]
        public void Snt_Should_Not_Be_Editable_In_Status()
        {
            var _notEditableStatusSntList = GetEnumSntStatusesExcept(_editableStatusSntList);

            Assert.All(_notEditableStatusSntList, status =>
            {
                var snt = new Snt() { SntInfo = new SntInfo { Status = status } };

                Assert.Throws<ValidationException>(() => snt.ValidateForEdit());
            });
        }
    }
}
