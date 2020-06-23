﻿using System;
using System.Globalization;
using System.Reflection;
using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComAuditsDemo
    {
        private ILegacyMetasysClient legacyClient;
        private LogInitializer log;

        public IComAuditsDemo(ILegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
            Type declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            log = new LogInitializer(declaringType);
        }
        public void Run()
        {
            try
            {
                Console.WriteLine("Enter audit id to get audit details: ");
                string inputAuditId = Console.ReadLine();

                IComProvideAuditItem auditItem = (IComProvideAuditItem)legacyClient.GetSingleAudit(inputAuditId);

                Console.WriteLine(string.Format("\n Audit details found for {0}", inputAuditId));
                Console.WriteLine($"\n Id: {auditItem.Id}, User: {auditItem.User}, PreData: {auditItem.PreData}, PostDate: {auditItem.PostData}");

                string auditFilterInputItem;
                ComAuditFilter auditFilterItem = new ComAuditFilter();

                Console.WriteLine("\n Please enter these parameters separated by space: Start Time, End Time, Origin Applications," +
                                  "Class Levels, Action Type, Exclude discarded, Page, Page Size, Sort" +
                                  "\nRefer to the metasys-server/basic-services-dotnet README if you need help getting started.");

                auditFilterInputItem = Console.ReadLine();

                string[] args;
                args = auditFilterInputItem.Split(' ');

                if (args != null)
                {
                    auditFilterItem = ReadUserInput(args);
                }

                Console.WriteLine("\n List of audits with details");

                IComPagedResult PagedResult = (IComPagedResult)legacyClient.GetAudits(auditFilterItem);
                IComProvideAuditItem[] auditItems = (IComProvideAuditItem[])PagedResult.Items;

                Console.WriteLine($"\n Total: {PagedResult.Total}");
                Console.WriteLine($"\n Page Count: {PagedResult.PageCount}");
                Console.WriteLine($"\n Page Size: {PagedResult.PageSize}");
                Console.WriteLine($"\n Current Page: {PagedResult.CurrentPage}");

                if (auditItems != null)
                {
                    foreach (var item in auditItems)
                    {
                        Console.WriteLine($"\n Id: {item.Id}, User: {item.User}, PreData: {item.PreData}, PostDate: {item.PostData}");
                    }
                }
                else
                {
                    Console.WriteLine("No audit found.");
                }

                Console.WriteLine("\n Enter object id to get audit details: ");
                string objectId = Console.ReadLine();

                var auditsForObject = new ComAuditFilter();

                Console.WriteLine("\n Please enter these parameters separated by space: Start Time, End Time, Origin Applications," +
                                  "Class Levels, Action Type, Exclude discarded, Page, Page Size, Sort" +
                                  "\nRefer to the metasys-server/basic-services-dotnet README if you need help getting started.");

                auditFilterInputItem = Console.ReadLine();
                args = auditFilterInputItem.Split(' ');

                if (args != null)
                {
                    auditsForObject = ReadUserInput(args);
                }

                Console.WriteLine(string.Format("\nAudit details found for this object {0}", objectId));

                IComPagedResult PagedResultAuditForObject = (IComPagedResult)legacyClient.GetAuditsForAnObject(objectId, auditsForObject);
                IComProvideAuditItem[] auditItemsForObject = (IComProvideAuditItem[])PagedResultAuditForObject.Items;

                Console.WriteLine($"\n Total: {PagedResultAuditForObject.Total}");
                Console.WriteLine($"\n Page Count: {PagedResultAuditForObject.PageCount}");
                Console.WriteLine($"\n Page Size: {PagedResultAuditForObject.PageSize}");
                Console.WriteLine($"\n Current Page: {PagedResultAuditForObject.CurrentPage}");

                foreach (var item in auditItemsForObject)
                {
                    Console.WriteLine($"\n Id: {item.Id}, User: {item.User}, PreData: {item.PreData}, PostDate: {item.PostData}");
                }
            }
            catch (Exception exception)
            {
                log.Logger.Error(string.Format("An error occured while getting audit information - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
            }
            Console.ReadLine();
        }

        private static ComAuditFilter ReadUserInput(string[] args)
        {
            DateTime startTime = DateTime.Parse(args[0], null, DateTimeStyles.AssumeUniversal);
            DateTime endTime = DateTime.Parse(args[1], null, DateTimeStyles.AssumeUniversal);

            ComAuditFilter auditFilter = new ComAuditFilter
            {
                StartTime = startTime.ToString(),
                EndTime = endTime.ToString(),
                OriginApplications = args[2].ToLower() != "null" ? args[2] : "1,2",
                ClassLevels = args[3].ToLower() != "null" ? args[3] : "1,2",
                ActionTypes = args[4].ToLower() != "null" ? args[4] : "1,2",
                ExcludeDiscarded = !string.IsNullOrEmpty(args[5]) ? Convert.ToBoolean(args[5]) : false,
                Page = args[6].ToLower() != "null" ? args[6] : "0",
                PageSize = args[7].ToLower() != "null" ? args[7] : "0",
                Sort = args[8].ToLower() != "null" ? args[8] : "creationTime"
            };
            return auditFilter;
        }
    }
}
