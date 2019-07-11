using BL = CRMOntology.BusinessLayer;
using CRMOntology.DataAccessLayer;
using CRMOntology.RDFLayer;
using CRMOntology.RDFLayer.Entities;
using CRMOntology.RDFLayer.Entities.Activity;
using CRMOntology.RDFLayer.Entities.Case;
using CRMOntology.RDFLayer.Entities.Party;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using CRMOntology.RDFLayer.Entities.Accurate;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CRMOntology.RDFLayer.Entities.Billing;
using CRMOntology.RDFLayer.Entities.Billing.Credict;
using CRMOntology.RDFLayer.Entities.Characteristics;
using CRMOntology.RDFLayer.Entities.Characteristics.Attitude;
using CRMOntology.RDFLayer.Entities.Sales.Product;
using CRMOntology.RDFLayer.Entities.Sales;
using CRMOntology.RDFLayer.Entities.Characteristics.Perception;
using CRMOntology.RDFLayer.Entities.Characteristics.Motivation;
using CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Behavioral;
using CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Consumer;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact.Personality;
using CRMOntology.RDFLayer.Entities.Loyality;
using CRMOntology.RDFLayer.Entities.Demographics.Address;
using CRMOntology.RDFLayer.Entities.Demographics;
using CRMOntology.RDFLayer.Entities.Demographics.Address.Postal;
using CRMOntology.RDFLayer.Entities.Demographics.Address.Postal.Country;
using CRMOntology.RDFLayer.Entities.Party.Customer;
using CRMOntology.RDFLayer.Entities.Demographics.Address.Postal.Country.City;
using CRMOntology.RDFLayer.Entities.Loyality.Reward;
using CRMOntology.RDFLayer.Entities.Loyality.Segment;
using CRMOntology.RDFLayer.Entities.Preference;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account.Profile;
using CRMOntology.RDFLayer.Entities.Shipping;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account.Type;
using BrightstarDB.Client;
using System.Data;

namespace CRMOntology.BusinessLayer
{   
    class OWLTransfer
    {
        private const string URI = "http://www.comu.edu.tr/eatamuh/ontologies/";

        public OWLTransfer()
        {

        }

        public void AddRecordToMapOWL(CRMOntology.DataAccessLayer.CRMOntology_StagingEntities Context, OWLMapBase MapBase)
        {
            //Double record control for OWL            
            if (Context.OWLMapBases.Any(item => item.FromTablePKId == MapBase.FromTablePKId && item.FromTableName == MapBase.FromTableName && item.OWLMapId == MapBase.ToOWLId))
            {
                //update
                Context.OWLMapBases.Attach(MapBase);
                Context.Entry(MapBase).State = EntityState.Modified;
                var objectContext = ((IObjectContextAdapter)Context).ObjectContext;
                objectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, MapBase);
            }
            else
            {
                //insert
                Context.OWLMapBases.Add(MapBase);
                Context.Entry(MapBase).State = EntityState.Added;
            }
        }

        public KeyValuePair<string,Guid> GetSubjectofObjectCustomer(CRMOntologyContext OntologyContext, Guid Key)
        {
            string prefix_object = @" PREFIX crm-object: <" + URI + "customer#> ";
            string prefix_predicate = @" PREFIX crm-predicate: <"+ URI + "subClassOf#> ";
            
            XDocument xDoc = OntologyContext.ExecuteQuery( prefix_object + " " + prefix_predicate + 
                                                           " SELECT * WHERE " +
                                                           " {  " +
                                                           " ?object crm-predicate: crm-object:" + Key.ToString().Replace("{","").Replace("}","") +
                                                           " } " 
                                                           );

            foreach (var sparqlResultRow in xDoc.SparqlResultRows())
            {
                string result = sparqlResultRow.GetColumnValue("object").ToString();
                //get Guid from the result
                if (result.IndexOf(URI) >= 0)
                {
                    
                    string[] members = result.Split('#');
                    if (members.Length == 2)
                    {
                        if(members[0].Contains("account") || members[0].Contains("contact"))
                        {
                            Guid value;
                            if (Guid.TryParse(members[1], out value))
                            {
                                return new KeyValuePair<string,Guid>(members[0].Replace(URI,""),value);
                            }
                        }
                    }
                }
            }
            return new KeyValuePair<string,Guid>("unknown", Guid.Empty);
        }

        public KeyValuePair<string,Guid> GetSubjectofObject(CRMOntologyContext OntologyContext, Guid Key, string EntityName)
        {
            string prefix_object = @" PREFIX crm-object: <" + URI + EntityName + "#> ";
            string prefix_predicate = @" PREFIX crm-predicate: <"+ URI + "subClassOf#> ";
            
            XDocument xDoc = OntologyContext.ExecuteQuery( prefix_object + " " + prefix_predicate + 
                                                           " SELECT * WHERE " +
                                                           " {  " +
                                                           " crm-object:" + Key.ToString().Replace("{","").Replace("}","") + " crm-predicate: ?subject " +
                                                           " } " 
                                                           );
            
            foreach (var sparqlResultRow in xDoc.SparqlResultRows())
            {
                string result = sparqlResultRow.GetColumnValue("subject").ToString();
                //get Guid from the result
                if (result.IndexOf(URI) >= 0)
                {
                    
                    string[] members = result.Split('#');
                    if (members.Length == 2)
                    {
                        Guid value;
                        if (Guid.TryParse(members[1], out value))
                        {
                            return new KeyValuePair<string, Guid>(members[0].Replace(URI, ""), value);
                        }
                    }
                }
            }
            return new KeyValuePair<string, Guid>("unknown", Guid.Empty);
        }

        public IList<OWLMapBase> FindMapBaseRecord(CRMOntology.DataAccessLayer.CRMOntology_StagingEntities SQLServerContext, CRMOntologyContext OntologyContext, Guid PrivateKey, String EntityName)
        {
            IList<OWLMapBase> map = (from mp in SQLServerContext.OWLMapBases
                                     where mp.ToOWLId == PrivateKey
                                     select mp).ToList<OWLMapBase>();
            if (map.Count == 0)
            {
                KeyValuePair<string,Guid> priKey;

                if(EntityName == "customer")
                    priKey = GetSubjectofObjectCustomer(OntologyContext, PrivateKey);
                else
                    priKey = GetSubjectofObject(OntologyContext, PrivateKey, EntityName);

                if (priKey.Value == Guid.Empty)
                    return null;
                map = FindMapBaseRecord(SQLServerContext, OntologyContext, priKey.Value ,priKey.Key);
            }
            
            return map;

        }

        public System.Data.DataSet RetrieveRecordFromMapOWL(CRMOntology.DataAccessLayer.CRMOntology_StagingEntities SQLServerContext, CRMOntologyContext OntologyContext,  Guid PrivateKey, String EntityName)
        {
            IList<OWLMapBase> records = FindMapBaseRecord(SQLServerContext, OntologyContext, PrivateKey, EntityName);
            if (records == null)
                return null;
            DataDescription StagingDesc = new BusinessLayer.DataDescription(SQLServerContext.Database.Connection.ConnectionString);
            DataSet dsReturn = new DataSet();  
            foreach(OWLMapBase mp in records)
            {
                List<KeyValuePair<string,string>> primaryKeys = new List<KeyValuePair<string,string>>();
                List<string> keys = StagingDesc.GetPrimaryKeys(mp.FromTableName);
                foreach(string key in keys)
                {
                    KeyValuePair<string,string> kvp = new KeyValuePair<string,string>(key,mp.FromTablePKId.ToString());
                    primaryKeys.Add(kvp);
                }

                string strSQLStatment = StagingDesc.CreateSelectStatement(mp.FromTableName, primaryKeys);
                DataSet dsResult = StagingDesc.ExecuteStatement(strSQLStatment);

                if (dsResult != null)
                {
                    foreach (DataTable dt in dsResult.Tables)
                    {
                        dsReturn.Tables.Add(dt.Copy());
                    }
                }
            }

            return dsReturn;
        }

