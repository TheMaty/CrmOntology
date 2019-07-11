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
    
    public partial class OpportunityBase
    {
        public OpportunityBase()
        {
            this.LeadBases = new HashSet<LeadBase>();
        }
    
        public System.Guid OpportunityId { get; set; }
        public Nullable<System.Guid> PriceLevelId { get; set; }
        public Nullable<int> OpportunityRatingCode { get; set; }
        public Nullable<int> PriorityCode { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> StepId { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> EstimatedValue { get; set; }
        public string StepName { get; set; }
        public Nullable<int> SalesStageCode { get; set; }
        public Nullable<bool> ParticipatesInWorkflow { get; set; }
        public Nullable<int> PricingErrorCode { get; set; }
        public Nullable<System.DateTime> EstimatedCloseDate { get; set; }
        public Nullable<int> CloseProbability { get; set; }
        public Nullable<decimal> ActualValue { get; set; }
        public Nullable<System.DateTime> ActualCloseDate { get; set; }
        public Nullable<System.Guid> OwningBusinessUnit { get; set; }
        public Nullable<System.Guid> OriginatingLeadId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public byte[] VersionNumber { get; set; }
        public int StateCode { get; set; }
        public Nullable<int> StatusCode { get; set; }
        public Nullable<bool> IsRevenueSystemCalculated { get; set; }
        public Nullable<System.Guid> CampaignId { get; set; }
        public Nullable<System.Guid> TransactionCurrencyId { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<int> UTCConversionTimeZoneCode { get; set; }
        public Nullable<int> TimeZoneRuleVersionNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<decimal> ActualValue_Base { get; set; }
        public Nullable<decimal> EstimatedValue_Base { get; set; }
        public Nullable<decimal> TotalDiscountAmount { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<decimal> TotalAmountLessFreight { get; set; }
        public Nullable<decimal> TotalLineItemDiscountAmount { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public System.Guid OwnerId { get; set; }
        public Nullable<decimal> FreightAmount { get; set; }
        public Nullable<decimal> TotalTax { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<decimal> TotalLineItemAmount { get; set; }
        public string CustomerIdName { get; set; }
        public Nullable<int> CustomerIdType { get; set; }
        public int OwnerIdType { get; set; }
        public Nullable<decimal> TotalDiscountAmount_Base { get; set; }
        public Nullable<decimal> FreightAmount_Base { get; set; }
        public Nullable<decimal> TotalLineItemAmount_Base { get; set; }
        public Nullable<decimal> TotalTax_Base { get; set; }
        public Nullable<decimal> TotalLineItemDiscountAmount_Base { get; set; }
        public Nullable<decimal> TotalAmount_Base { get; set; }
        public Nullable<decimal> DiscountAmount_Base { get; set; }
        public Nullable<decimal> TotalAmountLessFreight_Base { get; set; }
        public string CustomerIdYomiName { get; set; }
        public Nullable<bool> FileDebrief { get; set; }
        public Nullable<int> BudgetStatus { get; set; }
        public Nullable<bool> PresentProposal { get; set; }
        public Nullable<bool> SendThankYouNote { get; set; }
        public Nullable<bool> EvaluateFit { get; set; }
        public Nullable<System.DateTime> FinalDecisionDate { get; set; }
        public Nullable<bool> ConfirmInterest { get; set; }
        public Nullable<bool> CompleteInternalReview { get; set; }
        public Nullable<int> TimeLine { get; set; }
        public string CustomerPainPoints { get; set; }
        public Nullable<bool> ResolveFeedback { get; set; }
        public string QuoteComments { get; set; }
        public Nullable<int> PurchaseProcess { get; set; }
        public Nullable<bool> CaptureProposalFeedback { get; set; }
        public Nullable<System.Guid> ParentContactId { get; set; }
        public Nullable<bool> IdentifyCustomerContacts { get; set; }
        public Nullable<bool> CompleteFinalProposal { get; set; }
        public Nullable<decimal> BudgetAmount { get; set; }
        public Nullable<System.Guid> ParentAccountId { get; set; }
        public Nullable<System.DateTime> ScheduleFollowup_Qualify { get; set; }
        public Nullable<int> Need { get; set; }
        public Nullable<bool> PursuitDecision { get; set; }
        public Nullable<System.Guid> ProcessId { get; set; }
        public Nullable<System.DateTime> ScheduleProposalMeeting { get; set; }
        public Nullable<System.Guid> StageId { get; set; }
        public string QualificationComments { get; set; }
        public Nullable<int> SalesStage { get; set; }
        public Nullable<int> InitialCommunication { get; set; }
        public Nullable<bool> IdentifyPursuitTeam { get; set; }
        public Nullable<System.DateTime> ScheduleFollowup_Prospect { get; set; }
        public Nullable<int> PurchaseTimeframe { get; set; }
        public Nullable<bool> IdentifyCompetitors { get; set; }
        public Nullable<bool> DecisionMaker { get; set; }
        public string CurrentSituation { get; set; }
        public string CustomerNeed { get; set; }
        public string ProposedSolution { get; set; }
        public Nullable<bool> PresentFinalProposal { get; set; }
        public Nullable<bool> DevelopProposal { get; set; }
        public Nullable<decimal> BudgetAmount_Base { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual AccountBase AccountBase { get; set; }
        public virtual BusinessUnitBase BusinessUnitBase { get; set; }
        public virtual CampaignBase CampaignBase { get; set; }
        public virtual ContactBase ContactBase { get; set; }
        public virtual ICollection<LeadBase> LeadBases { get; set; }
        public virtual LeadBase LeadBase { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual OwnerBase OwnerBase { get; set; }
        public virtual PriceLevelBase PriceLevelBase { get; set; }
        public virtual TransactionCurrencyBase TransactionCurrencyBase { get; set; }
    }
}
