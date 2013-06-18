﻿using System.Web.Configuration;
using AzureStorageUtils;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRole
{
    public class AzureStorageConfig
    {
        public static void InitializeAzureStorage()
        {
            string storageConnectionString = RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString");
            string ocrQueueName = WebConfigurationManager.AppSettings["OCRQueueName"];
            string imageBlobContainerName = WebConfigurationManager.AppSettings["ImageBlobContainerName"];

            // Email queue and Text blob container won't be used in Web Role so we'll just pass nulls.
            // Sure, in this situation AzureQueues and AzureBlobs classes don't look like good design but let's keep it simple.
            // I don't want to use tons of interfaces, DI and statelessness and in a simple 1K LOC project like this.

            AzureQueues.Initialize(storageConnectionString, ocrQueueName, null);
            AzureBlobs.Initialize(storageConnectionString, imageBlobContainerName, null);
        }
    }
}