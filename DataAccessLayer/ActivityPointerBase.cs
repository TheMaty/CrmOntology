//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMOntology.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityPointerBase
    {
        public ActivityPointerBase()
        {
            this.ActivityPartyBases = new HashSet<ActivityPartyBase>();
            this.ActivityPointerBase1 = new HashSet<ActivityPointerBase>();
            this.ActivityPointerBase11 = new HashSet<ActivityPointerBase>();
            this.CampaignActivityItemBases = new HashSet<CampaignActivityItemBase>();
        }
    
        public Nullable<System.Guid> OwningBusinessUnit { get; set; }
        public Nullable<System.DateTime> ActualEnd { get; set; }
        public byte[] VersionNumber { get; set; }
        public System.Guid ActivityId { get; set; }
        public Nullable<bool> IsBilled { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ServiceId { get; set; }
        public int ActivityTypeCode { get; set; }
        public int StateCode { get; set; }
        public Nullable<System.DateTime> ScheduledEnd { get; set; }
        public Nullable<int> ScheduledDurationMinutes { get; set; }
        public Nullable<int> ActualDurationMinutes { get; set; }
        public Nullable<int> StatusCode { get; set; }
        public Nullable<System.DateTime> ActualStart { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> PriorityCode { get; set; }
        public Nullable<System.Guid> RegardingObjectId { get; set; }
        public string Subject { get; set; }
        public Nullable<bool> IsWorkflowCreated { get; set; }
        public Nullable<System.DateTime> ScheduledStart { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<int> RegardingObjectTypeCode { get; set; }
        public string RegardingObjectIdName { get; set; }
        public Nullable<int> TimeZoneRuleVersionNumber { get; set; }
        public Nullable<int> UTCConversionTimeZoneCode { get; set; }
        public string RegardingObjectIdYomiName { get; set; }
        public Nullable<System.DateTime> RecApptMstrOverriddenCreatedOn { get; set; }
        public string RecApptMstrGlobalObjectId { get; set; }
        public Nullable<bool> SeriesStatus { get; set; }
        public Nullable<int> RecApptMstrOutlookOwnerApptId { get; set; }
        public string DeletedExceptionsList { get; set; }
        public Nullable<System.DateTime> NextExpansionInstanceDate { get; set; }
        public string RecApptMstrLocation { get; set; }
        public Nullable<System.Guid> GroupId { get; set; }
        public Nullable<System.DateTime> LastExpandedInstanceDate { get; set; }
        public Nullable<int> ExpansionStateCode { get; set; }
        public string RecApptMstrCategory { get; set; }
        public Nullable<bool> RecApptMstrIsAllDayEvent { get; set; }
        public string RecApptMstrSubcategory { get; set; }
        public Nullable<System.Guid> RecApptMstrSubscriptionId { get; set; }
        public Nullable<int> RecApptMstrImportSequenceNumber { get; set; }
        public string ModifiedFieldsMask { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public System.Guid OwnerId { get; set; }
        public int InstanceTypeCode { get; set; }
        public Nullable<System.Guid> SeriesId { get; set; }
        public Nullable<System.Guid> TransactionCurrencyId { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public bool IsRegularActivity { get; set; }
        public Nullable<System.DateTime> OriginalStartDate { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public int OwnerIdType { get; set; }
        public Nullable<System.DateTime> QteCloseOverriddenCreatedOn { get; set; }
        public string QuoteNumber { get; set; }
        public Nullable<int> QteCloseImportSequenceNumber { get; set; }
        public string QteCloseCategory { get; set; }
        public Nullable<int> QteCloseRevision { get; set; }
        public string QteCloseSubcategory { get; set; }
        public string ApptCategory { get; set; }
        public string ApptGlobalObjectId { get; set; }
        public Nullable<bool> ApptIsAllDayEvent { get; set; }
        public Nullable<int> ApptImportSequenceNumber { get; set; }
        public Nullable<int> ApptOutlookOwnerApptId { get; set; }
        public Nullable<System.DateTime> ApptOverriddenCreatedOn { get; set; }
        public string ApptSubcategory { get; set; }
        public Nullable<System.Guid> ApptSubscriptionId { get; set; }
        public string ApptLocation { get; set; }
        public Nullable<decimal> ActualCost_Base { get; set; }
        public Nullable<int> CampActImportSequenceNumber { get; set; }
        public Nullable<decimal> BudgetedCost_Base { get; set; }
        public Nullable<decimal> ActualCost { get; set; }
        public Nullable<bool> IgnoreInactiveListMembers { get; set; }
        public Nullable<bool> DoNotSendOnOptOut { get; set; }
        public Nullable<int> TypeCode { get; set; }
        public string CampActSubcategory { get; set; }
        public Nullable<System.DateTime> CampActOverriddenCreatedOn { get; set; }
        public Nullable<int> ExcludeIfContactedInXDays { get; set; }
        public string CampActCategory { get; set; }
        public Nullable<decimal> BudgetedCost { get; set; }
        public Nullable<int> CampActChannelTypeCode { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> ReceivedOn { get; set; }
        public Nullable<int> ResponseCode { get; set; }
        public string YomiLastName { get; set; }
        public Nullable<System.DateTime> CampResOverriddenCreatedOn { get; set; }
        public string YomiFirstName { get; set; }
        public string CompanyName { get; set; }
        public string CampResCategory { get; set; }
        public string Telephone { get; set; }
        public Nullable<System.Guid> OriginatingActivityId { get; set; }
        public string Fax { get; set; }
        public string LastName { get; set; }
        public Nullable<int> CampResImportSequenceNumber { get; set; }
        public Nullable<int> OriginatingActivityIdTypeCode { get; set; }
        public string EMailAddress { get; set; }
        public Nullable<int> CampResChannelTypeCode { get; set; }
        public string YomiCompanyName { get; set; }
        public string PromotionCodeName { get; set; }
        public string CampResSubcategory { get; set; }
        public Nullable<int> SuccessCount { get; set; }
        public Nullable<int> OperationTypeCode { get; set; }
        public string BulkOperationNumber { get; set; }
        public Nullable<int> TargetMembersCount { get; set; }
        public Nullable<int> CreatedRecordTypeCode { get; set; }
        public string Parameters { get; set; }
        public Nullable<int> ErrorNumber { get; set; }
        public Nullable<int> TargetedRecordTypeCode { get; set; }
        public Nullable<int> FailureCount { get; set; }
        public Nullable<bool> Compressed { get; set; }
        public Nullable<bool> ReadReceiptRequested { get; set; }
        public Nullable<bool> DeliveryReceiptRequested { get; set; }
        public string EmailSubcategory { get; set; }
        public Nullable<int> Notifications { get; set; }
        public string MessageId { get; set; }
        public string Sender { get; set; }
        public string ToRecipients { get; set; }
        public Nullable<System.DateTime> EmailOverriddenCreatedOn { get; set; }
        public string SubmittedBy { get; set; }
        public Nullable<int> EmailImportSequenceNumber { get; set; }
        public Nullable<bool> EmailDirectionCode { get; set; }
        public string MimeType { get; set; }
        public Nullable<System.Guid> MessageIdDupCheck { get; set; }
        public Nullable<int> DeliveryAttempts { get; set; }
        public string TrackingToken { get; set; }
        public string EmailCategory { get; set; }
        public Nullable<int> SvcApptImportSequenceNumber { get; set; }
        public string SvcApptLocation { get; set; }
        public Nullable<bool> SvcApptIsAllDayEvent { get; set; }
        public string SvcApptSubcategory { get; set; }
        public Nullable<System.Guid> SiteId { get; set; }
        public Nullable<System.DateTime> SvcApptOverriddenCreatedOn { get; set; }
        public string SvcApptCategory { get; set; }
        public Nullable<System.Guid> SvcApptSubscriptionId { get; set; }
        public string TaskCategory { get; set; }
        public Nullable<int> PercentComplete { get; set; }
        public Nullable<System.DateTime> TaskOverriddenCreatedOn { get; set; }
        public Nullable<System.Guid> TaskSubscriptionId { get; set; }
        public string TaskSubcategory { get; set; }
        public Nullable<int> TaskImportSequenceNumber { get; set; }
        public string Address { get; set; }
        public Nullable<int> LetterImportSequenceNumber { get; set; }
        public Nullable<System.Guid> LetterSubscriptionId { get; set; }
        public string LetterCategory { get; set; }
        public string LetterSubcategory { get; set; }
        public Nullable<bool> LetterDirectionCode { get; set; }
        public Nullable<System.DateTime> LetterOverriddenCreatedOn { get; set; }
        public Nullable<System.DateTime> PhoneOverriddenCreatedOn { get; set; }
        public Nullable<int> PhoneImportSequenceNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneSubcategory { get; set; }
        public Nullable<bool> PhoneDirectionCode { get; set; }
        public Nullable<System.Guid> PhoneSubscriptionId { get; set; }
        public string PhoneCategory { get; set; }
        public string OrdCloseSubcategory { get; set; }
        public Nullable<int> OrdCloseImportSequenceNumber { get; set; }
        public Nullable<int> OrdCloseRevision { get; set; }
        public string OrderNumber { get; set; }
        public string OrdCloseCategory { get; set; }
        public Nullable<System.DateTime> OrdCloseOverriddenCreatedOn { get; set; }
        public string FaxNumber { get; set; }
        public string CoverPageName { get; set; }
        public Nullable<int> NumberOfPages { get; set; }
        public Nullable<System.Guid> FaxSubscriptionId { get; set; }
        public Nullable<int> FaxImportSequenceNumber { get; set; }
        public string BillingCode { get; set; }
        public string Tsid { get; set; }
        public Nullable<bool> FaxDirectionCode { get; set; }
        public Nullable<System.DateTime> FaxOverriddenCreatedOn { get; set; }
        public string FaxSubcategory { get; set; }
        public string FaxCategory { get; set; }
        public string IncResSubcategory { get; set; }
        public string IncResCategory { get; set; }
        public Nullable<int> IncResImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> IncResOverriddenCreatedOn { get; set; }
        public Nullable<int> TimeSpent { get; set; }
        public Nullable<System.Guid> CompetitorId { get; set; }
        public Nullable<System.DateTime> OppCloseOverriddenCreatedOn { get; set; }
        public Nullable<int> OppCloseImportSequenceNumber { get; set; }
        public Nullable<decimal> ActualRevenue_Base { get; set; }
        public Nullable<decimal> ActualRevenue { get; set; }
        public string OppCloseSubcategory { get; set; }
        public string OppCloseCategory { get; set; }
        public int EmailAttachmentCount { get; set; }
        public string ConversationIndex { get; set; }
        public string InReplyTo { get; set; }
        public Nullable<int> CorrelationMethod { get; set; }
        public Nullable<int> BaseConversationIndexHash { get; set; }
        public Nullable<System.Guid> ParentActivityId { get; set; }
        public Nullable<System.Guid> SenderMailboxId { get; set; }
        public Nullable<bool> IsMapiPrivate { get; set; }
        public Nullable<bool> LeftVoiceMail { get; set; }
        public Nullable<System.DateTime> DeliveryLastAttemptedOn { get; set; }
        public Nullable<System.Guid> StageId { get; set; }
        public Nullable<int> DeliveryPriorityCode { get; set; }
        public Nullable<System.DateTime> SentOn { get; set; }
        public Nullable<System.DateTime> PostponeActivityProcessingUntil { get; set; }
        public Nullable<System.Guid> ProcessId { get; set; }
        public Nullable<int> PostMessageType { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public string InResponseTo { get; set; }
        public Nullable<System.Guid> PostAuthor { get; set; }
        public Nullable<System.DateTime> PostedOn { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public string ThreadId { get; set; }
        public string SocialAdditionalParams { get; set; }
        public string PostURL { get; set; }
        public Nullable<System.Guid> PostFromProfileId { get; set; }
        public Nullable<bool> SocialActivityDirectionCode { get; set; }
        public string PostId { get; set; }
        public Nullable<double> SentimentValue { get; set; }
        public Nullable<System.Guid> PostAuthorAccount { get; set; }
        public string PostToProfileId { get; set; }
        public string PostAuthorAccountName { get; set; }
        public Nullable<int> PostAuthorAccountType { get; set; }
        public Nullable<int> PostAuthorType { get; set; }
        public string PostAuthorName { get; set; }
        public string PostAuthorYomiName { get; set; }
        public string PostAuthorAccountYomiName { get; set; }
        public Nullable<int> Community { get; set; }
        public Nullable<System.Guid> EmailSender { get; set; }
        public Nullable<System.Guid> SendersAccount { get; set; }
        public Nullable<int> EmailSenderObjectTypeCode { get; set; }
        public string EmailSenderName { get; set; }
        public string SendersAccountName { get; set; }
        public Nullable<int> SendersAccountObjectTypeCode { get; set; }
        public string EmailSenderYomiName { get; set; }
        public string SendersAccountYomiName { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual ICollection<ActivityPartyBase> ActivityPartyBases { get; set; }
        public virtual ICollection<ActivityPointerBase> ActivityPointerBase1 { get; set; }
        public virtual ActivityPointerBase ActivityPointerBase2 { get; set; }
        public virtual BusinessUnitBase BusinessUnitBase { get; set; }
        public virtual BusinessUnitBase BusinessUnitBase1 { get; set; }
        public virtual CompetitorBase CompetitorBase { get; set; }
        public virtual ICollection<ActivityPointerBase> ActivityPointerBase11 { get; set; }
        public virtual ActivityPointerBase ActivityPointerBase3 { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual AppointmentBase AppointmentBase { get; set; }
        public virtual CampaignActivityBase CampaignActivityBase { get; set; }
        public virtual CampaignResponseBase CampaignResponseBase { get; set; }
        public virtual EmailBase EmailBase { get; set; }
        public virtual FaxBase FaxBase { get; set; }
        public virtual LetterBase LetterBase { get; set; }
        public virtual PhoneCallBase PhoneCallBase { get; set; }
        public virtual ICollection<CampaignActivityItemBase> CampaignActivityItemBases { get; set; }
        public virtual OwnerBase OwnerBase { get; set; }
        public virtual ServiceBase ServiceBase { get; set; }
        public virtual SiteBase SiteBase { get; set; }
        public virtual SocialProfileBase SocialProfileBase { get; set; }
        public virtual TransactionCurrencyBase TransactionCurrencyBase { get; set; }
        public virtual TransactionCurrencyBase TransactionCurrencyBase1 { get; set; }
        public virtual TaskBase TaskBase { get; set; }
    }
}