        public void StartTransfer(string ConnectionString)
        {
            var dataContext = new CRMOntologyContext(ConnectionString);

            using (var context = new CRMOntology.DataAccessLayer.CRMOntology_StagingEntities())
            {
                context.Configuration.ValidateOnSaveEnabled = true;

                IList<TransferHistoryBase> transferHistoryBases = (from t in context.TransferHistoryBases
                                                                   where t.ConvertionDateToOwl == null
                                                                   select t).ToList<TransferHistoryBase>();
                foreach (TransferHistoryBase tHb in transferHistoryBases)
                {
                    #region party
                    var party = dataContext.Parties.Create();
                    #endregion
                    #region BusinessUnit
                    IList<BusinessUnitBase> businessUnitBases = (from bu in context.BusinessUnitBases.Include("SystemUserBases")
                                                                 where bu.TransferHistoryId == tHb.TransferHistoryId
                                                                 select bu).ToList<BusinessUnitBase>();
                    foreach (BusinessUnitBase businessUnitBase in businessUnitBases)
                    {
                        var businessunit = dataContext.BusinessUnits.Create();
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(businessunit.Id), businessUnitBase.BusinessUnitId, "BusinessUnitBase", tHb.TransferHistoryId));
                        #endregion
                        businessunit.baseClass = party;
                        businessunit.SystemUsers = new Collection<ISystemUser>();
                        foreach (SystemUserBase sysUserBase in businessUnitBase.SystemUserBases)
                        {
                            ISystemUser sysUsr = dataContext.SystemUsers.Create();
                            businessunit.SystemUsers.Add(sysUsr);

                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(sysUsr.Id), sysUserBase.SystemUserId, "SystemUserBase", tHb.TransferHistoryId));
                            #endregion
                        }

                    }
                    #endregion
                    #region Competitor
                    IList<CompetitorBase> competitorBases = (from bu in context.CompetitorBases
                                                             where bu.TransferHistoryId == tHb.TransferHistoryId
                                                             select bu).ToList<CompetitorBase>();
                    foreach (CompetitorBase competitorBase in competitorBases)
                    {
                        var competitor = dataContext.Competitors.Create();
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(competitor.Id), competitorBase.CompetitorId, "CompetitorBase", tHb.TransferHistoryId));
                        #endregion
                        competitor.baseClass = party;
                    }
                    #endregion
                    #region SystemUser
                    IList<SystemUserBase> systemUserBases = (from bu in context.SystemUserBases.Include("TeamMemberships.TeamBase")
                                                             where bu.TransferHistoryId == tHb.TransferHistoryId
                                                             select bu).ToList<SystemUserBase>();

                    foreach (SystemUserBase systemUserBase in systemUserBases)
                    {
                        var systemuser = dataContext.SystemUsers.Create();
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(systemuser.Id), systemUserBase.SystemUserId, "SystemUserBase", tHb.TransferHistoryId));
                        #endregion
                        systemuser.baseClass = party;
                        systemuser.Teams = new Collection<ITeam>();
                        foreach (TeamMembership teamMembership in systemUserBase.TeamMemberships)
                        {
                            ITeam team = dataContext.Teams.Create();
                            systemuser.Teams.Add(team);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(team.Id), teamMembership.TeamBase.TeamId, "TeamBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        systemuser.Accounts = new Collection<IAccount>();
                        systemuser.Contacts = new Collection<IContact>();

                        //Users can be set as Owner instead of Prefered System User so finds out Accounts and Contacts accordingly
                        IList<OwnerBase> ownerBases = (from owner in context.OwnerBases.Include("AccountBases").Include("ContactBases")
                                                       where owner.OwnerId == systemUserBase.SystemUserId
                                                       select owner).ToList<OwnerBase>();
                        foreach (OwnerBase ownerBase in ownerBases)
                        {
                            foreach (AccountBase accountBase in ownerBase.AccountBases)
                            {
                                IAccount account = dataContext.Accounts.Create();
                                systemuser.Accounts.Add(account);
                                #region Update map table
                                AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(account.Id), accountBase.AccountId, "AccountBase", tHb.TransferHistoryId));
                                #endregion
                            }

                            foreach (ContactBase contactBase in ownerBase.ContactBases)
                            {
                                IContact contact = dataContext.Contacts.Create();
                                systemuser.Contacts.Add(contact);
                                #region Update map table
                                AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(contact.Id), contactBase.ContactId, "ContactBase", tHb.TransferHistoryId));
                                #endregion
                            }
                        }

                        systemuser.BusinessUnits = new Collection<IBusinessUnit>();
                        systemuser.BusinessUnits.Add(dataContext.BusinessUnits.Create());
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(systemuser.BusinessUnits.FirstOrDefault().Id), systemUserBase.BusinessUnitBase.BusinessUnitId, "BusinessUnitBase", tHb.TransferHistoryId));
                        #endregion


                    }
                    #endregion
                    #region Account                    
                    IList<AccountBase> accountBases = (from acc in context.AccountBases
                                                       where acc.TransferHistoryId == tHb.TransferHistoryId
                                                       select acc).ToList<AccountBase>();
                    foreach (AccountBase accountBase in accountBases)
                    {
                        #region Customer
                        var customerAccount = dataContext.Customers.Create();
                        customerAccount.baseClass = party;
                        #endregion

                        var account = dataContext.Accounts.Create();
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(account.Id), accountBase.AccountId, "AccountBase", tHb.TransferHistoryId));
                        #endregion
                        account.baseClass = customerAccount;
                        account.Annotations = new Collection<IAnnotation>();

                        //get related Annotation
                        ICollection<AnnotationBase> annotationBases = OWLBusinessProcess.GetRelatedAnnotation(1, accountBase.AccountId, context);
                        foreach (AnnotationBase annotationBase in annotationBases)
                        {
                            IAnnotation annotation = dataContext.Annotations.Create();
                            account.Annotations.Add(annotation);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(annotation.Id), annotationBase.AnnotationId, "AnnotationBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.Appointments = new Collection<IAppointment>();
                        //get related Appointment
                        ICollection<AppointmentBase> appointmentBases = OWLBusinessProcess.GetRelatedAppointment(1, accountBase.AccountId, context);
                        foreach (AppointmentBase appointmentBase in appointmentBases)
                        {
                            IAppointment appointment = dataContext.Appointments.Create();
                            account.Appointments.Add(appointment);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(appointment.Id), appointmentBase.ActivityId, "AppointmentBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.EMails = new Collection<IEmail>();
                        //get related email
                        ICollection<EmailBase> emailBases = OWLBusinessProcess.GetRelatedEMail(1, accountBase.AccountId, context);
                        foreach (EmailBase emailBase in emailBases)
                        {
                            IEmail email = dataContext.Emails.Create();
                            account.EMails.Add(email);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(email.Id), emailBase.ActivityId, "EmailBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.Faxes = new Collection<IFax>();
                        //get related fax
                        ICollection<FaxBase> faxBases = OWLBusinessProcess.GetRelatedFax(1, accountBase.AccountId, context);
                        foreach (FaxBase faxBase in faxBases)
                        {
                            IFax fax = dataContext.Faxs.Create();
                            account.Faxes.Add(fax);

                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(fax.Id), faxBase.ActivityId, "FaxBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.Incidents = new Collection<IIncident>();
                        //get related issue
                        ICollection<IncidentBase> incidentBases = OWLBusinessProcess.GetRelatedIncident(1, accountBase.AccountId, context);
                        foreach (IncidentBase incidentBase in incidentBases)
                        {
                            IIncident incident = dataContext.Incidents.Create();
                            account.Incidents.Add(incident);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(incident.Id), incidentBase.IncidentId, "IncidentBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.Letters = new Collection<ILetter>();
                        //get related letter
                        ICollection<LetterBase> letterBases = OWLBusinessProcess.GetRelatedLetter(1, accountBase.AccountId, context);
                        foreach (LetterBase letterBase in letterBases)
                        {
                            ILetter letter = dataContext.Letters.Create();
                            account.Letters.Add(letter);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(letter.Id), letterBase.ActivityId, "LetterBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.Phones = new Collection<IPhone>();
                        //get related phone call
                        ICollection<PhoneCallBase> phoneCallBases = OWLBusinessProcess.GetRelatedPhoneCall(1, accountBase.AccountId, context);
                        foreach (PhoneCallBase phoneCallBase in phoneCallBases)
                        {
                            IPhone phone = dataContext.Phones.Create();
                            account.Phones.Add(phone);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(phone.Id), phoneCallBase.ActivityId, "PhoneCallBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.Tasks = new Collection<ITask>();
                        //get related task
                        ICollection<TaskBase> taskBases = OWLBusinessProcess.GetRelatedTask(1, accountBase.AccountId, context);
                        foreach (TaskBase taskBase in taskBases)
                        {
                            ITask task = dataContext.Tasks.Create();
                            account.Tasks.Add(task);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(task.Id), taskBase.ActivityId, "TaskBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.SystemUsers = new Collection<ISystemUser>();
                        //owner
                        ISystemUser user = dataContext.SystemUsers.Create();
                        account.SystemUsers.Add(user);
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(user.Id), accountBase.OwnerId, "SystemUserBase", tHb.TransferHistoryId));
                        #endregion

                        if (accountBase.ParentAccountId.HasValue)
                        {
                            account.Accounts = new Collection<IAccount>();
                            //parent account
                            IAccount parentaccount = dataContext.Accounts.Create();
                            account.Accounts.Add(parentaccount);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(parentaccount.Id), accountBase.ParentAccountId.Value, "AccountBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        account.Addresses = new Collection<IAddress>();
                        //get addresses
                        ICollection<CustomerAddressBase> addressBases = OWLBusinessProcess.GetCustomerAddresses(1, accountBase.AccountId, context);
                        foreach (CustomerAddressBase addressBase in addressBases)
                        {
                            IAddress address = dataContext.Addresss.Create();
                            account.Addresses.Add(address);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(address.Id), addressBase.CustomerAddressId, "CustomerAddressBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        //set Parental relation of the account
                        ICollection<ContactBase> childContacts = OWLBusinessProcess.GetChildContacts(1, accountBase.AccountId, context);
                        account.Contacts = new Collection<IContact>();
                        foreach (ContactBase contactBase in childContacts)
                        {
                            IContact contact = dataContext.Contacts.Create();
                            account.Contacts.Add(contact);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(contact.Id), contactBase.ContactId, "ContactBase", tHb.TransferHistoryId));
                            #endregion

                        }

                        #region Accurate                        
                        BL.OWLConfiguration owlConfig = new BL.OWLConfiguration();

                        XElement xElement = owlConfig.OWLConfigurations.Count > 0 ? owlConfig.OWLConfigurations[0] : null;

                        if (xElement != null)
                        {
                            BL.OWLDescription OWLDesc = new BL.OWLDescription(xElement);
                            foreach (IFactory item in OWLDesc.OWLItems)
                            {
                                if (item.Type == "Accurate")
                                {                                    
                                    IAccurate accountAccurate = dataContext.Accurates.Create();
                                    accountAccurate.baseClass = customerAccount;
                                    Accurate accurate = (Accurate)item;
                                    accountAccurate.Fullfill = accurate.getFullfill(OWLDesc.StagingDatabase.ConnectionString,CustomerType.Account,accountBase.AccountId.ToString()).ToString();
                                }
                            }
                        }
                        #endregion
                        #region billing 
                        IBilling billing = dataContext.Billings.Create();
                        billing.baseClass = customerAccount;
                        switch ((currency)Enum.Parse(typeof(currency), accountBase.TransactionCurrencyBase.ISOCurrencyCode))
                        {
                            case currency.Euro:
                                billing.Currency = currency.Euro.ToString();
                                break;
                            case currency.TL:
                                billing.Currency = currency.TL.ToString();
                                break;
                            case currency.USD:
                                billing.Currency = currency.USD.ToString();       
                                break;
                            default :
                                billing.Currency = currency.NotSpecified.ToString();
                                break;
                        }

                        switch ((paymentterm)Enum.Parse(typeof(paymentterm), accountBase.PaymentTermsCode.HasValue?accountBase.PaymentTermsCode.Value.ToString():paymentterm.NotSpecified.ToString()))
                        {
                            case paymentterm._percent_10_and_Net_30:
                                billing.PaymentTerm = paymentterm._percent_10_and_Net_30.ToString();
                                break;
                            case paymentterm.Net30:
                                billing.PaymentTerm = paymentterm.Net30.ToString();
                                break;
                            case paymentterm.Net45:
                                billing.PaymentTerm = paymentterm.Net45.ToString();       
                                break;
                             case paymentterm.Net60:
                                billing.PaymentTerm = paymentterm.Net60.ToString();
                                 break;
                             default:
                                 billing.PaymentTerm = paymentterm.NotSpecified.ToString();
                                 break;
                        }
                        #endregion
                        #region credict
                        ICredict credict = dataContext.Credicts.Create();
                        credict.baseClass = billing;
                        credict.Hold = accountBase.CreditOnHold.HasValue ? accountBase.CreditOnHold.Value : false;
                        credict.Limit = accountBase.CreditLimit.HasValue ? accountBase.CreditLimit.Value : 0;
                        #endregion
                        #region Characteristics
                        ICharacteristics characteristic = dataContext.Characteristicss.Create();
                        characteristic.baseClass = customerAccount;
                        #region belief
                        Array values = Enum.GetValues(typeof(belief));
                        Random random = new Random();
                        characteristic.Belief = ((belief)values.GetValue(random.Next(values.Length))).ToString(); //will come from customer Survey
                        #endregion
                        #region attitude
                        IAttitude attitude = dataContext.Attitudes.Create();
                        attitude.baseClass = characteristic;
                        #endregion
                        #region negative_experience
                        Guid negativePerceptionSubjectId = Guid.Parse("E4EC9D23-8D6E-4E46-8C3B-9A4626BEADC2"); //Dissatisfaction from product
                        ICollection<ProductBase> dissatisfiedProducts = OWLBusinessProcess.GetProductsBySubjectId(1,accountBase.AccountId,negativePerceptionSubjectId, context);
                        if (dissatisfiedProducts != null)
                        {
                            INegativeExperience negativeexperience = dataContext.NegativeExperiences.Create();
                            negativeexperience.baseClass = attitude;
                            negativeexperience.Products = new Collection<IProduct>();
                            #region
                            ISales sale = dataContext.Saless.Create();
                            foreach (ProductBase productBase in dissatisfiedProducts)
                            {
                                IProduct product = dataContext.Products.Create();
                                product.baseClass = sale;

                                #region Update map table
                                AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                                #endregion
                                negativeexperience.Products.Add(product);
                            }
                            #endregion
                        }
                        #endregion
                        #region positive_experience
                        Guid positrivePerceptionSubjectId = Guid.Parse("9F5ACBA9-9571-440F-8522-6857D3AFB3B7"); //Satisfied from product
                        ICollection<ProductBase> satisfiedProducts = OWLBusinessProcess.GetProductsBySubjectId(1, accountBase.AccountId, positrivePerceptionSubjectId, context);
                        if (satisfiedProducts != null)
                        {
                            IPositiveExperience positiveexperience = dataContext.PositiveExperiences.Create();
                            positiveexperience.baseClass = attitude;
                            positiveexperience.Products = new Collection<IProduct>();
                            #region
                            ISales sale = dataContext.Saless.Create();
                            foreach (ProductBase productBase in satisfiedProducts)
                            {
                                IProduct product = dataContext.Products.Create();
                                product.baseClass = sale;

                                #region Update map table
                                AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                                #endregion
                                positiveexperience.Products.Add(product);
                            }
                            #endregion
                        }
                        #endregion
                        #region knowledge
                        //Sales Order, Quotes will have specific rule to clarify perception of a customer for a product
                        //below is a demonstration of knowledge
                        ICollection<ProductBase> knowledgeProduct = (from x in context.ProductBases select x).ToList<ProductBase>();
                        IKnowledge knowledge = dataContext.Knowledges.Create();
                        knowledge.baseClass = characteristic;
                        ISales saleKnowledge = dataContext.Saless.Create();
                        #region
                        foreach (ProductBase productBase in knowledgeProduct)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = saleKnowledge;
                            switch (random.Next(1,3))  //1 - aim, 2- want 3-need
                            {
                                case 1:
                                    if (knowledge.AimProducts == null)
                                        knowledge.AimProducts = new Collection<IProduct>();
                                    knowledge.AimProducts.Add(product); 
                                    break;
                                case 2:
                                    if (knowledge.WantProducts == null)
                                        knowledge.WantProducts = new Collection<IProduct>();
                                    knowledge.WantProducts.Add(product); 
                                    break;
                                case 3 :
                                    if (knowledge.NeedProducts == null)
                                        knowledge.NeedProducts = new Collection<IProduct>();
                                    knowledge.NeedProducts.Add(product); 
                                    break;
                            }
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }
                        #endregion
                        #endregion
                        #region Perception
                        IPerception perception = dataContext.Perceptions.Create();
                        perception.baseClass = characteristic;
                        //below requires specific survey to set
                        perception.benefit = random.Next(1,100) < 50 ? false : true;
                        perception.price = random.Next(1, 100) < 50 ? false : true;
                        #endregion
                        #region motivation
                        IMotivation motivation = dataContext.Motivations.Create();
                        motivation.baseClass = characteristic;
                            //behavioral
                            IBehavioral behavioral = dataContext.Behaviorals.Create();
                            behavioral.baseClass = motivation;
                            values = Enum.GetValues(typeof(esteem));
                            behavioral.Esteem = ((esteem)values.GetValue(random.Next(values.Length))).ToString(); //will come from customer Survey
                            values = Enum.GetValues(typeof(safety));
                            behavioral.Safety = ((safety)values.GetValue(random.Next(values.Length))).ToString(); //will come from customer Survey
                            //consumer
                            IConsumer consumer = dataContext.Consumers.Create();
                            consumer.baseClass = motivation;
                                //desire
                                ICollection<ProductBase> desiredProduct = OWLBusinessProcess.GetDesiredProducts(accountBase.AccountId, context);
                                IDesire desire = dataContext.Desires.Create();
                                desire.baseClass = consumer;                        
                                ISales saleDesire = dataContext.Saless.Create();
                                foreach(ProductBase productBase in desiredProduct)
                                {
                                    IProduct product = dataContext.Products.Create();
                                    product.baseClass = saleDesire;
                                    if (desire.Products == null)
                                        desire.Products = new Collection<IProduct>();
                                    desire.Products.Add(product);
                                    #region Update map table
                                    AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                                    #endregion
                                }
                                
                                //drive - rule will be applied by a consumer survey (search motivated product to drive the party to buy something)
                                ICollection<ProductBase> drivedProduct = OWLBusinessProcess.GetDerivedProducts(accountBase.AccountId, context);
                                IDrive drive = dataContext.Drives.Create();
                                drive.baseClass = consumer;
                                ISales saleDrive = dataContext.Saless.Create();
                                foreach(ProductBase productBase in drivedProduct)
                                {
                                    IProduct product = dataContext.Products.Create();
                                    product.baseClass = saleDrive;
                                    if (drive.Products == null)
                                        drive.Products = new Collection<IProduct>();
                                    drive.Products.Add(product);
                                    #region Update map table
                                    AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                                    #endregion
                                }

                                //latent need - rule will be applied from Marketing Activities (if a customer response any compaing for a product,latent_need come up then.)
                                ICollection<ProductBase> latentNeedProduct = OWLBusinessProcess.GetLatentNeedProducts(accountBase.AccountId, context);
                                ILatentNeed latentneed = dataContext.LatentNeeds.Create();
                                latentneed.baseClass = consumer;
                                ISales saleLatentNeed = dataContext.Saless.Create();
                                foreach (ProductBase productBase in latentNeedProduct)
                                {
                                    IProduct product = dataContext.Products.Create();
                                    product.baseClass = saleDrive;
                                    if (latentneed.Products == null)
                                        latentneed.Products = new Collection<IProduct>();
                                    drive.Products.Add(product);
                                    #region Update map table
                                    AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                                    #endregion
                                }
                        #endregion
                        #endregion
                        #region Churn
                        IChurn churn = dataContext.Churns.Create();
                        churn.baseClass = customerAccount;
                        churn.Rate = OWLBusinessProcess.GetChurnRate(accountBase.AccountId, context);
                        #endregion
                        #region Demographics 
                        IDemographics demographics = dataContext.Demographicss.Create();
                        demographics.baseClass = customerAccount;
                        if (accountBase.EstablishedDate.HasValue)
                            demographics.EstablishDate = accountBase.EstablishedDate.Value;
                        demographics.Income = accountBase.Revenue.HasValue?accountBase.Revenue.Value:0;
                            #region Address
                            ICollection<CustomerAddressBase> customeraddresses = OWLBusinessProcess.GetCustomerAddresses(1, accountBase.AccountId, context);                            
                            foreach (CustomerAddressBase customeraddressbase in customeraddresses)
                            {
                                IAddress address = dataContext.Addresss.Create();
                                address.baseClass = demographics;
                                address.Customers = new Collection<ICustomer>();
                                address.Customers.Add(customerAccount);
                                if (customeraddressbase.AddressTypeCode.HasValue)
                                {
                                    switch (customeraddressbase.AddressTypeCode.Value)
                                    {
                                        case 1:
                                            address.AddressType = addresstype.Home.ToString();
                                            break;
                                        case 2:
                                            address.AddressType = addresstype.Work.ToString();
                                            break;
                                    }
                                }
                                else
                                {
                                    address.AddressType = addresstype.Not_Specified.ToString();
                                }
                                #region electronic addresses
                                IElectronic electronic1 = dataContext.Electronics.Create();
                                electronic1.baseClass = address;
                                electronic1.EMailAddress = accountBase.EMailAddress1;

                                IElectronic electronic2 = dataContext.Electronics.Create();
                                electronic2.baseClass = address;
                                electronic2.EMailAddress = accountBase.EMailAddress2;

                                IElectronic electronic3 = dataContext.Electronics.Create();
                                electronic3.baseClass = address;
                                electronic3.EMailAddress = accountBase.EMailAddress3;
                                #endregion
                                #region postal
                                IPostal postal = dataContext.Postals.Create();
                                postal.baseClass = address;
                                    #region country
                                    ICountry country = dataContext.Countries.Create();
                                    country.baseClass = postal;
                                    country.Name = customeraddressbase.Country;
                                        #region city
                                        ICity city = dataContext.Cities.Create();
                                        city.baseClass = country;
                                        city.Name = customeraddressbase.City;
                                            #region street
                                            IStreet street = dataContext.Streets.Create();
                                            street.baseClass = city;
                                            street.Name = customeraddressbase.Line1 + " " + customeraddressbase.Line2 + " " + customeraddressbase.Line3 + " ";
                                            #endregion
                                        #endregion
                                    #endregion
                                #endregion
                                #region URL
                                IWeb web = dataContext.Webs.Create();
                                web.baseClass = address;
                                web.URL = accountBase.WebSiteURL;
                                #endregion
                            }  
                            #endregion
                        #endregion
                        #region loyality
                        ILoyality loyality = dataContext.Loyalities.Create();
                        loyality.baseClass = customerAccount;
                            #region reward
                            IReward reward = dataContext.Rewards.Create();
                            reward.baseClass = loyality;
                            object obj = OWLBusinessProcess.GetCustomerClassification(1, accountBase.AccountId, context);
                            if (obj.GetType() == typeof(avantgarde))
                            {
                                reward.Avantgarde = ((avantgarde)obj).ToString();
                            }
                            else if (obj.GetType() == typeof(classic))
                            {
                                reward.Classic = ((classic)obj).ToString();
                            }
                            else if (obj.GetType() == typeof(vip))
                            {
                                reward.VIP = ((vip)obj).ToString();
                            }
                            
                            #endregion
                            #region segment
                            ISegment segment = dataContext.Segments.Create();
                            segment.baseClass = loyality;
                            obj = OWLBusinessProcess.GetCustomerSegment(1, accountBase.AccountId, dataContext);
                            if (obj.GetType() == typeof(IGold))    
                            {
                                #region gold
                               ((IGold)obj).baseClass = segment;
                                #endregion
                            } 
                            else if (obj.GetType() == typeof(IPremium))    
                            {
                                #region premium
                               ((IPremium)obj).baseClass = segment;
                                #endregion
                            }
                            else if (obj.GetType() == typeof(ISilver))    
                            {
                                #region silver
                               ((ISilver)obj).baseClass = segment;
                                #endregion
                            }
                            #endregion
                        #endregion
                        #region Preference
                        IPreference preference = dataContext.Preferences.Create();
                        preference.baseClass = customerAccount;
                        if (accountBase.PreferredContactMethodCode.HasValue)
                            preference.PreferredMethodCode = ((preferredmethodcode)accountBase.PreferredContactMethodCode.Value).ToString();
                            #region call
                            if (accountBase.DoNotPhone.HasValue)
                            {
                                ICall call = dataContext.Calls.Create();
                                call.baseClass = preference;
                                call.canCall = !accountBase.DoNotPhone.Value;
                            }
                            #endregion
                            #region sendbulkemail
                            if (accountBase.DoNotBulkEMail.HasValue)
                            {
                                ISendBulkEMail sendbulkemail = dataContext.SendBulkEMails.Create();
                                sendbulkemail.baseClass = preference;
                                sendbulkemail.canSendBulkEMail = !accountBase.DoNotBulkEMail.Value;
                            }
                            #endregion
                            #region sendemail
                            if (accountBase.DoNotEMail.HasValue)
                            {
                                ISendEMail sendemail = dataContext.SendEMails.Create();
                                sendemail.baseClass = preference;
                                sendemail.canSendEMail = !accountBase.DoNotEMail.Value;
                            }
                            #endregion
                            #region sendfax
                            if (accountBase.DoNotFax.HasValue)
                            {
                                ISendFax sendfax = dataContext.SendFaxs.Create();
                                sendfax.baseClass = preference;
                                sendfax.canSendFax = !accountBase.DoNotFax.Value;
                            }
                            #endregion
                            #region sendmail
                            if (accountBase.DoNotBulkPostalMail.HasValue)
                            {
                                ISendMail sendmail = dataContext.SendMails.Create();
                                sendmail.baseClass = preference;
                                sendmail.canSendMail = !accountBase.DoNotPostalMail.Value;
                            }
                            #endregion
                        #endregion
                        #region profile
                        IProfile profile = dataContext.Profiles.Create();
                        profile.baseClass = account;
                        profile.code = accountBase.SIC;
                        profile.Industry = accountBase.IndustryCode.HasValue ? ((industry)accountBase.IndustryCode.Value).ToString() : industry.other.ToString();
                        profile.Ownership = accountBase.OwnershipCode.HasValue ? ((ownership)accountBase.OwnershipCode.Value).ToString() : ownership._other.ToString();
                        #endregion
                        #region retention
                        // requires campaign management and sales force automation
                        #endregion
                        #region shipping
                        IShipping shipping = dataContext.Shippings.Create();
                        shipping.baseClass = customerAccount;
                        shipping.Method = accountBase.ShippingMethodCode.HasValue ? ((method)accountBase.ShippingMethodCode).ToString() : method.Not_Specified.ToString();
                        shipping.FreightTerm = freightterm.No_Charge.ToString(); //Support single type at the first version.freightterm requires consultancy from Export/Import professionals.                        
                        #endregion
                        #region type
                        if (accountBase.BusinessTypeCode.HasValue)
                        {
                            IType type = dataContext.Types.Create();
                            type.baseClass = account;
                            switch (accountBase.BusinessTypeCode.Value)
                            {
                                case 0:
                                case 1:
                                case 2:
                                    #region corporations
                                  
                                    switch (accountBase.BusinessTypeCode.Value)
                                    {
                                        case 0:
                                            type.Corporation = corporation._holding.ToString();
                                            break;
                                        case 1:
                                            type.Corporation = corporation._limited.ToString();
                                            break;
                                        case 2:
                                            type.Corporation = corporation._private.ToString();
                                            break;
                                    }
                                    #endregion
                                    break;
                                case 3:
                                    IGovernments government = dataContext.Governmentss.Create();
                                    government.baseClass = type;
                                    break;
                                case 4:
                                    INonGovernments nongovernment = dataContext.NonGovernmentss.Create();
                                    nongovernment.baseClass = type;
                                    break;
                            }
                        }
                        #endregion                       
                    }
                    #endregion
                    #region Contact
                    IList<ContactBase> contactBases = (from con in context.ContactBases
                                                       where con.TransferHistoryId == tHb.TransferHistoryId
                                                       select con).ToList<ContactBase>();
                    foreach (ContactBase contactBase in contactBases)
                    {
                        #region Customer
                        var customerContact = dataContext.Customers.Create();
                        customerContact.baseClass = party;
                        #endregion

                        var contact = dataContext.Contacts.Create();
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(contact.Id), contactBase.ContactId, "ContactBase", tHb.TransferHistoryId));
                        #endregion
                        contact.baseClass = customerContact;
                        contact.Annotations = new Collection<IAnnotation>();

                        //get related Annotation
                        ICollection<AnnotationBase> annotationBases = OWLBusinessProcess.GetRelatedAnnotation(2, contactBase.ContactId, context);
                        foreach (AnnotationBase annotationBase in annotationBases)
                        {
                            IAnnotation annotation = dataContext.Annotations.Create();
                            contact.Annotations.Add(annotation);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(annotation.Id), annotationBase.AnnotationId, "AnnotationBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.Appointments = new Collection<IAppointment>();
                        //get related Appointment
                        ICollection<AppointmentBase> appointmentBases = OWLBusinessProcess.GetRelatedAppointment(2, contactBase.ContactId, context);
                        foreach (AppointmentBase appointmentBase in appointmentBases)
                        {
                            IAppointment appointment = dataContext.Appointments.Create();
                            contact.Appointments.Add(appointment);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(appointment.Id), appointmentBase.ActivityId, "AppointmentBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.EMails = new Collection<IEmail>();
                        //get related email
                        ICollection<EmailBase> emailBases = OWLBusinessProcess.GetRelatedEMail(2, contactBase.ContactId, context);
                        foreach (EmailBase emailBase in emailBases)
                        {
                            IEmail email = dataContext.Emails.Create();
                            contact.EMails.Add(email);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(email.Id), emailBase.ActivityId, "EmailBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.Faxes = new Collection<IFax>();
                        //get related fax
                        ICollection<FaxBase> faxBases = OWLBusinessProcess.GetRelatedFax(2, contactBase.ContactId, context);
                        foreach (FaxBase faxBase in faxBases)
                        {
                            IFax fax = dataContext.Faxs.Create();
                            contact.Faxes.Add(fax);

                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(fax.Id), faxBase.ActivityId, "FaxBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.Incidents = new Collection<IIncident>();
                        //get related issue
                        ICollection<IncidentBase> incidentBases = OWLBusinessProcess.GetRelatedIncident(2, contactBase.ContactId, context);
                        foreach (IncidentBase incidentBase in incidentBases)
                        {
                            IIncident incident = dataContext.Incidents.Create();
                            contact.Incidents.Add(incident);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(incident.Id), incidentBase.IncidentId, "IncidentBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.Letters = new Collection<ILetter>();
                        //get related letter
                        ICollection<LetterBase> letterBases = OWLBusinessProcess.GetRelatedLetter(2, contactBase.ContactId, context);
                        foreach (LetterBase letterBase in letterBases)
                        {
                            ILetter letter = dataContext.Letters.Create();
                            contact.Letters.Add(letter);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(letter.Id), letterBase.ActivityId, "LetterBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.Phones = new Collection<IPhone>();
                        //get related phone call
                        ICollection<PhoneCallBase> phoneCallBases = OWLBusinessProcess.GetRelatedPhoneCall(2, contactBase.ContactId, context);
                        foreach (PhoneCallBase phoneCallBase in phoneCallBases)
                        {
                            IPhone phone = dataContext.Phones.Create();
                            contact.Phones.Add(phone);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(phone.Id), phoneCallBase.ActivityId, "PhoneCallBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.Tasks = new Collection<ITask>();
                        //get related task
                        ICollection<TaskBase> taskBases = OWLBusinessProcess.GetRelatedTask(2, contactBase.ContactId, context);
                        foreach (TaskBase taskBase in taskBases)
                        {
                            ITask task = dataContext.Tasks.Create();
                            contact.Tasks.Add(task);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(task.Id), taskBase.ActivityId, "TaskBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        contact.SystemUsers = new Collection<ISystemUser>();
                        //owner
                        ISystemUser user = dataContext.SystemUsers.Create();
                        contact.SystemUsers.Add(user);
                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(user.Id), contactBase.OwnerId, "SystemUserBase", tHb.TransferHistoryId));
                        #endregion

                        #region primaryContact of Accounts
                        ICollection<AccountBase> primaryAccountBases = OWLBusinessProcess.GetAccountsSetAsPrimaryContact(contactBase.ContactId, context);
                        contact.PrimaryContactForAccounts = new Collection<IAccount>();
                        foreach (AccountBase accountBase in primaryAccountBases)
                        {
                            IAccount account = dataContext.Accounts.Create();
                            contact.PrimaryContactForAccounts.Add(account);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(account.Id), accountBase.AccountId, "AccountBase", tHb.TransferHistoryId));
                            #endregion

                        }
                        #endregion

                        contact.Addresses = new Collection<IAddress>();
                        //get addresses
                        ICollection<CustomerAddressBase> addressBases = OWLBusinessProcess.GetCustomerAddresses(2, contactBase.ContactId, context);
                        foreach (CustomerAddressBase addressBase in addressBases)
                        {
                            IAddress address = dataContext.Addresss.Create();
                            contact.Addresses.Add(address);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(address.Id), addressBase.CustomerAddressId, "CustomerAddressBase", tHb.TransferHistoryId));
                            #endregion
                        }
                        #region Accurate
                        BL.OWLConfiguration owlConfig = new BL.OWLConfiguration();

                        XElement xElement = owlConfig.OWLConfigurations.Count > 0 ? owlConfig.OWLConfigurations[0] : null;

                        if (xElement != null)
                        {
                            BL.OWLDescription OWLDesc = new BL.OWLDescription(xElement);
                            foreach (IFactory item in OWLDesc.OWLItems)
                            {
                                if (item.Type == "Accurate")
                                {
                                    IAccurate contactAccurate = dataContext.Accurates.Create();
                                    contactAccurate.baseClass = customerContact;
                                    Accurate accurate = (Accurate)item;
                                    contactAccurate.Fullfill = accurate.getFullfill(OWLDesc.StagingDatabase.ConnectionString, CustomerType.Contact, contactBase.ContactId.ToString()).ToString();
                                }
                            }
                        }
                        #endregion
                        #region billing
                        IBilling billing = dataContext.Billings.Create();
                        billing.baseClass = customerContact;
                        switch ((currency)Enum.Parse(typeof(currency), contactBase.TransactionCurrencyBase.ISOCurrencyCode))
                        {
                            case currency.Euro:
                                billing.Currency = currency.Euro.ToString();
                                break;
                            case currency.TL:
                                billing.Currency = currency.TL.ToString();
                                break;
                            case currency.USD:
                                billing.Currency = currency.USD.ToString();
                                break;
                            default:
                                billing.Currency = currency.NotSpecified.ToString();
                                break;
                        }

                        switch ((paymentterm)Enum.Parse(typeof(paymentterm), contactBase.PaymentTermsCode.HasValue ? contactBase.PaymentTermsCode.Value.ToString() : paymentterm.NotSpecified.ToString()))
                        {
                            case paymentterm._percent_10_and_Net_30:
                                billing.PaymentTerm = paymentterm._percent_10_and_Net_30.ToString();
                                break;
                            case paymentterm.Net30:
                                billing.PaymentTerm = paymentterm.Net30.ToString();
                                break;
                            case paymentterm.Net45:
                                billing.PaymentTerm = paymentterm.Net45.ToString();
                                break;
                            case paymentterm.Net60:
                                billing.PaymentTerm = paymentterm.Net60.ToString();
                                break;
                            default:
                                billing.PaymentTerm = paymentterm.NotSpecified.ToString();
                                break;
                        }
                        #endregion
                        #region credict
                        ICredict credict = dataContext.Credicts.Create();
                        credict.baseClass = billing;
                        credict.Hold = contactBase.CreditOnHold.HasValue ? contactBase.CreditOnHold.Value : false;
                        credict.Limit = contactBase.CreditLimit.HasValue ? contactBase.CreditLimit.Value : 0;
                        #endregion
                        #region Characteristics
                        ICharacteristics characteristicContact = dataContext.Characteristicss.Create();
                        characteristicContact.baseClass = customerContact;
                        #region belief
                        Array values = Enum.GetValues(typeof(belief));
                        Random random = new Random();
                        characteristicContact.Belief = ((belief)values.GetValue(random.Next(values.Length))).ToString(); //will come from customer Survey
                        #endregion
                        #region attitude
                        IAttitude attitudeContact = dataContext.Attitudes.Create();
                        attitudeContact.baseClass = characteristicContact;
                        #endregion
                        #region negative_experience
                        Guid negativePerceptionSubjectId = Guid.Parse("E4EC9D23-8D6E-4E46-8C3B-9A4626BEADC2"); //Dissatisfaction from product
                        ICollection<ProductBase> dissatisfiedProducts = OWLBusinessProcess.GetProductsBySubjectId(2, contactBase.ContactId, negativePerceptionSubjectId, context);
                        if (dissatisfiedProducts != null)
                        {
                            INegativeExperience negativeexperience = dataContext.NegativeExperiences.Create();
                            negativeexperience.baseClass = attitudeContact;
                            negativeexperience.Products = new Collection<IProduct>();
                            #region
                            ISales sale = dataContext.Saless.Create();
                            foreach (ProductBase productBase in dissatisfiedProducts)
                            {
                                IProduct product = dataContext.Products.Create();
                                product.baseClass = sale;

                                #region Update map table
                                AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                                #endregion
                                negativeexperience.Products.Add(product);
                            }
                            #endregion
                        }
                        #endregion
                        #region positive_experience
                        Guid positrivePerceptionSubjectId = Guid.Parse("9F5ACBA9-9571-440F-8522-6857D3AFB3B7"); //Satisfied from product
                        ICollection<ProductBase> satisfiedProducts = OWLBusinessProcess.GetProductsBySubjectId(1, contactBase.ContactId, positrivePerceptionSubjectId, context);
                        if (satisfiedProducts != null)
                        {
                            IPositiveExperience positiveexperience = dataContext.PositiveExperiences.Create();
                            positiveexperience.baseClass = attitudeContact;
                            positiveexperience.Products = new Collection<IProduct>();
                            #region
                            ISales sale = dataContext.Saless.Create();
                            foreach (ProductBase productBase in satisfiedProducts)
                            {
                                IProduct product = dataContext.Products.Create();
                                product.baseClass = sale;

                                #region Update map table
                                AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                                #endregion
                                positiveexperience.Products.Add(product);
                            }
                            #endregion
                        }
                        #endregion
                        #region knowledge
                        //Sales Order, Quotes will have specific rule to clarify perception of a customer for a product
                        //below is a demonstration of knowledge
                        ICollection<ProductBase> knowledgeProduct = (from x in context.ProductBases select x).ToList<ProductBase>();
                        IKnowledge knowledge = dataContext.Knowledges.Create();
                        knowledge.baseClass = characteristicContact;
                        ISales saleKnowledge = dataContext.Saless.Create();
                        #region
                        foreach (ProductBase productBase in knowledgeProduct)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = saleKnowledge;
                            switch (random.Next(1, 3))  //1 - aim, 2- want 3-need
                            {
                                case 1:
                                    if (knowledge.AimProducts == null)
                                        knowledge.AimProducts = new Collection<IProduct>();
                                    knowledge.AimProducts.Add(product);
                                    break;
                                case 2:
                                    if (knowledge.WantProducts == null)
                                        knowledge.WantProducts = new Collection<IProduct>();
                                    knowledge.WantProducts.Add(product);
                                    break;
                                case 3:
                                    if (knowledge.NeedProducts == null)
                                        knowledge.NeedProducts = new Collection<IProduct>();
                                    knowledge.NeedProducts.Add(product);
                                    break;
                            }
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }
                        #endregion
                        #endregion
                        #region Demographics
                        IDemographics demographics = dataContext.Demographicss.Create();
                        demographics.baseClass = customerContact;
                        if (contactBase.Anniversary.HasValue)
                            demographics.Anniversary = contactBase.Anniversary.Value;
                        if (contactBase.BirthDate.HasValue)
                            demographics.BirthDate = contactBase.BirthDate.Value;
                        #region Address
                        ICollection<CustomerAddressBase> customeraddresses = OWLBusinessProcess.GetCustomerAddresses(2, contactBase.ContactId, context);
                        foreach (CustomerAddressBase customeraddressbase in customeraddresses)
                        {
                            IAddress address = dataContext.Addresss.Create();
                            address.baseClass = demographics;
                            address.Customers = new Collection<ICustomer>();
                            address.Customers.Add(customerContact);
                            if (customeraddressbase.AddressTypeCode.HasValue)
                            {
                                switch (customeraddressbase.AddressTypeCode.Value)
                                {
                                    case 1:
                                        address.AddressType = addresstype.Home.ToString();
                                        break;
                                    case 2:
                                        address.AddressType = addresstype.Work.ToString();
                                        break;
                                }
                            }
                            else
                            {
                                address.AddressType = addresstype.Not_Specified.ToString();
                            }
                            #region electronic addresses
                            IElectronic electronicContact1 = dataContext.Electronics.Create();
                            electronicContact1.baseClass = address;
                            electronicContact1.EMailAddress = contactBase.EMailAddress1;

                            IElectronic electronicContact2 = dataContext.Electronics.Create();
                            electronicContact2.baseClass = address;
                            electronicContact2.EMailAddress = contactBase.EMailAddress2;

                            IElectronic electronicContact3 = dataContext.Electronics.Create();
                            electronicContact3.baseClass = address;
                            electronicContact3.EMailAddress = contactBase.EMailAddress3;
                            #endregion
                            #region postal
                            IPostal postal = dataContext.Postals.Create();
                            postal.baseClass = address;
                            #region country
                            ICountry country = dataContext.Countries.Create();
                            country.baseClass = postal;
                            country.Name = customeraddressbase.Country;
                            #region city
                            ICity city = dataContext.Cities.Create();
                            city.baseClass = country;
                            city.Name = customeraddressbase.City;
                            #region street
                            IStreet street = dataContext.Streets.Create();
                            street.baseClass = city;
                            street.Name = customeraddressbase.Line1 + " " + customeraddressbase.Line2 + " " + customeraddressbase.Line3 + " ";
                            #endregion
                            #endregion
                            #endregion
                            #endregion
                            #region URL
                            IWeb webContact = dataContext.Webs.Create();
                            webContact.baseClass = address;
                            webContact.URL = contactBase.WebSiteUrl;
                            #endregion 
                        }
                        #endregion
                        #endregion
                        #region lifestyle
                        ILifeStyle lifestyle = dataContext.LifeStyles.Create();
                        ISales salelifestyle = dataContext.Saless.Create();
                        lifestyle.baseClass = characteristicContact;
                        lifestyle.ChoiceProducts = new Collection<IProduct>();
                        ICollection<ProductBase> mostPreferableProducts = OWLBusinessProcess.GetMostPreferredProducts(contactBase.ContactId, context);
                        foreach(ProductBase productBase in mostPreferableProducts)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = salelifestyle;
                            lifestyle.ChoiceProducts.Add(product);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }
                        lifestyle.Demographics = new Collection<IDemographics>();
                        lifestyle.Demographics.Add(demographics);
                        //lifestyle.PostalAddress = <not applicable at that moment>
                        lifestyle.PurchaseProducts = new Collection<IProduct>();
                        ICollection<ProductBase> purchasedProducts = OWLBusinessProcess.GetPurchasedProducts(contactBase.ContactId, context);
                        foreach (ProductBase productBase in purchasedProducts)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = salelifestyle;
                            lifestyle.PurchaseProducts.Add(product);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        lifestyle.UseProducts = new Collection<IProduct>();
                        ICollection<ProductBase> usedProducts = OWLBusinessProcess.GetUsedProducts(contactBase.ContactId, context);
                        foreach (ProductBase productBase in usedProducts)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = salelifestyle;
                            lifestyle.UseProducts.Add(product);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }
                        #endregion
                        #region motivation
                        IMotivation motivation = dataContext.Motivations.Create();
                        motivation.baseClass = characteristicContact;
                        //behavioral
                        IBehavioral behavioral = dataContext.Behaviorals.Create();
                        behavioral.baseClass = motivation;
                        values = Enum.GetValues(typeof(esteem));
                        behavioral.Esteem = ((esteem)values.GetValue(random.Next(values.Length))).ToString(); //will come from customer Survey
                        values = Enum.GetValues(typeof(safety));
                        behavioral.Safety = ((safety)values.GetValue(random.Next(values.Length))).ToString(); //will come from customer Survey
                        values = Enum.GetValues(typeof(physicological));
                        behavioral.Physicological = ((physicological)values.GetValue(random.Next(values.Length))).ToString(); //will come from customer Survey
                        //consumer
                        IConsumer consumer = dataContext.Consumers.Create();
                        consumer.baseClass = motivation;
                        //desire
                        ICollection<ProductBase> desiredProduct = OWLBusinessProcess.GetDesiredProducts(contactBase.ContactId, context);
                        IDesire desire = dataContext.Desires.Create();
                        desire.baseClass = consumer;
                        ISales saleDesire = dataContext.Saless.Create();
                        foreach (ProductBase productBase in desiredProduct)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = saleDesire;
                            if (desire.Products == null)
                                desire.Products = new Collection<IProduct>();
                            desire.Products.Add(product);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        //drive - rule will be applied by a consumer survey (search motivated product to drive the party to buy something)
                        ICollection<ProductBase> drivedProduct = OWLBusinessProcess.GetDerivedProducts(contactBase.ContactId, context);
                        IDrive drive = dataContext.Drives.Create();
                        drive.baseClass = consumer;
                        ISales saleDrive = dataContext.Saless.Create();
                        foreach (ProductBase productBase in drivedProduct)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = saleDrive;
                            if (drive.Products == null)
                                drive.Products = new Collection<IProduct>();
                            drive.Products.Add(product);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }

                        //latent need - rule will be applied from Marketing Activities (if a customer response any compaing for a product,latent_need come up then.)
                        ICollection<ProductBase> latentNeedProduct = OWLBusinessProcess.GetLatentNeedProducts(contactBase.ContactId, context);
                        ILatentNeed latentneed = dataContext.LatentNeeds.Create();
                        latentneed.baseClass = consumer;
                        ISales saleLatentNeed = dataContext.Saless.Create();
                        foreach (ProductBase productBase in latentNeedProduct)
                        {
                            IProduct product = dataContext.Products.Create();
                            product.baseClass = saleDrive;
                            if (latentneed.Products == null)
                                latentneed.Products = new Collection<IProduct>();
                            drive.Products.Add(product);
                            #region Update map table
                            AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(product.Id), productBase.ProductId, "ProductBase", tHb.TransferHistoryId));
                            #endregion
                        }
                        #endregion
                        #region Perception
                        IPerception perception = dataContext.Perceptions.Create();
                        perception.baseClass = characteristicContact;
                        //below requires specific survey to set
                        perception.benefit = random.Next(1, 100) < 50 ? false : true;
                        perception.price = random.Next(1, 100) < 50 ? false : true;
                        // will apply later,perception.self = random.Next(1, 100) < 50 ? false : true;
                        #endregion
                        #region personality
                        //apply later
                        #endregion
                        #endregion
                        #region Churn
                        IChurn churn = dataContext.Churns.Create();
                        churn.baseClass = customerContact;
                        churn.Rate = OWLBusinessProcess.GetChurnRate(contactBase.ContactId, context);
                        #endregion
                        #region emotion
                        //will apply later
                        #endregion
                        #region loyality
                        ILoyality loyality = dataContext.Loyalities.Create();
                        loyality.baseClass = customerContact;
                        #region reward
                        IReward reward = dataContext.Rewards.Create();
                        reward.baseClass = loyality;
                        object obj = OWLBusinessProcess.GetCustomerClassification(2, contactBase.ContactId, context);
                        if (obj.GetType() == typeof(avantgarde))
                        {
                            reward.Avantgarde = ((avantgarde)obj).ToString();
                        }
                        else if (obj.GetType() == typeof(classic))
                        {
                            reward.Classic = ((classic)obj).ToString();
                        }
                        else if (obj.GetType() == typeof(vip))
                        {
                            reward.VIP = ((vip)obj).ToString();
                        }

                        #endregion
                        #region segment
                        ISegment segment = dataContext.Segments.Create();
                        segment.baseClass = loyality;
                        obj = OWLBusinessProcess.GetCustomerSegment(2, contactBase.ContactId, dataContext);
                        if (obj.GetType() == typeof(IGold))
                        {
                            #region gold
                            ((IGold)obj).baseClass = segment;
                            #endregion
                        }
                        else if (obj.GetType() == typeof(IPremium))
                        {
                            #region premium
                            ((IPremium)obj).baseClass = segment;
                            #endregion
                        }
                        else if (obj.GetType() == typeof(ISilver))
                        {
                            #region silver
                            ((ISilver)obj).baseClass = segment;
                            #endregion
                        }
                        #endregion
                        #endregion
                        #region Preference
                        IPreference preference = dataContext.Preferences.Create();
                        preference.baseClass = customerContact;
                        if (contactBase.PreferredContactMethodCode.HasValue)
                            preference.PreferredMethodCode = ((preferredmethodcode)contactBase.PreferredContactMethodCode.Value).ToString();
                        #region call
                        if (contactBase.DoNotPhone.HasValue)
                        {
                            ICall call = dataContext.Calls.Create();
                            call.baseClass = preference;
                            call.canCall = !contactBase.DoNotPhone.Value;
                        }
                        #endregion
                        #region sendbulkemail
                        if (contactBase.DoNotBulkEMail.HasValue)
                        {
                            ISendBulkEMail sendbulkemail = dataContext.SendBulkEMails.Create();
                            sendbulkemail.baseClass = preference;
                            sendbulkemail.canSendBulkEMail = !contactBase.DoNotBulkEMail.Value;
                        }
                        #endregion
                        #region sendemail
                        if (contactBase.DoNotEMail.HasValue)
                        {
                            ISendEMail sendemail = dataContext.SendEMails.Create();
                            sendemail.baseClass = preference;
                            sendemail.canSendEMail = !contactBase.DoNotEMail.Value;
                        }
                        #endregion
                        #region sendfax
                        if (contactBase.DoNotFax.HasValue)
                        {
                            ISendFax sendfax = dataContext.SendFaxs.Create();
                            sendfax.baseClass = preference;
                            sendfax.canSendFax = !contactBase.DoNotFax.Value;
                        }
                        #endregion
                        #region sendmail
                        if (contactBase.DoNotBulkPostalMail.HasValue)
                        {
                            ISendMail sendmail = dataContext.SendMails.Create();
                            sendmail.baseClass = preference;
                            sendmail.canSendMail = !contactBase.DoNotPostalMail.Value;
                        }
                        #endregion
                        #endregion
                        #region retention
                        // requires campaign management and sales force automation
                        #endregion
                        #region shipping
                        IShipping shipping = dataContext.Shippings.Create();
                        shipping.baseClass = customerContact;
                        shipping.Method = contactBase.ShippingMethodCode.HasValue ? ((method)contactBase.ShippingMethodCode).ToString() : method.Not_Specified.ToString();
                        shipping.FreightTerm = freightterm.No_Charge.ToString(); //Support single type at the first version.freightterm requires consultancy from Export/Import professionals.                        
                        #endregion                        
                    }
                    #endregion                                        
                    #region Lead
                    #region Customer
                    var customerLead = dataContext.Customers.Create();
                    customerLead.baseClass = party;
                    #endregion
                    IList<LeadBase> leadBases = (from lead in context.LeadBases
                                                       where lead.TransferHistoryId == tHb.TransferHistoryId
                                                       select lead).ToList<LeadBase>();
                    foreach (LeadBase leadBase in leadBases)
                    {
                        ILead lead = dataContext.Leads.Create();

                        #region Update map table
                        AddRecordToMapOWL(context, Utilities.Convert(Guid.Parse(lead.Id), leadBase.LeadId, "LeadBase", tHb.TransferHistoryId));
                        #endregion
                        
                    }                  
                    #endregion

                    #region update TransferHistoryBases in order to set ConvertionDateToOwl
                    tHb.ConvertionDateToOwl = DateTime.Now;
                    #endregion
                    context.SaveChanges();
                    dataContext.SaveChanges();
                }

                // Shutdown Brightstar processing threads.
                BrightstarDB.Client.BrightstarService.Shutdown();
            }
        }

    } 
}
