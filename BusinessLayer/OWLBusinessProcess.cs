using CRMOntology.DataAccessLayer;
using CRMOntology.RDFLayer;
using CRMOntology.RDFLayer.Entities.Accurate;
using CRMOntology.RDFLayer.Entities.Loyality.Reward;
using CRMOntology.RDFLayer.Entities.Sales.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMOntology.BusinessLayer
{
    class OWLBusinessProcess
    {
        public static ICollection<AnnotationBase> GetRelatedAnnotation(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from annotation in Context.AnnotationBases
                    where annotation.ObjectId == ObjectId && annotation.ObjectTypeCode == ObjectTypeCode
                    select annotation).ToList<AnnotationBase>();
        }

        public static ICollection<AppointmentBase> GetRelatedAppointment(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from appointment in Context.AppointmentBases
                    join apb in Context.ActivityPartyBases on appointment.ActivityId equals apb.ActivityId
                    where apb.PartyId == ObjectId && apb.PartyObjectTypeCode == ObjectTypeCode
                    select appointment).ToList<AppointmentBase>();
        }

        public static ICollection<EmailBase> GetRelatedEMail(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from email in Context.EmailBases
                    join apb in Context.ActivityPartyBases on email.ActivityId equals apb.ActivityId
                    where apb.PartyId == ObjectId && apb.PartyObjectTypeCode == ObjectTypeCode
                    select email).ToList<EmailBase>();
        }

        public static ICollection<FaxBase> GetRelatedFax(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from fax in Context.FaxBases
                    join apb in Context.ActivityPartyBases on fax.ActivityId equals apb.ActivityId
                    where apb.PartyId == ObjectId && apb.PartyObjectTypeCode == ObjectTypeCode
                    select fax).ToList<FaxBase>();
        }

        public static ICollection<IncidentBase> GetRelatedIncident(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from incident in Context.IncidentBases
                    where incident.CustomerId == ObjectId && incident.CustomerIdType == ObjectTypeCode
                    select incident).ToList<IncidentBase>();
        }

        public static ICollection<LetterBase> GetRelatedLetter(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from letter in Context.LetterBases
                    join apb in Context.ActivityPartyBases on letter.ActivityId equals apb.ActivityId
                    where apb.PartyId == ObjectId && apb.PartyObjectTypeCode == ObjectTypeCode
                    select letter).ToList<LetterBase>();
        }

        public static ICollection<PhoneCallBase> GetRelatedPhoneCall(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from phone in Context.PhoneCallBases
                    join apb in Context.ActivityPartyBases on phone.ActivityId equals apb.ActivityId
                    where apb.PartyId == ObjectId && apb.PartyObjectTypeCode == ObjectTypeCode
                    select phone).ToList<PhoneCallBase>();
        }

        public static ICollection<TaskBase> GetRelatedTask(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from task in Context.TaskBases
                    join apb in Context.ActivityPartyBases on task.ActivityId equals apb.ActivityId
                    where apb.PartyId == ObjectId && apb.PartyObjectTypeCode == ObjectTypeCode
                    select task).ToList<TaskBase>();
        }

        public static ICollection<CustomerAddressBase> GetCustomerAddresses(int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from address in Context.CustomerAddressBases
                    where address.ParentId == ObjectId && address.ObjectTypeCode == ObjectTypeCode
                    select address).ToList<CustomerAddressBase>();
        }
      
        public static ICollection<ProductBase> GetProductsBySubjectId(int ObjectTypeCode, Guid ObjectId, Guid SubjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            return (from incident in Context.IncidentBases
                    join prdct in Context.ProductBases on incident.ProductId equals prdct.ProductId
                    where incident.CustomerId == ObjectId && incident.CustomerIdType == ObjectTypeCode
                    && incident.SubjectId == SubjectId
                    select prdct).ToList<ProductBase>();
        }

        public static ICollection<ProductBase> GetDesiredProducts(Guid CustomerId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
             Random random = new Random();
             var array = new[]{  "F686C909-5274-41A5-A70A-0C3BE95A93E5",
                                "402D5FF3-EF80-4306-9408-3A36C04BF370",
                                "CD291A81-E7AE-46A0-884C-59C7DF36ABB2",
                                "09AEC54E-8588-49C3-9640-5E2F059ED2D9",
                                "505BF78F-F539-4C49-B2AD-749154FB34CA",
                                "1FD78B85-3632-484E-8849-F196BA1ABF1F"};
             Guid productId = Guid.Parse(array[random.Next(array.Length)]);

            //// To Do :
            //// Business Rule = Get products from Invoice.
            //// Rule will apply for the future release which has Sales modules.
            return (from prdct in Context.ProductBases
                    where prdct.ProductId == productId
                    select prdct).ToList<ProductBase>();
        }

        public static ICollection<ProductBase> GetDerivedProducts(Guid CustomerId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            Random random = new Random();
            var array = new[]{  "F686C909-5274-41A5-A70A-0C3BE95A93E5",
                                "402D5FF3-EF80-4306-9408-3A36C04BF370",
                                "CD291A81-E7AE-46A0-884C-59C7DF36ABB2",
                                "09AEC54E-8588-49C3-9640-5E2F059ED2D9",
                                "505BF78F-F539-4C49-B2AD-749154FB34CA",
                                "1FD78B85-3632-484E-8849-F196BA1ABF1F"};
            Guid productId = Guid.Parse(array[random.Next(array.Length)]);
            //// To Do :
            //// Business Rule = Find incident about customer asking a question about a product.if the customer buys the product.We catch drived products
            //// Rule will apply for the future release which has Sales modules.
            return (from prdct in Context.ProductBases
                    where prdct.ProductId == productId
                    select prdct).ToList<ProductBase>();
        }

        public static ICollection<ProductBase> GetLatentNeedProducts(Guid CustomerId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            Random random = new Random();
            var array = new[]{  "F686C909-5274-41A5-A70A-0C3BE95A93E5",
                                "402D5FF3-EF80-4306-9408-3A36C04BF370",
                                "CD291A81-E7AE-46A0-884C-59C7DF36ABB2",
                                "09AEC54E-8588-49C3-9640-5E2F059ED2D9",
                                "505BF78F-F539-4C49-B2AD-749154FB34CA",
                                "1FD78B85-3632-484E-8849-F196BA1ABF1F"};
            Guid productId = Guid.Parse(array[random.Next(array.Length)]);

            //// To Do :
            //// Business Rule = Find Campaign response for a customer.            
            //// Rule will apply for the future release which has Campaign modules.
            return (from prdct in Context.ProductBases
                    where prdct.ProductId == productId
                    select prdct).ToList<ProductBase>();
        }

        public static ICollection<ProductBase> GetMostPreferredProducts(Guid ContactId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            Random random = new Random();
            var array = new[]{  "F686C909-5274-41A5-A70A-0C3BE95A93E5",
                                "402D5FF3-EF80-4306-9408-3A36C04BF370",
                                "CD291A81-E7AE-46A0-884C-59C7DF36ABB2",
                                "09AEC54E-8588-49C3-9640-5E2F059ED2D9",
                                "505BF78F-F539-4C49-B2AD-749154FB34CA",
                                "1FD78B85-3632-484E-8849-F196BA1ABF1F"};

            Guid productId = Guid.Parse(array[random.Next(array.Length)]);

            //// To Do :
            //// Business Rule = grouped product from Sales Order fo the customer and return first 2 items as most preferred products.
            //// Rule will apply for the future release which has Sales modules.
            return (from prdct in Context.ProductBases
                    where prdct.ProductId == productId
                    select prdct).ToList<ProductBase>();
        }

        public static ICollection<ProductBase> GetPurchasedProducts(Guid ContactId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            Random random = new Random();
            var array = new[]{  "F686C909-5274-41A5-A70A-0C3BE95A93E5",
                                "402D5FF3-EF80-4306-9408-3A36C04BF370",
                                "CD291A81-E7AE-46A0-884C-59C7DF36ABB2",
                                "09AEC54E-8588-49C3-9640-5E2F059ED2D9",
                                "505BF78F-F539-4C49-B2AD-749154FB34CA",
                                "1FD78B85-3632-484E-8849-F196BA1ABF1F"};
            Guid productId = Guid.Parse(array[random.Next(array.Length)]);
            //// To Do :
            //// Business Rule = retrieve all products that are bought by Contact via Invoice Items.
            //// Rule will apply for the future release which has Sales modules.
            return (from prdct in Context.ProductBases
                    where prdct.ProductId == productId
                    select prdct).ToList<ProductBase>();
        }

        public static ICollection<ProductBase> GetUsedProducts(Guid ContactId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            Random random = new Random();
            var array = new[]{  "F686C909-5274-41A5-A70A-0C3BE95A93E5",
                                "402D5FF3-EF80-4306-9408-3A36C04BF370",
                                "CD291A81-E7AE-46A0-884C-59C7DF36ABB2",
                                "09AEC54E-8588-49C3-9640-5E2F059ED2D9",
                                "505BF78F-F539-4C49-B2AD-749154FB34CA",
                                "1FD78B85-3632-484E-8849-F196BA1ABF1F"};
            Guid productId = Guid.Parse(array[random.Next(array.Length)]);
            //// To Do :
            //// Business Rule = comming from survey and incident.Customer can create a case since customer uses the product.
            //// Rule will apply for the future release which has Sales modules.
            return (from prdct in Context.ProductBases
                    where prdct.ProductId == productId
                    select prdct).ToList<ProductBase>();
        }

        public static int GetChurnRate(Guid CustomerId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)
        {
            //// To Do :
            //// calculation is the count of incident in last 3 months, deviation of order in a year and count of disputing bill in last quarter.
            //// Rule will apply for the future release which has sales modules.
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }      

        public static object GetCustomerClassification (int ObjectTypeCode, Guid ObjectId, CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context)  
        {
            //sales modules needs to apply to calculate segmentation
            //rules are;
            //if the customer has business more than 1.000.000 (default currency) by total amount of invoices , 
            // customer will be in AVANTGARDE group.
            //each sales order has 1 coin to gain so 
            //if the customer has 1 - 40 coins: 500 points will fill to customer account per sale
            //if the customer has 41 - 80 coins : 750 points will fill to customer account per sale
            //if the customer has 91 - 100 coins : 1000 points will fill to customer account per sale
            //if the customer has business between 1000 - 1.000.000 (default currency) by total amount of invoices , 
            // customer will be in CLASSIC group.
            //each sales order gains 1 coin so 
            //if the customer has 1 - 20 : 50 points will fill to customer account
            //if the customer has 21 - 80 : 10 points will fill to customer account
            //if the customer has 81 - 100 : 250 points will fill to customer account
            //if the customer has business between 1.000.000 (default currency) by total amount of invoices and
            // customer record's "created on" must be older than 10 years and
            // there should not be more than 2 months gap between 2 invoices by "created on". 
            // so customer will be in VIP group.
            //each sales order gains 1 coin so 
            //if the customer has  1 - 30  : 5000 points will fill to customer account
            //if the customer has 31 - 60  : 7500 points will fill to customer account
            //if the customer has 61 - 100 : 10000 points will fill to customer account

            //In this Graduated Thesis, All formulas are removed since it will be a saleable product in the market.
            //to generate test data random result will be useing in order to demonstrate ontology

            Random random = new Random();
            Array values;
            switch (random.Next(1,3))
            {
                case 1 :
                    values = Enum.GetValues(typeof(avantgarde));
                    return (avantgarde)values.GetValue(random.Next(values.Length)); 
                case 2 :
                    values = Enum.GetValues(typeof(classic));
                    return (classic)values.GetValue(random.Next(values.Length)); 
                case 3 :
                    values = Enum.GetValues(typeof(vip));
                    return (vip)values.GetValue(random.Next(values.Length));
                default: return null;
            }

        }

        public static object GetCustomerSegment(int ObjectTypeCode, Guid ObjectId, CRMOntologyContext DataContext)
        {
            //sales modules needs to apply to calculate segmentation
            //rules are;          
            //each sales order has 2 coin and each invoice has 4 coins and each quote has 1 coin
            //FullfillLevel.high = 100 coin or FullfillLevel.low = 20 coin or FullfillLevel.medium = 50 coin
            //if total number between 501 - 1001, segment will be GOLD
            //if total number above 1001, segment will be PREMIUM
            //if total number between 1 - 500, segment will be SILVER
            Random random = new Random();
            switch (random.Next(1, 3))
            {
                case 1:            
                    return DataContext.Golds.Create();;
                case 2:
                    return DataContext.Silvers.Create();
                case 3:
                    return DataContext.Premiums.Create();
                default: return null;
            }

        }

        public static ICollection<ContactBase> GetChildContacts(int ObjectTypeCode, Guid ObjectId, CRMOntology_StagingEntities Context)
        {
            return (from contact in Context.ContactBases
                    where contact.ParentCustomerId == ObjectId && contact.ParentCustomerIdType == ObjectTypeCode
                    select contact).ToList<ContactBase>();
        }

        public static ICollection<AccountBase> GetAccountsSetAsPrimaryContact(Guid ContactId, CRMOntology_StagingEntities Context)
        {
            return (from account in Context.AccountBases
                    where account.PrimaryContactId == ContactId
                    select account).ToList<AccountBase>();
        }
           
    
    }  
    
        
}
